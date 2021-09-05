using ResourcesManager.Services.ParkingPlaces.Infrastructure.Extensions;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Options;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Services
{
    public class Seeder : ISeeder
    {
        private readonly SeedOptions seedOptions;

        public Seeder(SeedOptions seedOptions)
        {
            this.seedOptions = seedOptions;
        }
        public async Task SeedAsync()
        {
            if (seedOptions.SeedReservationStates)
            {
                foreach (var reservationStateSeed in seedOptions.ReservationStates)
                {
                    try
                    {
                        var reservationState = reservationStateSeed.AsReservationState();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }
    }
}
