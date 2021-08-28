using ResourcesManager.Services.Libraries.Exceptions;
using System;

namespace ResourcesManager.Services.ParkingPlaces.Core.Exceptions
{
    public class InvalidDateTimeException : CustomException
    {
        public InvalidDateTimeException(DateTime dateTime)
            : base($"Property {nameof(dateTime)} with value {dateTime} is invalid.")
        {
        }
    }
}
