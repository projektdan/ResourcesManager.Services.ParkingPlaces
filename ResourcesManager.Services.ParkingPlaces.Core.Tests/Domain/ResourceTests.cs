using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResourcesManager.Services.ParkingPlaces.Core.Domain;
using ResourcesManager.Services.ParkingPlaces.Core.Domain.ValueObjects;
using System;

namespace ResourcesManager.Services.ParkingPlaces.Core.Tests.Domain
{
    [TestClass]
    public class ResourceTests : BaseTests
    {
        [TestMethod]
        public void CreateResource_ValidParameters_ShouldCreate()
        {
            //ARRANGE

            //ACT
            var resource = new Resource(uniqueResourceIdentifier, resourceName);

            //ASSERT
            resource.Id.Should().NotBeEmpty();
            resource.CreatedAt.Should().BeBefore(DateTime.UtcNow);
            resource.UniqueResourceIdentifier.Should().Be(uniqueResourceIdentifier);
            resource.Name.Should().Be(resourceName);
            resource.UpdatedAt.HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void SetUniqueResourceIdentifier_ToExistsResource_ShouldSet()
        {
            //ARRANGE
            var resource = new Resource(uniqueResourceIdentifier, resourceName);
            var newUniqueResourceIdentifier = new UniqueResourceIdentifier("new_resource_identifier");

            //ACT
            resource.SetUniqueResourceIdentifier(newUniqueResourceIdentifier);

            //ASSERT
            resource.UniqueResourceIdentifier.Should().Be(newUniqueResourceIdentifier);
            resource.UpdatedAt.HasValue.Should().BeTrue();
        }

        [TestMethod]
        public void SetName_ToExistsResource_ShouldSet()
        {
            //ARRANGE
            var resource = new Resource(uniqueResourceIdentifier, resourceName);
            var newResourceName = new Name("new resource name");

            //ACT
            resource.SetName(newResourceName);

            //ASSERT
            resource.Name.Should().Be(newResourceName);
            resource.UpdatedAt.HasValue.Should().BeTrue();
        }
    }
}
