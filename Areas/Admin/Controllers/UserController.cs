using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using RealEstateAgencySystem.Models;
using RealEstateAgencySystem.Areas.Admin.Views;

namespace RealEstateAgencySystem.Areas.Admin.Controllers
{
    // [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class UserController : Controller
    {
        // private AppDbContext context;
        // public ContractController(AppDbContext ctx) => context = ctx;

        private Repository<Property> data { get; set; }

        public UserController(AppDbContext ctx)
        {
            data = new Repository<Property>(ctx);
        }

        public RedirectToActionResult Index() => RedirectToAction("List");


        public ViewResult List()
        {
            return View();
        }
    }
}