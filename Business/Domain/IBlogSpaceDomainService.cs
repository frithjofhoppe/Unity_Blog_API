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
        void CreateBlogSpace(string username, BlogSpace blogSpace);
        void DelteBlogSpace(string username, int blogId);
        List<BlogSpace> GetAllBlogSpaces(string username);
        BlogSpace GetBlogById(int id);
        void ModifyBlogSpace(string username, BlogSpace blogSpace);
        void DeleteAllBlogSpaces(string username);
    }
}
