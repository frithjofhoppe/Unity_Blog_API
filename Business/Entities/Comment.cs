using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entity
{
    public class Comment
    {
        public int CommentId { get; set; }
        public String CommentContent { get; set; }
        public Article Article { get; set; }
        public Member Member { get; set; }
        public Comment() { }
    }
}
