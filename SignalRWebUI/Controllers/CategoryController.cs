using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.CategoryDtos;
using SignalRWebUI.Services.Interfaces;

namespace SignalRWebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly HttpClient _httpClient;

        public CategoryController(ICategoryService categoryService, HttpClient httpClient)
        {
            _categoryService = categoryService;
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
           var categoryList = await _categoryService.GetCategoriesListAsync();

            return View(categoryList);
            
        }



        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
          HttpResponseMessage response = await _categoryService.CreateCategoryAsync(createCategoryDto);

			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction(nameof(Index));
			}
			return View();



		}

        public async Task<IActionResult> DeleteCategory(int id)
        {
            HttpResponseMessage response =await _categoryService.DeleteCategoryAsync(id);

            if (response.IsSuccessStatusCode)
            {
				return RedirectToAction(nameof(Index));
			}
            return View();
        }




        [HttpGet]
		public async Task<IActionResult> UpdateCategory(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            TempData["CategoryId"] = category.CategoryId; // viewde bu değerleri geçmemek için burda temp data ile aldım
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var category = await _categoryService.GetCategoryByIdAsync(Convert.ToInt32( TempData["CategoryId"]));
            updateCategoryDto.CategoryId = category.CategoryId;
            updateCategoryDto.CategoryStatus = category.CategoryStatus;
            HttpResponseMessage response = await _categoryService.UpdateCategoryAsync(updateCategoryDto);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }



    }
}
