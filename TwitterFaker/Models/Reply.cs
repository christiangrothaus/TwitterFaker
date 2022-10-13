using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TwitterFaker.Models
{
    [Table("Replies")]
    public class Reply
    {
        // EF will instruct the database to automatically generate this value
        [Key]
        public int ReplyId { get; set; }

        public ReplyChain ReplyChain { get; set; }

        [Required(ErrorMessage = "Please enter a username.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter a display name.")]
        public string DisplayName { get; set; }

        public string ProfilePicture { get; set; }

        [Required(ErrorMessage = "Please enter a body.")]
        public string Body { get; set; }

        [Required(ErrorMessage = "Please enter a date and time.")]
        public DateTime DateTime { get; set; }

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

        public int Index { get; set; }
    }
}