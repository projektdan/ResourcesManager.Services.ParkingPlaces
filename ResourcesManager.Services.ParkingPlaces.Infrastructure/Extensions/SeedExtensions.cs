using ResourcesManager.Services.ParkingPlaces.Core.Domain;
using ResourcesManager.Services.ParkingPlaces.Core.Domain.ValueObjects;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Options;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Extensions
{
    public static class SeedExtensions
    {
        public static ReservationState AsReservationState(this SeedOptions.ReservationStateSeed reservationStateSeed)
        {
            //TODO : Create valueobject
            var tempName = reservationStateSeed.name;
            var reservationState = new ReservationState(tempName);

            return reservationState;
        }
    }
}
