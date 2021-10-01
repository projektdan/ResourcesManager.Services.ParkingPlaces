using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResourcesManager.Services.ParkingPlaces.Core.Domain;
using ResourcesManager.Services.ParkingPlaces.Core.Domain.ValueObjects;
using System;

namespace ResourcesManager.Services.ParkingPlaces.Core.Tests.Domain
{
    [TestClass]
    public class LocationResourceTests : BaseTests
    {
        [TestMethod]
        public void CreateLocationResource_ValidParameters_ShouldCreate()
        {
            //ARRANGE
            var quantity = new ResourceQuantity(2);
            //ACT
            var locationResource = new LocationResource(location, parkingResource, quantity);
            //ASSERT
            locationResource.Id.Should().NotBeEmpty();
            locationResource.CreatedAt.Should().BeBefore(DateTime.UtcNow);
            locationResource.Resource.Should().NotBeNull();
            locationResource.Location.Should().NotBeNull();
            locationResource.UpdatedAt.HasValue.Should().BeFalse();

        }
    }
}
