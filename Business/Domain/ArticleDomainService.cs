using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entity;
using System.Data.Entity;

namespace Business.Domain
{
    public class ArticleDomainService : IArticleDomainService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IMemberDomainService _memberDomain;
        private readonly IBlogSpaceDomainService _blogDomain;
        public ArticleDomainService(IArticleRepository articleRepository, IBlogSpaceDomainService blogDomain, IMemberDomainService memberDomain)
        {
            _articleRepository = articleRepository;
            _blogDomain = blogDomain;
            _memberDomain = memberDomain;
        }

        public void CreateArticle(string username, int blogId, Article article)
        {
            Member existingMember = _memberDomain.GetMemberByUsername(username);
            BlogSpace exisitingBlog = _blogDomain.GetBlogById(blogId);

            if (exisitingBlog != null && existingMember != null)
            {
                if (_memberDomain.RelationWithBlogSpace(existingMember.MemberId, exisitingBlog.BlogSpaceId))
                {
                    Article existingArticle = _articleRepository
                        .GetAllArticles()
                        .Include(item => item.BlogSpace)
                        .FirstOrDefault(item => item.ArticleTitle.Trim().ToUpper() == article.ArticleTitle.Trim().ToUpper() &&
                                                item.BlogSpace.BlogSpaceId == exisitingBlog.BlogSpaceId);
                    if(exisitingBlog == null)
                    {
                        _articleRepository.CreateArticle(new Article() {
                            ArticleCreation = article.ArticleCreation,
                            ArticleLastModification = article.ArticleLastModification,
                            ArticleTitle = article.ArticleTitle,
                            BlogSpace = exisitingBlog
                        });
                    }
                }
            }
        }

        public void DeleteAllArticles(int blogId)
        {
            List<Article> articles = _articleRepository
                .GetAllArticles()
                .Include(item => item.BlogSpace)
                .Where(item => item.BlogSpace.BlogSpaceId == blogId)
                .ToList();
            _articleRepository.DeleteMultipleArticles(articles);
        }

        public void DeleteArticle(string username, int blogId, int articleId)
        {
            Member exisitingMember = _memberDomain.GetMemberByUsername(username);
            BlogSpace existingBlog = _blogDomain.GetBlogById(blogId);
            if(exisitingMember != null && existingBlog != null)
            {
                if(_memberDomain.RelationWithBlogSpace(exisitingMember.MemberId, existingBlog.BlogSpaceId))
                {
                    Article exisitingArticle = _articleRepository
                        .GetAllArticles()
                        .Include(item => item.BlogSpace)
                        .FirstOrDefault(item => item.BlogSpace.BlogSpaceId == blogId &&
                                                item.ArticleId == articleId);
                    if(exisitingArticle != null)
                    {
                        _articleRepository.DeleteArticle(exisitingArticle);
                    }
                }
            }
        }

        public List<Article> GetAllArticles(string username, int blogId)
        {
            Member existingMember = _memberDomain.GetMemberByUsername(username);
            if(existingMember != null)
            {
                if(_memberDomain.RelationWithBlogSpace(existingMember.MemberId, blogId)){
                    BlogSpace exisitingBlog = _blogDomain.GetBlogById(blogId);
                    return exisitingBlog.Articles.ToList();
                }
            }

            return null;
        }

        public void ModifyArticle(string username, int blogId, Article article)
        {
            Member exisitingMember = _memberDomain.GetMemberByUsername(username);
            BlogSpace existingBlogSpace = _blogDomain.GetBlogById(blogId);
            if(exisitingMember != null && existingBlogSpace != null)
            {
                if(_memberDomain.RelationWithBlogSpace(exisitingMember.MemberId, existingBlogSpace.BlogSpaceId))
                {
                    Article existingArticle = _articleRepository
                        .GetAllArticles()
                        .Include(item => item.BlogSpace)
                        .FirstOrDefault(item => item.BlogSpace.BlogSpaceId == blogId &&
                                                item.ArticleId == article.ArticleId);
                    if(exisitingMember != null)
                    {
                        existingArticle.ArticleCreation = article.ArticleCreation;
                        existingArticle.ArticleLastModification = article.ArticleLastModification;
                        existingArticle.ArticleTitle = article.ArticleTitle;
                        _articleRepository.ModfiyArticle();
                    }
                }
            }
        }
    }
}
