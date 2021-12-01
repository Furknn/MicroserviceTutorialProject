using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicesTutorial.Services.Catalog.Dtos;
using MicroservicesTutorial.Services.Catalog.Models;
using MicroservicesTutorial.Shared.Dtos;

namespace MicroservicesTutorial.Services.Catalog.Services
{
    public interface ICategoryService
    {
        public Task<Response<List<CategoryDto>>> GetAllAsync();
        public Task<Response<CategoryDto>> CreateAsync(CategoryDto category);
        public Task<Response<CategoryDto>> GetByIdAsync(string categoryId);

    }
}