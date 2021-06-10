using System.Collections.Generic;
using BitCrunch.Models;

namespace BitCrunch.Repositories
{
    public interface IUserRepository
    {
         IEnumerable<User> GetUsers();
         User GetUserById(int userId);
         User CreateUser(User newUser);
         User UpdateUser(User newUser);
         void DeleteUser(int userId);
    }
}