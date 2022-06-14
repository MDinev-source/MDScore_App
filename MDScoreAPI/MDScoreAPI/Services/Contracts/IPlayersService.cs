namespace MDScoreAPI.Services.Contracts
{
    using MDScoreAPI.Models.Players;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPlayersService
    {
        Task<int> CreatePlayerAsync(CreatePlayerRequestModel input);

        Task<PlayerDetailsServiceModel> Details(int playerId);

        Task<IEnumerable<AllPlayersListServiceModel>> AllPlayersList();

        Task EditAsync(EditPlayerServiceModel model);

        Task AddWinner(AddWinnerServiceModel model);


        string GetWinnerDataByIdAsync(int? id);

        void Delete(int id);
    }
}
