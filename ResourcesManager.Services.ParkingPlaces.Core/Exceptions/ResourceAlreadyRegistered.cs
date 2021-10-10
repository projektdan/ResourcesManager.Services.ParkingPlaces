using ResourcesManager.Services.Libraries.Exceptions;
using ResourcesManager.Services.ParkingPlaces.Core.Domain;

namespace ResourcesManager.Services.ParkingPlaces.Core.Exceptions
{
    public class ResourceAlreadyRegistered : CustomException
    {
        public ResourceAlreadyRegistered(Resource resource)
            : base(ErrorCodes.ResourceAlreadyRegistered, $"Resource '{resource.Name.Value}' is already registered for location.")
        {
        }
    }
}
