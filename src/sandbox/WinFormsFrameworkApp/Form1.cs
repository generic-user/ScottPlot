﻿using ScottPlot.Plottable;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsFrameworkApp
{
    public partial class Form1 : Form
    {
        private readonly HLine HLine;
        private readonly VLine VLine;
        private readonly SignalPlot Signal;

        public Form1()
        {
            InitializeComponent();

            // simulate 10 seconds of 48 kHz audio
            int sampleRate = 48_000;
            Random rand = new Random(0);
            double[] data = ScottPlot.DataGen.RandomWalk(rand, sampleRate * 10);
            Signal = formsPlot1.Plot.AddSignal(data, sampleRate);

            // markers to indicate where the mouse is
            HLine = formsPlot1.Plot.AddHorizontalLine(0, Color.Red, 1, ScottPlot.LineStyle.Dash);
            VLine = formsPlot1.Plot.AddVerticalLine(0, Color.Red, 1, ScottPlot.LineStyle.Dash);

            formsPlot1.Render();
        }

        private void FormsPlot1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.None)
                return; // don't move markers if actively panning or zooming

            double mouseX = formsPlot1.Plot.GetCoordinateX(e.X);
            (double x, double y, int index) = Signal.GetPointNearestX(mouseX);
            VLine.X = x;
            HLine.Y = y;
            Text = $"Mouse is over point {index:N0} ({x:.03}, {y:.03})";
            formsPlot1.Render();
        }
    }
}
