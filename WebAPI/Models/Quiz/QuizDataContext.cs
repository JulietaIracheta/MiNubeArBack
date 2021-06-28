using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.Quiz
{
    public partial class QuizDataContext : DbContext
    {
        public QuizDataContext() { }
        public QuizDataContext(DbContextOptions<QuizDataContext> options) : base(options)  { }

        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Question> Questions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder();
                builder.AddJsonFile("appsettings.json");
                var configuration = builder.Build();
                optionsBuilder
                    .UseSqlServer(configuration["ConnectionStrings:DevConnection"]);

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>(entity =>
            {
                entity.HasOne(d => d.Question)
                .WithMany(p => p.Answers)
                 .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("FK_Answer_Question");
            });

  
        }

    }
}
