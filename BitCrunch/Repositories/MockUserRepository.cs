using System.Collections.Generic;
using BitCrunch.Models;

namespace BitCrunch.Repositories
{
    public class MockUserRepository : IUserRepository
    {
        public List<User> mockUsers;
        public MockUserRepository()
        {
            mockUsers = new List<User>
            {
                new User {UserId = 1, UserName = "William", Password = "train", Email = "sculley@playbyweb.com", StoreName = "Dungeon Crawlers", City = "Jacksonville", State = "FL"},
                new User {UserId = 2, UserName = "Dane", Password = "Boat", Email="Dane@playbyweb.com", StoreName="Seattle", State="WA"}
            };
        }
        public User CreateUser(User newUser)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteUser(int userId)
        {
            throw new System.NotImplementedException();
        }

        public User GetUserById(int userId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> GetUsers()
        {
            throw new System.NotImplementedException();
        }

        public User UpdateUser(User newUser)
        {
            throw new System.NotImplementedException();
        }
    }
}