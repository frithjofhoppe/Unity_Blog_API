using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entity
{
    public class Tag
    {
        public int TagId { get; set; }
        public String TagIdentifier { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public Tag() { }
    }
}
