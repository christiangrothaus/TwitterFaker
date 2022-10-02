using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TwitterFaker.Models
{
    public class ReplyChain
    {
        // EF will instruct the database to automatically generate this value
        public int ReplyChainId { get; set; }

        public int UserId { get; set; }

        public List<Reply> replies { get; set; }

    }
}
