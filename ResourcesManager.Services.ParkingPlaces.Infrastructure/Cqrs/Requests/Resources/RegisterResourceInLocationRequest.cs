using MediatR;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Cqrs.Requests.Resources
{
    public class RegisterResourceInLocationRequest : IRequest
    {
        public RegisterResourceInLocationRequest(string uniqeResourceIdentifier, int resourceQuantity, string locationName)
        {
            UniqeResourceIdentifier = uniqeResourceIdentifier;
            ResourceQuantity = resourceQuantity;
            LocationName = locationName;
        }

        public string UniqeResourceIdentifier { get; }
        public int ResourceQuantity { get; }
        public string LocationName { get; }
    }
}
