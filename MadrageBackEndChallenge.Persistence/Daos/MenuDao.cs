using System.Collections.Generic;
using System.Linq;
using MadrageBackEndChallenge.Domain;

namespace MadrageBackEndChallenge.Persistence.Daos
{
    internal class MenuDao : Dao<Menu>, IMenuDao
    {
        public MenuDao(DaoContext context) : base(context)
        {

        }

        public bool HasParent(int id)
        {
            return Context.Set<Menu>().Any(e => e.Id == id);
        }
        
        public Menu[] GetSubmenus(int id)
        {
            var result = new List<Menu>();
            BuildSubmenus(result, new []{ id });
            return result.ToArray();
        }

        private void BuildSubmenus(List<Menu> menus, int[] ids)
        {
            var list = Context.Set<Menu>().Where(e => e.ParentId.HasValue && ids.Contains(e.ParentId.Value));
            
            if (!list.Any()) return;
            
            menus.AddRange(list);
            BuildSubmenus(menus, list.Select(e => e.Id).ToArray());
        }
    }
}