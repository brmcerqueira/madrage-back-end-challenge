using System.Collections.Generic;

namespace MadrageBackEndChallenge.Domain
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IList<MenuUser> Menus { get; set; }
    }
}