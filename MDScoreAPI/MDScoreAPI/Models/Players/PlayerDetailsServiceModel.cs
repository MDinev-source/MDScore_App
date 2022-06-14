namespace MDScoreAPI.Models.Players
{
    public class PlayerDetailsServiceModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ImageUrl { get; set; }

        public int Age { get; set; }

        public string Town { get; set; }

        public string Country { get; set; }

        public double AverageSpeed { get; set; }

        public int? Win { get; set; }

        public int? Losses { get; set; }

        public int? TournamentsCount { get; set; }
    }
}
