using MadrageBackEndChallenge.Business.Dtos;

namespace MadrageBackEndChallenge.Business
{
    public interface IUserService
    {
        string SignIn(ISignInDto dto);
        object[] All(int? index, int? limit);
        object Get(int id);
        void Save(IUserSaveDto dto);
        void Delete(int id);
    }
}