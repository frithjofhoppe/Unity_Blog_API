using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entity;

namespace Business.Domain
{
    public class BlogSpaceDomainService : IBlogSpaceDomainService
    {
        public void CreateBlogSpaceIfNotExists(BlogSpace blogSpace)
        {
            throw new NotImplementedException();
        }

        public List<Member> GetAllBlogSpaces()
        {
            throw new NotImplementedException();
        }

        public List<Member> GetAllBlogSpacesByMemberId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
