using MadrageBackEndChallenge.Business.Dtos;

namespace MadrageBackEndChallenge.Web.Models
{
    public class UserSaveModel : IUserSaveDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}