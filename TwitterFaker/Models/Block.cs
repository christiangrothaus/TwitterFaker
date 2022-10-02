using System.ComponentModel.DataAnnotations;

namespace TwitterFaker.Models
{
    public class Block
    {
        // EF will instruct the database to automatically generate this value
        public int BlockId { get; set; }

        public int UserId { get; set; }

        [Required(ErrorMessage = "Please enter a username.")]
        public string UserName { get; set; }

        public bool Verified { get; set; }
    }
}
