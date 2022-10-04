using System.Buffers.Text;
using System.ComponentModel.DataAnnotations;

namespace TwitterFaker.Models
{
    public class Suspension
    {
        // EF will instruct the database to automatically generate this value
        public int SuspensionId { get; set; }

        public int UserId { get; set; }

        [Required(ErrorMessage = "Please enter a username.")]
        public string UserName { get; set; }

        public string DisplayName { get; set; }

        public string ProfilePicture { get; set; }

        public string Theme { get; set; }

        public string Font { get; set; } 

        public bool Verified { get; set; }
    }
}
