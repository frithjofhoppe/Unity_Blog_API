using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entity
{
    public interface IBlogSpaceRepository
    {
        void ModifyBlog(BlogSpace blogSpace);
        void DeleteBlogSpaceById(int id);
        void CreateBlogSpace(BlogSpace blog);
        BlogSpace GetBlogSpaceById(int id);
        IQueryable<BlogSpace> GetAllBlogSpaces();
    }
}
