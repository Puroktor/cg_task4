using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace cg_task4;

public partial class Form1 : Form
{
    private const int FPS = 30;
    private const float FONT_SIZE = 12f;

    private readonly Pen normalPen = new(Color.Black, 2);
    private readonly Pen selectedPen = new(Color.Red, 2);
    private readonly Brush fontBrush = new SolidBrush(Color.Black);
    private readonly Font font = new(FontFamily.GenericMonospace, FONT_SIZE, FontStyle.Bold);

    private PaintCell[] cells = Array.Empty<PaintCell>();
    private float cellSize;
    private int selectedI = -1, selectedJ = -1;

    private Action[] actions = Array.Empty<Action>();
    private int actionIndex, swapCount, compCount;

    private int swapIndex1 = -1, swapIndex2 = -1;
    private float centerX, centerY, radius;
    private double t, dt;

    public Form1()
    {
        InitializeComponent();
        AcceptButton = readButton;
        timer.Interval = 1000 / FPS;
        timer.Tick += PaintFrame;
        actionTimer.Interval = 1500;
        actionTimer.Tick += ActionTimer_Tick;
        timer.Start();
    }

    private void ActionTimer_Tick(object sender, EventArgs e)
    {
        if (actionIndex == actions.Length)
            StopActionTimer();
        ForwardButton_Click(sender, e);
    }

    private void PaintFrame(object sender, EventArgs e)
    {
        int w = pictureBox.Width, h = pictureBox.Height;
        if (w == 0 || h == 0)
            return;

        CalcSwapCoords();
        Image image = new Bitmap(w, h);
        using Graphics g = Graphics.FromImage(image);
        g.Clear(pictureBox.BackColor);
        PaintCells(g, w, h);
        pictureBox.Image?.Dispose();
        pictureBox.Image = image;
    }

    private void PaintCells(Graphics g, int w, int h)
    {
        for (int i = 0; i < cells.Length; i++)
        {
            if (i == selectedI || i == selectedJ)
                continue;

            PaintCell(cells[i], g, w, h, normalPen);
        }
        if (selectedI != -1)
            PaintCell(cells[selectedI], g, w, h, selectedPen);
        if (selectedJ != -1)
            PaintCell(cells[selectedJ], g, w, h, selectedPen);
    }

    private void PaintCell(PaintCell cell, Graphics g, int w, int h, Pen pen)
    {
        float startX = cell.LocationX * w, startY = cell.LocationY * h;
        float sizeX = cellSize * w, sizeY = cellSize * h;
        g.DrawRectangle(pen, startX, startY, sizeX, sizeY);
        g.DrawString(cell.StrValue, font, fontBrush,
            startX + sizeX / 2 - FONT_SIZE * cell.StrValue.Length / 2,
            startY + sizeY / 2 - FONT_SIZE / 2);
    }

    private void CalcSwapCoords()
    {
        if (!(swapIndex1 == -1 || swapIndex2 == -1))
        {
            float cos = (float)Math.Cos(t);
            float sin = (float)Math.Sin(t);
            cells[swapIndex1].LocationX = centerX - radius * cos;
            cells[swapIndex1].LocationY = centerY - radius * sin;
            cells[swapIndex2].LocationX = centerX + radius * cos;
            cells[swapIndex2].LocationY = centerY + radius * sin;

            t += dt;
            if (t > Math.PI + 1e-7)
                swapIndex1 = swapIndex2 = -1;
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
        if (sender is not Timer && actionTimer.Enabled)
            StopActionTimer();

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
                case Operation.COMPARE:
                    selectedI = action.I;
                    selectedJ = action.J;
                    compLabel.Text = (++compCount).ToString();
                    break;

                case Operation.SWAP:
                    Swap(action.I, action.J);
                    swapLabel.Text = (++swapCount).ToString();
                    break;

            }
        }
        else
        {
            selectedI = selectedJ = -1;
            MessageBox.Show("Array is sorted!");
        }
    }

    private void BackButton_Click(object sender, EventArgs e)
    {
        if (actionTimer.Enabled)
            StopActionTimer();
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
                case Operation.COMPARE:
                    selectedI = selectedJ = -1;
                    GoTillCompare();
                    compLabel.Text = (--compCount).ToString();
                    break;

                case Operation.SWAP:
                    Swap(action.I, action.J);
                    swapLabel.Text = (--swapCount).ToString();
                    break;

            }
        }
        else
            MessageBox.Show("Start of the sort!");
    }

    private void GoTillCompare()
    {
        for (int i = actionIndex - 1; i >= 0; i--)
        {
            Action action = actions[i];
            if (action.Operation == Operation.COMPARE)
            {
                selectedI = action.I;
                selectedJ = action.J;
                break;
            }
        }
    }

    private void Panel_Resize(object sender, EventArgs e) => textBox.Width = ((Panel)sender).Width - 450;

    private void ReadButton_Click(object sender, EventArgs e)
    {
        int[] arr = textBox.Text.Split().Select(x => int.Parse(x)).ToArray();
        cells = new PaintCell[arr.Length];
        float locationX = 0.1f;
        cellSize = 0.8f / arr.Length;
        float locationY = 0.5f - cellSize / 2;
        for (int i = 0; i < arr.Length; i++)
        {
            cells[i] = new PaintCell(locationX, locationY, arr[i]);
            locationX += cellSize;
        }
        StopActionTimer();
        swapIndex1 = swapIndex2 = -1;
        t = actionIndex = swapCount = compCount = 0;
        compLabel.Text = compCount.ToString();
        swapLabel.Text = swapCount.ToString();
        selectedI = selectedJ = -1;
        actions = Sorts.StoogeSort(arr);
    }

    private void PlayButton_Click(object sender, EventArgs e)
    {
        actionTimer.Start();
        animationLabel.Text = "On";
        animationLabel.ForeColor = Color.Red;
        ActionTimer_Tick(actionTimer, e);
    }

    private void StopButton_Click(object sender, EventArgs e)
    {
        StopActionTimer();
        t = Math.PI;
        CalcSwapCoords();
    }

    private void StopActionTimer()
    {
        actionTimer.Stop();
        animationLabel.Text = "Off";
        animationLabel.ForeColor = Color.Black;
    }
}

