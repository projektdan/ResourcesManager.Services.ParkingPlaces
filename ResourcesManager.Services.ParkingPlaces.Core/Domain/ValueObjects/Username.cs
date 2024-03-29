﻿using ResourcesManager.Services.Libraries.FluentValidation;
using ResourcesManager.Services.ParkingPlaces.Core.Exceptions;

namespace ResourcesManager.Services.ParkingPlaces.Core.Domain.ValueObjects
{
    public record Username
    {
        private const int MinLength = 3;
        private const int MaxLength = 30;

        public string Value { get; }
        public Username(string value)
        {
            value = value?.Trim();
            value.GetValidator()
                .Throw(new EmptyStringException(ErrorCodes.EmptyUsername, nameof(Username)))
                    .WhenIsEmpty()
                .Throw(new InvalidStringLengthException(nameof(Username), MinLength, MaxLength))
                    .WhenLengthIsNotBetween(MinLength, MaxLength)
                .Validate();
            this.Value = value;
        }
    }
}
