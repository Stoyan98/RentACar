using MyTested.AspNetCore.Mvc;
using RentACar.Controllers;
using RentACar.Data.Models;
using RentACar.Models.Cars;
using RentACar.Models.Dealers;
using System.Linq;
using Xunit;

namespace RentACar.Test.Controllers
{
    using static WebConstants;

    public class DealersControllerTest
    {
        [Fact]
        public void GetBecomeShouldBeForAuthorizedUsersAndReturnView()
            => MyController<DealersController>
                .Instance()
                .Calling(c => c.Become())
                .ShouldHave()
                .ActionAttributes(attributes => attributes
                    .RestrictingForAuthorizedRequests())
                .AndAlso()
                .ShouldReturn()
                .View();

        [Theory]
        [InlineData("DealerTest", "+359888888888")]
        public void PostBecomeShouldBeForAuthorizedUsersAndReturnRedirectWithValidModel(
            string dealerName,
            string phoneNumber)
            => MyController<DealersController>
                .Instance(controller => controller
                    .WithUser())
                .Calling(c => c.Become(new DealerFormModel
                {
                    Name = dealerName,
                    PhoneNumber = phoneNumber
                }))
                .ShouldHave()
                .ActionAttributes(attributes => attributes
                    .RestrictingForHttpMethod(HttpMethod.Post)
                    .RestrictingForAuthorizedRequests())
                .ValidModelState()
                .Data(data => data
                    .WithSet<Dealer>(dealers => dealers
                        .Any(d =>
                            d.Name == dealerName &&
                            d.PhoneNumber == phoneNumber &&
                            d.UserId == TestUser.Identifier)))
                .TempData(tempData => tempData
                    .ContainingEntryWithKey(GlobalMessageKey))
                .AndAlso()
                .ShouldReturn()
                .Redirect(redirect => redirect
                    .To<CarsController>(c => c.All(With.Any<AllCarsQueryModel>())));
    }
}
