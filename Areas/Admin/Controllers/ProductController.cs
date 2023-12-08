using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nov30task.Areas.Admin.ViewModels;
using nov30task.Context;
using nov30task.Models;
using System;
using nov30task.ViewModels.BlogVM;
using nov30task.ViewModels.CategoryVM;
using nov30task.ViewModels.ProductVM;
using System.Drawing;

namespace nov30task.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ProductController : Controller
	{

		ApplicationDbContext _db { get; }

		public ProductController(ApplicationDbContext db)
		{
			_db = db;
		}

		public IActionResult Index()
		{
			return View(_db.Products.Select(p => new AdminProductListItemVM {
				Id = p.Id,
				Name = p.Name,
				CostPrice = p.CostPrice,
				SellPrice = p.SellPrice,
				Discount = p.Discount,
				Category = p.Category,
				ImageUrl = p.ImageUrl,
				IsDeleted = p.IsDeleted,
				Quantity = p.Quantity
			}));
		}

		public IActionResult Create()
		{
			ViewBag.Categories = _db.Categories;
			return View();
		}

		[HttpPost]

		public async Task<IActionResult> Create(ProductCreateVM vm)
		{

			if (vm.CostPrice > vm.SellPrice)
			{
				ModelState.AddModelError("SellPrice", "SellPrice > CostPrice olmalidir.");
			}
			if (!ModelState.IsValid)
			{
				ViewBag.Categories = _db.Categories;
				return View(vm);
			}
			if (!await _db.Categories.AnyAsync(c => c.Id == vm.CategoryId))
			{
				ModelState.AddModelError("CategoryId", "Bele kateqoriya yoxdur.");
				ViewBag.Categories = _db.Categories;
				return View(vm);
			}
			var rootpath = Directory.GetCurrentDirectory();
			var imagepath = Path.Combine(rootpath, "wwwroot/prodimages");
			var fileName = Guid.NewGuid().ToString()+vm.formFile.FileName;
			var imageFile = System.IO.File.Create(Path.Combine(imagepath, fileName));

			await  vm.formFile.CopyToAsync(imageFile);
			imageFile.Close();

			Product product = new Product
			{
				Name = vm.Name,
				About = vm.About,
				SellPrice = vm.SellPrice,
				CostPrice = vm.CostPrice,
				Avability = vm.Avability,
				Brand = vm.Brand,
				Quantity = vm.Quantity,
                ImageUrl =fileName,
                Description = vm.Description,
				Discount = vm.Discount,
				

				CategoryId = vm.CategoryId
			};

			await _db.Products.AddAsync(product);
			await _db.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}
		public async Task<IActionResult> Update(int id)
		{
			if (id == null || id <= 0) return BadRequest();
			var data = await _db.Products.FindAsync(id);
			ViewBag.Categories = _db.Categories;
			if (data == null) return NotFound();
			return View(new ProductUpdateVM
			{
				Name = data.Name,
				About = data.About,
				Avability = data.Avability,
				Brand = data.Brand,
				CategoryId = data.CategoryId,
				CostPrice = data.CostPrice,
				Description = data.Description,
				Discount = data.Discount,
				ExTax = data.ExTax,
				ProductCode = data.ProductCode,
				Quantity = data.Quantity,

				RewardPoints = data.RewardPoints,
				SellPrice = data.SellPrice,
			});

		}
		[HttpPost]

		public async Task<IActionResult> Update(int? id, ProductUpdateVM vm)
		{
			TempData["ProductRenovationResponse"] = false;

			if (id == null || id <= 0) return BadRequest();
			if (!ModelState.IsValid)
			{
				return View(vm);
			}
			var data = await _db.Products.FindAsync(id);
			if (data == null) return NotFound();

			data.Name = vm.Name;
			data.About = vm.About;
			data.Avability = vm.Avability;
			data.Brand = vm.Brand;
			data.CostPrice = vm.CostPrice;
			data.Description = vm.Description;
			data.Discount = vm.Discount;
			data.ExTax = vm.ExTax;
			data.ProductCode = (string?)vm.ProductCode;
			data.Quantity = vm.Quantity;
			data.RewardPoints = vm.RewardPoints;

			data.CategoryId = vm.CategoryId;

			TempData["BookRenovationResponse"] = true;
			await _db.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Delete(int? id)
        {
            TempData["BookDeletionResponse"] = false;
            if (id == null) return BadRequest();
            var data = await _db.Products.FindAsync(id);
            if (data == null) return NotFound();
            _db.Products.Remove(data);
            await _db.SaveChangesAsync();
            TempData["BookDeletionResponse"] = true;
            return RedirectToAction(nameof(Index));
        }
        

    }

}