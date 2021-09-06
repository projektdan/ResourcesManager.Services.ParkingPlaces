using ResourcesManager.Services.ParkingPlaces.Core.Domain.ValueObjects;
using ResourcesManager.Services.ParkingPlaces.Core.Exceptions;
using System;

namespace ResourcesManager.Services.ParkingPlaces.Core.Domain
{
    public class ReservationState : DbEntityBase
    {
        public Guid Id { get; private set; }
        public Name Name { get; private set; }
        public DateTime CreatedAt { get; private set; }

        #region CTOR
        private ReservationState()
        {
        }

        public ReservationState(Name name)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
        }

        public ReservationState(string name) : this(new Name(name))
        {
        }
        #endregion

        public void AddNewReservationState(Name name)
        {
            if (name is null)
            {
                throw new NullEntityException<Name>();
            }

            if (this.Name != name && this.Name is not null)
            {
                Update();
            }

            this.Name = name;
        }
    }
}
