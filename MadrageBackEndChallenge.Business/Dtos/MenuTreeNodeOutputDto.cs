using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using MadrageBackEndChallenge.Domain;

namespace MadrageBackEndChallenge.Business.Dtos
{
    public class MenuTreeNodeOutputDto
    {
        private readonly IList<MenuTreeNodeOutputDto> _childNodes;

        public MenuTreeNodeOutputDto(Menu menu = null)
        {
            if (menu != null)
            {
                Parse(menu);
            }
            IsRoot = false;
            _childNodes = new List<MenuTreeNodeOutputDto>();
        }

        public int Id { get; private set; }
        
        public string Label { get; private set; }
        
        [JsonIgnore]
        public bool IsRoot { get; set; }
        
        public MenuTreeNodeOutputDto[] Children => _childNodes.ToArray();

        public void Parse(Menu menu)
        {
            Id = menu.Id;
            Label = menu.Label;
        }
        
        public void AddChild(MenuTreeNodeOutputDto nodeOutputDto) 
        {
            _childNodes.Add(nodeOutputDto);
        }
    }
}