using ApiProject.Db;
using ApiProject.Models.Admin;
using ApiProject.Repositories.Interfaces;

namespace ApiProject.Repositories.Implementations
{
    public class WinnerRepository : GenericRepository<Winner>, IWinnerRepository
    {
        public WinnerRepository(ProjectContext context) : base(context)
        {
        }
    }
}
