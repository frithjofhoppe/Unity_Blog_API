using Business.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Data.Entity;

namespace Infrastructure.Repositories
{
    public class BlogSpaceRepository : IBlogSpaceRepository
    {
        private ApplicationContext _context;
        public BlogSpaceRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void ChangeEntityState(object entity, EntityState state)
        {
            _context.Entry(entity).State = state;
        }

        public void CreateBlogSpace(BlogSpace blog)
        {
            _context.BlogSpaces.Add(blog);
            _context.SaveChanges();
        }

        public void DeleteBlogSpace(BlogSpace blog)
        {
            _context.BlogSpaces.Remove(blog);
            _context.SaveChanges();
        }

        public void DeleteMultipleBlogSpaces(List<BlogSpace> blogs)
        {
            blogs.ForEach(item => _context.BlogSpaces.Remove(item));
            _context.SaveChanges();
        }

        public IQueryable<BlogSpace> GetAllBlogSpaces()
        {
            return _context.BlogSpaces;
        }

        public BlogSpace GetBlogSpaceById(int id)
        {
            return _context.BlogSpaces
                .Include(item => item.Articles)
                .Include(item => item.Member)
                .FirstOrDefault(item => item.BlogSpaceId == id);
        }

        public void ModifyBlog()
        {
            _context.SaveChanges();
        }
    }
}
