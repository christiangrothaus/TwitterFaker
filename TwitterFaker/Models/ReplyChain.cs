using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TwitterFaker.Models
{
    public class ReplyChain
    {
        // EF will instruct the database to automatically generate this value
        public int ReplyChainId { get; set; }

        //Will be obtained from the signed in user 
        public int UserId { get; set; }

        public List<Reply> replies { get; set; }

        public int Theme { get; set; }

        public int Font { get; set; }

    }
}
