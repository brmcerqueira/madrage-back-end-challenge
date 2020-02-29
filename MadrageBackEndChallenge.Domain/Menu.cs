namespace MadrageBackEndChallenge.Domain
{
    public class Menu
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public Menu Parent { get; set; }
    }
}