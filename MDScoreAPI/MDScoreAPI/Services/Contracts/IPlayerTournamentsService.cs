namespace MDScoreAPI.Services.Contracts
{
    using MDScoreAPI.Models.PlayerTournaments;
    using System.Threading.Tasks;

    public interface IPlayerTournamentsService
    {
        Task Participates(PlayerTournamentsRequestModel model);
    }
}
