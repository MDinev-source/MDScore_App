namespace MDScoreAPI.Controllers
{
    using MDScoreAPI.Authorization;
    using MDScoreAPI.Models.PlayerTournaments;
    using MDScoreAPI.Services.Contracts;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PlayerTournaments : ControllerBase
    {
        private readonly IPlayerTournamentsService playerTournament;

        public PlayerTournaments(
            IPlayerTournamentsService playerTournament)
        {
            this.playerTournament = playerTournament;
        }


        [HttpPost]
        public async Task<ActionResult> Participates(PlayerTournamentsRequestModel model)
        {
            await playerTournament.Participates(model);

            return Ok(new { message = "User added successfully" });
        }
    }
}
