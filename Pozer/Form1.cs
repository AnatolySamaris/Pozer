using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Pozer
{

    public partial class Main : Form
    {
        Graphics graphics;
        private int NodeSize = 30;
        private int paintingZeroX = 0;
        private int paintingZeroY = 35;

        private Node Root;
        private int TreeHeight = 1;

        private Node CheckedNode;
        //private Node CurrentNode;

        public void SetNodeSize(int NodeSize)
        {
            this.NodeSize = NodeSize;
        }

        public int GetNodeSize()
        {
            return this.NodeSize;
        }

        public void SetCheckedNode(Node CheckedNode)
        {
            this.CheckedNode = CheckedNode;
        }

        public Node GetCheckedNode()
        {
            return this.CheckedNode;
        }

        public Main()
        {
            InitializeComponent();
        }


        //public static void GraphTraverse(Node root, IAction action)
        //{
        //    action.Function(root);

        //    foreach (Node child in root.GetChildren())
        //    {
        //        GraphTraverse(child, action);
        //    }
        //}

        public void FindNode(Node node1, Node node2)
        {
            if (Math.Abs(node1.GetX() - node2.GetX()) <= NodeSize && Math.Abs(node1.GetY() - node2.GetY()) <= NodeSize)
            {
                CheckedNode = node1;
            }
        }

        // Рекусивно считает количество нод на уровне
        private int CountLevelNodes(Node node, Node searchNode)
        {
            if (node.GetLevel() == searchNode.GetLevel())
            {
                return 1;
            }
            else
            {
                int count = 0;
                foreach (Node child in node.GetChildren())
                {
                    count += CountLevelNodes(child, searchNode);
                }
                return count;
            }
        }

        // Рекурсивно ищет порядковый номер ноды на её уровне
        private int FindNodeLevelOrder(Node root, Node searchNode)
        {
            void FillTreeMap(Node node, Dictionary<int, List<Node>> treeMap)
            {
                try
                {
                    treeMap[node.GetLevel()].Add(node);
                }
                catch (KeyNotFoundException)
                {
                    treeMap.Add(node.GetLevel(), new List<Node>() { node });
                }
                foreach (Node child in node.GetChildren())
                {
                    FillTreeMap(child, treeMap);
                }
            }

            Dictionary<int, List<Node>> map = new Dictionary<int, List<Node>>();
            FillTreeMap(root, map);
            return map[searchNode.GetLevel()].IndexOf(searchNode) + 1;
        }

        private void RecalculateNode(Node node)
        {
            // Считаем Y коодинату
            int SpaceVertical = (this.Height - this.paintingZeroY - this.NodeSize * this.TreeHeight) / (this.TreeHeight + 1);
            //int SpaceVertical = 400;
            node.SetY(this.paintingZeroY + this.NodeSize * (node.GetLevel() - 1) + SpaceVertical * (node.GetLevel() - 1));

            // Считаем X координату
            int LevelNodesAmount = CountLevelNodes(this.Root, node);
            int NodeLevelOrder = FindNodeLevelOrder(this.Root, node);
            int SpaceHoriz = (this.Width - this.NodeSize * LevelNodesAmount) / (LevelNodesAmount + 1);
            node.SetX(this.paintingZeroX + this.NodeSize * (NodeLevelOrder - 1) + SpaceHoriz * NodeLevelOrder);
        }

        public void GraphTraverse(Node root, Node node = null, bool draw = false, bool search = false, bool calculate = false)
        {
            if (search == true)
            {
                FindNode(root, node);
            }
            else if (draw == true)
            {
                DrawNode(root);
            }

            else if (calculate == true)
            {
                RecalculateNode(root);
            }

            foreach (Node child in root.GetChildren())
            {
                if (search == true)
                {
                    GraphTraverse(root: child, node: node, search: true);
                }
                else if (draw == true)
                {
                    GraphTraverse(root: child, draw: true);
                }
                else if(calculate == true)
                {
                    GraphTraverse(root: child, calculate: true);
                }
            }
        }

        private void UpdateTreeHeight()
        {
            int recursiveMaxHeight(Node node)
            {
                // Если нет детей
                if (!node.GetChildren().Any())
                {
                    return node.GetLevel();
                }

                int MaxHeight = 0;
                foreach (Node child in node.GetChildren())
                {
                    MaxHeight = Math.Max(MaxHeight, recursiveMaxHeight(child));
                }
                return MaxHeight;
            }

            this.TreeHeight = Math.Max(this.TreeHeight, recursiveMaxHeight(this.Root));
        }

        private void CreateNode(Node Parent = null)
        {
            if (Parent == null)
            {
                this.Root = new Node(1);
            }
            else
            {
                Parent.AddChild(
                    new Node(Parent.GetLevel() + 1, Parent)
                );
            }

            UpdateTreeHeight();
        }

        public void DrawNode(Node node)
        {
            graphics = CreateGraphics();
            graphics.DrawEllipse(
                Pens.Black,
                node.GetX(), node.GetY(),
                NodeSize, NodeSize);

            string label = "A";
            Font font = new Font("Arial", 12);
            SizeF labelSize = graphics.MeasureString(label, font);
            float labelX = node.GetX() + (NodeSize - labelSize.Width) / 2;
            float labelY = node.GetY() + (NodeSize - labelSize.Height) / 2;
            if (node.GetLevel() % 2 == 1)
            {
                label = "A";
            }
            else
            {
                label = "B";
            }
            SolidBrush brush = new SolidBrush(Color.Black);
            graphics.DrawString(label, font, brush, labelX, labelY);
        }

        private void DrawGraph()
        {
            graphics.Clear(Color.White);
            GraphTraverse(root: this.Root, calculate: true);
            GraphTraverse(root: this.Root, draw: true);

            //graphics = CreateGraphics();

            //// рисуем начальную вершину
            //graphics.DrawEllipse(
            //    Pens.Black,
            //    this.Root.GetX(),
            //    this.Root.GetY(),
            //    NodeSize, NodeSize);

            //Node CurrentNode = new Node();
            //CurrentNode = Root;
            //foreach (Node node in CurrentNode.GetChildren())
            //{

            //}

            //foreach (Node node in this.Root.GetChildren())
            //{
            //    foreach (Node child in node.GetChildren())
            //    {
            //        graphics.DrawEllipse(
            //            Pens.Black,
            //            child.GetX(),
            //            child.GetY(),
            //            NodeSize, NodeSize
            //        );
            //        graphics.FillEllipse(
            //            Brushes.Red,
            //            child.GetX(),
            //            child.GetY(),
            //            NodeSize, NodeSize
            //        );
            //    }
            //}
        }

        // Обработка клика на кнопку "Справка"
        private void help_Click(object sender, EventArgs e)
        {

        }

        // Обработка клика на кнопку "Режим работы"
        private void wayOfWorking_Click(object sender, EventArgs e)
        {
            Work work = new Work();
            work.ShowDialog();
        }

        // Обработка хз чего в главном окне
        private void Main_Load(object sender, EventArgs e)
        {
            // ...
        }

        // Обработка клика на кнопку "Очистить поле"
        private void delete_Click(object sender, EventArgs e)
        {
            TreeHeight = 1;
            graphics.Clear(Color.White);
            CreateNode();
            DrawGraph();
        }

        // Обработка клика на кнопку "Начать решение"
        private void start_Click(object sender, EventArgs e)
        {
            
        }

        // Обработка наведения мыши на ноду
        //private void Main_MouseEnter(object sender, EventArgs e)
        //{
        //    MouseEventArgs mouseEventArgs = e as MouseEventArgs;
        //    if (mouseEventArgs != null)
        //    {
        //        int X = mouseEventArgs.Location.X;
        //        int Y = mouseEventArgs.Location.Y;

        //        if (FindNode(X, Y).GetLevel() != -1)
        //        {
        //            Form formAdd = new Form();
        //            formAdd.ShowDialog();
        //        }
        //    }
        //}

        //private void Main_MouseMove(object sender, MouseEventArgs e)
        //{
        //    int X = e.X;
        //    int Y = e.Y;

        //    if (FindNode(X, Y).GetLevel() != -1)
        //    {
        //        Form formAdd = new Form();
        //        formAdd.ShowDialog();
        //    }
        //}

        // Обработка клика правой кнопкой на ноду
        private void Main_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int X = e.X;
                int Y = e.Y;

                Node node = new Node(X, Y);
                GraphTraverse(root: this.Root, node: node, search: true);

                if (CheckedNode.GetLevel() != -1)
                {
                    ToolStripMenuItem contextMenuItemChild = new ToolStripMenuItem("Добавить ребенка");
                    ToolStripMenuItem contextMenuItemList = new ToolStripMenuItem("Добавить лист");
                    ContextMenuStrip contextMenu = new ContextMenuStrip();
                    contextMenu.Items.AddRange(new[] { contextMenuItemChild, contextMenuItemList });
                    contextMenu.Show(new Point(CheckedNode.GetX(), CheckedNode.GetY()));
                    contextMenuItemChild.Click += contextMenuItemChild_Click;
                }
            }
        }

        private void contextMenuItemChild_Click(object sender, EventArgs e)
        {
            //Node Child = new Node();
            //Child.SetParent(CheckedNode);
            //CheckedNode.AddChild(Child);

            //graphics = CreateGraphics();
            //graphics.Clear(Color.White);
            CreateNode(CheckedNode);
            //GraphTraverse(root: this.Root, calculate: true);
            //GraphTraverse(root: this.Root, draw: true);
            DrawGraph();
        }

        // поиск вершины
        //private Node FindNode(int X, int Y)
        //{
        //    // массив для хранения количества посещенных детей на каждом
        //    // уровне
        //    int[] VisitedNodes = new int[TreeHeight];
        //    Array.Clear(VisitedNodes, 0, TreeHeight);
        //    Node CurrentNode = new Node(1);
        //    CurrentNode.SetPosition(paintingZeroX, paintingZeroY);
        //    Node CurrentChild = new Node();
        //    //CurrentNode = Root;

        //    //if (Math.Abs(CurrentChild.GetX() - X) <= 30 && Math.Abs(CurrentChild.GetY() - Y) <= 30)
        //    //{
        //    //    return CurrentNode;
        //    //}

        //    int Level = 1;
        //    while(true)
        //    {
        //        // проверены не все дети
        //        if (VisitedNodes[Level - 1] < CurrentNode.CountChildren())
        //        {
        //            CurrentChild = CurrentNode.GetChildren()[VisitedNodes[Level - 1] - 1];
        //            VisitedNodes[Level - 1]++;
        //            Level++;
        //            if (Math.Abs(CurrentChild.GetX() - X) <= 30 && Math.Abs(CurrentChild.GetY() - Y) <= 30)
        //            {
        //                return CurrentChild;
        //            }
        //            else
        //            {
        //                CurrentNode = CurrentChild;
        //            }
        //        }

        //        //проверены все дети текущей вершины
        //        else
        //        {
        //            if (CurrentNode.GetLevel() == 1)
        //            {
        //                if (Math.Abs(CurrentNode.GetX() - X) <= 30 && Math.Abs(CurrentNode.GetY() - Y) <= 30)
        //                {
        //                    return CurrentNode;
        //                }
        //                else
        //                {
        //                    return new Node(-1);
        //                }
        //            }
        //            else
        //            {
        //                CurrentNode = CurrentChild.GetParent();
        //                Level--;
        //            }
        //        }

        //        //if (CurrentNode.GetLevel() == 1 && VisitedNodes.Length == CurrentNode.CountChildren())
        //        //{
        //        //    return new Node(-1);
        //        //}
        //    }
        //}

        private void Main_Paint(object sender, PaintEventArgs e)
        {
            graphics = CreateGraphics();
            //graphics.Clear(Color.White);
            if (this.Root == null) CreateNode();
            //GraphTraverse(root: this.Root, calculate: true);
            //GraphTraverse(root: this.Root, draw: true);
            DrawGraph();

            //foreach (Node child in this.Root.GetChildren())
            //{
            //    int X = child.GetX();
            //}

            //int height = this.Height;

            //DrawNode(421, 547);
            //DrawNode(500, 300);


            //paintingZeroX = this.paintingZeroX + this.Width / 2 - NodeSize;
            //paintingZeroX = 0;
            //this.CreateNode();

            //this.CreateNode(this.Root);
            //this.CreateNode(this.Root);
            //this.CreateNode(this.Root);

            //this.CreateNode(this.Root.GetChildren()[0]);

            //this.DrawGraph();
        }
    }


    public class Node
    {
        private Node Parent;
        private int Level;  // определяем лейблы по правилу ((level + 1) % 2 == 0) ? "A" : "B"
        int[] Costs = new int[2];   // выигрыши А и В соответственно
        private List<Node> Children = new List<Node>();
        private int XCoordinate, YCoordinate;

        // Null Object Constructor
        public Node()
        {
            this.Parent = null;
            this.Children = null;
        }

        public Node(int level, Node parent = null)
        {
            this.Parent = parent;
            this.Level = level;
        }

        // Для поиска ноды по координатам
        public Node(int XCoordinate, int YCoordinate)
        {
            this.XCoordinate = XCoordinate;
            this.YCoordinate = YCoordinate;
        }

        public int GetLevel()
        {
            return this.Level;
        }

        public int GetX()
        {
            return this.XCoordinate;
        }

        public int GetY()
        {
            return this.YCoordinate;
        }

        public void SetX(int x)
        {
            this.XCoordinate = x;
        }

        public void SetY(int y)
        {
            this.YCoordinate = y;
        }

        public int[] GetPosition()
        {
            return new int[] { this.XCoordinate, this.YCoordinate };
        }

        public void SetPosition(int XCoordinate, int YCoordinate)
        {
            this.XCoordinate = XCoordinate;
            this.YCoordinate = YCoordinate;
        }

        public void AddChild(Node child)
        {
            this.Children.Add(child);
        }

        public void DeleteChildren()
        {
            this.Children.Clear();
        }

        public List<Node> GetChildren()
        {
            return this.Children;
        }

        public int CountChildren()
        {
            return this.Children.Count;
        }

        public void SetParent(Node Parent)
        {
            this.Parent = Parent;
        }

        public Node GetParent()
        {
            return this.Parent;
        }

        public Node FindChild(int XCoordinate, int YCoordinate, int epsilon = 10)
        {
            return new Node();
        }

        public int[] FindBestCosts()
        {
            int label = (this.Level + 1) % 2; // 0 -> A, 1 -> B
            List<Node> TempChildren = new List<Node>(this.Children);
            TempChildren.Sort(
                (x, y) => x.Costs[label].CompareTo(y.Costs[label])
            );
            return TempChildren[TempChildren.Count - 1].Costs;
        }
    }

    public interface IAction
    {
        void Function(Node node1, Node node2 = null);
    }

    public class FindNodeAction : IAction
    {
        // Передается нода содержащая только координаты 
        // node1 - текущая, node2 - на которую нажали
        public void Function(Node node1, Node node2 = null)
        {
            Main main = new Main();
            if (Math.Abs(node1.GetX() - node2.GetX()) <= main.GetNodeSize() && Math.Abs(node1.GetY() - node2.GetY()) <= main.GetNodeSize())
            {
                main.SetCheckedNode(node1);
            }
        }
    }

    public class RecalculateNodesAction : IAction
    {
        public void Function(Node node1, Node node2 = null)
        {
            // господи боже
        }
    }

    //public class DrawNodeAction : IAction
    //{
    //    public void Function(Node node1, Node node2 = null)
    //    {
    //        // тупо рисуем ноду
    //        Main main = new Main();
    //        main.DrawNode(node1.GetX(), node2.GetY());
    //    }
    //}
}
