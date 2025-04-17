using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using RealEstateAgencySystem.Models;

namespace RealEstateAgencySystem.Controllers
{
    public class PropertyController : Controller
    {
        // private AppDbContext context;
        // public ContractController(AppDbContext ctx) => context = ctx;

        private AppDbContext context;
        private Repository<Property> data { get; set; }

        public PropertyController(AppDbContext ctx)
        {
            data = new Repository<Property>(ctx);
            context = ctx;
        }

        public RedirectToActionResult Index() => RedirectToAction("List");


        public ViewResult List()
        {
            return View();
        }


        public ViewResult Detail(int id)
        {
            // create options for querying SalesContract
            var options = new QueryOptions<Property>
            {
                Includes = "Images, PropertyAmenities",
                // OrderByDirection = values.SortDirection,
                // PageNumber = values.PageNumber,
                // PageSize = values.PageSize
            };
            // if (values.IsSortBySalePrice)
            // {
            //     options.OrderBy = c => c.SalePrice;
            //     options.OrderByColumn = "SalePrice";
            // }
            // else
            // {
            //     options.OrderBy = c => c.TransactionDate;
            //     options.OrderByColumn = "TransactionDate";
            // }

            // create view model
            var vm = data.Get(id);

            vm.PropertyAmenities = context.PropertyAmenities.FirstOrDefault(c => c.PropertyID == id);
            vm.Images = context.Images
                .Where(c => c.PropertyID == id)
                .ToList();
            // vm.Owner = context.Users.FirstOrDefault(c => c.Id == vm.OwnerCustomerID);

            return View(vm);
        }
    }
}