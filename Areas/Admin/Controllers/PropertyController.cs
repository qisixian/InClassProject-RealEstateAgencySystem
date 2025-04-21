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

            // set the order by property
            if (values.IsSortByPropertyType)
            {
                options.OrderBy = p => p.PropertyType;
                options.OrderByColumn = nameof(Property.PropertyType);
            }
            else if (values.IsSortByBuildYear)
            {
                options.OrderBy = p => p.BuildYear;
                options.OrderByColumn = nameof(Property.BuildYear);
            }
            else if (values.IsSortBySizeOfHouse)
            {
                options.OrderBy = p => p.SizeOfHouse;
                options.OrderByColumn = nameof(Property.SizeOfHouse);
            }
            else if (values.IsSortByBedrooms)
            {
                options.OrderBy = p => p.Bedrooms;
                options.OrderByColumn = nameof(Property.Bedrooms);
            }
            else if (values.IsSortByBathrooms)
            {
                options.OrderBy = p => p.Bathrooms;
                options.OrderByColumn = nameof(Property.Bathrooms);
            }
            else if (values.IsSortByCurrentStatus)
            {
                options.OrderBy = p => p.CurrentStatus;
                options.OrderByColumn = nameof(Property.CurrentStatus);
            }
            else if (values.IsSortByRentalPrice)
            {
                options.OrderBy = p => p.RentalPrice;
                options.OrderByColumn = nameof(Property.RentalPrice);
            }
            else if (values.IsSortBySellingPrice)
            {
                options.OrderBy = p => p.SellingPrice;
                options.OrderByColumn = nameof(Property.SellingPrice);
            }
            else // Default: IsSortByListingDate
            {
                options.OrderBy = p => p.ListingDate;
                options.OrderByColumn = nameof(Property.ListingDate);
            }


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