using FluentValidation.Resources;
using LightInject;

namespace MadrageBackEndChallenge.Business
{
    public class BusinessRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<ILanguageManager, ValidationLanguageManager>();
            serviceRegistry.Register<IUserService, UserService>();
        }
    }
}