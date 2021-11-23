using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace cg_task4
{
    public partial class Form1 : Form
    {
        private const int FPS = 30;
        private const float FONT_SIZE = 12f;

        private readonly Pen normalPen = new Pen(Color.Black, 2);
        private readonly Pen selectedPen = new Pen(Color.Red, 2);
        private readonly Brush fontBrush = new SolidBrush(Color.Black);
        private readonly Font font = new Font(FontFamily.GenericMonospace, FONT_SIZE, FontStyle.Bold);

        private PaintCell[] cells = new PaintCell[0];
        private float cellSize;

        private Action[] actions = new Action[0];
        private int actionIndex = 0;
        private int swapCount = 0;
        private int compCount = 0;

        private int swapIndex1 = -1, swapIndex2 = -1;
        private float centerX, centerY, radius;
        private double t, dt;

        public Form1()
        {
            InitializeComponent();
            timer.Interval = 1000 / FPS;
            timer.Tick += PaintFrame;
            timer.Start();
        }

        private void PaintFrame(object sender, EventArgs e)
        {
            int w = pictureBox.Width, h = pictureBox.Height;
            if (w == 0 || h == 0)
            {
                return;
            }
            CalcSwapCoords();
            Image image = new Bitmap(w, h);
            using Graphics g = Graphics.FromImage(image);
            g.Clear(pictureBox.BackColor);
            PaintCells(g, w, h, false);
            PaintCells(g, w, h, true);
            pictureBox.Image?.Dispose();
            pictureBox.Image = image;
        }

        private void PaintCells(Graphics g, int w, int h, bool selected)
        {
            Pen pen = selected ? selectedPen : normalPen;
            foreach (var cell in cells)
            {
                if (cell.IsSelected != selected)
                {
                    continue;
                }
                float startX = cell.LocationX * w, startY = cell.LocationY * h;
                float sizeX = cellSize * w, sizeY = cellSize * h;
                g.DrawRectangle(pen, startX, startY, sizeX, sizeY);
                g.DrawString(cell.StrValue, font, fontBrush,
                    startX + sizeX / 2 - FONT_SIZE * cell.StrValue.Length / 2,
                    startY + sizeY / 2 - FONT_SIZE / 2);
            }
        }

        private void CalcSwapCoords()
        {
            if (swapIndex1 != -1 && swapIndex2 != -1)
            {
                float cos = (float)Math.Cos(t);
                float sin = (float)Math.Sin(t);
                cells[swapIndex1].LocationX = centerX - radius * cos;
                cells[swapIndex1].LocationY = centerY - radius * sin;
                cells[swapIndex2].LocationX = centerX + radius * cos;
                cells[swapIndex2].LocationY = centerY + radius * sin;

                t += dt;
                if (t > Math.PI + 1e-6)
                {
                    swapIndex1 = swapIndex2 = -1;
                }
            }
        }

        private void Swap(int i, int j)
        {
            int f = Math.Min(i, j);
            int s = Math.Max(i, j);
            swapIndex1 = f;
            swapIndex2 = s;
            radius = (cells[s].LocationX - cells[f].LocationX) / 2;
            centerX = (cells[s].LocationX + cells[f].LocationX) / 2;
            centerY = cells[f].LocationY;
            t = 0;
            dt = Math.PI / FPS;
        }

        private void ForwardButton_Click(object sender, EventArgs e)
        {
            if (swapIndex1 != -1 && swapIndex2 != -1)
            {
                t = Math.PI;
                CalcSwapCoords();
            }
            if (actionIndex < actions.Length)
            {
                Action action = actions[actionIndex++];
                switch (action.Operation)
                {
                    case Operation.SELECT:
                        {
                            cells[action.I].IsSelected = true;
                            cells[action.J].IsSelected = true;
                            compLabel.Text = (++compCount).ToString();
                            break;
                        }
                    case Operation.SWAP:
                        {
                            Swap(action.I, action.J);
                            swapLabel.Text = (++swapCount).ToString();
                            break;
                        }
                    case Operation.DESELECT:
                        {
                            cells[action.I].IsSelected = false;
                            cells[action.J].IsSelected = false;
                            ForwardButton_Click(sender, e);
                            break;
                        }
                }
            }
            else
            {
                MessageBox.Show("Array is sorted!");
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            if (swapIndex1 != -1 && swapIndex2 != -1)
            {
                t = Math.PI;
                CalcSwapCoords();
            }
            if (actionIndex > 0)
            {
                Action action = actions[--actionIndex];
                switch (action.Operation)
                {
                    case Operation.SELECT:
                        {
                            cells[action.I].IsSelected = false;
                            cells[action.J].IsSelected = false;
                            compLabel.Text = (--compCount).ToString();
                            BackButton_Click(sender, e);
                            break;
                        }
                    case Operation.SWAP:
                        {
                            Swap(action.I, action.J);
                            swapLabel.Text = (--swapCount).ToString();
                            break;
                        }
                    case Operation.DESELECT:
                        {
                            cells[action.I].IsSelected = true;
                            cells[action.J].IsSelected = true;
                            break;
                        }
                }
            }
            else
            {
                MessageBox.Show("Start of the sort!");
            }
        }

        private void Panel_Resize(object sender, EventArgs e)
        {
            textBox.Width = ((Panel)sender).Width - 285;
        }

        private void ReadButton_Click(object sender, EventArgs e)
        {
            int[] arr = textBox.Text.Split().Select(x => int.Parse(x)).ToArray();
            cells = new PaintCell[arr.Length];
            float locationX = 0.1f;
            cellSize = 0.8f / arr.Length;
            float locationY = 0.5f - cellSize / 2;
            for (int i = 0; i < arr.Length; i++)
            {
                cells[i] = new PaintCell(locationX, locationY, arr[i], false);
                locationX += cellSize;
            }
            swapCount = compCount = 0;
            compLabel.Text = swapCount.ToString();
            swapLabel.Text = compCount.ToString();
            actions = Sorts.StoogeSort(arr);
        }
    }
}
