using Microsoft.AspNetCore.Identity;
using ResourcesManager.Services.ParkingPlaces.Core.Domain;
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
        private readonly IUnitOfWorkFactory unitOfWorkFactory;
        //private readonly IPasswordHasher<User> passwordHasher;

        public Seeder(SeedOptions seedOptions, IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.seedOptions = seedOptions;
            this.unitOfWorkFactory = unitOfWorkFactory;
            //this.passwordHasher = passwordHasher;
        }
        public async Task SeedAsync()
        {
            var uow = this.unitOfWorkFactory.Create();

            if (seedOptions.SeedReservationStates)
            {
                foreach (var reservationStateSeed in seedOptions.ReservationStates)
                {
                    try
                    {
                        var reservationState = reservationStateSeed.AsReservationState();
                        await uow.ReservationStates.AddAsync(reservationState);
                        await uow.CompleteAsync();
                    }
                    catch (Exception ex)
                    {
                        //TODO : Implement logger
                        Console.WriteLine(ex);
                    }
                }
            }
        }
    }
}
