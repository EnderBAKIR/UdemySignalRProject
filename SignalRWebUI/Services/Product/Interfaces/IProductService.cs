using SignalRWebUI.Services.Product.Dtos;

namespace SignalRWebUI.Services.Product.Interfaces
{
    public interface IProductService
    {
        Task<HttpResponseMessage> CreateProductAsync(CreateProductDto createProductDto);
        Task<List<ResultProductDto>> GetProductsListAsync();
        Task<GetProductDto> GetProductByIdAsync(int id);
        Task<HttpResponseMessage> UpdateProductAsync(UpdateProductDto updateProductDto);
        Task<HttpResponseMessage> DeleteProductAsync(int id);
    }
}
