using ApiProject.Db;
using ApiProject.Models.Admin;
using ApiProject.Repositories.Interfaces;

namespace ApiProject.Repositories.Implementations
{
    public class StatisticRepository : GenericRepository<Statistic>, IStatisticRepository
    {
        public StatisticRepository(ProjectContext context) : base(context)
        {
        }
    }
}
