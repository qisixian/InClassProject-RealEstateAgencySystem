using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using RealEstateAgencySystem.Models;
using RealEstateAgencySystem.Views;

namespace RealEstateAgencySystem.Controllers
{
    public class PropertyController : Controller
    {
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

            values.PageSize = 50;
            values.Filters.filteredCountries = new HashSet<string>(HttpContext.Request.Query["Filters.filteredCountries"]);
            values.Filters.filteredProvinces = new HashSet<string>(HttpContext.Request.Query["Filters.filteredProvinces"]);
            values.Filters.filteredCities = new HashSet<string>(HttpContext.Request.Query["Filters.filteredCities"]);
            values.Filters.filteredStatuses = new HashSet<string>(HttpContext.Request.Query["Filters.filteredStatuses"]);
            values.Filters.filteredPropertyTypes = new HashSet<string>(HttpContext.Request.Query["Filters.filteredPropertyTypes"]);

            // create options for querying
            var options = new QueryOptions<Property>
            {
                OrderByDirection = values.SortDirection,
                PageNumber = values.PageNumber,
                PageSize = values.PageSize,
                Wheres = values.Filters.buildFilters()
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

            var properties = data.List(options);
            // create view model
            var vm = new PropertyListViewModel
            {
                Properties = properties,
                CurrentRoute = values,
                TotalPages = values.GetTotalPages(properties.Count()),
            };
            return View(vm);
        }

        [Authorize]
        public IActionResult Detail(int id)
        {
            // create options for querying
            // var options = new QueryOptions<Property>
            // {
            //     Includes = "PropertyAmenities",
            //     OrderByDirection = values.SortDirection,
            //     PageNumber = values.PageNumber,
            //     PageSize = values.PageSize
            // };
            
            var property = data.Get(id);
            if (property == null)
            {
                return NotFound();
            }
            property.PropertyAmenities = context.PropertyAmenities.FirstOrDefault(c => c.PropertyId == id);
            property.ImageIds = context.Images.Where(c => c.PropertyId == id).Select(c => c.ImageId).ToList();
            property.Owner = context.Customers.FirstOrDefault(c => c.Id == property.OwnerCustomerId);

            return View(property);
        }
    }
}