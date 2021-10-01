namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Models.Dtos
{
    public class ReservationDto
    {
        public UserDto User { get; set; }
        public ResourceDto Resource { get; set; }
        public int ResourceQuantity { get; set; }
        public LocationDto Location { get; set; }
        public string State { get; set; }
    }
}
