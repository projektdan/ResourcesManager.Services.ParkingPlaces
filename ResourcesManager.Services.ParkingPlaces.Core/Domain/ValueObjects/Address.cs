using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourcesManager.Services.ParkingPlaces.Core.Domain.ValueObjects
{
    public record Address
    {
        public string Value { get; }

        public Address(string value)
        {

        }
    }
}
