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

        private Repository<Customer> data { get; set; }
        private AppDbContext context;

        public UserController(AppDbContext ctx)
        {
            data = new Repository<Customer>(ctx);
            context = ctx;
        }

        public RedirectToActionResult Index() => RedirectToAction("List");


        public ViewResult List(CustomerGridData values)
        {
            // create options for querying
            var options = new QueryOptions<Customer>
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
            var vm = new UserListViewModel
            {
                Customers = data.List(options),
                CurrentRoute = values,
                TotalPages = values.GetTotalPages(data.Count)
            };
            return View(vm);
        }
    }
}