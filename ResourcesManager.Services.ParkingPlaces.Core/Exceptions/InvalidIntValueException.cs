using ResourcesManager.Services.Libraries.Exceptions;

namespace ResourcesManager.Services.ParkingPlaces.Core.Exceptions
{
    public class InvalidIntValueException : CustomException
    {
        public InvalidIntValueException(string propertyName)
            : base(ErrorCodes.InvalidIntvalue, $"{propertyName} must be greater than 0.")
        {
        }
    }
}
