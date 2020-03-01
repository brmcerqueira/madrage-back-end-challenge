namespace MadrageBackEndChallenge.Domain.Exceptions
{
    public class ParentNotFoundException : MadrageBackEndChallengeException
    {
        public ParentNotFoundException() : base("ParentNotFoundException", 5)
        {
        }
    }
}