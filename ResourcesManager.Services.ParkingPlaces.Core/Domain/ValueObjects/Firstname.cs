using ResourcesManager.Services.Libraries.FluentValidation;
using ResourcesManager.Services.ParkingPlaces.Core.Exceptions;

namespace ResourcesManager.Services.ParkingPlaces.Core.Domain.ValueObjects
{
    public record Firstname
    {
        public const int MinLength = 3;
        public const int MaxLength = 26;
        public string Value { get; }

        private Firstname()
        {
        }

        public Firstname(string value)
        {
            value.GetValidator()
                .Throw(new EmptyStringException(ErrorCodes.EmptyFirstname, nameof(Firstname)))
                    .WhenIsEmpty()
                .Throw(new InvalidStringLengthException(nameof(Firstname), MinLength, MaxLength))
                    .WhenLengthIsNotBetween(MinLength, MaxLength)
                .Validate();

            this.Value = value;
        }
    }
}
