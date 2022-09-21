using ApiProject.Models;
using ApiProject.Models.Admin;
using Microsoft.EntityFrameworkCore;

namespace ApiProject.Db
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {

        }
        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<Statistic> Statistics { get; set; }
        public DbSet<Winner> Winners { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswers { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
