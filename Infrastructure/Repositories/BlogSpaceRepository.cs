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
        public void CreateBlogSpace(BlogSpace blog)
        {
            _context.BlogSpaces.Add(blog);
            _context.SaveChanges();
        }

        public void DeleteBlogSpaceById(int id)
        {
            BlogSpace exisiting = _context.BlogSpaces.FirstOrDefault(item => item.BlogSpaceId == id);
            if(exisiting != null)
            {
                _context.BlogSpaces.Remove(exisiting);
                _context.SaveChanges();
            }
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

        public void ModifyBlog(BlogSpace blogSpace)
        {
            BlogSpace exisiting = _context.BlogSpaces
                .FirstOrDefault(item => item.BlogSpaceId == blogSpace.BlogSpaceId);
            if (exisiting != null)
            {
                exisiting.BlogSpaceIsPublic = blogSpace.BlogSpaceIsPublic;
                exisiting.BlogSpaceTitle = blogSpace.BlogSpaceTitle;
                _context.SaveChanges();
            }
        }
    }
}
