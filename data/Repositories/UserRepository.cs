using liverary.Data;
using liverary.Data.Interfaces;
using liverary.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace liverary.Data.Repositories;
{
public class UserRepository : BaseRepository, IUserRepository
{
    public UserRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {

    }

    public IQueryable<User> GetUsers()
    {
        return this.GetDbSet<User>();
    }

    public User GetUserById(int id)
    {
        return this.GetDbSet<User>().FirstOrDefault(x => x.Id == id);
    }

    public void AddUser(User user)
    {
        this.GetDbSet<User>().Add(user);

        this.SaveChanges();
        UnitOfWork.SaveChanges();
    }

    public void UpdateUser(User user)
    {

        this.GetDbSet<User>().Update(user);

        this.SaveChanges();
        UnitOfWork.SaveChanges();
    }

    public void DeleteUser(int id)
    {
        var user = this.GetUserById(id);

        if (user != null)
        {
            this.GetDbSet<User>().Remove(user);

            this.SaveChanges();
            UnitOfWork.SaveChanges();
        }
        else
        {
            Console.WriteLine($"User record with ID {id} not found.");
        }

    }

    public bool UserExists(int id)
    {
        return this.GetDbSet<User>().Any(x => x.Id == id);
    }

    public int CountUsers()
    {
        return this.GetDbSet<User>().Count();
    }
}

}
