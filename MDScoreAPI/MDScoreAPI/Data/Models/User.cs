﻿namespace MDScoreAPI.Data.Models
{
    using System.Text.Json.Serialization;

    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public bool IsOrganizer { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; set; }
    }
}
