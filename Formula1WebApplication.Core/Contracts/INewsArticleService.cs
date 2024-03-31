using Formula1WebApplication.Core.Models.Home;

namespace Formula1WebApplication.Core.Contracts
{
    public interface INewsArticleService
    {
        Task<IEnumerable<NewsArticleIndexServiceModel>> LastThreeNewsArticlesAsync();
    }
}
