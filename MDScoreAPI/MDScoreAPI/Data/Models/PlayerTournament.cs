namespace MDScoreAPI.Data.Models
{
    public class PlayerTournament
    {
        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; }

    }
}
