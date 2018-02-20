using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.CustomException;
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
                .FirstOrDefault(item => item.MemberUserName.ToUpper() == member.MemberUserName.ToUpper());

            if(possiblyExists == null)
            {
                _memberRepository
                    .CreateMember(member);
            }
        }

        public void DeleteMember(Member member)
        {
            if(member.MemberId < 0)
            {
                throw new MemberNotFoundException();
            }

            Member toDelete = _memberRepository.GetMemberById(member.MemberId);

            _memberRepository
                .DeleteMember(toDelete);
        }

        public List<Member> GetAllMembers()
        {
            return _memberRepository
                .GetAllMembers()
                .ToList();
        }

        public Member GetMemberById(int id)
        {
            return _memberRepository
                .GetMemberById(id);
        }

        public Member GetMemberByUsername(string name)
        {
            return _memberRepository
                .GetAllMembers()
                .FirstOrDefault(item => item.MemberUserName.ToUpper() == name.ToUpper());
        }

        public void ModifyMember(Member member)
        {
            Member possiblyExists = _memberRepository
                .GetAllMembers()
                .FirstOrDefault(item => item.MemberId == member.MemberId);

            if(possiblyExists != null)
            {
                possiblyExists.MemberFirstName = member.MemberFirstName;
                possiblyExists.MemberIsActive = member.MemberIsActive;
                possiblyExists.MemberLastName = member.MemberLastName;
                _memberRepository.ModifyMember();
            }
        }
    }
}
