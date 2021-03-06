﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entity
{
    public interface IMemberRepository
    {
        void CreateMember(Member member);
        void DeleteMember(Member member);
        void ModifyMember();
        Member GetMemberById(int id);
        IQueryable<Member> GetAllMembers();
    }
}
