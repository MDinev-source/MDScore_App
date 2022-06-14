namespace MDScoreAPI.Services.Contracts
{
    using MDScoreAPI.Models.Tournaments;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITournamentsService
    {
        Task<int> CreateTournamentAsync(CreateTournamentRequestModel input);

        TournamentDetailsServiceModel Details(int tournamentId);

        Task<IEnumerable<AllTournamentsListServiceModel>> AllTournamentsList();

        void Delete(int id);
    }
}
