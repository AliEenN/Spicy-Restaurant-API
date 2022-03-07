namespace SpicyRestaurant.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubCategoriesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;

        public SubCategoriesController(IUnitOfWork unitOfWork, IMapper mapper, IToastNotification toastNotification)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _toastNotification = toastNotification;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<IndexSubCategoryViewModel>>(await _unitOfWork.SubCategories.GetAllAsync(e => e.Name, new[] { "Category" })));
        }

        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new SubCategoryFormViewModel());
            else
            {
                var result = await _unitOfWork.SubCategories.GetByIdAsync(id);

                if (result == null)
                    return NotFound();

                return View(_mapper.Map<SubCategoryFormViewModel>(result));
            }
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateOrEdit(int id, SubCategoryViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //        return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, nameof(CreateOrEdit), model) });

        //    if (id == 0)
        //    {
        //        if (await _unitOfWork.SubCategories.FindAsync(e => e.Name == model.SubCategory.Name) != null)
        //        {
        //            ModelState.AddModelError("Name", "This Sub Category Is Already Exist!");
        //            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, nameof(CreateOrEdit), model) });
        //        }

        //        await _unitOfWork.SubCategories.AddAsync(_mapper.Map<SubCategory>(model));
        //        _unitOfWork.Complete();
        //    }
        //    else
        //    {
        //        if (await _unitOfWork.SubCategories.FindAsync(e => e.Name == model.SubCategory.Name && e.Id != model.SubCategory.Id) != null)
        //        {
        //            ModelState.AddModelError("Name", "This Sub Category Is Already Exist");
        //            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, nameof(CreateOrEdit), model) });
        //        }

        //        _unitOfWork.SubCategories.Edit(_mapper.Map<SubCategory>(model));
        //        _unitOfWork.Complete();
        //    }

        //    return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _mapper.Map<IEnumerable<SubCategoryViewModel>>(await _unitOfWork.SubCategories.GetAllAsync(e => e.Name))) });
        //}

        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //        return BadRequest();

        //    var category = await _unitOfWork.SubCategories.GetByIdAsync((int)id);

        //    if (category == null)
        //        return NotFound();

        //    _unitOfWork.SubCategories.Delete(category);
        //    _unitOfWork.Complete();

        //    return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _mapper.Map<IEnumerable<SubCategoryViewModel>>(await _unitOfWork.SubCategories.GetAllAsync(e => e.Name))) });
        //}

        public async Task<IActionResult> GetSubCategories(int id)
        {
            var subCategories = await _unitOfWork.SubCategories.GetAllAsync(e => e.CategoryId == id);

            return Json(new SelectList(subCategories, "Id", "Name"));
        }
    }
}
