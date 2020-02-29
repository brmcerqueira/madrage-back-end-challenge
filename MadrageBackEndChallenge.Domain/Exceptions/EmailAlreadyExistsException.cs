namespace MadrageBackEndChallenge.Domain.Exceptions
{
    public class EmailAlreadyExistsException : MadrageBackEndChallengeException
    {
        public EmailAlreadyExistsException() : base("EmailAlreadyExistsException", 1)
        {
        }
    }
}