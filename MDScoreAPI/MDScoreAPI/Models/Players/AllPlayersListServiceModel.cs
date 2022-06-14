namespace MDScoreAPI.Models.Players
{
    using MDScoreAPI.Data.Models;
    using System.Collections.Generic;

    public class AllPlayersListServiceModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Town { get; set; }

        public string Country { get; set; }

        public ICollection<PlayerTournament> PlayerTournaments { get; set; }

        public int? Win { get; set; }
    }
}
