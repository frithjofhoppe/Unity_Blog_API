using Business.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Presentation.Controllers
{
    [RoutePrefix("api/public/member/{memberName}/blog")]
    public class BlogController : ApiController
    {

        [HttpGet]
        [Route("")]
        public IEnumerable<BlogSpace> GetAllBlogs()
        {
            return null;
        }

        [HttpGet]
        [Route("{blogId}")]
        public String GetAllBlogs(int blogId, int memberId)
        {
            return "member id:" + memberId + "| blog id: " + blogId;
        }
    }
}