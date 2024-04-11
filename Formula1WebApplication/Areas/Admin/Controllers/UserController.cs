using Formula1WebApplication.Core.Contracts;
using Formula1WebApplication.Core.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using static Formula1WebApplication.Core.Constants.AdministratorConstants;

namespace Formula1WebApplication.Areas.Admin.Controllers
{
    public class UserController : AdminBaseController
    {
        private readonly IUserService userService;
        private readonly IMemoryCache memoryCache;

        public UserController(
            IUserService _userService,
            IMemoryCache _memoryCache)
        {
            userService = _userService;
            memoryCache = _memoryCache;
        }

        public async Task<IActionResult> All()
        {
            var model = memoryCache.Get<IEnumerable<UserServiceModel>>(UsersCacheKey);

            if (model == null || model.Any() == false)
            {
                model = await userService.AllUsersAsync();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(2));

                memoryCache.Set(UsersCacheKey, model, cacheOptions);
            }

            return View(model);
        }
    }
}
