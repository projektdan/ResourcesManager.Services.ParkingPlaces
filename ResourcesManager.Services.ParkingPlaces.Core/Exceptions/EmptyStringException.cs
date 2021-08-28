using ResourcesManager.Services.Libraries.Exceptions;

namespace ResourcesManager.Services.ParkingPlaces.Core.Exceptions
{
    public class EmptyStringException : CustomException
    {
        public EmptyStringException(string errorCode, string propertyName)
            : base(errorCode, $"{propertyName} can't be empty.")
        {
        }
    }
}
