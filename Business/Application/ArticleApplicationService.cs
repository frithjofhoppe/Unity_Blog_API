using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Domain;
using Business.Entity;

namespace Business.Application
{
    public class ArticleApplicationService : IArticleApplicationService
    {
        private readonly IArticleDomainService _articleDomainService;
        public ArticleApplicationService(IArticleDomainService domain)
        {
            _articleDomainService = domain;
        }
        public void CreateArticle(string username, int blogId, Article article)
        {
            _articleDomainService.CreateArticle(username, blogId, article);
        }

        public void DeleteArticle(string username, int blogId, int articleId)
        {
            _articleDomainService.DeleteArticle(username, blogId, articleId);
        }

        public List<Article> GetAllArticles(string username, int blogId)
        {
            return _articleDomainService.GetAllArticles(username, blogId);
        }

        public void ModifyArticle(string username, int blogId, Article article)
        {
            _articleDomainService.ModifyArticle(username, blogId, article);
        }
    }
}
