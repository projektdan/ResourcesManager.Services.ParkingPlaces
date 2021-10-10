using MediatR;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Cqrs.Requests.Resources
{
    public class UnregisterResourceInLocationRequest : IRequest
    {
        public UnregisterResourceInLocationRequest(string locationName, string UniqueResourceIdentifier)
        {
            LocationName = locationName;
            this.UniqueResourceIdentifier = UniqueResourceIdentifier;
        }

        public string LocationName { get; }
        public string UniqueResourceIdentifier { get; }
    }
}
