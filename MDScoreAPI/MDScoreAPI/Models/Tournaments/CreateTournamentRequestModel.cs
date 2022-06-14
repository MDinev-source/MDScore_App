namespace MDScoreAPI.Models.Tournaments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CreateTournamentRequestModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        [Required]
        public string Town { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string Style { get; set; }

        [Required]
        public string Distance { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.End < this.Start)
            {
                yield return new ValidationResult("Start date cannot be less than end date");
            }
        }
    }
}
