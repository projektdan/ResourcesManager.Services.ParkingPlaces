using ResourcesManager.Services.Libraries.FluentValidation;
using ResourcesManager.Services.ParkingPlaces.Core.Exceptions;

namespace ResourcesManager.Services.ParkingPlaces.Core.Domain.ValueObjects
{
    public record ResourceQuantity
    {
        public const int MinValue = 1;
        public int Value { get; }

        private ResourceQuantity()
        {
        }

        public ResourceQuantity(int value)
        {
            value.GetValidator()
                .Throw(new InvalidQuantityValueException(nameof(value)))
                .WhenLessThan(MinValue)
            .Validate();

            Value = value;
        }
    }
}
