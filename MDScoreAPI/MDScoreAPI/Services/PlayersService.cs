namespace MDScoreAPI.Services
{
    using MDScoreAPI.Data;
    using MDScoreAPI.Data.Models;
    using MDScoreAPI.Models.Players;
    using MDScoreAPI.Services.Contracts;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class PlayersService : IPlayersService
    {
        private readonly MDScoreDbContext data;

        public PlayersService(
            MDScoreDbContext data)
        {
            this.data = data;
        }

        public async Task AddWinner(AddWinnerServiceModel model)
        {
            var playerId = int.Parse(model.PlayerId);

            var tournamentId = int.Parse(model.TournamentId);

            var playerWinner = await this.data
                .Players
                .FirstOrDefaultAsync(p => p.Id == playerId);

            var tournament = await this.data
                .Tournaments
                .FirstOrDefaultAsync(p => p.Id == tournamentId);

            if (tournament.WinnerId == null)
            {
                tournament.WinnerId = playerId;
                tournament.Winner = playerWinner;

                playerWinner.Win += 1;

                await this.data.SaveChangesAsync();

                var playersInTournament = await this.data
                    .PlayerTournaments
                    .Where(pt => pt.TournamentId == tournamentId && pt.PlayerId != playerWinner.Id)
                    .ToListAsync();

                foreach (var player in playersInTournament)
                {
                    var currentPlayer = await this.data
                        .Players
                        .FirstOrDefaultAsync(p => p.Id == player.PlayerId);

                    currentPlayer.Losses += 1;

                    this.data.Players.Update(currentPlayer);
                }

                await this.data.SaveChangesAsync();
            }

        }

        public async Task<IEnumerable<AllPlayersListServiceModel>> AllPlayersList()
        {
            var players = await this.data
                .Players
                .Select(p => new AllPlayersListServiceModel
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Town = p.Town,
                    Country = p.Country,
                    Win = p.Win,
                    PlayerTournaments = p.PlayerTournaments
                })
                .OrderByDescending(p => p.Win)
                .ThenBy(p => p.FirstName)
                .ToListAsync();

            return players;
        }

        public async Task<int> CreatePlayerAsync(CreatePlayerRequestModel input)
        {
            var player = new Player
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                Age = input.Age,
                ImageUrl = input.ImageUrl,
                Town = input.Town,
                Country = input.Country,
                AverageSpeed = input.AverageSpeed,
                Win = 0,
                Losses = 0
            };

            this.data.Players.Add(player);

            await this.data.SaveChangesAsync();

            return player.Id;
        }

        public void Delete(int id)
        {
            var player = this.data
            .Players
            .FirstOrDefault(p => p.Id == id);

            foreach (var el in data.PlayerTournaments.Where(p => p.PlayerId == id))
            {
                this.data.PlayerTournaments.Remove(el);
            }

            this.data.Players.Remove(player);

            this.data.SaveChanges();
        }

        public async Task<PlayerDetailsServiceModel> Details(int playerId)
        {
            var tournamentsCount = await GetPlayerTournamentsCount(playerId);

            var player = await this.data.Players
                .Where(p => p.Id == playerId)
                .Select(p => new PlayerDetailsServiceModel
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Age = p.Age,
                    ImageUrl = p.ImageUrl,
                    Town = p.Town,
                    Country = p.Country,
                    AverageSpeed = p.AverageSpeed,
                    Win = p.Win == null ? 0 : p.Win,
                    Losses = p.Losses == null ? 0 : p.Win,
                    TournamentsCount = tournamentsCount
                })
                .FirstOrDefaultAsync();

            return player;
        }

        public async Task EditAsync(EditPlayerServiceModel model)
        {
            var player = await this.data
                .Players
                .FirstOrDefaultAsync(p => p.Id == model.Id);

            player.FirstName = model.FirstName;
            player.LastName = model.LastName;
            player.ImageUrl = model.ImageUrl;
            player.Age = model.Age;
            player.Town = model.Town;
            player.Country = model.Country;
            player.AverageSpeed = model.AverageSpeed;
            player.Win = model.Win;
            player.Losses = model.Losses;

            await this.data.SaveChangesAsync();
        }

        public string GetWinnerDataByIdAsync(int? id)
        {
            var player = this.data.Players
                .FirstOrDefault(p => p.Id == id);

            if (player == null)
            {
                return null;
            }

            var playerData = $"{player.FirstName} {player.LastName} ({player.Town},{player.Country})";

            return playerData;
        }

        private async Task<int> GetPlayerTournamentsCount(int playerId)
        {
            var playerTournamentsCount = await this.data.PlayerTournaments
                .CountAsync(p => p.PlayerId == playerId);

            return playerTournamentsCount;
        }
    }
}

