using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RealEstateAgencySystem.Models;

namespace RealEstateAgencySystem.Controllers;

public class ImageController : Controller
{
    private AppDbContext context;

    public ImageController(AppDbContext ctx)
    {
        context = ctx;
    }

    public IActionResult Get(int id)
    {
        var image = context.Images.FirstOrDefault(p => p.ImageID == id);
        if (image == null || image.ImageData == null)
            return NotFound();
        Console.WriteLine($"Image found: {image != null}, ContentType: {image?.ContentType}, Size: {image?.ImageData?.Length}");
        Response.Headers.Add("Cache-Control", "public,max-age=86400");

        return File(image.ImageData, image.ContentType);
    }


    // public async void SeedImage()
    // {
    //     // Seed Images (sample images, you would need real image data in a real application)
    //     var random = new Random();
    //     var images = new List<Image>();
    //     for (int i = 1; i <= 60; i++)
    //     {
    //         // Assign each property 3 images
    //         var propertyId = ((i - 1) / 3) + 1;

    //         int sampleImageNum = random.Next(1, 11);

    //         string imagePath = Path.Combine("/Users/sixian/Code/VSCodeProjects/6844_Programming_for_the_Internet/RealEstateAgencySystem/Models/Data", $"sample_image_{sampleImageNum}.jpg");

    //         if (System.IO.File.Exists(imagePath))
    //         {
    //             byte[] imageData = System.IO.File.ReadAllBytes(imagePath);

    //             var image = new Image
    //             {
    //                 ImageID = i,
    //                 PropertyID = propertyId,
    //                 FileName = $"property_{propertyId}_image_{i % 3 + 1}.jpg",
    //                 ContentType = "image/jpeg",
    //                 ImageData = imageData
    //             };
    //             context.Images.Add(image);
    //             await context.SaveChangesAsync();
    //         }
    //         else
    //         {
    //             Console.WriteLine($"Image file not found: {imagePath}");
    //         }
            
    //     }
    // }

}
