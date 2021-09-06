using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResourcesManager.Services.ParkingPlaces.Core.Domain;
using ResourcesManager.Services.ParkingPlaces.Core.Domain.ValueObjects;
using System;
using System.Linq;

namespace ResourcesManager.Services.ParkingPlaces.Core.Tests.Domain
{
    [TestClass]
    public class ReservationTests : BaseTests
    {
        [TestMethod]
        public void CreateReservation_WithStringReservationStateAndValidParameters_ShouldCreate()
        {
            //ARRANGE
            var newReservationStateValue = "New";
            var newReservationState = new ReservationState(newReservationStateValue);
            //ACT
            var reservation = new Reservation(user, parkingResource, resourceQuantity, location, todayDateTime, tomorrowDateTime);

            //ASSERT
            reservation.Id.Should().NotBeEmpty();
            reservation.User.Should().NotBeNull();
            reservation.Resource.Should().NotBeNull();
            reservation.ResourceQuantity.Should().Be(resourceQuantity);
            reservation.Location.Should().NotBeNull();
            reservation.CreatedAt.Should().BeBefore(DateTime.UtcNow);
            reservation.State.Should().Equals(newReservationState);
            reservation.BeginDate.HasValue.Should().BeTrue();
            reservation.EndDate.Should().BeAfter(reservation.BeginDate.Value);
            reservation.EndDate.HasValue.Should().BeTrue();
            reservation.UpdatedAt.HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void CreateReservation_WithRecordReservationStateAndValidParameters_ShouldCreate()
        {
            //ARRANGE
            var newReservationStateValue = "New";
            var reservationStateName = new Name(newReservationStateValue);
            var newReservationState = new ReservationState(reservationStateName);
            //ACT
            var reservation = new Reservation(user, parkingResource, resourceQuantity, location, todayDateTime, tomorrowDateTime);

            //ASSERT
            reservation.Id.Should().NotBeEmpty();
            reservation.User.Should().NotBeNull();
            reservation.Resource.Should().NotBeNull();
            reservation.ResourceQuantity.Should().Be(resourceQuantity);
            reservation.Location.Should().NotBeNull();
            reservation.CreatedAt.Should().BeBefore(DateTime.UtcNow);
            reservation.State.Should().Equals(newReservationState);
            reservation.BeginDate.HasValue.Should().BeTrue();
            reservation.EndDate.Should().BeAfter(reservation.BeginDate.Value);
            reservation.EndDate.HasValue.Should().BeTrue();
            reservation.UpdatedAt.HasValue.Should().BeFalse();
        }

        [TestMethod]
        public void SetUser_CreateNewUserAndSet_ShouldCreate()
        {
            //ARRANGE
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
        public void SetResource_SetNewResourceToExistsReservation_ShouldSet()
        {
            //ARRANGE
            this.uniqueResourceIdentifier = new UniqueResourceIdentifier("new_parking_place");
            var newResource = new Resource(uniqueResourceIdentifier, resourceName);
            var reservation = new Reservation(user, parkingResource, resourceQuantity, location, todayDateTime, tomorrowDateTime);

            //ACT
            reservation.SetResource(newResource);

            //ASSERT
            reservation.Resource.Should().Be(newResource);
            reservation.UpdatedAt.HasValue.Should().BeTrue();
        }

        [TestMethod]
        public void SetQuantity_SetNewQuantityToExistsReservation_ShouldSet()
        {
            //ARRANGE
            var reservation = new Reservation(user, parkingResource, resourceQuantity, location, todayDateTime, tomorrowDateTime);
            var newResourceQuantity = 10;

            //ACT
            reservation.SetQuantity(newResourceQuantity);

            //ASSERT
            reservation.ResourceQuantity.Should().Be(newResourceQuantity);
            reservation.UpdatedAt.HasValue.Should().BeTrue();
        }

        [TestMethod]
        public void SetLocation_SetNewLocationToExistsReservation_ShouldSet()
        {
            //ARRANGE
            var reservation = new Reservation(user, parkingResource, resourceQuantity, location, todayDateTime, tomorrowDateTime);
            var newLocationName = new Name("Location 2");
            var newLocationAddress = new Address("Poznań, new location address");
            var newLocation = new Location(newLocationName, newLocationAddress);

            //ACT
            reservation.SetLocation(newLocation);

            //ASSERT
            reservation.Location.Should().Be(newLocation);
            reservation.UpdatedAt.HasValue.Should().BeTrue();
        }
        //TODO : Change enum to class
        [TestMethod]
        public void SetState_SetNewStateToExistsReservation_ShouldSet()
        {
            //ARRANGE
            var reservation = new Reservation(user, parkingResource, resourceQuantity, location, todayDateTime, tomorrowDateTime);

            //ACT
            var newReservationState = new ReservationState("Completed");
            reservation.SetState(newReservationState);

            //ASSERT
            reservation.State.Should().Be(newReservationState);
            reservation.UpdatedAt.HasValue.Should().BeTrue();
        }

        [TestMethod]
        public void SetBeginDate_SetNewBeginDateToExistsReservation_ShouldSet()
        {
            //ARRANGE
            var reservation = new Reservation(user, parkingResource, resourceQuantity, location, todayDateTime, tomorrowDateTime);

            //ACT
            var newReservationBeginDate = tomorrowDateTime;
            reservation.SetBeginDate(newReservationBeginDate);

            //ASSERT
            reservation.BeginDate.Should().Be(newReservationBeginDate);
            reservation.UpdatedAt.HasValue.Should().BeTrue();
        }

        [TestMethod]
        public void SetEndDate_SetNewEndDateToExistsReservation_ShouldSet()
        {
            //ARRANGE
            var reservation = new Reservation(user, parkingResource, resourceQuantity, location, todayDateTime, tomorrowDateTime);

            //ACT
            var newReservationEndDate = DateTime.Now.AddDays(3);
            reservation.SetEndDate(newReservationEndDate);

            //ASSERT
            reservation.EndDate.Should().Be(newReservationEndDate);
            reservation.UpdatedAt.HasValue.Should().BeTrue();
        }
    }
}
