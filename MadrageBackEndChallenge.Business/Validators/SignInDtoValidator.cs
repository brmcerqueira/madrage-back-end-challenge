using FluentValidation;
using MadrageBackEndChallenge.Business.Dtos;

namespace MadrageBackEndChallenge.Business.Validators
{
    internal class SignInDtoValidator : AbstractValidator<ISignInDto>
    {
        public SignInDtoValidator()
        {
            RuleFor(x => x.Email).NotNull().EmailAddress();
            RuleFor(x => x.Password).NotNull().MinimumLength(7).MaximumLength(30);
        }
    }
}