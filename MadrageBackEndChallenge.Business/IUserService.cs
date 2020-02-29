using MadrageBackEndChallenge.Business.Dtos;

namespace MadrageBackEndChallenge.Business
{
    public interface IUserService
    {
        string SignIn(ISignInDto dto);
        void Save(IUserSaveDto dto);
    }
}