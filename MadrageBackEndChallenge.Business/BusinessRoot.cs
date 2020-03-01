using FluentValidation.Resources;
using LightInject;
using MadrageBackEndChallenge.Business.Dtos;

namespace MadrageBackEndChallenge.Business
{
    public class BusinessRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<ILanguageManager, ValidationLanguageManager>();
            serviceRegistry.Register<IUserService, UserService>();
            serviceRegistry.Register<ICrudService<IMenuSaveDto>, MenuService>();
        }
    }
}