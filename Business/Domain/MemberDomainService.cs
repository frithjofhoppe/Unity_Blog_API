using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entity;

namespace Business.Domain
{
    public class MemberDomainService : IMemberDomainService
    {
        private IMemberRepository _memberRepository;
        public MemberDomainService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }
        public void CreateMemberIfNotExists(Member member)
        {
            Member possiblyExists = _memberRepository
                .GetAllMembers()
                .FirstOrDefault(item => item.MemberUserName == member.MemberUserName);

            if(possiblyExists == null)
            {
                _memberRepository.CreateMember(member);
            }
        }

        public void DeleteMember(Member member)
        {
            _memberRepository.DeleteMember(member);
        }

        public List<Member> GetAllMembers()
        {
            return _memberRepository.GetAllMembers().ToList();
        }

        public void ModifyMember(Member member)
        {
            throw new NotImplementedException();
        }
    }
}
