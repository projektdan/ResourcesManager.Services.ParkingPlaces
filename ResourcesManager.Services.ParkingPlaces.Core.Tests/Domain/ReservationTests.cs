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
            var parkingResource = new Resource(uniqueResourceIdentifier, resourceName);
            var resourceQuantity = 5;
            var location = new Location(name, address);
            var todayDateTime = DateTime.Now;
            var tomorrowDateTime = todayDateTime.AddDays(1);

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
        }
    }
}
