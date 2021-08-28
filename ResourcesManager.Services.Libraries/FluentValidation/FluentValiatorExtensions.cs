using System.Text.RegularExpressions;

namespace ResourcesManager.Services.Libraries.FluentValidation
{
    public static class FluentValiatorExtensions
    {
        public static FluentValidatorBase<TEntity> GetValidator<TEntity>(this TEntity entity)
            => new FluentValidator<TEntity>(entity);

        public static FluentValidator<string> WhenLengthIsNotBetween(this FluentValidator<string> validator, int minLength, int maxLength)
            => validator.When(x => x.Length < minLength || x.Length > maxLength);

        public static FluentValidator<string> WhenIsLongerThan(this FluentValidator<string> validator, int maxLength)
            => validator.When(x => x.Length > maxLength);

        public static FluentValidator<string> WhenIsEmpty(this FluentValidator<string> validator)
            => validator.When(x => string.IsNullOrWhiteSpace(x));

        public static FluentValidator<string> WhenIsNotMatchRegex(this FluentValidator<string> validator, Regex regex)
            => validator.When(x => !regex.IsMatch(x));
    }
}
