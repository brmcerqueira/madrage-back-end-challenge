using MadrageBackEndChallenge.Business.Dtos;

namespace MadrageBackEndChallenge.Business
{
    public interface IUserService : ICrudService<IUserSaveDto>
    {
        string SignIn(ISignInDto dto);
    }
}