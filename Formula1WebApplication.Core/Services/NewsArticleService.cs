using Formula1WebApplication.Core.Contracts;
using Formula1WebApplication.Core.Models.Home;
using Formula1WebApplication.Infrastructure.Common;
using Formula1WebApplication.Infrastructure.Data.Models;
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
    }
}
