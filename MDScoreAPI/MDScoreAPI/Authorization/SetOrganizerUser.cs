namespace MDScoreAPI.Authorization
{
    using MDScoreAPI.Data;
    using MDScoreAPI.Data.Models;
    using System.Linq;
    using BCryptNet = BCrypt.Net.BCrypt;

    public static class SetOrganizerUser
    {
        public static void AddOrganizer(MDScoreDbContext context)
        {
            var organizer = new User
            {
                FirstName = "Organizer",
                LastName = "User",
                Username = "organizer",
                PasswordHash = BCryptNet.HashPassword("organizer"),
                IsOrganizer = true
            };

            var isUserNotExist = context.Users.FirstOrDefault(
                u => u.Username == organizer.Username
                && u.FirstName == organizer.FirstName) == null;

            if (isUserNotExist)
            {
                context.Users.Add(organizer);
                context.SaveChanges();
            }
        }
    }
}
