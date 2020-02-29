using System;

namespace MadrageBackEndChallenge.Domain.Exceptions
{
    public abstract class MadrageBackEndChallengeException : Exception
    {
        public int Code { get; private set; }

        public MadrageBackEndChallengeException(string message, int code) : base(message)
        {
            Code = code;
        }
    }
}