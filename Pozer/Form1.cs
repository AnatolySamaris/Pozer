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
        private int EndNodeSize = 8;
        private int paintingZeroX = 0;
        private int paintingZeroY = 35;

        private Node Root;
        private int TreeHeight = 1;

        private Node CheckedNode;
        //private Node CurrentNode;

        private bool Start = false;
        Form CostsForm;
        TextBox CostA;

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

            else if (draw == true && calculate == true)
            {
                RecalculateNode(root);
                DrawNode(root);
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

                else if (draw == true && calculate == true)
                {
                    GraphTraverse(root: child, draw: true, calculate: true);
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

        private void CreateNode(Node Parent = null, bool EndNode = false)
        {
            if (Parent == null)
            {
                this.Root = new Node(1);
            }
            else
            {
                Node node = new Node(Parent.GetLevel() + 1, Parent);
                if (EndNode) node.SetEndNode(EndNode);
                Parent.AddChild(node);
                //Parent.AddChild(
                //    new Node(Parent.GetLevel() + 1, Parent)
                //);
            }

            UpdateTreeHeight();
        }

        public void DrawNode(Node node)
        {
            if (node.GetEndNode())
            {
                // сама нода
                graphics.FillEllipse(
                Brushes.Black,
                node.GetX(), node.GetY(),
                EndNodeSize, EndNodeSize);

                if (node.GetLevel() > 1)
                {
                    graphics.DrawLine(
                        Pens.Black,
                        node.GetX() + EndNodeSize / 2,
                        node.GetY(),
                        node.GetParent().GetX() + NodeSize / 2,
                        node.GetParent().GetY() + NodeSize);
                }
            }
            else
            {
                // сама нода
                graphics.DrawEllipse(
                Pens.Black,
                node.GetX(), node.GetY(),
                NodeSize, NodeSize);

                // надпись
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

                if (node.GetLevel() > 1)
                {
                    graphics.DrawLine(
                        Pens.Black,
                        node.GetX() + NodeSize / 2,
                        node.GetY(),
                        node.GetParent().GetX() + NodeSize / 2,
                        node.GetParent().GetY() + NodeSize);
                }
            }
        }

        private void DrawGraph()
        {
            graphics = CreateGraphics();
            graphics.Clear(Color.White);
            GraphTraverse(root: this.Root, draw: true, calculate: true);
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
            if (!Start)
            {
                Start = true;
                this.start.BackColor = Color.Gray;
            }
            else
            {
                Start = false;
                this.start.BackColor = Color.White;
            }
        }

        // Обработка клика правой кнопкой на ноду
        private void Main_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int X = e.X;
                int Y = e.Y;

                Node node = new Node(X, Y);
                GraphTraverse(root: this.Root, node: node, search: true);

                if (!Start)
                {
                    if (CheckedNode != null && !CheckedNode.GetEndNode())
                    {
                        ToolStripMenuItem contextMenuItemChild = new ToolStripMenuItem("Добавить ребенка");
                        ToolStripMenuItem contextMenuItemList = new ToolStripMenuItem("Добавить лист");
                        ContextMenuStrip contextMenu = new ContextMenuStrip();

                        int ContextMenuX = this.Location.X + CheckedNode.GetX() + NodeSize;
                        int ContextMenuY = this.Location.Y + CheckedNode.GetY() + NodeSize * 2;

                        contextMenu.Items.AddRange(new[] { contextMenuItemChild, contextMenuItemList });
                        contextMenu.Show(new Point(ContextMenuX, ContextMenuY));
                        contextMenuItemChild.Click += contextMenuItemChild_Click;
                        contextMenuItemList.Click += contextMenuItemList_Click;
                    }
                }
                else
                {
                    Form CostsForm = new Form();

                    int CostsFormX = this.Location.X + CheckedNode.GetX() + NodeSize;
                    int CostsFormY = this.Location.Y + CheckedNode.GetY() + NodeSize * 2;

                    int CostWidth = 40;
                    int CostHeight = 10;

                    CostsForm.StartPosition = FormStartPosition.Manual;
                    CostsForm.Location = new Point(CostsFormX, CostsFormY);
                    CostsForm.FormBorderStyle = FormBorderStyle.None;
                    CostsForm.Width = 200;
                    CostsForm.Height = 100;
                    //CostsForm.BackColor = Color.White;

                    Label CostsText = new Label();
                    CostsText.Text = "Задать выигрыш: ";
                    CostsText.Font = new Font("Arial", 10);
                    CostsText.Location = (new Point(5, 5));
                    CostsText.AutoSize = true;
                    CostsForm.Controls.Add(CostsText);

                    Label LeftBraket = new Label();
                    LeftBraket.Text = "(";
                    LeftBraket.AutoSize = true;
                    LeftBraket.Location = (new Point(20, 26));
                    LeftBraket.Font = new Font("Arial", 16);
                    CostsForm.Controls.Add(LeftBraket);

                    TextBox CostA = new TextBox();
                    CostA.Location = (new Point(40, 30));
                    CostA.Width = CostWidth;
                    CostA.Height = CostHeight;
                    CostsForm.Controls.Add(CostA);

                    Label Separator = new Label();
                    Separator.Text = ";";
                    Separator.AutoSize = true;
                    Separator.Location = (new Point(CostA.Location.X + CostWidth + 20, 26));
                    Separator.Font = new Font("Arial", 16);
                    CostsForm.Controls.Add(Separator);

                    TextBox CostB = new TextBox();
                    CostB.Location = (new Point(Separator.Location.X + 20, 30));
                    CostB.Width = CostWidth;
                    CostB.Height = CostHeight;
                    CostsForm.Controls.Add(CostB);

                    Label RightBraket = new Label();
                    RightBraket.Text = ")";
                    RightBraket.AutoSize = true;
                    RightBraket.Location = (new Point(CostB.Location.X + CostWidth + 20, 26));
                    RightBraket.Font = new Font("Arial", 16);
                    CostsForm.Controls.Add(RightBraket);

                    Button SetCostButton = new Button();
                    SetCostButton.Text = "Ок";
                    SetCostButton.Location = (new Point(130, 70));
                    SetCostButton.Width = 50;
                    SetCostButton.Height = 25;
                    SetCostButton.Font = new Font("Arial", 10);
                    CostsForm.Controls.Add(SetCostButton);
                    SetCostButton.Click += SetCostButton_Click;

                    CostsForm.ShowDialog();
                }
            }
        }

        private void contextMenuItemChild_Click(object sender, EventArgs e)
        {
            CreateNode(CheckedNode);
            DrawGraph();
        }

        private void contextMenuItemList_Click(object sender, EventArgs e)
        {
            CreateNode(CheckedNode, true);
            DrawGraph();
        }

        private void SetCostButton_Click(object sender, EventArgs e)
        {
            
        }

        private void Main_Paint(object sender, PaintEventArgs e)
        {
            graphics = CreateGraphics();
            if (this.Root == null) CreateNode();
            DrawGraph();
        }
    }


    public class Node
    {
        private Node Parent;
        private int Level;  // определяем лейблы по правилу ((level + 1) % 2 == 0) ? "A" : "B"
        int[] Costs = new int[2];   // выигрыши А и В соответственно
        private List<Node> Children = new List<Node>();
        private int XCoordinate, YCoordinate;
        bool EndNode;

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

        public void SetEndNode(bool EndNode)
        {
            this.EndNode = EndNode;
        }

        public bool GetEndNode()
        {
            return this.EndNode;
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
}
