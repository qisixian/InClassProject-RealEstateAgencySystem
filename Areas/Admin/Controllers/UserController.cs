using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using RealEstateAgencySystem.Models;
using RealEstateAgencySystem.Areas.Admin.Views;

namespace RealEstateAgencySystem.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class UserController : Controller
    {
        // private AppDbContext context;
        // public ContractController(AppDbContext ctx) => context = ctx;

        private Repository<Customer> data { get; set; }
        private AppDbContext context;
        private readonly UserManager<Customer> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public UserController(AppDbContext ctx, UserManager<Customer> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            data = new Repository<Customer>(ctx);
            context = ctx;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public RedirectToActionResult Index() => RedirectToAction("List");


        public async Task<ViewResult> List(CustomerGridData values)
        {
            // create options for querying
            var options = new QueryOptions<Customer>
            {
                OrderByDirection = values.SortDirection,
                PageNumber = values.PageNumber,
                PageSize = values.PageSize
            };
            var customers = data.List(options);

            foreach (var customer in customers)
            {
                customer.RoleNames = await _userManager.GetRolesAsync(customer);
            }

            // create view model
            var vm = new UserListViewModel
            {
                Customers = customers,
                CurrentRoute = values,
                TotalPages = values.GetTotalPages(data.Count),
                AllRoles = _roleManager.Roles.Select(r => r.Name).ToList()
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(string userId, string roleName)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(roleName))
            {
                TempData["message"] = "Invalid user ID or role name.";
                return RedirectToAction("List");
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                TempData["message"] = "User not found.";
                return RedirectToAction("List");
            }
            var roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                TempData["message"] = $"Role '{roleName}' does not exist.";
                return RedirectToAction("List");
            }
            var isInRole = await _userManager.IsInRoleAsync(user, roleName);
            if (isInRole)
            {
                TempData["message"] = $"User already has the role '{roleName}'.";
                return RedirectToAction("List");
            }

            // add role
            var result = await _userManager.AddToRoleAsync(user, roleName);
            if (result.Succeeded)
            {
                TempData["message"] = $"Role '{roleName}' added to user successfully.";
            }
            else
            {
                TempData["message"] = $"Error adding role: {string.Join(", ", result.Errors.Select(e => e.Description))}";
            }

            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveRole(string userId, string roleName)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(roleName))
            {
                TempData["message"] = "Invalid user ID or role name.";
                return RedirectToAction("List");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user != null && await _userManager.IsInRoleAsync(user, roleName))
            {
                await _userManager.RemoveFromRoleAsync(user, roleName);
                TempData["message"] = $"Role '{roleName}' removed from user.";
            }

            return RedirectToAction("List");
        }
    }
}