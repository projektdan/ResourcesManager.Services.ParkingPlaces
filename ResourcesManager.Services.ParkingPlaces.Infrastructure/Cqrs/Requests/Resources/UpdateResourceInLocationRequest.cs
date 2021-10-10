using MediatR;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Cqrs.Requests.Resources
{
    public class UpdateResourceInLocationRequest : IRequest
    {
        public UpdateResourceInLocationRequest(string uniqeResourceIdentifier, int resourceQuantity, string locationName)
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
