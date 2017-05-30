using Forum.Data;
using Forum.Data.Common;
using Forum.Models;
using Forum.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Forum.Web.Controllers
{
    public class CategoriesController : Controller
    {
        public IRepository<Category> categories;
        public Func<IUnitOfWork> unitOfWork;

        public CategoriesController(
            Func<IUnitOfWork> unitOfWork,
             IRepository<Category> categories)
        {
            this.categories = categories;
            this.unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var categories = this.categories.GetAll();

            var model = categories.Select(x => new CategoryViewModel()
            {
                Name = x.Name
            });

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var model = new CategoryAddViewModel();
            
            model.Categories = this.categories.GetAll().Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.ParentCategoryId.ToString()
            });

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var foundCategory = this.categories.GetAll().SingleOrDefault(x => x.Id == id);

            return this.View(foundCategory);
        }

        [HttpPost]
        public ActionResult Add(CategoryAddViewModel category)
        {
            if (!ModelState.IsValid)
            {
                category.Categories = this.categories.GetAll().Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.ParentCategoryId.ToString()
                });
                return this.View(category);
            }

            var categoryToAdd = new Category()
            {
                Name = category.Name,
                ParentCategoryId = category.ParentCategoryId == null ? null : (int?)int.Parse(category.ParentCategoryId)
            };

            using (var unitOfWork = this.unitOfWork())
            {
                this.categories.Add(categoryToAdd);

                unitOfWork.Commit();
            }

            return this.RedirectToAction("Details/" + categoryToAdd.Id, "Categories");
        }
    }
}