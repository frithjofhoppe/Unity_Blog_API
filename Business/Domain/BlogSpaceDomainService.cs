using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entity;
using System.Data.Entity;

namespace Business.Domain
{
    public class BlogSpaceDomainService : IBlogSpaceDomainService
    {
        private readonly IBlogSpaceRepository _blogRepository;
        private readonly IMemberRepository _memberRepository;
        public BlogSpaceDomainService(IBlogSpaceRepository blogSpaceRepository, IMemberRepository memberRepository)
        {
            _blogRepository = blogSpaceRepository;
            _memberRepository = memberRepository;
        }
        public void CreateBlogSpaceIfNotExists(BlogSpace blogSpace)
        {
            BlogSpace existingBlog = _blogRepository.GetAllBlogSpaces()
                .Include(item => item.Member)
                .FirstOrDefault(item => item.BlogSpaceTitle.ToUpper() == blogSpace.BlogSpaceTitle.ToUpper());
            if(existingBlog != null)
            {
                Member existingMember = _memberRepository.GetMemberById(existingBlog.Member.MemberId);
                //if(exist)
            }
        }

        public void DeleteBlogByBlogId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Member> GetAllBlogSpaces()
        {
            throw new NotImplementedException();
        }

        public List<Member> GetAllBlogSpacesByMemberUserName(string username)
        {
            throw new NotImplementedException();
        }

        public void ModifyBlog(BlogSpace blogSpace)
        {
            throw new NotImplementedException();
        }
    }
}
