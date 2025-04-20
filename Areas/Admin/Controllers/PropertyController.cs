using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using RealEstateAgencySystem.Models;
using RealEstateAgencySystem.Views;
using RealEstateAgencySystem.Areas.Admin.Views;

namespace RealEstateAgencySystem.Areas.Admin.Controllers
{
    // [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class PropertyController : Controller
    {
        // private AppDbContext context;
        // public ContractController(AppDbContext ctx) => context = ctx;

        private Repository<Property> data { get; set; }

        public PropertyController(AppDbContext ctx)
        {
            data = new Repository<Property>(ctx);
        }

        public RedirectToActionResult Index() => RedirectToAction("List");


        public ViewResult List(PropertyGridData values)
        {
            // create options for querying
            var options = new QueryOptions<Property>
            {
                OrderByDirection = values.SortDirection,
                PageNumber = values.PageNumber,
                PageSize = values.PageSize
            };
            // if (values.IsSortBySalePrice)
            // {
            //     options.OrderBy = c => c.SalePrice;
            //     options.OrderByColumn = "SalePrice";
            // }
            // else
            // {
            //     options.OrderBy = c => c.TransactionDate;
            // }


            // create view model
            var vm = new PropertyListViewModel
            {
                Properties = data.List(options),
                CurrentRoute = values,
                TotalPages = values.GetTotalPages(data.Count)
            };
            return View(vm);
        }
    }
}