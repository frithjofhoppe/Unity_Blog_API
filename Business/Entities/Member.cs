using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entity
{
    public class Member
    {
        public int MemberId { get; set; }
        public String MemberFirstName { get; set; }
        public String MemberLastName { get; set; }
        public String MemberUserName { get; set; }
        public Member() { }
    }
}
