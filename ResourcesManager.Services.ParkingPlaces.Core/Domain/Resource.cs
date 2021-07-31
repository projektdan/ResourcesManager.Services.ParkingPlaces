using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourcesManager.Services.ParkingPlaces.Core.Domain
{
    public class Resource
    {
        public Guid Id { get; private set; }
        public string UniqueResourceIdentifier { get; private set; }
        public string Name { get; private set; }
    }
}
