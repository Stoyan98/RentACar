using AutoMapper;
using RentACar.Data.Models;
using RentACar.Models.Cars;
using RentACar.Services.Cars.Models;
using RentACar.Services.Comments.Models;
using RentACar.Services.Rents.Models;

namespace RentACar.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Category, CarCategoryServiceModel>();

            this.CreateMap<Car, LatestCarServiceModel>();
            this.CreateMap<CarDetailsServiceModel, CarFormModel>();
            this.CreateMap<Comment, CommentServiceModel>();
            this.CreateMap<Rent, RentServiceModel>();

            this.CreateMap<Car, CarServiceModel>()
                .ForMember(c => c.CategoryName, cfg => cfg.MapFrom(c => c.Category.Name));

            this.CreateMap<Car, CarDetailsServiceModel>()
                .ForMember(c => c.UserId, cfg => cfg.MapFrom(c => c.Dealer.UserId))
                .ForMember(c => c.CategoryName, cfg => cfg.MapFrom(c => c.Category.Name));
        }
    }
}
