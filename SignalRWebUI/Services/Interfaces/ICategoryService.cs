using SignalRWebUI.Dtos.CategoryDtos;

namespace SignalRWebUI.Services.Interfaces
{
	public interface ICategoryService
	{
		Task<List<ResultCategoryDto>> GetCategoriesListAsync();
		Task<HttpResponseMessage> CreateCategoryAsync(CreateCategoryDto createCategoryDto);
		Task<HttpResponseMessage> DeleteCategoryAsync(int id);
    }
}
