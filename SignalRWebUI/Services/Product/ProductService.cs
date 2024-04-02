using SignalRWebUI.Services.Product.Dtos;
using SignalRWebUI.Services.Product.Interfaces;

namespace SignalRWebUI.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<HttpResponseMessage> CreateProductAsync(CreateProductDto createProductDto)
        {
            createProductDto.ProductStatus = true;
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7247/api/Product", createProductDto);

            return response;
        }


        public async Task<List<ResultProductDto>> GetProductsListAsync()
        {
            var response = await _httpClient.GetAsync("https://localhost:7247/api/Product/ProductListWithCategory");
            if (response.IsSuccessStatusCode)
            {
                var values = await response.Content.ReadFromJsonAsync<List<ResultProductDto>>();

                return values.ToList();
            }
            return null;
        }


        public async Task<GetProductDto> GetProductByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7247/api/Product/{id}");

            if (response.IsSuccessStatusCode)
            {
                var value = await response.Content.ReadFromJsonAsync<GetProductDto>();

                return value;
            }
            return null;
        }

        public async Task<HttpResponseMessage> UpdateProductAsync(UpdateProductDto updateProductDto)
        {

            var response = await _httpClient.PutAsJsonAsync("https://localhost:7247/api/Product", updateProductDto);

            return response;
        }


        public async Task<HttpResponseMessage> DeleteProductAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7247/api/Product/{id}");

            return response;
        }
    }
}
