using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Domain;
using Business.Entity;

namespace Business.Application
{
    public class MemberApplicationService : IMemberApplicationService
    {
        private readonly IMemberDomainService _domain;

        public MemberApplicationService(IMemberDomainService repository)
        {
            _domain = repository;
        }
    
        public void CreateMember(Member member)
        {
            _domain.CreateMemberIfNotExists(member);
        }

        public void DeleteMember(Member member)
        {
            _domain.DeleteMember(member);
        }

        public List<Member> GetAllMembers()
        {
            return _domain.GetAllMembers();
        }

        public Member GetMemberById(int id)
        {
            return _domain.GetMemberById(id);
        }

        public Member GetMemberByUsername(string username)
        {
            return _domain.GetMemberByUsername(username);
        }

        public void ModifyMember(Member member)
        {
            _domain.ModifyMember(member);
        }
    }
}
