using Formula1WebApplication.Infrastructure.Pagination;

namespace Formula1WebApplication.Infrastructure.Common
{
    public interface IRepository
    {
        IQueryable<T> All<T>() where T : class;

        IQueryable<T> AllReadOnly<T>() where T : class;

        Task AddAsync<T>(T entity) where T : class;

        Task<int> SaveChangesAsync();

        Task<T?> GetByIdAsync<T>(object id) where T : class;

        Task DeleteAsync<T>(object id) where T : class;

        Task<PaginatedList<T>> GetPaginatedAsync<T>(IQueryable<T> query, int pageIndex, int pageSize) where T : class;

        void Remove<T>(T entity) where T : class;
    }
}
