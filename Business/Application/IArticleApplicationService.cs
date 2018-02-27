using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entity;

namespace Business.Application
{
    public interface IArticleApplicationService
    {
        void CreateArticle(string username, int blogId, Article article);
        List<Article> GetAllArticles(string username, int blogId);
        void DeleteArticle(string username, int blogId, int articleId);
        void ModifyArticle(string username, int blogId, Article article);
    }
}
