using System.Collections.Generic;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Options
{
    public class SeedOptions
    {
        public bool SeedReservationStates { get; set; }
        public IEnumerable<ReservationStateSeed> ReservationStates { get; set; }

        public class ReservationStateSeed
        {
            public string name { get; set; }
        }
    }
}
