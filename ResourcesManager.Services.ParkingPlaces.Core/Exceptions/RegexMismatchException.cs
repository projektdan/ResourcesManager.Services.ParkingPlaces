using ResourcesManager.Services.Libraries.Exceptions;
using System.Text.RegularExpressions;

namespace ResourcesManager.Services.ParkingPlaces.Core.Exceptions
{
    public class RegexMismatchException : CustomException
    {
        public RegexMismatchException(string propertyName, Regex regex)
            : base (ErrorCodes.InvalidRegex, $"{propertyName} not match an regex email: {regex}.")
        {
        }
    }
}
