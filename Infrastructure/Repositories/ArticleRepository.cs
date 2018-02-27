using Business.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ApplicationContext _context;
        public ArticleRepository(ApplicationContext context)
        {
            _context = context;
        }
        public void ChangeEntityState(object entity, EntityState state)
        {
            _context.Entry(entity).State = state;
        }

        public void CreateArticle(Article blog)
        {
            _context.Articles.Add(blog);
            _context.SaveChanges();
        }

        public void DeleteArticle(Article article)
        {
            _context.Articles.Remove(article);
            _context.SaveChanges();
        }

        public void DeleteMultipleArticles(List<Article> articles)
        {
            articles.ForEach(item => _context.Articles.Remove(item));
            _context.SaveChanges();
        }

        public IQueryable<Article> GetAllArticles()
        {
            return _context.Articles;
        }

        public Article GetArticleById(int id)
        {
            return _context.Articles
                .Include(item => item.Comments)
                .FirstOrDefault(item => item.ArticleId == id);
        }

        public void ModfiyArticle()
        {
            _context.SaveChanges();
        }
    }
}
