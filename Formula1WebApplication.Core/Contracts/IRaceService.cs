﻿using Formula1WebApplication.Core.Models.Race;
using Formula1WebApplication.Infrastructure.Pagination;

namespace Formula1WebApplication.Core.Contracts
{
    public interface IRaceService
    {
        Task<PaginatedList<RaceServiceModel>> GetAllRacesAsync(string searchString,
                                                               string sortOrder,
                                                               int pageIndex,
                                                               int pageSize);
    }
}
