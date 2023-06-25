using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SpicyRestaurant.DAL.Data;
using SpicyRestaurant.BLL.Models;
using Microsoft.EntityFrameworkCore;
using SpicyRestaurant.BLL.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace SpicyRestaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        protected ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.Categories.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        [Route("Id={Id}")]
        public async Task<IActionResult> GetByIdAsync([Required] byte Id)
        {
            var result = await _context.Categories.FindAsync(Id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}