namespace MDScoreAPI.Models.Players
{
    using System.ComponentModel.DataAnnotations;

    public class CreatePlayerRequestModel
    {
        [Required]
        [MaxLength(15)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(15)]
        public string LastName { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public int Age { get; set; }

        [Required]
        public string Town { get; set; }

        [Required]
        public string Country { get; set; }

        public double AverageSpeed { get; set; }
    }
}
