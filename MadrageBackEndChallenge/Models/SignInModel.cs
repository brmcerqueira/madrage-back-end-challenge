using MadrageBackEndChallenge.Business.Dtos;

namespace MadrageBackEndChallenge.Web.Models
{
    public class SignInModel : ISignInDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}