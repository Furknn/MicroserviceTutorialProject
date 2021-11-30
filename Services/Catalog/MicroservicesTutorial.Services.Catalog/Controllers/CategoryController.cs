using System.Threading.Tasks;
using MicroservicesTutorial.Services.Catalog.Dtos;
using MicroservicesTutorial.Services.Catalog.Services;
using MicroserviceTutorial.Shared.ControllerBases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MicroservicesTutorial.Services.Catalog.Controllers
{
    [Route("v1/[controller]/[action]")]
    [ApiController]
    public class CategoryController:CustomBaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var response = await _categoryService.GetAllAsync();
            return CreateActionResultInstance(response);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(string categoryId)
        {
            var response = await _categoryService.GetByIdAsync(categoryId);
            return CreateActionResultInstance(response);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            var response = await _categoryService.CreateAsync(categoryDto);
            return CreateActionResultInstance(response);
        }
    }
}