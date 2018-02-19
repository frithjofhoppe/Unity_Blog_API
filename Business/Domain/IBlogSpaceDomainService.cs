using Business.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Domain
{
    public interface IBlogSpaceDomainService
    {
        void CreateBlogSpaceIfNotExists(BlogSpace blogSpace);
        List<Member> GetAllBlogSpaces();
        List<Member> GetAllBlogSpacesByMemberId(int id);
        /**
         * Hier aufgehört => kein Bearbeiten erstekkeb
         * GetAllBlogSpacesByMember(Member member)
         * */
    }
}
