namespace MadrageBackEndChallenge.Business
{
    public interface ICrudService<in TSaveDto>
    {
        object[] All(int? index, int? limit);
        object Get(int id);
        void Save(TSaveDto dto);
        void Delete(int id);
    }
}