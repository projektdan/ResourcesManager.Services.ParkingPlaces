using ResourcesManager.Services.Libraries.Exceptions;

namespace ResourcesManager.Services.ParkingPlaces.Core.Exceptions
{
    public class InvalidQuantityValueException : CustomException
    {
        public InvalidQuantityValueException(string propertyName)
            : base(ErrorCodes.InvalidIntvalue, $"{propertyName} must be greater than 0.")
        {
        }
    }
}
