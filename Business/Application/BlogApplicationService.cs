using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Domain;
using Business.Entity;

namespace Business.Application
{
    public class BlogApplicationService : IBlogApplicationService
    {
        private readonly IBlogSpaceDomainService _blogDomain;
        public BlogApplicationService(IBlogSpaceDomainService blogSpaceDomainService)
        {
            _blogDomain = blogSpaceDomainService;
        }

        public void CreateBlogSpace(string username, BlogSpace blogSpace)
        {
            _blogDomain.CreateBlogSpace(username, blogSpace);
        }

        public void DeleteAllBlogSpaces(string username)
        {
            _blogDomain.DeleteAllBlogSpaces(username);
        }

        public void DeleteBlogSpace(string username, int blogId)
        {
            _blogDomain.DelteBlogSpace(username, blogId);
        }

        public List<BlogSpace> GetAllBlogSpaces(string username)
        {
            return _blogDomain.GetAllBlogSpaces(username);
        }

        public void ModifyBlogSpace(string username, BlogSpace blogSpace)
        {
            _blogDomain.ModifyBlogSpace(username, blogSpace);
        }
    }
}
