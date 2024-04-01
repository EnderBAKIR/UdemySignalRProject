using SignalRWebUI.Dtos.CategoryDtos;

namespace SignalRWebUI.Services.Interfaces
{
	public interface ICategoryService
	{
		Task<List<ResultCategoryDto>> GetCategoriesListAsync();
		Task<UpdateCategoryDto> GetCategoryByIdAsync(int id);
		Task<HttpResponseMessage> CreateCategoryAsync(CreateCategoryDto createCategoryDto);
		Task<HttpResponseMessage> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task<HttpResponseMessage> DeleteCategoryAsync(int id);
		

	}
}
