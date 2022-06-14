namespace MDScoreAPI.Controllers
{
    using MDScoreAPI.Authorization;
    using MDScoreAPI.Models.Players;
    using MDScoreAPI.Services.Contracts;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using static MDScoreAPI.Common.WebConstants;

    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayersService playersService;

        public PlayersController(
            IPlayersService playersService)
        {
            this.playersService = playersService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePlayerRequestModel model)
        {
            var playerId = await this.playersService.CreatePlayerAsync(model);

            return Created(nameof(this.Create), playerId);
        }

        [HttpGet]
        [Route(Id)]
        [AllowAnonymous]
        public async Task<PlayerDetailsServiceModel> Details(int id)
        {
            return await this.playersService.Details(id);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<AllPlayersListServiceModel>> All()
        {
            return await this.playersService.AllPlayersList();
        }

        [HttpPost]
        [Route(Id)]
        public async Task<ActionResult> Update(EditPlayerServiceModel model)
        {
            await this.playersService.EditAsync(model);

            return Ok(new { message = "Player updated successfully" });
        }

        [HttpPost]
        [Route(Winner)]
        public async Task<ActionResult> AddWinner(AddWinnerServiceModel model)
        {
            await this.playersService.AddWinner(model);

            return Ok(new { message = "Added winner successfully" });
        }

        [HttpDelete(Id)]
        public IActionResult Delete(int id)
        {
            playersService.Delete(id);

            return Ok(new { message = "Player deleted successfully" });
        }
    }
}
