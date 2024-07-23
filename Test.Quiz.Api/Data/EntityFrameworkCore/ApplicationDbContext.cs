using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Test.Quiz.Api.Data.Entities;
using Test.Quiz.Api.Data.EntityFrameworkCore.Seeders;

namespace Test.Quiz.Api.Data.EntityFrameworkCore
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        #region Dbset
        public virtual DbSet<Section> Sections { get; set; } = null!;
        public virtual DbSet<Exam> Exams { get; set; } = null!;
        public virtual DbSet<ExamQuestion> ExamQuestions { get; set; } = null!;
        public virtual DbSet<ExamResult> ExamResults { get; set; } = null!;
        public virtual DbSet<Question> Questions { get; set; } = null!;
        public virtual DbSet<QuestionCategory> QuestionCategories { get; set; } = null!;
        public virtual DbSet<QuestionAnswer> QuestionAnswers { get; set; } = null!;


        public virtual DbSet<ExamToeic> ExamToeics { get; set; } = null!;
        //public virtual DbSet<ExamToeicPart> ExamToeicParts { get; set; } = null!;
        public virtual DbSet<PartToeic> PartToeics { get; set; } = null!;
        public virtual DbSet<ExamToeicResult> ExamToeicResults { get; set; } = null!;
        public virtual DbSet<ExamToeicResultDetail> ExamToeicResultDetails { get; set; } = null!;
        //public virtual DbSet<PartToeicGroup> PartToeicGroups { get; set; } = null!;
        public virtual DbSet<GroupToeic> GroupToeics { get; set; } = null!;
        public virtual DbSet<GroupToeicQuestion> GroupToeicQuestions { get; set; } = null!;

        public virtual DbSet<Comment>? Comments { get; set; }

        public virtual DbSet<ToeicScore>? ToeicScores { get; set; }


        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Configuration
           

            //Entity
            builder.Entity<User>().ToTable("Users");
            builder.Entity<Role>().ToTable("Roles");
            builder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims");
            builder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles");
            builder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins");
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens");

            //Seeder 
            builder.Seed();
        }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
