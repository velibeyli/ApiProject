using ApiProject.Db;
using ApiProject.Models.Admin;
using ApiProject.Repositories.Interfaces;

namespace ApiProject.Repositories.Implementations
{
    public class AdminUserRepository : GenericRepository<AdminUser>, IAdminUserRepository
    {
        public AdminUserRepository(ProjectContext context) : base(context)
        {
        }
    }
}
