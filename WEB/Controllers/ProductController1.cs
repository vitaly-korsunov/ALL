using DAL.Repository;
using DAL.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using MODEL.ViewModel;
 

namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        //  private readonly IWebHostEnvironment _hostEnvironment;
        public ProductController(IUnitOfWork unitOfWork)//, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            //  _hostEnvironment = hostEnvironment;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id = null)
        {
            // Product product = new Product();

            ProductVM productVM = new()
            {
                Product = new()
                /*
                ,
                CategoryList = _unitOfWork.Category.GetAll().Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString(),
                }),
                CoverTypeList = _unitOfWork.CoverType.GetAll().Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                })
                */
            };




            if (id == null || id == 0)
            {
                // create product
                //  ViewBag.CategoryList = CategoryList;
                //  ViewData["CoverTypeList"] = CoverTypeList;
                return View(productVM);
            }
            else
            {
                productVM.Product = _unitOfWork.Product.GetFirstOrDefault(c => c.Id == id);
                // update product
                return View(productVM);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ProductVM obj)
        {

            if (ModelState.IsValid)
            {
                if (obj?.Product?.Id == 0)
                {
                    _unitOfWork.Product.Add(obj.Product);
                }
                else
                {
                    _unitOfWork.Product.Update(obj.Product);
                }

                _unitOfWork.Save();
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        #region API CALL
        [HttpGet]
        public IActionResult GetAll()
        {
            var productList = _unitOfWork.Product.GetAll();
            return Json(new { data = productList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Product.GetFirstOrDefault(c => c.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, Message = "Error while deleting" });
            }

            _unitOfWork.Product.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, Message = "Delete Successful" });

        }
        #endregion
    }

}