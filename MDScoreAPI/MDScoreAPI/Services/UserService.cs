namespace MDScoreAPI.Services
{
    using AutoMapper;
    using MDScoreAPI.Authorization;
    using MDScoreAPI.Data;
    using MDScoreAPI.Data.Models;
    using MDScoreAPI.Helpers;
    using MDScoreAPI.Models.Users;
    using MDScoreAPI.Services.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using BCryptNet = BCrypt.Net.BCrypt;

    public class UserService : IUserService
    {
        private MDScoreDbContext context;
        private IJwtUtils jwtUtils;
        private readonly IMapper mapper;

        public UserService(
            MDScoreDbContext context,
            IJwtUtils jwtUtils,
            IMapper mapper)
        {
            this.context = context;
            this.jwtUtils = jwtUtils;
            this.mapper = mapper;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = context.Users.SingleOrDefault(x => x.Username == model.Username);

            // validate
            if (user == null || !BCryptNet.Verify(model.Password, user.PasswordHash))
                throw new AppException("Username or password is incorrect");

            // authentication successful
            var response = mapper.Map<AuthenticateResponse>(user);

            response.Token = jwtUtils.GenerateToken(user);

            response.IsOrganizer = user.IsOrganizer;

            return response;
        }

        public IEnumerable<User> GetAll()
        {
            return context.Users;
        }

        public User GetById(int id)
        {
            return getUser(id);
        }

        public void Register(RegisterRequest model)
        {
            // validate
            if (context.Users.Any(x => x.Username == model.Username))
                throw new AppException("Username '" + model.Username + "' is already taken");

            // map model to new user object
            var user = mapper.Map<User>(model);

            // hash password
            user.PasswordHash = BCryptNet.HashPassword(model.Password);

            // save user
            context.Users.Add(user);

            context.SaveChanges();
        }

        public void Update(int id, UpdateRequest model)
        {
            var user = getUser(id);

            // validate
            if (model.Username != user.Username && context.Users.Any(x => x.Username == model.Username))
                throw new AppException("Username '" + model.Username + "' is already taken");

            // hash password if it was entered
            if (!string.IsNullOrEmpty(model.Password))
                user.PasswordHash = BCryptNet.HashPassword(model.Password);

            // copy model to user and save
            mapper.Map(model, user);

            context.Users.Update(user);

            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = getUser(id);

            context.Users.Remove(user);

            context.SaveChanges();
        }

        // helper methods

        private User getUser(int id)
        {
            var user = context.Users.Find(id);

            if (user == null) throw new KeyNotFoundException("User not found");

            return user;
        }
    }
}