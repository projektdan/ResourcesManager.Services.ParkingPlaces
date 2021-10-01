using ResourcesManager.Services.Libraries.FluentValidation;
using ResourcesManager.Services.ParkingPlaces.Core.Exceptions;

namespace ResourcesManager.Services.ParkingPlaces.Core.Domain.ValueObjects
{
    public record Address
    {
        public const int MinLength = 3;
        public const int MaxLength = 100;
        public string Value { get; }

        private Address()
        {
        }

        public Address(string value)
        {
            value.GetValidator()
                .Throw(new EmptyStringException(ErrorCodes.EmptyAddress, nameof(Address)))
                    .WhenIsEmpty()
                .Throw(new InvalidStringLengthException(nameof(Address), MinLength, MaxLength))
                    .WhenLengthIsNotBetween(MinLength, MaxLength)
                .Validate();

            Value = value;
        }
    }
}
