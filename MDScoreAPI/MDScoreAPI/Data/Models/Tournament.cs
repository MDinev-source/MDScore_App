namespace MDScoreAPI.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Tournament : TournamentStats
    {
        public Tournament()
        {
            this.TournamentPlayers = new HashSet<PlayerTournament>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        [Required]
        public string Town { get; set; }

        [Required]
        public string Country { get; set; }

        public virtual ICollection<PlayerTournament> TournamentPlayers { get; set; }
    }
}