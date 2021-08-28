using ResourcesManager.Services.Libraries.Exceptions;

namespace ResourcesManager.Services.ParkingPlaces.Core.Exceptions
{
    public class InvalidStringLengthException : CustomException
    {
        public InvalidStringLengthException(string propertName, int minLength, int maxLength)
            : base(ErrorCodes.InvalidStringLength, $"{propertName} must be between {minLength} and {maxLength} characters.")
        {
        }
    }
}
