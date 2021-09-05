using ResourcesManager.Services.Libraries.FluentValidation;
using ResourcesManager.Services.ParkingPlaces.Core.Exceptions;

namespace ResourcesManager.Services.ParkingPlaces.Core.Domain.ValueObjects
{
    public record Password
    {
        private const int MinLength = 8;
        private const int MaxLength = 128;

        public string Value { get; }

        private Password()
        {
        }

        public Password(string value)
        {
            value.GetValidator()
                .Throw(new EmptyStringException(ErrorCodes.EmptyPassword, nameof(Password)))
                    .WhenIsEmpty()
                .Throw(new InvalidStringLengthException(nameof(Password), MinLength, MaxLength))
                    .WhenLengthIsNotBetween(MinLength, MaxLength)
                .Validate();

            this.Value = value;

        }
    }
}
