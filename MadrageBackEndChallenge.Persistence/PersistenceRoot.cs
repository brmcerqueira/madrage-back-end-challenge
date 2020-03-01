using LightInject;
using MadrageBackEndChallenge.Persistence.Daos;

namespace MadrageBackEndChallenge.Persistence
{
    public class PersistenceRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IUserDao, UserDao>();
            serviceRegistry.Register<IMenuDao, MenuDao>();
            serviceRegistry.Register<IMenuUserDao, MenuUserDao>();
        }
    }
}