using System;
using System.ComponentModel.DataAnnotations;

namespace TwitterFaker.Models
{
    public class Reply
    {
        // EF will instruct the database to automatically generate this value
        public int ReplyId { get; set; }

        public int UserId { get; set; }

        [Required(ErrorMessage = "Please enter a username.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter a body.")]
        public string Body { get; set; }

        [Required(ErrorMessage = "Please enter a date and time.")]
        public string DateTime { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid number of retweets.")]
        public int Retweets { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid number of quote tweets.")]
        public int QuoteTweets { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid number of likes.")]
        public int Likes { get; set; }

        public bool Verified { get; set; }
    }
}