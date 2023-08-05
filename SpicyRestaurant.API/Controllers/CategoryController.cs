using Microsoft.AspNetCore.Mvc;
using SpicyRestaurant.BLL.DTOs;
using SpicyRestaurant.BLL.ViewModels;
using SpicyRestaurant.BLL.Data.Entities;
using SpicyRestaurant.BLL.DTOs.Category;
using SpicyRestaurant.BLL.Data.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace SpicyRestaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public IUnitOfWork unitOfWork { get; set; }

        public CategoryController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await unitOfWork.Categories.GetAllAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddCategoryDTO category)
        {
            await unitOfWork.Categories.AddAsync(new Category { Name = category.Name });
            unitOfWork.Complete();
            return Ok();
        }

        [HttpGet]
        [Route("Id={Id}")]
        public async Task<IActionResult> GetByIdAsync([Required] string Id)
        {
            var result = await unitOfWork.Categories.FindAsync(e => e.Id == Id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateAsync(EditCategoryDTO category)
        {
            unitOfWork.Categories.Update(new Category { Id = category.Id, Name = category.Name });
            unitOfWork.Complete();
            return Ok();
        }

        [HttpPost]
        [Route("UpdateStatus")]
        public IActionResult UpdateStatusAsync(UpdateStatusDTO updateCategoryStatus)
        {
            unitOfWork.Categories.UpdateStatus(new Category { Id = updateCategoryStatus.Id, Active = updateCategoryStatus.Active });
            unitOfWork.Complete();
            return Ok();
        }
    }
}