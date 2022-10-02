using Microsoft.EntityFrameworkCore;

namespace TwitterFaker.Models
{
    public class TweetContext : DbContext
    {
        public TweetContext(DbContextOptions<TweetContext> options)
          : base(options)
        { }

        public DbSet<Tweet> Tweets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tweet>().HasData(
                new Tweet
                {
                    TweetId = 0,
                    UserId = 0,
                    UserName = "jack",
                    Body = "Lorem Ipsum",
                    DateTime = "2022-10-19T22:49",
                    Retweets = 3,
                    QuoteTweets = 5,
                    Likes = 2,
                    Verified = true
                },
                new Tweet
                {
                    TweetId = 1,
                    UserId = 0,
                    UserName = "elonmusk",
                    Body = "Lorem Ipsum",
                    DateTime = "2020-11-09T12:49",
                    Retweets = 1311,
                    QuoteTweets = 1321,
                    Likes = 411,
                    Verified = true
                },
                new Tweet
                {
                    TweetId = 2,
                    UserId = 1,
                    UserName = "NASA",
                    Body = "Lorem Ipsum",
                    DateTime = "2021-01-23T17:49",
                    Retweets = 1341311,
                    QuoteTweets = 131321,
                    Likes = 41311,
                    Verified = true
                }
            );
        }
    }
}
