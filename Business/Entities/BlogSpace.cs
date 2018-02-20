using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entity
{
    public class BlogSpace
    {
        public int BlogSpaceId { get; set; }
        public String BlogSpaceTitle { get; set; }
        public bool BlogSpaceIsPublic { get; set; }
        public ICollection<Article> Articles { get; set; }
        public Member Member { get; set; }
        public BlogSpace() { }
    }
}
