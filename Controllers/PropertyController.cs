using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using RealEstateAgencySystem.Models;
using RealEstateAgencySystem.Views;

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


        public ViewResult List(PropertyGridData values)
        {
            // create options for querying
            var options = new QueryOptions<Property>
            {
                OrderByDirection = values.SortDirection,
                PageNumber = values.PageNumber,
                PageSize = 40
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


        public IActionResult Detail(int id)
        {
            // create options for querying SalesContract
            var options = new QueryOptions<Property>
            {
                Includes = "Images, PropertyAmenities",
                // OrderByDirection = values.SortDirection,
                // PageNumber = values.PageNumber,
                // PageSize = values.PageSize
            };
            
            var property = data.Get(id);
            if (property == null)
            {
                return NotFound();
            }
            property.PropertyAmenities = context.PropertyAmenities.FirstOrDefault(c => c.PropertyId == id);
            property.Images = context.Images.Where(c => c.PropertyId == id).ToList();

            return View(property);
        }
    }
}