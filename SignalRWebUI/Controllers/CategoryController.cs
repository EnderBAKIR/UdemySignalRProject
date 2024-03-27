using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.CategoryDtos;
using SignalRWebUI.Services.Interfaces;

namespace SignalRWebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

		public CategoryController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		public async Task<IActionResult> Index()
        {
           var values = await _categoryService.GetCategoriesListAsync();

            return View(values);
            
        }
    }
}
