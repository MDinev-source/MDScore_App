namespace MDScoreAPI.Services
{
    using MDScoreAPI.Data;
    using MDScoreAPI.Data.Models;
    using MDScoreAPI.Helpers.PlayerTournamesDeserialize;
    using MDScoreAPI.Models.PlayerTournaments;
    using MDScoreAPI.Services.Contracts;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class PlayerTournamentsService : IPlayerTournamentsService
    {
        private readonly MDScoreDbContext data;

        public PlayerTournamentsService(
            MDScoreDbContext data)
        {
            this.data = data;
        }

        public async Task Participates(PlayerTournamentsRequestModel model)
        {
            var ids = PlayerTournamentsDeserializer.Desrizalizer(model.Ids);

            var tournamentId = int.Parse(model.TournamentId);

            var currentTorunament = await this.data
            .Tournaments
            .FirstOrDefaultAsync(t => t.Id == tournamentId);

            var startDate = currentTorunament.Start;

            var endDate = currentTorunament.End;

            foreach (var id in ids)
            {
                var currentPlayer = await this.data
                    .Players
                    .FirstOrDefaultAsync(p => p.Id == id);

                var isPlayerBusy = await CheckIfPlayerParticipateInAnotherTournament(tournamentId, startDate, endDate, id);

                var isPlayerAlreadyAdded = await this.data
                    .PlayerTournaments
                    .AnyAsync(p => p.PlayerId == id && p.TournamentId == tournamentId);

                if (!isPlayerBusy && !isPlayerAlreadyAdded)
                {
                    var playerParticipates = new PlayerTournament
                    {
                        PlayerId = id,
                        TournamentId = tournamentId
                    };

                    currentPlayer.PlayerTournaments.Add(playerParticipates);

                    currentTorunament.TournamentPlayers.Add(playerParticipates);

                    this.data.PlayerTournaments.Add(playerParticipates);

                    await this.data.SaveChangesAsync();
                }
            }

        }

        private async Task<bool> CheckIfPlayerParticipateInAnotherTournament(int tournamentId, DateTime startDate, DateTime endDate, int id)
        {
            var allPlayerTournaments = await this.data
                                .PlayerTournaments
                                .Where(p => p.PlayerId == id && p.TournamentId != tournamentId)
                                .ToListAsync();

            foreach (var tournament in allPlayerTournaments)
            {
                var checkedTournamet = await this.data
                    .Tournaments
                    .FirstOrDefaultAsync(t => t.Id == tournament.TournamentId);

                var checkedTournamentStart = checkedTournamet.Start;

                var checkedTournamentEnd = checkedTournamet.End;

                var endDateCheck = endDate >= checkedTournamentStart && endDate <= checkedTournamentEnd;

                var startDateCheck = startDate <= checkedTournamentEnd && startDate >= checkedTournamentStart;

                if (endDateCheck || startDateCheck)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
