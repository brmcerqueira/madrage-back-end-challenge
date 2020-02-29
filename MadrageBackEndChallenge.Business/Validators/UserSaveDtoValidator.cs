using FluentValidation;
using MadrageBackEndChallenge.Business.Dtos;

namespace MadrageBackEndChallenge.Business.Validators
{
    internal class UserSaveDtoValidator : AbstractValidator<IUserSaveDto>
    {
        public UserSaveDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().MinimumLength(3).MaximumLength(50);
            When(x => x.Id == null, () =>
            {
                RuleFor(x => x.Email).NotNull().EmailAddress().MaximumLength(30);
                RuleFor(x => x.Password).NotNull().MinimumLength(7).MaximumLength(30);
            });
        }
    }
}