using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Business.Entity
{
    public interface IBlogSpaceRepository
    {
        void ModifyBlog();
        void DeleteBlogSpace(BlogSpace blog);
        void DeleteMultipleBlogSpaces(List<BlogSpace> blogs);
        void CreateBlogSpace(BlogSpace blog);
        void ChangeEntityState(Object entity, EntityState state);
        BlogSpace GetBlogSpaceById(int id);
        IQueryable<BlogSpace> GetAllBlogSpaces();
    }
}
