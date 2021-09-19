using ResourcesManager.Services.ParkingPlaces.Core.Domain;
using ResourcesManager.Services.ParkingPlaces.Core.Domain.ValueObjects;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Options;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Extensions
{
    public static class SeedExtensions
    {
        public static ReservationState AsReservationState(this SeedOptions.ReservationStateSeed reservationStateSeed)
        {
            var name = new Name(reservationStateSeed.name);
            var reservationState = new ReservationState(name);

            return reservationState;
        }
    }
}
