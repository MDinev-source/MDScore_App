namespace MDScoreAPI.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Player : PlayerStats
    {
        public Player()
        {
            this.PlayerTournaments = new HashSet<PlayerTournament>();
        }

        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public int Age { get; set; }

        [Required]
        public string Town { get; set; }

        [Required]
        public string Country { get; set; }

        public virtual ICollection<PlayerTournament> PlayerTournaments { get; set; }
    }
}
