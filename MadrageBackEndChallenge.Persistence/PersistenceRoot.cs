using LightInject;
using MadrageBackEndChallenge.Domain;
using MadrageBackEndChallenge.Persistence.Daos;

namespace MadrageBackEndChallenge.Persistence
{
    public class PersistenceRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IUserDao, UserDao>();
            serviceRegistry.Register<IDao<Menu>, MenuDao>();
        }
    }
}