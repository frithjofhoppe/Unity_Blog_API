using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entity
{
    public interface IArticleRepository
    {
        void ModfiyArticle();
        void DeleteArticle(Article article);
        void CreateArticle(Article article);
        void ChangeEntityState(Object entity, EntityState state);
        Article GetArticleById(int id);
        IQueryable<Article> GetAllArticles();
        void DeleteMultipleArticles(List<Article> articles);
    }
}
