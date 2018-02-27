using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entity;

namespace Business.Domain
{
    public interface IArticleDomainService
    {
        void CreateArticle(string username, int blogId, Article article);
        void DeleteArticle(string username, int blogId, int articleId);
        void DeleteAllArticles(int blogId);
        List<Article> GetAllArticles(string username, int blogId);
        void ModifyArticle(string username, int blogId, Article article);
    }
}
