using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SpiceApp.Data;
using SpiceApp.Models;
using SpiceApp.Models.ViewModels;
using SpiceApp.Utility;

namespace SpiceApp.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.ManagerUser)]
    [Area("Admin")]
    public class SubCategoryController : Controller
    {

        private readonly ApplicationDbContext _db;
        [TempData]
        public string StatusMessage { get; set; }

        public SubCategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        //Get Index
        public IActionResult Index()
        {
            var subCategories = _db.SubCategory.Include(s=>s.Category).ToList();
            return View(subCategories);
        }

        //Get Create
        public IActionResult Create()
        {
            SubCategoryAndCategoryViewModel model = new SubCategoryAndCategoryViewModel()
            {
                CategoryList = _db.Category.ToList(),
                SubCategory = new SubCategory(),
                SubCategoryList = _db.SubCategory.OrderBy(p=>p.Name).Select(p=>p.Name).Distinct().ToList()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SubCategoryAndCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var doesSubCategoryExists = _db.SubCategory.Include(s => s.Category).Where(s => s.Name == model.SubCategory.Name && s.Category.Id == model.SubCategory.CategoryId);
                if(doesSubCategoryExists.Count() > 0)
                {
                    //Error
                    StatusMessage = "Error : Sub Category exists under " +
                        doesSubCategoryExists.First().Category.Name + " category.";
                }
                else
                {
                    _db.SubCategory.Add(model.SubCategory);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            SubCategoryAndCategoryViewModel modelVm = new SubCategoryAndCategoryViewModel()
            {
                CategoryList = _db.Category.ToList(),
                SubCategory = model.SubCategory,
                SubCategoryList = _db.SubCategory.OrderBy(p => p.Name).Select(p => p.Name).ToList(),
                StatusMessage = StatusMessage
            };

            return View(modelVm);
        }


        [ActionName("GetSubCategory")]
        public IActionResult GetSubCategory(int id)
        {
            List<SubCategory> subCategories = new List<SubCategory>();

            subCategories = (from subCategory in _db.SubCategory
                             where subCategory.CategoryId==id
                             select subCategory).ToList();

            return Json(new SelectList(subCategories,"Id","Name"));

        }






        //Edit
        public IActionResult Edit(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }

            var subCategory = _db.SubCategory.SingleOrDefault(m=>m.Id==id);
            if (subCategory == null)
            {
                return NotFound();
            }


            SubCategoryAndCategoryViewModel model = new SubCategoryAndCategoryViewModel()
            {
                CategoryList = _db.Category.ToList(),
                SubCategory = subCategory,
                SubCategoryList = _db.SubCategory.OrderBy(p => p.Name).Select(p => p.Name).Distinct().ToList()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, SubCategoryAndCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var doesSubCategoryExists = _db.SubCategory.Include(s => s.Category).Where(s => s.Name == model.SubCategory.Name && s.Category.Id == model.SubCategory.CategoryId);
                if (doesSubCategoryExists.Count() > 0)
                {
                    //Error
                    StatusMessage = "Error : Sub Category exists under " +
                        doesSubCategoryExists.First().Category.Name + " category.";
                }
                else
                {
                    var subCatFromDb = _db.SubCategory.Find(id);
                    subCatFromDb.Name = model.SubCategory.Name;
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            SubCategoryAndCategoryViewModel modelVm = new SubCategoryAndCategoryViewModel()
            {
                CategoryList = _db.Category.ToList(),
                SubCategory = model.SubCategory,
                SubCategoryList = _db.SubCategory.OrderBy(p => p.Name).Select(p => p.Name).ToList(),
                StatusMessage = StatusMessage
            };

            return View(modelVm);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subCategory = _db.SubCategory.Find(id);
            if (subCategory == null)
            {
                return NotFound();
            }
            _db.SubCategory.Remove(subCategory);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}