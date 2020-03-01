namespace MadrageBackEndChallenge.Business.Dtos
{
    public interface IMenuSaveDto
    {
        int? Id { get; }
        string Label { get; }
        int? ParentId { get; }
    }
}