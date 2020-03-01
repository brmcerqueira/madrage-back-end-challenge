namespace MadrageBackEndChallenge.Domain.Exceptions
{
    public class UserNotFoundException : MadrageBackEndChallengeException
    {
        public UserNotFoundException() : base("UserNotFoundException", 7)
        {
        }
    }
}