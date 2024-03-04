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

        private Node root;

   
        public Main()
        {
            InitializeComponent();
        }

        private void CreateNode(Node Parent = null)
        {
            int XCoordinate = this.paintingZeroX + this.Width / 2 - NodeSize;
            int YCoordinate = this.paintingZeroY;

            if (Parent != null)
            {
                Node child = new Node(Parent.GetLevel() + 1,Parent);

                int NumberOfChildren = Parent.CountChildren();
                List<Node> ParentChildren = Parent.GetChildren();

                int RestWidth = this.Width - NodeSize * NumberOfChildren;
                int SpaceBetweenHorizontal = RestWidth / (NumberOfChildren + 1);
                //XCoordinate = SpaceBetweenHorizontal * NumberOfChildren + NodeSize * (NumberOfChildren - 1);

                for (int i = 0; i < NumberOfChildren; i++)
                {
                    //ParentChildren[i].SetPosition(
                    //    SpaceBetweenHorizontal * (i + 1) + NodeSize * i,
                    //    
                    //);
                }

                //int RestHeight = this.Height - this.paintingZeroY - Parent.GetPosition()[1] - NodeSize;
                //int SpaceBetweenVertical = RestHeight / (NumberOfChildren + 1);
                //YCoordinate = SpaceBetweenHorizontal * NumberOfChildren + NodeSize * (NumberOfChildren - 1);
                YCoordinate = Parent.GetPosition()[1] + 100;
            }

            graphics = CreateGraphics();
            graphics.DrawEllipse(
                Pens.Black,
                XCoordinate,
                YCoordinate,
                NodeSize, NodeSize
            );
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

        private void Main_Paint(object sender, PaintEventArgs e)
        {
            paintingZeroX = this.paintingZeroX + this.Width / 2 - NodeSize;
            //this.CreateNode(paintingZeroX, paintingZeroY);
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
