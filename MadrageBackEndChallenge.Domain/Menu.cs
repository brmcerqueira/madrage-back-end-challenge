namespace MadrageBackEndChallenge.Domain
{
    public class Menu : IEntity
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public Menu Parent { get; set; }
    }
}