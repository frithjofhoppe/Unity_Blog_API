using Business.Application;
using Business.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Presentation.Controllers
{
    [RoutePrefix("api/public/member/{username}/blog")]
    public class BlogController : ApiController
    {
        private readonly IBlogApplicationService _blogApplicationService;
        public BlogController(IBlogApplicationService blogApplicationService)
        {
            _blogApplicationService = blogApplicationService;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<BlogSpace> GetAllBlogs()
        {
            return _blogApplicationService.GetAllBlogs();
        }

        [HttpPut]
        [Route("")]
        public void ModifyBlogSpace([FromBody] BlogSpace blogSpace)
        {
            _blogApplicationService.ModifyBlogSpace(blogSpace);
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<BlogSpace> GetAllBlogsByMemberUsername(String username)
        {
            return _blogApplicationService.GetAllBlogsByMemberUsername(username);
        }

        [HttpPut]
        [Route("")]
        public void DeleteAllBlogSpacesByMemberUsername(String username)
        {
            _blogApplicationService.DeleteAllBlogSpacesByMemberUsername(username);
        }

        [HttpDelete]
        [Route("{blogId}")]
        public void DeleteBlogSpaceByBlogId(int blogId)
        {
            _blogApplicationService.DeleteBlogSpaceByBlogId(blogId);
        }
    }
}