namespace MadrageBackEndChallenge.Domain.Exceptions
{
    public class MenuNotFoundException : MadrageBackEndChallengeException
    {
        public MenuNotFoundException() : base("MenuNotFoundException", 6)
        {
        }
    }
}