namespace MadrageBackEndChallenge.Domain.Exceptions
{
    public class AuthenticationException : MadrageBackEndChallengeException
    {
        public AuthenticationException() : base("AuthenticationException", 2)
        {
        }
    }
}