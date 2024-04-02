using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.FeatureDto;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var value = _mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());

            return Ok(value);
        }

        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var productsWithCategories = _productService.TGetProductsWithCategories();

            var productListWithCategoryDto = new List<ResultProductWithCategoryDto>();
            foreach (var product in productsWithCategories)
            {
                var resultDto = new ResultProductWithCategoryDto
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    Description = product.Description,
                    Price = product.Price,
                    ImageUrl = product.ImageUrl,
                    ProductStatus = product.ProductStatus,
                    CategoryName = product.Category.CategoryName
                };

                productListWithCategoryDto.Add(resultDto);
            }
            return Ok(productListWithCategoryDto);
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateProductDto createProductDto)
        {
            var createProductMap = _mapper.Map<Product>(createProductDto);
            _productService.TAdd(createProductMap);

            return Ok($"Product Başarılı Bir Şekilde Eklendi Product Id = {createProductMap.ProductId}");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetById(id);
            _productService.TDelete(value);

            return Ok("Product Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var value = _productService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            var updateProductMap = _mapper.Map<Product>(updateProductDto);
            _productService.TUpdate(updateProductMap);
            return Ok("Product başarılı bir şekilde güncellendi");
        }
    }
}
