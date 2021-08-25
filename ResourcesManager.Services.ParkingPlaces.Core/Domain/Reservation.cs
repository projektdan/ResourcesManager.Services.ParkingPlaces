using ResourcesManager.Services.ParkingPlaces.Core.Exceptions;
using System;

namespace ResourcesManager.Services.ParkingPlaces.Core.Domain
{
    public class Reservation : DatabaseEntityBase
    {
        public Guid Id { get; private set; }
        public User User { get; private set; }
        public Resource Resource { get; private set; }
        public int ResourceQuantity { get; private set; }
        public Location Location { get; private set; }
        public ReservationState State { get; private set; }
        public DateTime BeginDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private Reservation()
        {
        }

        public Reservation(User user, Resource resource, int resourceQuantity, Location location,
            DateTime beginDate, DateTime endDate)
        {
            this.Id = Guid.NewGuid();
            this.CreatedAt = DateTime.UtcNow;
            SetUser(user);
            SetResource(resource);
            SetQuantity(resourceQuantity);
            SetLocation(location);
            SetState(ReservationState.New);
            SetBeginDate(beginDate);
            SetEndDate(endDate);
        }
        
        public void SetUser(User user)
        {
            if (user is null)
            {
                throw new NullEntityException<User>();
            }

            if (this.User != user && this.User is not null)
            {
                Update();
            }

            this.User = user;
        }

        public void SetResource(Resource resource)
        {
            if (resource is null)
            {
                throw new NullEntityException<Resource>();
            }

            if (this.Resource != resource && this.Resource is not null)
            {
                Update();
            }

            this.Resource = resource;
        }

        public void SetQuantity(int resourceQuantity)
        {
            if (resourceQuantity <= 0)
            {
                throw new InvalidIntValueException(nameof(resourceQuantity));
            }

            if (this.ResourceQuantity != resourceQuantity && this.ResourceQuantity > 0)
            {
                Update();
            }

            this.ResourceQuantity = resourceQuantity;
        }

        public void SetLocation(Location location)
        {
            if (location is null)
            {
                throw new NullEntityException<Location>();
            }

            if (this.Location != location && this.Location is not null)
            {
                Update();
            }

            this.Location = location;
        }

        public void SetState(ReservationState reservationState)
        {
            if (this.State != reservationState)
            {
                Update();
            }

            this.State = reservationState;
        }

        public void SetBeginDate(DateTime beginDate)
        {
            if (beginDate < DateTime.UtcNow)
            {
                throw new InvalidDateTimeException(beginDate);
            }

            if (this.BeginDate != beginDate)
            {
                Update();
            }

            this.BeginDate = beginDate;
        }

        public void SetEndDate(DateTime endDate)
        {
            if (endDate < DateTime.UtcNow || endDate < this.BeginDate)
            {
                throw new InvalidDateTimeException(endDate);
            }

            if (this.EndDate != endDate)
            {
                Update();
            }

            this.EndDate = endDate;
        }
    }
}
