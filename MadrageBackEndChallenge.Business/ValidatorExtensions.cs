using System.Linq;
using FluentValidation;
using FluentValidation.Resources;
using LightInject;

namespace MadrageBackEndChallenge.Business
{
    public static class ValidatorExtensions
    {       
        public static void AdjustValidationLanguageManager(this IServiceFactory serviceFactory)
        {
            ValidatorOptions.LanguageManager = serviceFactory.GetInstance<ILanguageManager>();
        }

        internal static void Check<T>(this IValidator<T> validator, T instance)
        {
            var validationResult = validator.Validate(instance);

            if (!validationResult.IsValid)
            {
                throw new Domain.Exceptions.ValidationException(validationResult.Errors.Select(e => e.ErrorMessage));
            }
        }
    }
}