using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StackOverflowing.Models;

namespace StackOverflowing.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<AnswerModel> Answers {get; set;}
        public DbSet<CommentModel> Comments {get; set;}
        public DbSet<QtieModel> Qties {get; set;}
        public DbSet<QuestionModel> Questions {get; set;}
        public DbSet<TagModel> Tags {get; set;}
        public DbSet<ApplicationUser> Userinos {get; set;}
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
