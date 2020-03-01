using MadrageBackEndChallenge.Business.Dtos;

namespace MadrageBackEndChallenge.Web.Models
{
    public class MenuSaveModel : IMenuSaveDto
    {
        public int? Id { get; set; }
        public string Label { get; set; }
        public int? ParentId { get; set; }
    }
}