using ApiProject.Db;
using ApiProject.Models;
using ApiProject.Repositories.Interfaces;

namespace ApiProject.Repositories.Implementations
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ProjectContext context) : base(context)
        {
        }
    }
}
