using AutoMapper;
using RetailManager.Data.DTOs;
using RetailManager.Data.Models;
namespace RetailManager.Data.MapProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(p => p.Tags, m => m.MapFrom(s => s.ProductTags.Select(x => x.Tag.TagName)))
                .ForMember(p => p.ReviewStars, m => m.MapFrom(s => s.Reviews.Average(x => x.NumStars)));
        }
    }
}
