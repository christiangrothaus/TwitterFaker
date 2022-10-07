using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TwitterFaker.Models
{
    public class TwitterFakerContext : IdentityDbContext
    {
        public TwitterFakerContext(DbContextOptions<TwitterFakerContext> options)
            : base(options)
        { }

        // Table
        public DbSet<IdentityUser> AspNetUsers { get; }

        public DbSet<Block> Blocks { get; set; }

        public DbSet<Reply> Replys { get; set; }

        public DbSet<ReplyChain> ReplyChains { get; set; }

        public DbSet<Suspension> Suspensions { get; set; }

        public DbSet<Tweet> Tweets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<IdentityUser>().HasData(
            //    new IdentityUser
            //    {
            //        UserName = "admin",            
            //    }
            //);
        }
    }
}
