namespace SpicyRestaurant.UI.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category, CategoryViewModel>()
                .ReverseMap();

            CreateMap<SubCategory, IndexSubCategoryViewModel>()
                .ReverseMap();

            CreateMap<SubCategory, SubCategoryFormViewModel>()
                .ReverseMap();
        }
    }
}
