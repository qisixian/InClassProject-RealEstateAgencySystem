// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RealEstateAgencySystem.Models;
using RealEstateAgencySystem.Views;

namespace RealEstateAgencySystem.Areas.Identity.Pages.Account.Manage
{
    public class YourPropertiesModel : PageModel
    {
        private readonly UserManager<Customer> _userManager;
        private readonly SignInManager<Customer> _signInManager;
        private readonly AppDbContext _context; 
        private readonly Repository<Property> _propertyData;
        public YourPropertiesModel(
            UserManager<Customer> userManager,
            SignInManager<Customer> signInManager,
            AppDbContext context,
            Repository<Property> propertyData)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _propertyData = propertyData;
        }

        public string Username { get; set; }
        [TempData]
        public string StatusMessage { get; set; }
        [BindProperty]
        public InputModel Input { get; set; }
        public PropertyListViewModel PropertyList { get; set; }

        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
            public string Name { get; set; } = string.Empty;
            public string ContactAddress { get; set; } = string.Empty;
            public string PostalCode { get; set; } = string.Empty;
        }


        public async Task<IActionResult> OnGetAsync(PropertyGridData values)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            Username = user.UserName;

            // 如果未提供查询参数，初始化默认值
            if (values == null)
            {
                values = new PropertyGridData();
            }

            // 创建查询选项
            var options = new QueryOptions<Property>
            {
                OrderByDirection = values.SortDirection,
                PageNumber = values.PageNumber,
                PageSize = 50
            };

            // 添加筛选条件 - 只加载当前用户的属性
            options.Where = p => p.OwnerCustomerId == user.Id;

            // 设置排序方式
            options.OrderBy = p => p.ListingDate;

            // 创建视图模型
            var data = _propertyData.List(options);
            PropertyList = new PropertyListViewModel
            {
                Properties = data,
                CurrentRoute = values,
                TotalPages = values.GetTotalPages(data.Count())
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            return Page();
        }
    }
}
