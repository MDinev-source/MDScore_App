namespace MDScoreAPI.Models.Tournaments
{
    using MDScoreAPI.Data.Models;
    using System;
    using System.Collections.Generic;

    public class TournamentDetailsServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public string Town { get; set; }

        public string Country { get; set; }

        public string Style { get; set; }

        public string Distance { get; set; }

        public ICollection<PlayerTournament> PlayerTournaments { get; set; }

        public string WinnerData { get; set; }
    }
}
