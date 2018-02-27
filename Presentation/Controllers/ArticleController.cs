using Business.Application;
using Business.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Presentation.Controllers
{
    [RoutePrefix("api/public/member/{username}/blog/{blogId}/article")]
    public class ArticleController : ApiController
    {
        private readonly IArticleApplicationService _articleApplicationService;

        public ArticleController(IArticleApplicationService service)
        {
            _articleApplicationService = service;
        }

        [HttpPost]
        [Route("")]
        public void CreateArticle(String username, int blogId, Article article)
        {
            _articleApplicationService.CreateArticle(username, blogId, article);
        }

        [HttpPut]
        [Route("")]
        public void ModifyArticle(String username, int blogId, Article article)
        {
            _articleApplicationService.ModifyArticle(username, blogId, article);
        }

        [HttpDelete]
        [Route("{articleId}")]
        public void DeleteArticle(String username, int blogId, int articleId)
        {
            _articleApplicationService.DeleteArticle(username, blogId, articleId);
        }

        [HttpGet]
        [Route("")]
        public List<Article> GetAllArticles(String username, int blogId)
        {
            return _articleApplicationService.GetAllArticles(username, blogId);
        }
    }
}