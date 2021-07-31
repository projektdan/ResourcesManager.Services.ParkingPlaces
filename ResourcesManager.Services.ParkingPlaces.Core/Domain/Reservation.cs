using System;

namespace ResourcesManager.Services.ParkingPlaces.Core.Domain
{
    public class Reservation
    {
        public Guid Id { get; private set; }
        public User User { get; private set; }
        public Resource Resource { get; private set; }
        public int ResourceQuantity { get; private set; }
        public Location Location { get; private set; }
        public ReservationState State { get; private set; }
        public DateTime BeginDate { get; private set; }
        public DateTime EndDate { get; private set; }
    }
}
