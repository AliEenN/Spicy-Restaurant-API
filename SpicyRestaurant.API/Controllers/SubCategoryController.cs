using Microsoft.AspNetCore.Mvc;
using SpicyRestaurant.BLL.Data.Entities;
using SpicyRestaurant.BLL.Data.Interfaces;
using SpicyRestaurant.BLL.DTOs.SubCategory;
using System.ComponentModel.DataAnnotations;

namespace SpicyRestaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        public IUnitOfWork unitOfWork { get; set; }

        public SubCategoryController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await unitOfWork.SubCategories.GetAllAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddSubCategoryDTO subCategory)
        {
            await unitOfWork.SubCategories.AddAsync(new SubCategory { Name = subCategory.Name, CategoryId = subCategory.SubCategoryId });
            return Ok();
        }

        [HttpGet]
        [Route("Id={Id}")]
        public async Task<IActionResult> GetByIdAsync([Required] string Id)
        {
            var result = await unitOfWork.SubCategories.FindAsync(e => e.Id == Id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateAsync(EditSubCategoryDTO subCategory)
        {
            unitOfWork.SubCategories.Update(new SubCategory { Id = subCategory.Id, Name = subCategory.Name, CategoryId = subCategory.CategoryId });
            return Ok();
        }
    }
}