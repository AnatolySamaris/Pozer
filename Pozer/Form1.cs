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


        public Main()
        {
            InitializeComponent();
        }

        private void CreateNode(Node Parent = null)
        {
            int XCoordinate = this.paintingZeroX + this.Width / 2 - NodeSize;
            //int XCoordinate = this.paintingZeroX;
            int YCoordinate = this.paintingZeroY;

            if (Parent == null)
            {
                this.Root = new Node(1);
                this.Root.SetPosition(this.Width / 2, 0);

                this.CheckedNode = Root;
            }
            else
            {
                Parent.AddChild(
                    new Node(Parent.GetLevel() + 1, Parent)
                );

                bool IsNewRow = false;
                if (Parent.GetLevel() + 1 > this.TreeHeight)
                {
                    this.TreeHeight++;
                    IsNewRow = true;

                }

                int NumberOfChildren = Parent.CountChildren();
                List<Node> ParentChildren = Parent.GetChildren();

                int RestWidth = this.Width - NodeSize * NumberOfChildren;
                int SpaceBetweenHorizontal = RestWidth / (NumberOfChildren + 1);


                // Ставим X позицию для текущего ряда
                for (int i = 0; i < NumberOfChildren; i++)
                {
                    ParentChildren[i].SetX(SpaceBetweenHorizontal * (i + 1) + NodeSize * i);
                }
                
                // Ставим Y позицию для всех элементов кроме корня, если это новый ряд
                if (IsNewRow)
                {
                    int RestHeight = this.Height - this.paintingZeroY - NodeSize;
                    int SpaceBetweenVertical = RestHeight / this.Height;
                    for (int i = 0; i < this.Root.CountChildren(); i++)
                    {
                        Node node = Root.GetChildren()[i];
                        for (int j = 0; j < node.CountChildren(); j++)
                        {
                            node.SetY(SpaceBetweenVertical * (i + 1) + NodeSize * i);
                        }
                    }
                }
            }
        }

        private void DrawNode(int X, int Y)
        {
            graphics = CreateGraphics();
            graphics.DrawEllipse(
                Pens.Black,
                X, Y,
                NodeSize, NodeSize);
        }

        private void DrawGraph()
        {
            graphics = CreateGraphics();

            // рисуем начальную вершину
            graphics.DrawEllipse(
                Pens.Black,
                this.Root.GetX(),
                this.Root.GetY(),
                NodeSize, NodeSize);

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

                //Node CheckedNode = new Node();
                CheckedNode = FindNode(X, Y);

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
            Node Child = new Node();
            Child.SetParent(CheckedNode);
            CheckedNode.AddChild(Child);
        }

        // поиск вершины
        private Node FindNode(int X, int Y)
        {
            // массив для хранения количества посещенных детей на каждом
            // уровне
            int[] VisitedNodes = new int[TreeHeight];
            Array.Clear(VisitedNodes, 0, TreeHeight);
            Node CurrentNode = new Node(1);
            CurrentNode.SetPosition(paintingZeroX, paintingZeroY);
            Node CurrentChild = new Node();
            //CurrentNode = Root;

            //if (Math.Abs(CurrentChild.GetX() - X) <= 30 && Math.Abs(CurrentChild.GetY() - Y) <= 30)
            //{
            //    return CurrentNode;
            //}

            int Level = 1;
            while(true)
            {
                // проверены не все дети
                if (VisitedNodes[Level - 1] < CurrentNode.CountChildren())
                {
                    CurrentChild = CurrentNode.GetChildren()[VisitedNodes[Level - 1] - 1];
                    VisitedNodes[Level - 1]++;
                    Level++;
                    if (Math.Abs(CurrentChild.GetX() - X) <= 30 && Math.Abs(CurrentChild.GetY() - Y) <= 30)
                    {
                        return CurrentChild;
                    }
                    else
                    {
                        CurrentNode = CurrentChild;
                    }
                }

                //проверены все дети текущей вершины
                else
                {
                    if (CurrentNode.GetLevel() == 1)
                    {
                        if (Math.Abs(CurrentNode.GetX() - X) <= 30 && Math.Abs(CurrentNode.GetY() - Y) <= 30)
                        {
                            return CurrentNode;
                        }
                        else
                        {
                            return new Node(-1);
                        }
                    }
                    else
                    {
                        CurrentNode = CurrentChild.GetParent();
                        Level--;
                    }
                }

                //if (CurrentNode.GetLevel() == 1 && VisitedNodes.Length == CurrentNode.CountChildren())
                //{
                //    return new Node(-1);
                //}
            }
        }

        private void Main_Paint(object sender, PaintEventArgs e)
        {
            // пока что это исключительно для теста
            ///////////////////////////////////////////////
            
            // массив для хранения количества посещенных детей на каждом
            // уровне
            int[] VisitedNodes = new int[TreeHeight];
            Array.Clear(VisitedNodes, 0, TreeHeight);
            Node CurrentNode = new Node(1);
            CurrentNode.SetPosition(paintingZeroX, paintingZeroY);
            Node CurrentChild = new Node();
            //CurrentNode = Root;

            int Level = 1;
            while (true)
            {
                // проверены не все дети
                if (VisitedNodes[Level - 1] < CurrentNode.CountChildren())
                {
                    CurrentChild = CurrentNode.GetChildren()[VisitedNodes[Level - 1] - 1];
                    VisitedNodes[Level - 1]++;
                    Level++;
                    DrawNode(CurrentNode.GetX(), CurrentNode.GetY());
                }

                //проверены все дети текущей вершины
                else
                {
                    if (CurrentNode.GetLevel() == 1)
                    {
                        DrawNode(CurrentNode.GetX(), CurrentNode.GetY());
                        break;
                    }
                    else
                    {
                        CurrentNode = CurrentChild.GetParent();
                        Level--;
                    }
                }
            }

            ///////////////////////////////////////////////



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
}
