using ResourcesManager.Services.Libraries.FluentValidation;
using ResourcesManager.Services.ParkingPlaces.Core.Exceptions;

namespace ResourcesManager.Services.ParkingPlaces.Core.Domain.ValueObjects
{
    public record Lastname
    {
        public const int MinLength = 3;
        public const int MaxLength = 26;

        public string Value { get; }

        private Lastname()
        {
        }

        public Lastname(string value)
        {
            value.GetValidator()
                .Throw(new EmptyStringException(ErrorCodes.EmptyLastname, nameof(Lastname)))
                    .WhenIsEmpty()
                .Throw(new InvalidStringLengthException(nameof(Lastname), MinLength, MaxLength))
                    .WhenLengthIsNotBetween(MinLength, MaxLength)
                .Validate();

            this.Value = value;
        }
    }
}
