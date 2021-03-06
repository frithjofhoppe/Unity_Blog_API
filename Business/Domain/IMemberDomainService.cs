﻿using Business.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Domain
{
    public interface IMemberDomainService
    {
        void CreateMemberIfNotExists(Member member);
        void DeleteMember(Member member);
        void ModifyMember(Member member);
        List<Member> GetAllMembers();
        Member GetMemberById(int id);
        Member GetMemberByUsername(String name);
        bool RelationWithBlogSpace(int memberId, int blogId);
    }
}
