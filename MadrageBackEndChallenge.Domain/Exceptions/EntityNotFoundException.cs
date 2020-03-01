namespace MadrageBackEndChallenge.Domain.Exceptions
{
    public class EntityNotFoundException : MadrageBackEndChallengeException
    {
        public EntityNotFoundException() : base("EntityNotFoundException", 4)
        {
        }
    }
}