using Education.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Education.Data
{
    public class EduContext : DbContext
    {
        const string SQL_CONNECTION_CONFIG_NAME = "Education";
        readonly string _connectionString;

        public EduContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString(SQL_CONNECTION_CONFIG_NAME);
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<EvaluatedWork> EvaluatedWorks { get; set; }
        public DbSet<EvaluatedWorkAnswer> EvaluatedWorkAnswers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LessonFile> LessonFiles { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Tutor> Tutors { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
