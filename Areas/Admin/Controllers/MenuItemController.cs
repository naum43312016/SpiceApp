using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using SpiceApp.Data;
using SpiceApp.Models;
using SpiceApp.Models.ViewModels;
using SpiceApp.Utility;

namespace SpiceApp.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.ManagerUser)]
    [Area("Admin")]
    public class MenuItemController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public MenuItemController(ApplicationDbContext db, IWebHostEnvironment host)
        {
            _db = db;
            _hostingEnvironment = host;
        }
        public IActionResult Index()
        {
            var ItemsList = _db.MenuItem.Include(m => m.Category).Include(m => m.SubCategory).ToList();

            return View(ItemsList);
        }

        //Get - Create
        public IActionResult Create()
        {
            var categoryList = _db.Category.ToList();
            var subCategoryList = _db.SubCategory.Include(m => m.Category).ToList();

            MenuItemAndCategoryViewModel model = new MenuItemAndCategoryViewModel()
            {
                CategoryList = categoryList,
                SubCategoryList = subCategoryList,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MenuItemAndCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var Category = _db.Category.Find(model.MenuItem.CategoryId);
                var SubCategory = _db.SubCategory.Find(model.MenuItem.SubCategoryId);
                MenuItem item = model.MenuItem;
                item.Category = Category;
                item.SubCategory = SubCategory;
                _db.MenuItem.Add(item);
                _db.SaveChanges();

                //Save Image
                string webRootPath = _hostingEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;

                var menuItemFromDB = _db.MenuItem.Find(item.Id);
                if (files.Count > 0)
                {
                    //files has been uploaded
                    var uploads = Path.Combine(webRootPath, "images");//all images wiil be int wwwroot/images
                    var extension = Path.GetExtension(files[0].FileName);

                    using (var fileStream = new FileStream(Path.Combine(uploads, item.Id + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }

                    menuItemFromDB.Image = @"\images\" + item.Id + extension;
                }
                else
                {
                    //No files, use default

                    var uploads = Path.Combine(webRootPath, @"images\" + SD.DefaultFoodImage);
                    System.IO.File.Copy(uploads, webRootPath + @"\images\" + item.Id+".png");
                    menuItemFromDB.Image = @"\images\" + item.Id+".png";
                }

                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                var categoryList = _db.Category.ToList();
                var subCategoryList = _db.SubCategory.Include(m => m.Category).ToList();

                MenuItemAndCategoryViewModel m = new MenuItemAndCategoryViewModel()
                {
                    MenuItem = model.MenuItem,
                    CategoryList = categoryList,
                    SubCategoryList = subCategoryList,
                };

                return View(m);
            }
        }





        //Get - Edit
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var categoryList = _db.Category.ToList();

            MenuItemAndCategoryViewModel model = new MenuItemAndCategoryViewModel()
            {
                CategoryList = categoryList,
            };
            model.MenuItem = _db.MenuItem.Include(m => m.Category).Include(m => m.SubCategory).SingleOrDefault(m => m.Id == id);
            model.SubCategoryList = _db.SubCategory.Where(s => s.CategoryId == model.MenuItem.CategoryId).ToList();

            if (model.MenuItem == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, MenuItemAndCategoryViewModel model)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var Category = _db.Category.Find(model.MenuItem.CategoryId);
                var SubCategory = _db.SubCategory.Find(model.MenuItem.SubCategoryId);
                MenuItem item = model.MenuItem;
                item.Category = Category;
                item.SubCategory = SubCategory;
                /*_db.MenuItem.Add(item);
                _db.SaveChanges();*/

                //Save Image
                string webRootPath = _hostingEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;

                var menuItemFromDB = _db.MenuItem.Find(item.Id);
                if (files.Count > 0)
                {
                    //Delete orig file
                    var imagePath = Path.Combine(webRootPath, menuItemFromDB.Image.TrimStart('\\'));
                    //Delete old image
                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }

                    //upload new image
                    //new images has been uploaded
                    var uploads = Path.Combine(webRootPath, "images");//all images wiil be int wwwroot/images
                    var extension_new = Path.GetExtension(files[0].FileName);

                    using (var fileStream = new FileStream(Path.Combine(uploads, item.Id + extension_new), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }

                    menuItemFromDB.Image = @"\images\" + item.Id + extension_new;
                }

                menuItemFromDB.Name = model.MenuItem.Name;
                menuItemFromDB.Description = model.MenuItem.Description;
                menuItemFromDB.price = model.MenuItem.price;
                menuItemFromDB.CategoryId = model.MenuItem.CategoryId;
                menuItemFromDB.SubCategoryId = model.MenuItem.SubCategoryId;


                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                var categoryList = _db.Category.ToList();
                var subCategoryList = _db.SubCategory.Include(m => m.Category).ToList();

                MenuItemAndCategoryViewModel m = new MenuItemAndCategoryViewModel()
                {
                    MenuItem = model.MenuItem,
                    CategoryList = categoryList,
                    SubCategoryList = subCategoryList,
                };

                return View(m);
            }
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = _db.MenuItem.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            _db.MenuItem.Remove(item);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}