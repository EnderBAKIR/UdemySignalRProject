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

        public async Task<IActionResult> Index()
        {
           var values = await _categoryService.GetCategoriesListAsync();

            return View(values);
            
        }
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {

            var response = await _httpClient.PostAsJsonAsync("https://localhost:7247/api/Category", createCategoryDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();

        }
    }
}
