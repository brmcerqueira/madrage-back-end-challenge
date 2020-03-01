namespace MadrageBackEndChallenge.Domain
{
    public class MenuUser
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
    }
}