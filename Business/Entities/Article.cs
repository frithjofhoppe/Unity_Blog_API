using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entity
{
    public class Article
    {
        public int ArticleId { get; set; }
        public String ArticleTitle { get; set; }
        public DateTime ArticleCreation { get; set; }
        public DateTime ArticleLastModification { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public BlogSpace BlogSpace { get; set; }
        public Article() { }
    }
}
