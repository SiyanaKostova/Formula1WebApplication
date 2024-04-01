using Formula1WebApplication.Core.Contracts;
using Formula1WebApplication.Core.Models.Home;
using Formula1WebApplication.Core.Models.NewsArticle;
using Formula1WebApplication.Infrastructure.Common;
using Formula1WebApplication.Infrastructure.Data.Models;
using Formula1WebApplication.Infrastructure.Pagination;
using Microsoft.EntityFrameworkCore;

namespace Formula1WebApplication.Core.Services
{
    public class NewsArticleService : INewsArticleService
    {
        private readonly IRepository repository;

        public NewsArticleService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task AddAsync(NewsArticleServiceModel model, int organizerId)
        {
            var article = new NewsArticle
            {
                Title = model.Title,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                OrganizerId = organizerId 
            };

            await repository.AddAsync(article);
            await repository.SaveChangesAsync();
        }

        public async Task EditAsync(int newsArticleId, NewsArticleServiceModel model)
        {
            var newsArticle = await repository.GetByIdAsync<NewsArticle>(newsArticleId);
            
            if (newsArticle != null)
            {
                newsArticle.Title = model.Title;
                newsArticle.Description = model.Description;
                newsArticle.ImageUrl = model.ImageUrl;

                await repository.SaveChangesAsync();
            }
        }

        public async Task<PaginatedList<NewsArticleServiceModel>> GetArticlesAsync(
            string sortOrder,
            string searchString,
            int pageIndex,
            int pageSize)
        {
            var query = repository.All<NewsArticle>();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(n => n.Title.Contains(searchString) || n.Description.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "title":
                    query = query.OrderBy(n => n.Title);
                    break;
                case "newest":
                    query = query.OrderByDescending(n => n.Id);
                    break;
                default:
                    query = query.OrderByDescending(n => n.Id);
                    break;
            }

            var count = await query.CountAsync();

            var items = await query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .Select(a => new NewsArticleServiceModel
                {
                    Id = a.Id,
                    Title = a.Title,
                    Description = a.Description,
                    ImageUrl = a.ImageUrl
                })
                .ToListAsync();

            return new PaginatedList<NewsArticleServiceModel>(items, count, pageIndex, pageSize);
        }

        public async Task<NewsArticleServiceModel> GetDetailsAsync(int articleId)
        {
            var article = await repository.AllReadOnly<NewsArticle>()
            .Where(a => a.Id == articleId)
            .Select(a => new NewsArticleServiceModel
            {
                Id = a.Id,
                Title = a.Title,
                Description = a.Description,
                ImageUrl = a.ImageUrl 
            })
            .FirstOrDefaultAsync();

            return article;
        }

        public async Task<NewsArticleServiceModel?> GetNewsArticleServiceModelByIdAsync(int id)
        {
            var newsArticle = await repository.AllReadOnly<NewsArticle>()
                .Where(a => a.Id == id)
                .Select(a => new NewsArticleServiceModel()
                {
                    Id = a.Id,
                    Title = a.Title,
                    Description = a.Description,
                    ImageUrl = a.ImageUrl
                })
                .FirstOrDefaultAsync();

            return newsArticle;
        }

        public async Task<bool> HasOrganizerWithIdAsync(int newsArticleId, string userId)
        {
            return await repository.AllReadOnly<NewsArticle>()
                .AnyAsync(a=>  a.Id == newsArticleId && a.Organizer.UserId == userId);
        }

        public async Task<IEnumerable<NewsArticleIndexServiceModel>> LastThreeNewsArticlesAsync()
        {
            return await repository
                .AllReadOnly<NewsArticle>()
                .OrderByDescending(n => n.Id)
                .Take(3)
                .Select(n => new NewsArticleIndexServiceModel()
                {
                    Id = n.Id,
                    Title = n.Title,
                    ImageUrl = n.ImageUrl
                })
                .ToListAsync();
        }

        public async Task DeleteAsync(int newsArticleId)
        {
            await repository.DeleteAsync<NewsArticle>(newsArticleId);
            await repository.SaveChangesAsync();
        }
    }
}
