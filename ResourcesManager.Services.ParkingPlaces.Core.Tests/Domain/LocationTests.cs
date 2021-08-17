using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResourcesManager.Services.ParkingPlaces.Core.Domain;
using ResourcesManager.Services.ParkingPlaces.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourcesManager.Services.ParkingPlaces.Core.Tests.Domain
{
    [TestClass]
    public class LocationTests
    {
        [TestMethod]
        public void CreateLocation_ValidParameters_ShouldCreate()
        {
            var name = new Name("Nobel Tower");
            var address = new Address("Poznań, Dąbrowskiego");
            var location = new Location(name, address);

            location.Id.Should().NotBeEmpty();
            location.Address.Should().NotBeNull();
            location.Name.Should().NotBeNull();
            location.CreatedAt.Should().BeBefore(DateTime.UtcNow);
        }

        [TestMethod]
        //[DataRow(1, 5, 10)]
        public void AddResource_CreateLocationAndResource_ShouldReturnResource()
        {
            var name = new Name("Nobel Tower");
            var address = new Address("Poznań, Dąbrowskiego");
            var location = new Location(name, address);

            var uniqueResourceIdentifier = new UniqueResourceIdentifier("nobel_tower_parking_place");
            var resourceName = new Name("Parking Place");
            var parkingResource = new Resource(uniqueResourceIdentifier, resourceName);

            location.AddResource(parkingResource, 1);

            location.Resources.Count().Should().BeGreaterThan(0);

        }

        [TestMethod]
        public void AddResource_CreateLocationAndAddExistingResource_SholudIncreaseTheValue()
        {
            var name = new Name("Nobel Tower");
            var address = new Address("Poznań, Dąbrowskiego");
            var location = new Location(name, address);

            var uniqueResourceIdentifier = new UniqueResourceIdentifier("nobel_tower_parking_place");
            var resourceName = new Name("Parking Place");
            var parkingResource = new Resource(uniqueResourceIdentifier, resourceName);

            location.AddResource(parkingResource, 1);

            location.AddResource(parkingResource, 1);

            var expectedResourcesCount = 1;
            location.Resources.Count().Should().Be(expectedResourcesCount);

            var expectedResourceQuantity = 2;
            location.Resources.Where(x => x.Key == parkingResource).FirstOrDefault().Value.Should().Be(expectedResourceQuantity);
        }
    }
}
