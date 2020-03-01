using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace MadrageBackEndChallenge.Domain.Utils
{
    public class MenuTreeNode
    {
        private readonly IList<MenuTreeNode> _childNodes;

        public MenuTreeNode(Menu menu = null)
        {
            if (menu != null)
            {
                Parse(menu);
            }
            IsRoot = false;
            _childNodes = new List<MenuTreeNode>();
        }

        public int Id { get; private set; }
        
        public string Label { get; private set; }
        
        [JsonIgnore]
        public bool IsRoot { get; set; }
        
        public MenuTreeNode[] Children => _childNodes.ToArray();

        public void Parse(Menu menu)
        {
            Id = menu.Id;
            Label = menu.Label;
        }
        
        public void AddChild(MenuTreeNode node) 
        {
            _childNodes.Add(node);
        }
    }
}