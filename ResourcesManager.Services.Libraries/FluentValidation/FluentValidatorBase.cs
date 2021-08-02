using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourcesManager.Services.Libraries.FluentValidation
{
    public abstract class FluentValidatorBase<TEntity>
    {
        private readonly TEntity validationEntity;
        private Dictionary<Exception, List<Func<TEntity, bool>>> validators;
        private List<Func<TEntity, bool>> currentValidators;

        public FluentValidatorBase(TEntity validationEntity)
        {
            this.validators = new();
            this.validationEntity = validationEntity;
        }

        public FluentValidator<TEntity> Throw<TException>(TException exception)
            where TException : Exception
        {
            if (this.validators.TryGetValue(exception, out var validators))
            {
                this.currentValidators = validators;
            }
            else
            {
                this.currentValidators = new();
                this.validators.Add(exception, this.currentValidators);
            }

            return (FluentValidator<TEntity>)this;
        }

        protected void AddValiator(Func<TEntity, bool> func)
        {
            if (this.currentValidators != null)
            {
                this.currentValidators.Add(func);
            }
        }

        protected void ValidateEntity()
        {
            foreach (var dictionaryValidator in this.validators)
            {
                if (dictionaryValidator.Value.Any(x => x.Invoke(this.validationEntity)))
                {
                    throw dictionaryValidator.Key;
                }
            }
        }
    }
}
