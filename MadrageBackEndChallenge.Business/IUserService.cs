using MadrageBackEndChallenge.Business.Dtos;

namespace MadrageBackEndChallenge.Business
{
    public interface IUserService
    {
        string SignIn(ISignInDto dto);
        object[] All(int? index, int? limit);
        void Save(IUserSaveDto dto);
        void Delete(int id);
    }
}