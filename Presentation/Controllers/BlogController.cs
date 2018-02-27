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

        [HttpPost]
        [Route("")]
        public void CreateBlog(String username ,[FromBody] BlogSpace blogSpace)
        {
            _blogApplicationService.CreateBlogSpace(username ,blogSpace);
        }

        [HttpPut]
        [Route("")]
        public void ModifyBlogSpace(String username ,[FromBody] BlogSpace blogSpace)
        {
            _blogApplicationService.ModifyBlogSpace(username, blogSpace);
        }

        [HttpGet]
        [Route("")]
        public List<BlogSpace> GetAllBlogsByMemberUsername(String username)
        {
            return _blogApplicationService.GetAllBlogSpaces(username);
        }

        [HttpDelete]
        [Route("{blogId}")]
        public void DeleteBlogSpaceByBlogId(String username, int blogId)
        {
            _blogApplicationService.DeleteBlogSpace(username, blogId);
        }
    }
}