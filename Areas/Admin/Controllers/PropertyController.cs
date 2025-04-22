using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RealEstateAgencySystem.Models;
using RealEstateAgencySystem.Views;
using RealEstateAgencySystem.Areas.Admin.Views;

namespace RealEstateAgencySystem.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class PropertyController : Controller
    {
        private AppDbContext context;
        private Repository<Property> data { get; set; }
        private readonly UserManager<Customer> _userManager;


        public PropertyController(AppDbContext ctx, UserManager<Customer> userManager)
        {
            data = new Repository<Property>(ctx);
            context = ctx;
            _userManager = userManager;
        }

        public RedirectToActionResult Index() => RedirectToAction("List");


        [Authorize(Roles = "Admin")]
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



        public async Task<IActionResult> Edit(int id)
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

            // 检查当前用户是否是 Property 的所有者，或者是 Admin 权限
            var currentUser = await _userManager.GetUserAsync(User);
            if (property.OwnerCustomerId != currentUser.Id && !User.IsInRole("Admin"))
            {
                return Forbid(); // 返回 403 Forbidden
            }

            ViewBag.Action = "Edit";
            ViewBag.PropertyTypes = new string[] { "House", "Apartment", "Condo", "Townhouse", "Basement Suite", "Duplex" };
            ViewBag.Statuses = new string[] { "For Sale", "For Rent", "Sold", "Rented" };


            property.PropertyAmenities = context.PropertyAmenities.FirstOrDefault(c => c.PropertyId == id);
            property.ImageIds = context.Images.Where(c => c.PropertyId == id).Select(c => c.ImageId).ToList();
            property.Owner = context.Customers.FirstOrDefault(c => c.Id == property.OwnerCustomerId);

            return View(property);
        }

        public async Task<IActionResult> Add()
        {
            ViewBag.Action = "Add";
            ViewBag.PropertyTypes = new string[] { "House", "Apartment", "Condo", "Townhouse", "Basement Suite", "Duplex" };
            ViewBag.Statuses = new string[] { "For Sale", "For Rent", "Sold", "Rented" };
            var property = new Property();
            property.PropertyAmenities = new PropertyAmenities();
            property.Images = new List<Image>();

            // Get the current user
            var user = await _userManager.GetUserAsync(User);

            Console.WriteLine("User: " + user);

            // todo: prevent bug if user have not logged in

            property.OwnerCustomerId = user.Id;
            property.Owner = user;

            return View("Edit", property);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Property property, List<IFormFile> newImages, int[] deletedImageIds)
        {

            // 检查当前用户是否是 Property 的所有者，或者是 Admin 权限
            var currentUser = await _userManager.GetUserAsync(User);
            if (property.OwnerCustomerId != currentUser.Id && !User.IsInRole("Admin"))
            {
                return Forbid(); // 返回 403 Forbidden
            }

            if (!ModelState.IsValid)
            {
                // 重新加载必要数据
                ViewBag.Action = "Edit";
                ViewBag.PropertyTypes = new string[] { "House", "Apartment", "Condo", "Townhouse", "Basement Suite", "Duplex" };
                ViewBag.Statuses = new string[] { "For Sale", "For Rent", "Sold", "Rented" };

                // 重新加载所有者信息，因为模型绑定可能丢失
                property.Owner = await context.Customers.FirstOrDefaultAsync(c => c.Id == property.OwnerCustomerId);

                Console.WriteLine("ModelState is invalid");
                return View(property);
            }

            var existingProperty = data.Get(property.PropertyId);
            if (existingProperty == null)
            {
                return NotFound();
            }
            try
            {
                // update property
                context.Entry(existingProperty).CurrentValues.SetValues(property);
                // update property amenities
                if (property.PropertyAmenities != null)
                {
                    var existingAmenities = await context.PropertyAmenities
                        .FirstOrDefaultAsync(pa => pa.PropertyId == property.PropertyId);
                    if (existingAmenities != null)
                    {
                        context.Entry(existingAmenities).CurrentValues.SetValues(property.PropertyAmenities);
                    }
                    else
                        Console.WriteLine("PropertyAmenities not found for PropertyId: " + property.PropertyId);
                }
                // delete marked images
                if (deletedImageIds != null && deletedImageIds.Length > 0)
                {
                    Console.WriteLine("deletedImageIds: " + string.Join(", ", deletedImageIds));
                    var imagesToDelete = await context.Images
                        .Where(i => i.PropertyId == property.PropertyId && deletedImageIds.Contains(i.ImageId))
                        .ToListAsync();

                    context.Images.RemoveRange(imagesToDelete);
                }
                // add new images
                if (newImages != null && newImages.Count > 0)
                {
                    foreach (var imageFile in newImages)
                    {
                        Console.WriteLine("imageFile: " + imageFile.FileName + " " + imageFile.ContentType + " " + imageFile.Length);
                        if (imageFile.Length > 0)
                        {
                            // 读取图片数据
                            using (var memoryStream = new MemoryStream())
                            {
                                await imageFile.CopyToAsync(memoryStream);

                                // 创建新图片记录
                                var image = new Image
                                {
                                    PropertyId = property.PropertyId,
                                    ImageData = memoryStream.ToArray(),
                                    FileName = Path.GetFileName(imageFile.FileName),
                                    ContentType = imageFile.ContentType
                                };

                                context.Images.Add(image);
                            }
                        }
                    }
                }
                // save all changes
                await context.SaveChangesAsync();

                TempData["message"] = $"Property {property.PropertyId} updated successfully.";
                return RedirectToAction("Detail", new { area = "", id = property.PropertyId });
            }
            catch (Exception ex)
            {
                // 记录错误
                ModelState.AddModelError("", $"Error updating property: {ex.Message}");

                // 重新加载视图所需数据
                ViewBag.Action = "Edit";
                ViewBag.PropertyTypes = new string[] { "House", "Apartment", "Condo", "Townhouse", "Basement Suite", "Duplex" };
                ViewBag.Statuses = new string[] { "For Sale", "For Rent", "Sold", "Rented" };

                Console.WriteLine("Error updating property: " + ex.Message);
                return View(property);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Property property, List<IFormFile> newImages)
        {
            if (!ModelState.IsValid)
            {
                // 重新加载必要数据
                ViewBag.Action = "Add";
                ViewBag.PropertyTypes = new string[] { "House", "Apartment", "Condo", "Townhouse", "Basement Suite", "Duplex" };
                ViewBag.Statuses = new string[] { "For Sale", "For Rent", "Sold", "Rented" };

                // 重新加载所有者信息
                property.Owner = await context.Customers.FirstOrDefaultAsync(c => c.Id == property.OwnerCustomerId);

                return View("Edit", property);
            }
            using (var transaction = await context.Database.BeginTransactionAsync())
            {
                try
                {
                    if (property.ListingDate == default)
                        property.ListingDate = DateTime.Now;
                    // keep the date, but set the time to now
                    DateTime selectedDate = property.ListingDate.Date;
                    TimeSpan currentTime = DateTime.Now.TimeOfDay;
                    property.ListingDate = selectedDate.Add(currentTime);

                    // add property and property amenities
                    context.Properties.Add(property);
                    await context.SaveChangesAsync();
                    Console.WriteLine("Property added: " + property.PropertyId);

                    // add new images
                    if (newImages != null && newImages.Count > 0)
                    {
                        foreach (var imageFile in newImages)
                        {
                            if (imageFile.Length > 0)
                            {
                                using (var memoryStream = new MemoryStream())
                                {
                                    await imageFile.CopyToAsync(memoryStream);

                                    var image = new Image
                                    {
                                        PropertyId = property.PropertyId,
                                        ImageData = memoryStream.ToArray(),
                                        FileName = Path.GetFileName(imageFile.FileName),
                                        ContentType = imageFile.ContentType
                                    };

                                    context.Images.Add(image);
                                }
                            }
                        }
                    }

                    // save all changes
                    await context.SaveChangesAsync();

                    await transaction.CommitAsync();

                    TempData["message"] = $"Property added successfully.";
                    return RedirectToAction("Detail", "Property", new { area = "", id = property.PropertyId });
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    Console.WriteLine("transaction rolled back");
                    
                    ModelState.AddModelError("", $"Error adding property: {ex.Message}");

                    ViewBag.Action = "Add";
                    ViewBag.PropertyTypes = new string[] { "House", "Apartment", "Condo", "Townhouse", "Basement Suite", "Duplex" };
                    ViewBag.Statuses = new string[] { "For Sale", "For Rent", "Sold", "Rented" };

                    Console.WriteLine("Error adding property: " + ex.Message);
                    return View("Edit", property);
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, string redirectTo)
        {

            // 查找要删除的 Property
            var property = data.Get(id);

            if (property == null)
            {
                TempData["error"] = "Property not found.";
                if (redirectTo == "Admin")
                    return RedirectToAction("List");
                else
                    return RedirectToPage("/Account/Manage/YourProperties", new { area = "Identity" });
            }

            // 检查当前用户是否是 Property 的所有者，或者是 Admin 权限
            var currentUser = await _userManager.GetUserAsync(User);
            if (property.OwnerCustomerId != currentUser.Id && !User.IsInRole("Admin"))
            {
                return Forbid(); // 返回 403 Forbidden
            }

            using (var transaction = await context.Database.BeginTransactionAsync())
            {
                try
                {
                    // 1. 删除相关的销售记录
                    var salesRecords = await context.SalesRecords
                        .Where(sr => sr.PropertyId == id)
                        .ToListAsync();

                    if (salesRecords.Any())
                    {
                        context.SalesRecords.RemoveRange(salesRecords);
                        await context.SaveChangesAsync();
                        Console.WriteLine($"Deleted {salesRecords.Count} sales records for PropertyId: {id}");
                    }

                    // 2. 删除相关的租赁记录
                    var rentalRecords = await context.RentalRecords
                        .Where(rr => rr.PropertyId == id)
                        .ToListAsync();

                    if (rentalRecords.Any())
                    {
                        context.RentalRecords.RemoveRange(rentalRecords);
                        await context.SaveChangesAsync();
                        Console.WriteLine($"Deleted {rentalRecords.Count} rental records for PropertyId: {id}");
                    }

                    // 3. 删除相关的图片
                    var images = await context.Images
                        .Where(i => i.PropertyId == id)
                        .ToListAsync();

                    if (images.Any())
                    {
                        context.Images.RemoveRange(images);
                        await context.SaveChangesAsync();
                        Console.WriteLine($"Deleted {images.Count} images for PropertyId: {id}");
                    }

                    // 4. 删除相关的 PropertyAmenities
                    var amenities = await context.PropertyAmenities
                        .FirstOrDefaultAsync(pa => pa.PropertyId == id);

                    if (amenities != null)
                    {
                        context.PropertyAmenities.Remove(amenities);
                        await context.SaveChangesAsync();
                        Console.WriteLine($"Deleted amenities for PropertyId: {id}");
                    }

                    // 5. 删除 Property 本身
                    context.Properties.Remove(property);
                    await context.SaveChangesAsync();
                    Console.WriteLine($"Deleted PropertyId: {id}");

                    // 提交事务
                    await transaction.CommitAsync();

                    TempData["message"] = $"Property {id} has been deleted.";
                    if (redirectTo == "Admin")
                        return RedirectToAction("List");
                    else
                        return RedirectToPage("/Account/Manage/YourProperties", new { area = "Identity" });
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    Console.WriteLine($"Error deleting property {id}, transaction rolled back");

                    TempData["error"] = $"Error deleting property: {ex.Message}";
                    if (redirectTo == "Admin")
                        return RedirectToAction("List");
                    else
                        return RedirectToPage("/Account/Manage/YourProperties", new { area = "Identity" });
                }
            }
        }
    }
}