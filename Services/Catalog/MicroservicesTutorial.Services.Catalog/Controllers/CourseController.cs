using System.Threading.Tasks;
using MicroservicesTutorial.Services.Catalog.Dtos;
using MicroservicesTutorial.Services.Catalog.Services;
using MicroservicesTutorial.Shared.ControllerBases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MicroservicesTutorial.Services.Catalog.Controllers
{
    [Route("v1/[controller]/[action]")]
    [ApiController]
    public class CourseController : CustomBaseController
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var response = await _courseService.GetAllAsync();
            return CreateActionResultInstance(response);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(string courseId)
        {
            var response = await _courseService.GetByIdAsync(courseId);
            return CreateActionResultInstance(response);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetByUserId(string userId)
        {
            var response = await _courseService.GetAllByUserIdAsync(userId);
            return CreateActionResultInstance(response);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create(CourseCreateDto createDto)
        {
            var response = await _courseService.CreateAsync(createDto);
            return CreateActionResultInstance(response);
        }

        [HttpPut]
        [AllowAnonymous]
        public async Task<IActionResult> Update(CourseUpdateDto updateDto)
        {
            var response = await _courseService.UpdateAsync(updateDto);
            return CreateActionResultInstance(response);
        }

        [HttpDelete]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(string courseId)
        {
            var response = await _courseService.DeleteAsync(courseId);
            return CreateActionResultInstance(response);
        }
    }
}