using System;
using System.Linq;

namespace liverary.data.Interfaces
{
    public interface IUserRepository
    {
        IQueryable<User> GetUsers();

        User GetUserById(int id);

        void AddUser(User User);

        void UpdateUser(User User);

        void DeleteUser(int id);

        bool UserExists(int id);

        int CountUsers();
    }
}
