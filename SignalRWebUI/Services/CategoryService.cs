using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS;
using SignalRWebUI.Dtos.CategoryDtos;
using SignalRWebUI.Services.Interfaces;
using System.Net;

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
		
		public async Task<HttpResponseMessage> CreateCategoryAsync(CreateCategoryDto createCategoryDto)
		{
            createCategoryDto.CategoryStatus = true;
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7247/api/Category", createCategoryDto);

			return response;
           
			
        }
		
		public async Task<HttpResponseMessage> DeleteCategoryAsync(int id)
		{
			var response = await _httpClient.DeleteAsync($"https://localhost:7247/api/Category/{id}");

			return response;
        }

	}
}
