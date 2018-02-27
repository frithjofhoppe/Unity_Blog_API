using Business.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Application
{
    public interface IBlogApplicationService
    {
        void CreateBlogSpace(string username, BlogSpace blogSpace);
        void ModifyBlogSpace(string username, BlogSpace blogSpace);
        List<BlogSpace> GetAllBlogSpaces(string username);
        void DeleteBlogSpace(string username, int blogId);
        void DeleteAllBlogSpaces(string username);
    }
}
