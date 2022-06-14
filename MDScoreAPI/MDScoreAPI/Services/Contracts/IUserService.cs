namespace MDScoreAPI.Services.Contracts
{
    using MDScoreAPI.Data.Models;
    using MDScoreAPI.Models.Users;
    using System.Collections.Generic;

    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
        void Register(RegisterRequest model);
        void Update(int id, UpdateRequest model);
        void Delete(int id);
    }
}
