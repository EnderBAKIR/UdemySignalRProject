using SignalRWebUI.Dtos.CategoryDtos;
using SignalRWebUI.Services.Interfaces;

namespace SignalRWebUI.Services
{
	public class CategoryService : ICategoryService
	{
		private readonly HttpClient _httpClient;

		public CategoryService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<List<ResultCategoryDto>> GetCategoriesListAsync()
		{
			var response = await _httpClient.GetAsync("https://localhost:7247/api/Category");
			if (response.IsSuccessStatusCode)
			{
				var value = await response.Content.ReadFromJsonAsync<List<ResultCategoryDto>>();

				return value.ToList();
			}
			return null;
		}
			

	}
}
