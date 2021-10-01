using System;

namespace ResourcesManager.Services.Libraries.FluentValidation
{
    public class FluentValidator<TEntity> : FluentValidatorBase<TEntity>
    {
        public FluentValidator(TEntity validationEntity) : base(validationEntity)
        {
        }

        public FluentValidator<TEntity> When(Func<TEntity, bool> func)
        {
            this.AddValiator(func);
            return this;
        }
        
        public FluentValidator<TEntity> WhenIsNull()
            => this.When(x => x is null);

        public FluentValidator<TEntity> WhenIsNotNull()
            => this.When(x => x is not null);

        public void Validate() => base.ValidateEntity();
    }
}
