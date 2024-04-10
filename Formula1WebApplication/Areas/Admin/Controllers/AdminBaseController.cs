using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Formula1WebApplication.Core.Constants.AdministratorConstants;

namespace Formula1WebApplication.Areas.Admin.Controllers
{
    [Area(AdminAreaName)]
    [Authorize(Roles = AdminRole)]
    public class AdminBaseController : Controller
    {
    }
}
