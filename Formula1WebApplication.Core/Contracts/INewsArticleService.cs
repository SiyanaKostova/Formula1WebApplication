using Formula1WebApplication.Core.Models.Home;
using Formula1WebApplication.Core.Models.NewsArticle;
using Formula1WebApplication.Infrastructure.Pagination;

namespace Formula1WebApplication.Core.Contracts
{
    public interface INewsArticleService
    {
        Task<IEnumerable<NewsArticleIndexServiceModel>> LastThreeNewsArticlesAsync();
        Task<PaginatedList<NewsArticleServiceModel>> GetArticlesAsync(string sortOrder, string searchString, int pageIndex, int pageSize);
        Task<NewsArticleServiceModel> GetDetailsAsync(int articleId);
    }
}
