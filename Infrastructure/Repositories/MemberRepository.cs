using Business.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class MemberRepository : IMemberRepository
    {
        private readonly ApplicationContext _context;

        public MemberRepository(ApplicationContext applicationContext)
        {
            _context = applicationContext;
        }

        public void ModifyMember()
        {
            _context.SaveChanges();
        }

        public void CreateMember(Member member)
        {
            _context.Members.Add(member);
            _context.SaveChanges();
        }

        public void DeleteMember(Member member)
        {
            _context.Members.Remove(member);
            _context.SaveChanges();
        }

        public IQueryable<Member> GetAllMembers()
        {
            return _context.Members;
        }

        public Member GetMemberById(int id)
        {
            return _context.Members.FirstOrDefault(item => item.MemberId == id);
        }
    }
}
