using System.Collections.Generic;
using System.Linq;

namespace MadrageBackEndChallenge.Domain.Utils
{
    public class TreeNode<T>
        where T : class
    {
        private readonly IList<TreeNode<T>> _childNodes;

        public TreeNode(T node = null)
        {
            Node = node;
            _childNodes = new List<TreeNode<T>>();
        }

        public T Node { get; set; }

        public TreeNode<T>[] Children => _childNodes.ToArray();
        
        public void AddChild(TreeNode<T> node) 
        {
            _childNodes.Add(node);
        }
    }
}