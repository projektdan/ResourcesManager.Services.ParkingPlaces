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
        //TODO : Change setters to public and updatedAt
        private void SetUser(User user)
        {
            if (user is null)
            {
                throw new NullEntityException<User>();
            }

            this.User = user;
        }

        private void SetResource(Resource resource)
        {
            if (resource is null)
            {
                throw new NullEntityException<Resource>();
            }

            this.Resource = resource;
        }

        private void SetQuantity(int resourceQuantity)
        {
            if (resourceQuantity <= 0)
            {
                throw new InvalidIntValueException(nameof(resourceQuantity));
            }

            this.ResourceQuantity = resourceQuantity;
        }

        private void SetLocation(Location location)
        {
            if (location is null)
            {
                throw new NullEntityException<Location>();
            }

            this.Location = location;
        }

        private void SetState(ReservationState reservationState)
        {
            this.State = reservationState;
        }

        private void SetBeginDate(DateTime beginDate)
        {
            if (beginDate < DateTime.UtcNow)
            {
                throw new InvalidDateTimeException(beginDate);
            }

            this.BeginDate = beginDate;
        }

        private void SetEndDate(DateTime endDate)
        {
            if (endDate < DateTime.UtcNow || endDate < this.BeginDate)
            {
                throw new InvalidDateTimeException(endDate);
            }

            this.EndDate = endDate;
        }

        public void UpdateState(ReservationState reservationState)
        {

            this.State = reservationState;
            Update();

        }
    }
}
