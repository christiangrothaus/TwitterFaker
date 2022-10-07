using System;
using System.ComponentModel.DataAnnotations;

namespace TwitterFaker.Models
{
    public class Tweet
    {
        // EF will instruct the database to automatically generate this value
        public int TweetId { get; set; }

        //Will be obtained from the signed in user 
        public int UserId { get; set; }

        [Required(ErrorMessage = "Please enter a username.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter a display name.")]
        public string DisplayName { get; set; }

        [Required(ErrorMessage = "Please enter a body.")]
        public string Body { get; set; }

        public string ProfilePicture { get; set; }

        public string Picture { get; set; }

        public string FactCheck { get; set; }

        public string Client { get; set; }

        [Required(ErrorMessage = "Please enter a date and time.")]
        public string DateTime { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid number of retweets.")]
        public int Retweets { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid number of quote tweets.")]
        public int QuoteTweets { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid number of likes.")]
        public int Likes { get; set; }

        public bool Verified { get; set; }

        public int Theme { get; set; }

        public int Font { get; set; }
    }
}
