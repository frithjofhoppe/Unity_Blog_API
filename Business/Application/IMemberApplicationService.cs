using Business.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Application
{
    public interface IMemberApplicationService
    {
        void CreateMember(Member member);
        void ModifyMember(Member member);
        void DeleteMember(Member member);
        List<Member> GetAllMembers();
        Member GetMemberById(int id);
        Member GetMemberByUsername(String username);
    }
}
