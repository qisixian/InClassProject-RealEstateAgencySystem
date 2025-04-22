using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using RealEstateAgencySystem.Models;
using RealEstateAgencySystem.Areas.Admin.Views;

namespace RealEstateAgencySystem.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ContractController : Controller
    {
        // private AppDbContext context;
        // public ContractController(AppDbContext ctx) => context = ctx;

        private Repository<RentalRecord> rentalData { get; set; }
        private Repository<SalesRecord> salesData { get; set; }
        private AppDbContext context { get; set; }
        private UserManager<Customer> userManager { get; set; }

        public ContractController(AppDbContext ctx, UserManager<Customer> userMgr)
    
        {
            context = ctx;
            rentalData = new Repository<RentalRecord>(ctx);
            salesData = new Repository<SalesRecord>(ctx);
            userManager = userMgr;
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


        public IActionResult AddRentalRecord()
        {
            var rentalRecord = new RentalRecord();
            ViewBag.Action = "Add";
            ViewBag.Properties = context.Properties.ToList();
            ViewBag.Users = context.Customers.ToList();
            ViewBag.defaultRentalContractTerm = "Month-to-month lease with 30-day notice required for termination.";

            return View("EditRentalRecord", rentalRecord);
        }
        public IActionResult EditRentalRecord(int id)
        {
            var rentalRecord = rentalData.Get(id);
            if (rentalRecord == null)
            {
                return NotFound();
            }
            ViewBag.Action = "Edit";
            ViewBag.Properties = context.Properties.ToList();
            ViewBag.Users = context.Customers.ToList();

            return View(rentalRecord);

        }

        [HttpPost]
        public IActionResult AddRentalRecord(RentalRecord rentalRecord)
        {
            if (ModelState.IsValid)
            {
                rentalData.Insert(rentalRecord);
                rentalData.Save();
                return RedirectToAction("ListRentals");
            }
            return View(rentalRecord);
        }

        [HttpPost]
        public IActionResult EditRentalRecord(RentalRecord rentalRecord)
        {
            if (ModelState.IsValid)
            {
                rentalData.Update(rentalRecord);
                rentalData.Save();
                return RedirectToAction("ListRentals");
            }
            return View(rentalRecord);
        }

        [HttpPost]
        public IActionResult DeleteRentalRecord(int id)
        {
            var rentalRecord = rentalData.Get(id);
            if (rentalRecord == null)
            {
                return NotFound();
            }
            rentalData.Delete(rentalRecord);
            rentalData.Save();
            return RedirectToAction("ListRentals");
        }

        // GET: AddSalesRecord
        public IActionResult AddSalesRecord()
        {
            var salesRecord = new SalesRecord();
            ViewBag.Action = "Add";
            ViewBag.Properties = context.Properties.ToList();
            ViewBag.Users = context.Customers.ToList();
            ViewBag.defaultSalesContractTerm = "Standard sale contract terms with 30-day closing period. Buyer is responsible for inspection costs.";

            return View("EditSalesRecord", salesRecord);
        }

        // GET: EditSalesRecord
        public IActionResult EditSalesRecord(int id)
        {
            var salesRecord = salesData.Get(id);
            if (salesRecord == null)
            {
                return NotFound();
            }
            ViewBag.Action = "Edit";
            ViewBag.Properties = context.Properties.ToList();
            ViewBag.Users = context.Customers.ToList();

            return View(salesRecord);
        }

        // POST: AddSalesRecord
        [HttpPost]
        public IActionResult AddSalesRecord(SalesRecord salesRecord)
        {
            if (ModelState.IsValid)
            {
                salesData.Insert(salesRecord);
                salesData.Save();
                return RedirectToAction("ListSales");
            }
            return View(salesRecord);
        }

        // POST: EditSalesRecord
        [HttpPost]
        public IActionResult EditSalesRecord(SalesRecord salesRecord)
        {
            if (ModelState.IsValid)
            {
                salesData.Update(salesRecord);
                salesData.Save();
                return RedirectToAction("ListSales");
            }
            return View(salesRecord);
        }

        // POST: DeleteSalesRecord
        [HttpPost]
        public IActionResult DeleteSalesRecord(int id)
        {
            var salesRecord = salesData.Get(id);
            if (salesRecord == null)
            {
                return NotFound();
            }
            salesData.Delete(salesRecord);
            salesData.Save();
            return RedirectToAction("ListSales");
        }
    }
}
