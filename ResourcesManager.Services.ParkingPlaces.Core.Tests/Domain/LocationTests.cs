﻿using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResourcesManager.Services.ParkingPlaces.Core.Domain;
using ResourcesManager.Services.ParkingPlaces.Core.Domain.ValueObjects;
using ResourcesManager.Services.ParkingPlaces.Core.Exceptions;
using System;
using System.Linq;

namespace ResourcesManager.Services.ParkingPlaces.Core.Tests.Domain
{
    [TestClass]
    public class LocationTests : BaseTests
    {
        [TestMethod]
        public void CreateLocation_ValidParameters_ShouldCreate()
        {
            //ACT
            var location = new Location(name, address);

            //ASSERT
            location.Id.Should().NotBeEmpty();
            location.Address.Should().NotBeNull();
            location.Name.Should().NotBeNull();
            location.CreatedAt.Should().BeBefore(DateTime.UtcNow);
            location.UpdatedAt.HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void SetName_ShouldUpdateNameAndSetDate_ReturnedUpdatedDate()
        {
            //ARRANGE
            var location = new Location(name, address);
            var newLocationName = "Apator Powogaz";
            var updatedName = new Name(newLocationName);

            //ACT
            location.SetName(updatedName);

            //ASSERT
            Assert.IsNotNull(location.UpdatedAt);
            location.UpdatedAt.Should().BeAfter(location.CreatedAt);
            location.Name.Value.Should().BeSameAs(newLocationName);
        }

        [TestMethod]
        public void SetAddress_ShouldUpdateAddressAndSetDate_ReturnedUpdatedDate()
        {
            //ARRANGE
            var location = new Location(name, address);
            var newLocationAddress = "Poznań, Janickiego";
            var updatedAddress = new Address(newLocationAddress);

            //ACT
            location.SetAddress(updatedAddress);

            //ASSERT
            Assert.IsNotNull(location.UpdatedAt);
            location.UpdatedAt.Should().BeAfter(location.CreatedAt);
            location.Address.Value.Should().BeSameAs(newLocationAddress);
        }

        [TestMethod]
        public void AddResource_CreateLocationAndResource_ShouldReturnResource()
        {
            //ARRANGE
            var location = new Location(name, address);
            var parkingResource = new Resource(uniqueResourceIdentifier, resourceName);
            var resourceQuantity = new ResourceQuantity(2);

            //ACT
            location.AddOrUpdateResource(parkingResource, resourceQuantity);

            //ASSERT
            location.Resources.Count().Should().BeGreaterThan(0);
            Assert.IsNotNull(location.UpdatedAt);
        }

        [TestMethod]
        public void AddResource_CreateLocationAndAddExistingResource_SholudIncreaseQuantity()
        {
            //ARRANGE
            var location = new Location(name, address);
            var parkingResource = new Resource(uniqueResourceIdentifier, resourceName);
            var resourceQuantity = new ResourceQuantity(2);

            //ACT
            location.AddOrUpdateResource(parkingResource, resourceQuantity);
            location.AddOrUpdateResource(parkingResource, resourceQuantity);

            //ASSERT
            var expectedResourcesCount = 1;
            location.Resources.Count().Should().Be(expectedResourcesCount);

            var expectedResourceQuantity = 2;
            location.Resources.Where(x => x.Resource == parkingResource).FirstOrDefault().ResourceQuantity.Value.Should().Be(expectedResourceQuantity);
        }

        [TestMethod]
        public void AddResource_CreateLocationAndAddNotExistingResource_SholudAdd()
        {
            //ARRANGE
            var location = new Location(name, address);
            var parkingResource = new Resource(uniqueResourceIdentifier, resourceName);
            var resourceQuantity = new ResourceQuantity(1);

            var newUniqueResourceIdentifier = new UniqueResourceIdentifier("nobel_tower_parking_place");
            var newResourceName = new Name("Parking Place");
            var newParkingResource = new Resource(newUniqueResourceIdentifier, newResourceName);

            //ACT
            location.AddOrUpdateResource(parkingResource, resourceQuantity);
            location.AddOrUpdateResource(newParkingResource, resourceQuantity);

            //ASSERT
            var expectedResourcesCount = 2;
            location.Resources.Count().Should().Be(expectedResourcesCount);

            var expectedResourceQuantity = 1;
            location.Resources.Where(x => x.Resource == parkingResource).FirstOrDefault().ResourceQuantity.Value.Should().Be(expectedResourceQuantity);
        }

        [TestMethod]
        public void RemoveResource_AddAndRemoveExistingResource_ShouldSuccess()
        {
            //ARRANGE
            var location = new Location(name, address);
            var parkingResource = new Resource(uniqueResourceIdentifier, resourceName);
            var resourceQuantity = new ResourceQuantity(2);

            //ACT
            location.AddOrUpdateResource(parkingResource, resourceQuantity);
            location.RemoveResource(parkingResource);

            //ASSERT
            var expectedResourcesCount = 0;
            location.Resources.Count().Should().Be(expectedResourcesCount);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        [ExpectedException(typeof(InvalidQuantityValueException))]
        public void AddResource_CreateLocationAndResourceWithIncorrectQuantity_ShouldFailed(int incorrectQuantity)
        {
            //ARRANGE
            var location = new Location(name, address);
            var parkingResource = new Resource(uniqueResourceIdentifier, resourceName);
            var resourceQuantity = new ResourceQuantity(incorrectQuantity);

            //ACT
            location.AddOrUpdateResource(parkingResource, resourceQuantity);

            //ASSERT
            Assert.IsNull(location.Resources);
        }

        [TestMethod]
        [ExpectedException(typeof(NullEntityException<Resource>))]
        public void AddResource_CreateLocationAndAddNullResource_ShouldFailed()
        {
            //ARRANGE
            var location = new Location(name, address);
            Resource parkingResource = null;
            var resourceQuantity = new ResourceQuantity(2);

            //ACT
            location.AddOrUpdateResource(parkingResource, resourceQuantity);

            //ASSERT
            Assert.IsNull(location.Resources);
        }


    }
}
