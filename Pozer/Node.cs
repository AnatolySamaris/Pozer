using System;

namespace Pozer
{
    public class Node
    {
        private Node Parent;
        private int Level;  // определяем лейблы по правилу ((level + 1) % 2 == 0) ? "A" : "B"
        int[] Costs = new int[2];   // выигрыши А и В соответственно
        private List<Node> Children = new List<Node>();

        public Node(Node parent, int level)
        {
            this.Parent = parent;
            this.Level = level;
        }

        public void AddChild(Node child)
        {
            this.Children.Add(child);
        }

        public void DeleteChildren()
        {
            this.Children.Clear();
        }

        public int[] FindBestCosts()
        {
            int label = (this.Level + 1) % 2; // 0 -> A, 1 -> B
            this.Children.Sort(
                (x, y) => x.Costs[label].CompareTo(y.Costs[label])
            );
            return this.Children[this.Children.Count - 1].Costs;
        }
    }
}
