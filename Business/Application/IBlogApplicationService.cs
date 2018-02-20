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
        List<BlogSpace> GetAllBlogs();
        List<BlogSpace> GetAllBlogsByMemberId(int id);
    }
}
