namespace MDScoreAPI.Controllers
{
    using MDScoreAPI.Authorization;
    using MDScoreAPI.Models.Tournaments;
    using MDScoreAPI.Services.Contracts;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using static MDScoreAPI.Common.WebConstants;

    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TournamentsController : ControllerBase
    {
        private readonly ITournamentsService tournamentsService;

        public TournamentsController(
            ITournamentsService tournamentsService)
        {
            this.tournamentsService = tournamentsService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTournamentRequestModel model)
        {
            var tournamentId = await this.tournamentsService.CreateTournamentAsync(model);

            return Created(nameof(this.Create), tournamentId);
        }

        [HttpGet]
        [Route(Id)]
        [AllowAnonymous]
        public TournamentDetailsServiceModel Details(int id)
        {
            return this.tournamentsService.Details(id);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<AllTournamentsListServiceModel>> All()
        {
            return await this.tournamentsService.AllTournamentsList();
        }

        [HttpDelete(Id)]
        public IActionResult Delete(int id)
        {
            tournamentsService.Delete(id);
            return Ok(new { message = "Tournament deleted successfully" });
        }
    }
}
