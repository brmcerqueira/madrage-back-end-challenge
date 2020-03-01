using FluentValidation;
using MadrageBackEndChallenge.Business.Dtos;

namespace MadrageBackEndChallenge.Business.Validators
{
    internal class MenuSaveDtoValidator : AbstractValidator<IMenuSaveDto>
    {
        public MenuSaveDtoValidator()
        {
            RuleFor(x => x.Label).NotNull().MinimumLength(3).MaximumLength(30);
            When(x => x.Id != null && x.ParentId.HasValue, () => 
            {
                    RuleFor(x => x.ParentId).NotEqual(x => x.Id);
            });
        }
    }
}