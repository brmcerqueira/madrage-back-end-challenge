namespace MadrageBackEndChallenge.Business.Dtos
{
    public interface IUserSaveDto
    {
        int? Id { get; }
        string Name { get; }
        string Email { get; }
        string Password { get; }
    }
}