using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entity;
using System.Data.Entity;

namespace Business.Domain
{
    public class BlogSpaceDomainService : IBlogSpaceDomainService
    {
        private readonly IBlogSpaceRepository _blogRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly IArticleRepository _articleRepository;
        private readonly IMemberDomainService _memberDomainService;
        private readonly IArticleDomainService _articleDomainService;
        public BlogSpaceDomainService(IBlogSpaceRepository blogSpaceRepository, IMemberRepository memberRepository, IArticleRepository articleRepository, IMemberDomainService memberDomainService, IArticleDomainService articleDomainService)
        {
            _blogRepository = blogSpaceRepository;
            _memberRepository = memberRepository;
            _articleRepository = articleRepository;
            _memberDomainService = memberDomainService;
            _articleDomainService = articleDomainService;
        }

        public void CreateBlogSpace(string username, BlogSpace blogSpace)
        {
            Member existingMember = _memberRepository.GetAllMembers().FirstOrDefault(item => item.MemberUserName == username);
            if(existingMember != null)
            {
                BlogSpace exisitingBlog = _blogRepository
                    .GetAllBlogSpaces()
                    .Include(item => item.Member)
                    .FirstOrDefault(item => item.BlogSpaceTitle.Trim().ToUpper() == blogSpace.BlogSpaceTitle.Trim().ToUpper() &&
                                            item.Member.MemberUserName == username);
                if(exisitingBlog == null)
                {
                    _blogRepository.ChangeEntityState(existingMember, EntityState.Unchanged);
                    BlogSpace toCreate = new BlogSpace()
                    {
                        BlogSpaceIsPublic = blogSpace.BlogSpaceIsPublic,
                        BlogSpaceTitle = blogSpace.BlogSpaceTitle,
                        Member = existingMember
                    };
                    _blogRepository.CreateBlogSpace(toCreate);
                }
            }
        }

        public void DeleteAllBlogSpaces(string username)
        {
            List<BlogSpace> blogs = _blogRepository
                .GetAllBlogSpaces()
                .Include(item => item.Member)
                .Where(item => item.Member.MemberUserName == username)
                .ToList();

            if (blogs != null)
            {
                blogs.ForEach(item => _articleDomainService.DeleteAllArticles(item.BlogSpaceId));
                _blogRepository.DeleteMultipleBlogSpaces(blogs);
            }
        }

        public void DelteBlogSpace(string username, int blogId)
        {
            Member exisitingMember = _memberRepository
                .GetAllMembers()
                .FirstOrDefault(item => item.MemberUserName == username);
            BlogSpace exisitingBlogSpace = _blogRepository
                .GetAllBlogSpaces()
                .FirstOrDefault(item => item.BlogSpaceId == blogId);

            if(exisitingMember != null && exisitingBlogSpace != null)
            {
                if(_memberDomainService.RelationWithBlogSpace(exisitingMember.MemberId, blogId))
                {
                    _blogRepository.DeleteBlogSpace(exisitingBlogSpace);
                }
            }
        }

        public List<BlogSpace> GetAllBlogSpaces(string username)
        {
            Member existingMember = _memberDomainService.GetMemberByUsername(username);
            if (existingMember != null)
            {
                List<BlogSpace> blogSpaces = _blogRepository
                     .GetAllBlogSpaces()
                     .Include(item => item.Member)
                     .Where(item => item.Member.MemberUserName == username)
                     .ToList();
                blogSpaces.ForEach(item => item.Member = null);
                return blogSpaces;
            }
            return null;
        }

        public BlogSpace GetBlogById(int id)
        {
            return _blogRepository.GetBlogSpaceById(id);
        }

        public void ModifyBlogSpace(string username, BlogSpace blogSpace)
        {
            Member exisitingMember = _memberRepository
                .GetAllMembers()
                .FirstOrDefault(item => item.MemberUserName == username);

            BlogSpace exisitingBlogSpace = _blogRepository
                .GetAllBlogSpaces()
                .FirstOrDefault(item => item.BlogSpaceId == blogSpace.BlogSpaceId);

            BlogSpace possiblyDuplicate = _blogRepository
                .GetAllBlogSpaces()
                .FirstOrDefault(item => item.BlogSpaceTitle.Trim().ToUpper() == blogSpace.BlogSpaceTitle.Trim().ToUpper());

            if(exisitingBlogSpace != null && exisitingMember != null && possiblyDuplicate == null)
            {
                if(_memberDomainService.RelationWithBlogSpace(exisitingMember.MemberId, blogSpace.BlogSpaceId))
                {
                    exisitingBlogSpace.BlogSpaceIsPublic = blogSpace.BlogSpaceIsPublic;
                    exisitingBlogSpace.BlogSpaceTitle = blogSpace.BlogSpaceTitle;
                    _blogRepository.ModifyBlog();
                }
            }
        }

        public bool RelationWithArticle(int blogId, int articleId)
        {
            BlogSpace existing = _blogRepository.GetBlogSpaceById(blogId);
            if (existing != null)
            {
                Article existingArticle = _articleRepository
                    .GetAllArticles()
                    .Include(item => item.BlogSpace)
                    .FirstOrDefault(item => item.ArticleId == articleId &&
                                            item.BlogSpace.BlogSpaceId == blogId);
                if(existingArticle != null)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
