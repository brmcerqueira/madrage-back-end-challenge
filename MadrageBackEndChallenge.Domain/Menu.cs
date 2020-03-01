using System.Collections.Generic;

namespace MadrageBackEndChallenge.Domain
{
    public class Menu : IEntity
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public int ParentId { get; set; }
        public Menu Parent { get; set; }
        public IList<MenuUser> Users { get; set; }
    }
}