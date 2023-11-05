using liverary.data.Interfaces;
using liverary.data.Models;
using System;
using System.Linq;

namespace liverary.data.Repositories
{
    public class AdminRepository : BaseRepository, IAdminRepository
    {

        public AdminRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public IQueryable<Admin> GetAdmins()
        {
            return this.GetDbSet<Admin>();
        }

        public Admin GetAdminById(int id)
        {
            var dbSet = this.GetDbSet<Admin>();
            var admin = dbSet.Find(id);

            if (admin == null)
            {
                throw new ArgumentException($"No admin found with ID {id}");
            }

            return admin;
        }

        public void AddAdmin(Admin admin)
        {
            // Get the DbSet
            var dbSet = this.GetDbSet<Admin>();

            // Add the new admin record
            dbSet.Add(admin);

            // Save the changes
            this.SaveChanges();
            UnitOfWork.SaveChanges();
        }

        public void DeleteAdmin(int id)
        {
            // Get the DbSet
            var dbSet = this.GetDbSet<Admin>();

            // Find the existing admin record
            var existingAdmin = dbSet.Find(id);

            if (existingAdmin != null)
            {
                // Remove the admin record
                dbSet.Remove(existingAdmin);

                // Save the changes
                this.SaveChanges();
                UnitOfWork.SaveChanges();
            }
            else
            {
                // Handle the case where the admin record was not found
                Console.WriteLine($"Admin record with ID {id} not found.");
            }
        }

        public void UpdateAdmin(Admin admin)
        {
            // Get the DbSet
            var dbSet = this.GetDbSet<Admin>();

            // Find the existing admin record
            var existingAdmin = dbSet.Find(admin.Id);

            if (existingAdmin != null)
            {
                // Update the fields of the existing admin record
                existingAdmin.name = admin.name;
                existingAdmin.Username = admin.Username;
                existingAdmin.Password = admin.Password;

                // Save the changes
                this.SaveChanges();
                UnitOfWork.SaveChanges();
            }
            else
            {
                // Handle the case where the admin record was not found
                Console.WriteLine($"Admin record with ID {admin.Id} not found.");
            }
        }

        public bool AdminExists(int id)
        {
            var dbSet = this.GetDbSet<Admin>();
            return dbSet.Any(a => a.Id == id);
        }

        public int CountAdmins()
        {
            var dbSet = this.GetDbSet<Admin>();
            return dbSet.Count();
        }
    }
}
