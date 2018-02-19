using Business.Application;
using Business.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Presentation.Controllers
{
    [Route("api/member")]
    public class MemberController : ApiController
    {
        private IMemberApplicationService _service;

        public MemberController (IMemberApplicationService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Member> GetAllMembers()
        {
            return _service.GetAllMembers();
        }

        [HttpPost]
        public void CreateMember([FromBody] Member member)
        {
            _service.CreateMember(member);
        }
    }
}