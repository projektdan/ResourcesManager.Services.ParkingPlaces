using System;

namespace ResourcesManager.Services.ParkingPlaces.Core.Domain
{
    public class ReservationState
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        private ReservationState()
        {
        }

        public ReservationState(string name)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
        }

        public void CreateReservationState(string name)
        {

        }
    }
}
