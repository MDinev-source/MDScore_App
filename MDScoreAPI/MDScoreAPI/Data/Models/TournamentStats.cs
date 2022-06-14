namespace MDScoreAPI.Data.Models
{
    using MDScoreAPI.Data.Models.Enums;
    using System.ComponentModel.DataAnnotations;

    public class TournamentStats
    {
        [Required]
        public SwimmingStyleType Style { get; set; }

        [Required]
        public SwimmingDistance Distance { get; set; }

        public int? WinnerId { get; set; }
        public Player Winner { get; set; }
    }
}
