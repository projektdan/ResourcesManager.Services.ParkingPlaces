using ResourcesManager.Services.Libraries.FluentValidation;
using ResourcesManager.Services.ParkingPlaces.Core.Exceptions;

namespace ResourcesManager.Services.ParkingPlaces.Core.Domain.ValueObjects
{
    public record UniqueResourceIdentifier
    {
        public const int MinLength = 3;
        public const int MaxLength = 26;
        public string Value { get; }

        public UniqueResourceIdentifier(string value)
        {
            value.GetValidator()
                .Throw(new EmptyStringException(ErrorCodes.EmptyUniqueResourceIdentifier, nameof(UniqueResourceIdentifier)))
                    .WhenIsEmpty()
                .Throw(new InvalidStringLengthException(nameof(UniqueResourceIdentifier), MinLength, MaxLength))
                    .WhenLengthIsNotBetween(MinLength, MaxLength)
                .Validate();

            this.Value = value;
        }
    }
}
