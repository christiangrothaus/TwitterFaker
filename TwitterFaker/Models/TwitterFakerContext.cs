using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TwitterFaker.Models
{
    public class TwitterFakerContext : IdentityDbContext
    {
        public TwitterFakerContext(DbContextOptions<TwitterFakerContext> options)
            : base(options)
        { }

        // Table
        public DbSet<Block> Blocks { get; set; }

        public DbSet<Reply> Replys { get; set; }

        public DbSet<ReplyChain> ReplyChains { get; set; }

        public DbSet<Suspension> Suspensions { get; set; }

        public DbSet<Tweet> Tweets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Blocks
            modelBuilder.Entity<Block>()
                .HasOne(b => b.User)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            //Replies
            modelBuilder.Entity<Reply>()
                .HasOne(r => r.ReplyChain)
                .WithMany(c => c.replies)
                .IsRequired();

            //ReplyChains
            modelBuilder.Entity<ReplyChain>()
                .HasMany(r => r.replies)
                .WithOne(c => c.ReplyChain)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ReplyChain>()
                .HasOne(c => c.User)
                .WithMany()
                .IsRequired();

            //Suspensions
            modelBuilder.Entity<Suspension>()
                .HasOne(s => s.User)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            //Tweets
            modelBuilder.Entity<Tweet>()
                .HasOne(t => t.User)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            //User
            modelBuilder.Entity<IdentityUser>();
        }
    }
}
