using MyTested.AspNetCore.Mvc;
using RentACar.Controllers;
using System;
using Xunit;
using RentACar.Models.Rents;

namespace RentACar.Test.Controllers
{
    using static WebConstants;

    public class RentsControllerTest
    {
        [Fact]
        public void GetNewRentShouldBeForAuthorizedUsersAndReturnView()
            => MyController<RentsController>
                .Instance()
                .Calling(c => c.NewRent(1))
                .ShouldHave()
                .ActionAttributes(attributes => attributes
                    .RestrictingForAuthorizedRequests())
                .AndAlso()
                .ShouldReturn()
                .View();

        //[Theory]
        //[InlineData(1, "FirstName", "LastName", "2021-8-24", "2021-8-26", "+359888888888")]
        //public void PostNewRentShouldBeForAuthorizedUsersAndReturnRedirectWithValidModel(
        //    int carId,
        //    string firstName,
        //    string lastName,
        //    DateTime startDate,
        //    DateTime endDate,
        //    string phoneNumber)
        //{
        //    MyController<RentsController>
        //                   .Instance(c => c.WithUser())
        //                   .Calling(c => c.NewRent(new RentFormModel
        //                   {
        //                       CarId = carId,
        //                       FirstName = firstName,
        //                       LastName = lastName,
        //                       StartDate = startDate,
        //                       EndDate = endDate,
        //                       PhoneNumber = phoneNumber
        //                   }))
        //                   .ShouldHave()
        //                   .ActionAttributes(a => a
        //                       .RestrictingForHttpMethod(HttpMethod.Post)
        //                       .RestrictingForAuthorizedRequests())
        //                   .TempData(t => t.ContainingEntryWithKey(GlobalMessageKey))
        //                   .AndAlso()
        //                   .ShouldReturn()
        //                   .Redirect(redirect => redirect
        //                       .To<HomeController>(c => c.Index()));
        //}
    }
}
