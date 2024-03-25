using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categorService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categorService, IMapper mapper)
        {
            _categorService = categorService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult CategoryList()
        {
            var value = _mapper.Map<List<ResultCategoryDto>>(_categorService.TGetListAll());

            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var createCategoryMap = _mapper.Map<Category>(createCategoryDto);
            _categorService.TAdd(createCategoryMap);

            return Ok($"Kategori Başarılı Bir Şekilde Eklendi Kategori Id = {createCategoryMap.CategoryId}");
        }
        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var value = _categorService.TGetById(id);
            _categorService.TDelete(value);

            return Ok("Kategori Silindi");
        }
        [HttpGet("GetCategory")]
        public IActionResult GetCategory(int id)
        {
            var value = _categorService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var updateCategoryMap = _mapper.Map<Category>(updateCategoryDto);
            _categorService.TUpdate(updateCategoryMap);
            return Ok("Kategori başarılı bir şekilde güncellendi");
        }
    }
}
