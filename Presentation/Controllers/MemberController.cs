using Business.Application;
using Business.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Presentation.Controllers
{
    [RoutePrefix("api/public/member")]
    public class MemberController : ApiController
    {
        private IMemberApplicationService _service;

        public MemberController (IMemberApplicationService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Member> GetAllMembers()
        {
            return _service.GetAllMembers();
        }

        [HttpGet]
        [Route("{username}")]
        public Member GetMemberByUserName(String username)
        {
            return _service.GetMemberByUsername(username);
        }

        [HttpPost]
        [Route("")]
        public void CreateMember([FromBody] Member member)
        {
            _service.CreateMember(member);
        }

        [HttpPut]
        [Route("")]
        public void ModifyMember([FromBody] Member member)
        {
            _service.ModifyMember(member);
        }

        [HttpDelete]
        [Route("")]
        public void DeleteMember([FromBody] Member member)
        {
            _service.DeleteMember(member);
        }
    }
}