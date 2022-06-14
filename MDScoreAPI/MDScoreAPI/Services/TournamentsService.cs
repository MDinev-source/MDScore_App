namespace MDScoreAPI.Services
{
    using MDScoreAPI.Data;
    using MDScoreAPI.Data.Models;
    using MDScoreAPI.Data.Models.Enums;
    using MDScoreAPI.Models.Tournaments;
    using MDScoreAPI.Services.Contracts;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class TournamentsService : ITournamentsService
    {
        private readonly MDScoreDbContext data;

        public TournamentsService(
            MDScoreDbContext data)
        {
            this.data = data;
        }

        public async Task<IEnumerable<AllTournamentsListServiceModel>> AllTournamentsList()
        {
            var tournaments = await this.data
                .Tournaments
                .Select(p => new AllTournamentsListServiceModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Start = p.Start,
                    End = p.End,
                    Town = p.Town,
                    Country = p.Country,
                })
                .OrderBy(p => p.Start)
                .ThenBy(p => p.Name)
                .ToListAsync();

            return tournaments;
        }

        public async Task<int> CreateTournamentAsync(CreateTournamentRequestModel input)
        {
            var startDate = DateTime.Parse(input.Start.ToString("dd.MM.yyyy"));

            var endDate = DateTime.Parse(input.End.ToString("dd.MM.yyyy"));

            var resultStyle = input.Style.Split(" ")[1];

            SwimmingStyleType enumOutStyle;

            var resultDistance = input.Distance.Split(" ")[1];

            SwimmingDistance enumOutDistance;

            Enum.TryParse(resultStyle, out enumOutStyle);

            Enum.TryParse(resultDistance, out enumOutDistance);

            var tournament = new Tournament
            {
                Name = input.Name,
                ImageUrl = input.ImageUrl,
                Start = startDate,
                End = endDate,
                Style = enumOutStyle,
                Distance = enumOutDistance,
                Town = input.Town,
                Country = input.Country,

            };

            this.data.Tournaments.Add(tournament);

            await this.data.SaveChangesAsync();

            return tournament.Id;
        }

        public TournamentDetailsServiceModel Details(int tournamentId)
        {
            var tournament = this.data.Tournaments
                .Where(t => t.Id == tournamentId)
                .Select(t => new TournamentDetailsServiceModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    ImageUrl = t.ImageUrl,
                    Town = t.Town,
                    Country = t.Country,
                    Start = t.Start,
                    End = t.End,
                    Style = t.Style.ToString(),
                    Distance = t.Distance.ToString(),
                    WinnerData = t.WinnerId == null
                    ? "No result"
                    : $"{t.Winner.FirstName} {t.Winner.LastName}, {t.Winner.Town}",
                    PlayerTournaments = t.TournamentPlayers
                })
                .FirstOrDefault();

            return tournament;
        }

        public void Delete(int id)
        {
            var tournament = this.data
            .Tournaments
            .FirstOrDefault(p => p.Id == id);

            foreach (var el in data.PlayerTournaments.Where(p => p.TournamentId == id))
            {
                this.data.PlayerTournaments.Remove(el);
            }

            this.data.Tournaments.Remove(tournament);

            this.data.SaveChanges();
        }
    }
}
