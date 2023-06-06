using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SpicyRestaurant.BLL.Interfaces;
using SpicyRestaurant.BLL.ViewModels;

namespace SpicyRestaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var query = await _unitOfWork.Categories.GetAllAsync(e => e.Name);
            return Ok(_mapper.Map<IEnumerable<CategoryViewModel>>(query));
        }
    }
}