using LightInject;
using MadrageBackEndChallenge.Domain;

namespace MadrageBackEndChallenge.Persistence
{
    public class PersistenceRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IDao<User>, UserDao>();
            serviceRegistry.Register<IDao<Menu>, MenuDao>();
        }
    }
}