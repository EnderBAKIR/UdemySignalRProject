using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SignalRWebUI.Services.Category.Intefaces;
using SignalRWebUI.Services.Product.Dtos;
using SignalRWebUI.Services.Product.Interfaces;

namespace SignalRWebUI.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var productsList = await _productService.GetProductsListAsync();

            return View(productsList);

        }



        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var categoriesList = await _categoryService.GetCategoriesListAsync();
            List<SelectListItem> categorySelectList = (from x in categoriesList
                                                       select new SelectListItem
                                                       {
                                                           Text = x.CategoryName,
                                                           Value = x.CategoryId.ToString()
                                                       }).ToList();
            ViewBag.categoryList = categorySelectList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            HttpResponseMessage response = await _productService.CreateProductAsync(createProductDto);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();



        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            HttpResponseMessage response = await _productService.DeleteProductAsync(id);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }




        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var category = await _productService.GetProductByIdAsync(id);
            TempData["ProductId"] = category.CategoryId; // viewde bu değerleri geçmemek için burada temp data ile aldım
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            var product = await _productService.GetProductByIdAsync(Convert.ToInt32(TempData["ProductId"]));

            updateProductDto.ProductId = product.ProductId;
            updateProductDto.ProductStatus = product.ProductStatus;

            HttpResponseMessage response = await _productService.UpdateProductAsync(updateProductDto);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}

