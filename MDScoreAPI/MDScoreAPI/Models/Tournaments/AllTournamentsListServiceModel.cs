namespace MDScoreAPI.Models.Tournaments
{
    using System;

    public class AllTournamentsListServiceModel
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public string Town { get; set; }

        public string Country { get; set; }
    }
}
