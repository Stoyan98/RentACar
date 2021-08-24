using MyTested.AspNetCore.Mvc;
using RentACar.Controllers;
using RentACar.Services.Cars.Models;
using System;
using System.Collections.Generic;
using Xunit;
using FluentAssertions;

namespace RentACar.Test.Controllers
{
    using static Data.Cars;
    using static WebConstants.Cache;

    public class HomeControllerTest
    {
        public object TenPublicCars { get; private set; }

        [Fact]
        public void IndexShouldReturnCorrectViewWithModel()
            => MyController<HomeController>
                .Instance(controller => controller
                    .WithData(ThreePublicCars))
                .Calling(c => c.Index())
                .ShouldHave()
                .MemoryCache(cache => cache
                    .ContainingEntry(entry => entry
                        .WithKey(LatestCarsCacheKey)
                        .WithAbsoluteExpirationRelativeToNow(TimeSpan.FromMinutes(15))
                        .WithValueOfType<List<LatestCarServiceModel>>()))
                .AndAlso()
                .ShouldReturn()
                .View(view => view
                    .WithModelOfType<List<LatestCarServiceModel>>()
                    .Passing(model => model.Should().HaveCount(3)));

        [Fact]
        public void ErrorShouldReturnView()
            => MyController<HomeController>
                .Instance()
                .Calling(c => c.Error())
                .ShouldReturn()
                .View();
    }
}
