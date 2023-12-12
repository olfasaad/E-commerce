using E_commerce.Models;
using E_commerce.Models.Repository;
using E_commerce.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {

        private IUnitWork _unitOfWork;
        private readonly ICategoryRepository _categoryRepository; 
        public CategoryController(IUnitWork unitwork, ICategoryRepository categoryRepository)
        {
            this._unitOfWork = unitwork;
            this._categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            CategoryVm categoryVM = new CategoryVm();
            categoryVM.Categories= _unitOfWork.Category.GetAll();
            return View(categoryVM);
        }
        public ActionResult Details(int id)
        {
            var c = _categoryRepository.GetCategory(id);
            return View(c);
        }


        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category p)
        {
             try
            {
                _categoryRepository.Add(p);
                return RedirectToAction("Index", "Category");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it in some way
                Console.WriteLine($"Error in Create action: {ex.Message}");
                return View();
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)

        {
            Category category = _categoryRepository.GetCategory(id);

            // Set ViewBag values
            ViewBag.Categoryid = category.Categoryid;
            ViewBag.Categoryname = category.Categoryname;
            return View();
        }

        // POST: SchoolController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category s)
        {
            try
            {
                _categoryRepository.Update(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var c = _categoryRepository.GetCategory(id);
            return View(c);
                
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id,Category c)
        {
            try
            {
                _categoryRepository.Delete(id);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }



    }

    
}
