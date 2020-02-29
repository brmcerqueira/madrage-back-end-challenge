using System.Collections.Generic;

namespace MadrageBackEndChallenge.Domain.Exceptions
{
    public class ValidationException : MadrageBackEndChallengeException
    {
        public ValidationException(IEnumerable<string> errors) : base("ValidationException", 3)
        {
            Errors = errors;
        }

        public IEnumerable<string> Errors { get; }
    }
}