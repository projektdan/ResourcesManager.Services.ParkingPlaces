using ResourcesManager.Services.Libraries.FluentValidation;
using ResourcesManager.Services.ParkingPlaces.Core.Exceptions;

namespace ResourcesManager.Services.ParkingPlaces.Core.Domain.ValueObjects
{
    public record Name
    {
        public const int MinLength = 3;
        public const int MaxLength = 26;
        public string Value { get; }

        private Name()
        {
        }

        public Name(string value)
        {
            value.GetValidator()
                .Throw(new EmptyStringException(ErrorCodes.EmptyName, nameof(Name)))
                    .WhenIsEmpty()
                .Throw(new InvalidStringLengthException(nameof(Name), MinLength, MaxLength))
                    .WhenLengthIsNotBetween(MinLength, MaxLength)
                .Validate();

            this.Value = value;
        }
    }
}
