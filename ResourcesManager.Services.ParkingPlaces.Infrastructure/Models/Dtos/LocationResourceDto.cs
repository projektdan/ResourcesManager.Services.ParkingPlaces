﻿namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Models.Dtos
{
    public class LocationResourceDto
    {
        public LocationDto Location { get; set; }
        public ResourceDto Resource { get; set; }
        public int ResourceQuantity { get; set; }
    }
}
