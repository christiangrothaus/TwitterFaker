using Microsoft.AspNetCore.Identity;
using System.Buffers.Text;
using System.ComponentModel.DataAnnotations;

namespace TwitterFaker.Models
{
    public class Suspension
    {
        // EF will instruct the database to automatically generate this value
        [Key]
        public int SuspensionId { get; set; }

        //Will be obtained from the signed in user 
        public IdentityUser User { get; set; }

        [Required(ErrorMessage = "Please enter a username.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter a display name.")]
        public string DisplayName { get; set; }

        public string ProfilePicture { get; set; }

        public int Theme { get; set; }

        public int Font { get; set; } 

        public bool Verified { get; set; }
    }
}
