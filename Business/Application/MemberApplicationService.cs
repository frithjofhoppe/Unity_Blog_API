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
        private readonly IMemberDomainService _repository;

        public MemberApplicationService(IMemberDomainService repository)
        {
            _repository = repository;
        }
    
        public void CreateMember(Member member)
        {
            _repository.CreateMemberIfNotExists(member);
        }

        public List<Member> GetAllMembers()
        {
            return _repository.GetAllMembers();
        }

        public void ModifyMember(Member member)
        {
            throw new NotImplementedException();
        }
    }
}
