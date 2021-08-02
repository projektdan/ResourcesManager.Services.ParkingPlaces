using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourcesManager.Services.ParkingPlaces.Core.Domain.ValueObjects
{
    public record Name
    {
        public string Value { get; }

        public Name(string value)
        {

        }
    }
}
