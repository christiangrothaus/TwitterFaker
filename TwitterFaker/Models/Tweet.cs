using System;
using System.ComponentModel.DataAnnotations;

namespace TwitterFaker.Models
{
    public class Tweet
    {
        // EF will instruct the database to automatically generate this value
        public int tweetId { get; set; }

        [Required(ErrorMessage = "Please enter a display name.")]
        public string name { get; set; }

        [Required(ErrorMessage = "Please enter a username.")]
        public string userName { get; set; }

        [Required(ErrorMessage = "Please enter a body.")]
        public string body { get; set; }

        [Required(ErrorMessage = "Please enter a date and time.")]
        public string dateTime { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid number of retweets.")]
        public int? retweets { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid number of quote tweets.")]
        public int? quoteTweets { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid number of likes.")]
        public int? likes { get; set; }
    }
}
