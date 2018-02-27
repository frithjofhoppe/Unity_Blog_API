using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.CustomException;
using Business.Entity;
using System.Data.Entity;

namespace Business.Domain
{
    public class MemberDomainService : IMemberDomainService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IBlogSpaceRepository _blogSpaceRepository;
        private readonly IBlogSpaceDomainService _blogSpaceDomainService;
        public MemberDomainService(IMemberRepository memberRepository, IBlogSpaceRepository blogSpaceRepository, IBlogSpaceDomainService blogSpaceDomainService)
        {
            _memberRepository = memberRepository;
            _blogSpaceRepository = blogSpaceRepository;
            _blogSpaceDomainService = blogSpaceDomainService;
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
            _blogSpaceDomainService.DeleteAllBlogSpaces(member.MemberUserName);

            Member toDelete = _memberRepository.GetMemberById(member.MemberId);

            if (toDelete != null)
            {
                _memberRepository.DeleteMember(toDelete);
            }
            else
            {
                throw new MemberNotFoundException();
            }
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

        public bool RelationWithBlogSpace(int memberId, int blogId)
        {
            Member existingMember = _memberRepository.GetMemberById(memberId);
            if (existingMember != null)
            {
                BlogSpace existingSpace = _blogSpaceRepository
                    .GetAllBlogSpaces()
                    .Include(item => item.Member)
                    .FirstOrDefault(item => item.Member.MemberId == memberId &&
                                            item.BlogSpaceId == blogId);
                if (existingSpace != null)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
