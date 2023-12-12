using System.Net.NetworkInformation;
using E_commerce.Models;
using E_commerce.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_commerce.Models.ViewModels;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.AspNetCore.Authorization;
namespace E_commerce.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        //   private UnitOfwork unitOfwork;
        private IProductRepository productRepository;
        private ICategoryRepository categoryRepository;
        private readonly IWebHostEnvironment hostingEnvironment;
        public ProductController(IProductRepository productRepository, IWebHostEnvironment hostingEnvironment)
        {
            //  this.unitOfwork = unitOfwork;
            this.productRepository = productRepository;
            this.hostingEnvironment = hostingEnvironment;
        }
        
        public IActionResult Index()
        {
            var v = productRepository.GetAllProducts();

            return View(v);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductVm model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                // If the Photo property on the incoming model object is not null, then the user has selected an image to upload.
                if (model.photo != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");

                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    model.photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                Product newPro = new Product
                {
                    productname = model.productname,
                    productDescription = model.productDescription,
                    price = model.price,
                    categoryid = model.categoryid,
                    photo = uniqueFileName
                };
                productRepository.AddProduct(newPro);
                return RedirectToAction("details", new { id = newPro.productid });
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Product pro = productRepository.GetProduct(id);
            EditViewModel prodEditViewModel = new EditViewModel
            {
                productid = pro.productid,
                productname = pro.productname,
                price = pro.price,
                categoryid = pro.categoryid,
                ExistingPhotoPath = pro.photo,
            };
            return View(prodEditViewModel);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditViewModel model)
        {
            if (ModelState.IsValid)
            {

                Product pro = productRepository.GetProduct(model.productid);

                pro.productname = model.productname;
                pro.price = model.price;
                pro.productDescription = model.productDescription;
                pro.categoryid = model.categoryid;

                if (model.photo != null)
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath, "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }

                    pro.photo = ProcessUploadedFile(model);
                }
            
            Product updatepro = productRepository.Update(pro);
            if (updatepro != null)
                return RedirectToAction(nameof(Index));
            else
                return NotFound();
        }
          return View(model);
        }
    [NonAction]
    private string ProcessUploadedFile(EditViewModel model)
    {
        string uniqueFileName = null;
        if (model.photo != null)
        {
            string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
            uniqueFileName = Guid.NewGuid().ToString() + "_" + model.photo.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                model.photo.CopyTo(fileStream);
            }
        }
        return uniqueFileName;
    }





    [HttpGet]
        public IActionResult Details(int id) {
            var c=productRepository.GetProduct(id);
            return View(c);
        }
        [HttpGet]
        public ActionResult Delete(int id,Product p)
        {
            var c = productRepository.GetProduct(id);
            return View(c);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            try
            {
                productRepository.Delete(id);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult CreateVm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateVm(ProductVm vm)
        {
            string filename = vm.photo.FileName;

            return View();
        }
    }
}
