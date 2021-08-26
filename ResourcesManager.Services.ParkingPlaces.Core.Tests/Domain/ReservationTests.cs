using FluentAssertions;
using Microsoft.AspNetCore.Identity;
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
    public class ReservationTests : BaseTests
    {
        [TestMethod]
        public void CreateReservation_ValidParameters_ShouldCreate()
        {
            //ARRANGE
            //var parkingResource = new Resource(uniqueResourceIdentifier, resourceName);
            var resourceQuantity = 5;
            //var location = new Location(name, address);
            //var todayDateTime = DateTime.Now;
            //var tomorrowDateTime = todayDateTime.AddDays(1);
            
            //ACT
            var reservation = new Reservation(user, parkingResource, resourceQuantity, location, todayDateTime, tomorrowDateTime);

            //ASSERT
            reservation.Id.Should().NotBeEmpty();
            reservation.User.Should().NotBeNull();
            reservation.Resource.Should().NotBeNull();
            reservation.ResourceQuantity.Should().Be(resourceQuantity);
            reservation.Location.Should().NotBeNull();
            reservation.CreatedAt.Should().BeBefore(DateTime.UtcNow);
            reservation.State.Should().Be(ReservationState.New);
            reservation.BeginDate.HasValue.Should().BeTrue();
            reservation.EndDate.Should().BeAfter(reservation.BeginDate.Value);
            reservation.EndDate.HasValue.Should().BeTrue();
            reservation.UpdatedAt.HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void SetUser_CreateNewUserAndSet_ShouldCreate()
        {
            //ARRANGE
            //var parkingResource = new Resource(uniqueResourceIdentifier, resourceName);
            var resourceQuantity = 5;
            //var location = new Location(name, address);
            //var todayDateTime = DateTime.Now;
            //var tomorrowDateTime = todayDateTime.AddDays(1);
            this.username = new Username("jankowalski2");
            var newUser = new User(email, username, password, passwordHasher, firstname, lastname);

            //ACT
            var reservation = new Reservation(user, parkingResource, resourceQuantity, location, todayDateTime, tomorrowDateTime);
            reservation.SetUser(newUser);

            //ASSERT
            reservation.User.Should().Be(newUser);
            reservation.UpdatedAt.HasValue.Should().BeTrue();
        }

        [TestMethod]
        public void SetResource_CreateNewResource_ShouldCreate()
        {
            //ARRANGE
            var resourceQuantity = 5;
            this.uniqueResourceIdentifier = new UniqueResourceIdentifier("new_parking_place");
            var newResource = new Resource(uniqueResourceIdentifier, resourceName);

            //ACT
            var reservation = new Reservation(user, parkingResource, resourceQuantity, location, todayDateTime, tomorrowDateTime);
            reservation.SetResource(newResource);

            //ASSERT
            reservation.Resource.Should().Be(newResource);
            reservation.UpdatedAt.HasValue.Should().BeTrue();
        }
    }
}
