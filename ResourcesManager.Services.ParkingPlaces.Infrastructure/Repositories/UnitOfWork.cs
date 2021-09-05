﻿using ResourcesManager.Services.ParkingPlaces.Core.Repositories;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Database;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        internal readonly AppDbContext context;

        private ILocationRepository locations;
        public ILocationRepository Locations
        {
            get
            {
                locations ??= new LocationRepository(context);
                return locations;
            }
        }

        private IReservationRepository reservations;
        public IReservationRepository Reservations
        {
            get
            {
                reservations ??= new ReservationRepository(context);
                return reservations;
            }
        }

        private IResourceRepository resources;
        public IResourceRepository Resources
        {
            get
            {
                resources ??= new ResourceRepository(context);
                return resources;
            }
        }

        private IUserRepository users;
        public IUserRepository Users
        {
            get
            {
                users ??= new UserRepository(context);
                return users;
            }
        }

        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
        }

        public async Task CompleteAsync()
            => await this.context.SaveChangesAsync();

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}