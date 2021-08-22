using RentACar.Models.Comments;
using RentACar.Services.Cars.Models;

namespace RentACar.Models.Cars
{
    public class DetailsModel
    {
        public CarDetailsServiceModel CarDetailModel { get; set; }

        public CommentsModel Comments { get; set; }
    }
}
