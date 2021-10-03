﻿using System.Collections.Generic;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Models.Dtos
{
    public class LocationDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public IEnumerable<LocationResourceDto> Resources { get; set; }
    }
}
