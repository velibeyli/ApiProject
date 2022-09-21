using ApiProject.Db;
using ApiProject.Models;
using ApiProject.Repositories.Interfaces;

namespace ApiProject.Repositories.Implementations
{
    public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(ProjectContext context) : base(context)
        {
        }
    }
}
