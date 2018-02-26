using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entity;

namespace Business.Application
{
    class BlogApplicationService : IBlogApplicationService
    {
        public void DeleteAllBlogSpacesByMemberUsername(string username)
        {
            
        }

        public void DeleteBlogSpaceByBlogId(int blogId)
        {
            throw new NotImplementedException();
        }

        public List<BlogSpace> GetAllBlogs()
        {
            throw new NotImplementedException();
        }

        public List<BlogSpace> GetAllBlogsByMemberUsername(string username)
        {
            throw new NotImplementedException();
        }

        public void ModifyBlogSpace(BlogSpace blogSpace)
        {
            throw new NotImplementedException();
        }
    }
}
