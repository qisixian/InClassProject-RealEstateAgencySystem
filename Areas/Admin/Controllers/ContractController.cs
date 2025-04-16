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

        private Repository<RentalContract> rentalData { get; set; }
        private Repository<SalesContract> salesData { get; set; }

        public ContractController(AppDbContext ctx)
        {
            rentalData = new Repository<RentalContract>(ctx);
            salesData = new Repository<SalesContract>(ctx);
        }

        public RedirectToActionResult Index() => RedirectToAction("List");

        public ViewResult ListSales(SalesContractGridData values)
        {
            // create options for querying SalesContract
            var options = new QueryOptions<SalesContract>
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
            var vm = new SalesContractListViewModel
            {
                SalesContracts = salesData.List(options),
                CurrentRoute = values,
                TotalPages = values.GetTotalPages(salesData.Count)
            };

            return View(vm);
        }


        public ViewResult ListRentals(RentalContractGridData values)
        {
            // create options for querying RentalContract
            var options = new QueryOptions<RentalContract>
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
            var vm = new RentalContractListViewModel
            {
                RentalContracts = rentalData.List(options),
                CurrentRoute = values,
                TotalPages = values.GetTotalPages(rentalData.Count)
            };

            return View(vm);
        }
    }
}
