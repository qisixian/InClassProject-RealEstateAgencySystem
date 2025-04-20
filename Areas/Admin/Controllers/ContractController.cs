using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using RealEstateAgencySystem.Models;
using RealEstateAgencySystem.Areas.Admin.Views;

namespace RealEstateAgencySystem.Areas.Admin.Controllers
{
    // [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ContractController : Controller
    {
        // private AppDbContext context;
        // public ContractController(AppDbContext ctx) => context = ctx;

        private Repository<RentalRecord> rentalData { get; set; }
        private Repository<SalesRecord> salesData { get; set; }

        public ContractController(AppDbContext ctx)
        {
            rentalData = new Repository<RentalRecord>(ctx);
            salesData = new Repository<SalesRecord>(ctx);
        }

        public RedirectToActionResult Index() => RedirectToAction("List");

        public ViewResult ListSales(SalesRecordGridData values)
        {
            // create options for querying SalesRecord
            var options = new QueryOptions<SalesRecord>
            {
                Includes = "OwnerCustomer, BuyerCustomer, Property",
                OrderByDirection = values.SortDirection,
                PageNumber = values.PageNumber,
                PageSize = values.PageSize
            };
            if (values.IsSortBySalePrice)
            {
                options.OrderBy = c => c.SalePrice;
                options.OrderByColumn = "SalePrice";
            }
            else
            {
                options.OrderBy = c => c.TransactionDate;
                options.OrderByColumn = "TransactionDate";
            }

            // create view model
            var vm = new SalesRecordListViewModel
            {
                SalesRecords = salesData.List(options),
                CurrentRoute = values,
                TotalPages = values.GetTotalPages(salesData.Count)
            };

            return View(vm);
        }


        public ViewResult ListRentals(RentalRecordGridData values)
        {
            // create options for querying RentalContract
            var options = new QueryOptions<RentalRecord>
            {
                Includes = "OwnerCustomer, TenantCustomer, Property",
                OrderByDirection = values.SortDirection,
                PageNumber = values.PageNumber,
                PageSize = values.PageSize
            };
            if (values.IsSortByRentalPrice)
            {
                options.OrderBy = c => c.RentalPrice;
                options.OrderByColumn = "RentalPrice";
            }
            else if (values.IsSortByDepositPrice)
            {
                options.OrderBy = c => c.DepositPrice;
                options.OrderByColumn = "DepositPrice";
            }
            else if (values.IsSortByEndDate)
            {
                options.OrderBy = c => c.EndDate;
                options.OrderByColumn = "EndDate";
            }
            else
            {
                options.OrderBy = c => c.StartDate;
                options.OrderByColumn = "StartDate";
            }

            // create view model
            var vm = new RentalRecordListViewModel
            {
                RentalRecords = rentalData.List(options),
                CurrentRoute = values,
                TotalPages = values.GetTotalPages(rentalData.Count)
            };

            return View(vm);
        }
    }
}
