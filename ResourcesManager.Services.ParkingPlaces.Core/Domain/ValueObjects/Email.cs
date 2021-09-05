using ResourcesManager.Services.Libraries.FluentValidation;
using ResourcesManager.Services.ParkingPlaces.Core.Exceptions;
using System.Text.RegularExpressions;

namespace ResourcesManager.Services.ParkingPlaces.Core.Domain.ValueObjects
{
    public record Email
    {
        public static readonly Regex Regex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");

        public string Value { get; }

        private Email()
        {
        }

        public Email(string value)
        {
            value.GetValidator()
                .Throw(new EmptyStringException(ErrorCodes.EmptyEmail, nameof(Email)))
                    .WhenIsEmpty()
                .Throw(new RegexMismatchException(nameof(Email), Regex))
                    .WhenIsNotMatchRegex(Regex)
                .Validate();

            this.Value = value;

        }
    }
}
