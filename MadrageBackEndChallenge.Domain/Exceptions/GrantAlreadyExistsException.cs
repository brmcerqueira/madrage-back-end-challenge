namespace MadrageBackEndChallenge.Domain.Exceptions
{
    public class GrantAlreadyExistsException : MadrageBackEndChallengeException
    {
        public GrantAlreadyExistsException() : base("GrantAlreadyExistsException", 8)
        {
        }
    }
}