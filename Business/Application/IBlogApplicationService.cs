using Business.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Application
{
    public interface IBlogApplicationService
    {
        List<BlogSpace> GetAllBlogs();
        void ModifyBlogSpace(BlogSpace blogSpace);
        List<BlogSpace> GetAllBlogsByMemberUsername(string username);
        void DeleteAllBlogSpacesByMemberUsername(string username);
        void DeleteBlogSpaceByBlogId(int blogId);
    }
}
