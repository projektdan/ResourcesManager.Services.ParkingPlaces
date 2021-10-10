using MediatR;

namespace ResourcesManager.Services.ParkingPlaces.Infrastructure.Cqrs.Requests.Locations
{
    public class RemoveLocationRequest : IRequest
    {
        public RemoveLocationRequest(string locationName)
        {
            LocationName = locationName;
        }

        public string LocationName { get; }
    }
}
