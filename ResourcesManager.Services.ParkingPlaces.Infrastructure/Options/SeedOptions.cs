using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
