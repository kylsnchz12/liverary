using System;
using System.Linq;

namespace liverary.data.Interfaces
{
    public interface IAdminRepository
    {
        IQueryable<Admin> GetAdmins();

        Admin GetAdminById(int id);

        void AddAdmin(Admin admin);

        void UpdateAdmin(Admin admin);

        void DeleteAdmin(int id);

        bool AdminExists(int id);

        int CountAdmins();
    }
}
