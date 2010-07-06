using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace TravelingSalesman
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            tabControl.SelectedIndex = 1;
            cboGraphType.SelectedIndex = 0;
            cboAlgorithm.SelectedIndex = 6;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (cboGraphType.SelectedIndex == 4)
                selectedPointList = customPointList;

            if (selectedPointList.Count < 2)
                return;

            PointList result = selectedAlgorithm(selectedPointList);
            displayList(result);
            displayGraph(result);
            
            result.RemoveAt(result.Count - 1);
            lblCost.Text = TspTest.CalculateCost(result).ToString("#,##0");
        }

        private void displayList(PointList points)
        {
            txtResults.Clear();
            foreach (Point p in points)
                txtResults.AppendText(p.ToString() + "\t\n");
        }

        private void displayGraph(PointList points)
        {
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            SolidBrush redBrush = new SolidBrush(Color.Red);
            Pen pen = new Pen(blackBrush, 1);
            Pen arrowPen = new Pen(new SolidBrush(Color.Gray), 6);
            arrowPen.DashStyle = DashStyle.Solid;
            arrowPen.SetLineCap(LineCap.NoAnchor, LineCap.ArrowAnchor, DashCap.Flat);
            
            Graphics graphics = picGraph.CreateGraphics();
            graphics.Clear(Color.White);

            foreach (Point p in points)
                drawPoint(graphics, blackBrush, p);

            for (int i = 0; i < points.Count - 1; i++)
                drawArc(graphics, pen, arrowPen, points[i], points[i + 1]);

            if (points.Count > 0)
                drawPoint(graphics, redBrush, points[0]);

            pen.Dispose();
            blackBrush.Dispose();
            redBrush.Dispose();
            graphics.Dispose();
        }

        private void drawPoint(Graphics graphics, SolidBrush brush, Point p)
        {
            const int s = 5;
            graphics.FillEllipse(brush, new Rectangle((int)p.X - s, (int)p.Y - s, 2 * s, 2 * s));
        }

        private void drawArc(Graphics graphics, Pen pen, Pen arrowPen, Point a, Point b)
        {
            const decimal f = 0.05m;
            Point c = new Point((a.X + b.X) / 2m + f * (b.Y - a.Y), (a.Y + b.Y) / 2m - f * (b.X - a.X));
            double angle = Math.Atan2((double)(b.Y - c.Y), (double)(b.X - c.X));
            Point d = new Point(b.X - 10 * (decimal)Math.Cos(angle), b.Y - 10 * (decimal)Math.Sin(angle));

            graphics.DrawCurve(pen, new PointF[] { a.ToPointF(), c.ToPointF(), b.ToPointF() }, 1f);
            graphics.DrawLine(arrowPen, d.ToPointF(), b.ToPointF());
        }

        private void cboGraphType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboGraphType.SelectedIndex)
            {
                case 0:
                    selectedPointList = TspTest.Cycle;
                    break;
                case 1:
                    selectedPointList = TspTest.StraightLine;
                    break;
                case 2:
                    selectedPointList = TspTest.RowsAndColumns;
                    break;
                case 3:
                    selectedPointList = new PointList(TspTest.Cycle);
                    selectedPointList.AddRange(TspTest.StraightLine);
                    selectedPointList.AddRange(TspTest.RowsAndColumns);
                    selectedPointList.AddRange(new PointList(selectedPointList.ConvertAll(p => new Point(p.Y + 260, p.X + 30))));
                    break;
                case 4:
                    selectedPointList = customPointList;
                    break;
            }
        }

        private void cboAlgorithm_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboAlgorithm.SelectedIndex)
            {
                case 0:
                    selectedAlgorithm = TspTest.NearestNeighbor;
                    break;
                case 1:
                    selectedAlgorithm = TspTest.NearestNeighborAll;
                    break;
                case 2:
                    selectedAlgorithm = TspTest.ClosestPair;
                    break;
                case 3:
                    selectedAlgorithm = TspTest.OptimalTsp;
                    break;
                case 4:
                    selectedAlgorithm = TspTest.IncrementalInsertion;
                    break;
                case 5:
                    selectedAlgorithm = TspTest.IncrementalInsertionAll;
                    break;
                case 6:
                    selectedAlgorithm = TspTest.RoughScan;
                    break;
                case 7:
                    selectedAlgorithm = TspTest.Scan;
                    break;
                case 8:
                    selectedAlgorithm = TspTest.RadialScan;
                    break;
                case 9:
                    selectedAlgorithm = TspTest.RandomPath;
                    break;
            }
        }
        
        protected delegate PointList Algorithm(PointList inputList);

        private PointList selectedPointList;
        private Algorithm selectedAlgorithm;
        private PointList customPointList = new PointList();

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnPermutations_Click(object sender, EventArgs e)
        {
            txtResults.Clear();
            foreach (PointList permutation in TspTest.AllPermutations(selectedPointList))
                txtResults.AppendText(permutation.ToString() + "\t\n");
        }

        private void picDrawGraph_MouseClick(object sender, MouseEventArgs e)
        {
            if (btnStartStop.Text == "Start")
                return;

            Point p = new Point(e.X, e.Y);
            customPointList.Add(p);

            Graphics graphics = picDrawGraph.CreateGraphics();
            SolidBrush blackBrush = new SolidBrush(Color.Black);

            drawPoint(graphics, blackBrush, p);
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            btnStartStop.Text = (btnStartStop.Text == "Start" ? "Stop" : "Start");

            if (btnStartStop.Text == "Start")
                return;

            SolidBrush blackBrush = new SolidBrush(Color.Black);

            Graphics graphics = picDrawGraph.CreateGraphics();
            graphics.Clear(Color.White);

            foreach (Point p in customPointList)
                drawPoint(graphics, blackBrush, p);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Graphics graphics = picDrawGraph.CreateGraphics();
            graphics.Clear(Color.White);
            customPointList = new PointList();
        }
    }
}
