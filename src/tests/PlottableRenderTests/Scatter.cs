﻿using NUnit.Framework;
using ScottPlot;
using ScottPlot.Plottable;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScottPlotTests.PlottableRenderTests
{
    class Scatter
    {
        [Test]
        public void Test_Scatter_ChangeData()
        {
            var plt = new ScottPlot.Plot();

            // start with default settings
            double[] xs = { 1, 2, 3, 4 };
            double[] ys = { 1, 4, 9, 16 };
            var splt = new ScatterPlot(xs, ys) { };

            plt.Add(splt);
            var bmp1 = TestTools.GetLowQualityBitmap(plt);

            // change the plottable
            splt.Ys[0] += 1;
            var bmp2 = TestTools.GetLowQualityBitmap(plt);

            // measure what changed
            //TestTools.SaveFig(bmp1, "1");
            //TestTools.SaveFig(bmp2, "2");
            var before = new MeanPixel(bmp1);
            var after = new MeanPixel(bmp2);
            Console.WriteLine($"Before: {before}");
            Console.WriteLine($"After: {after}");

            Assert.That(after.IsLighterThan(before));
        }

        [Test]
        public void Test_Scatter_ChangeErrorData()
        {
            var plt = new ScottPlot.Plot();

            // start with default settings
            double[] xs = { 1, 2, 3, 4 };
            double[] ys = { 1, 4, 9, 16 };
            double[] xErr = { .15, .15, .5, .5 };
            double[] yErr = { .5, .5, 1, 1 };
            var splt = new ScatterPlot(xs, ys, xErr, yErr) { };

            plt.Add(splt);
            var bmp1 = TestTools.GetLowQualityBitmap(plt);

            // change the plottable
            splt.XError[0] += .1;
            splt.YError[0] += .1;
            var bmp2 = TestTools.GetLowQualityBitmap(plt);

            // measure what changed
            //TestTools.SaveFig(bmp1, "1");
            //TestTools.SaveFig(bmp2, "2");
            var before = new MeanPixel(bmp1);
            var after = new MeanPixel(bmp2);
            Console.WriteLine($"Before: {before}");
            Console.WriteLine($"After: {after}");

            Assert.That(after.IsDarkerThan(before));
        }

        [Test]
        public void Test_Scatter_LineWidth()
        {
            var plt = new ScottPlot.Plot();

            // start with default settings
            double[] xs = { 1, 2, 3, 4 };
            double[] ys = { 1, 4, 9, 16 };
            double[] xErr = { .15, .15, .5, .5 };
            double[] yErr = { .5, .5, 1, 1 };
            var splt = new ScatterPlot(xs, ys, xErr, yErr) { };

            plt.Add(splt);
            var bmp1 = TestTools.GetLowQualityBitmap(plt);

            // change the plottable
            splt.LineWidth += 1;
            var bmp2 = TestTools.GetLowQualityBitmap(plt);

            // measure what changed
            //TestTools.SaveFig(bmp1, "1");
            //TestTools.SaveFig(bmp2, "2");
            var before = new MeanPixel(bmp1);
            var after = new MeanPixel(bmp2);
            Console.WriteLine($"Before: {before}");
            Console.WriteLine($"After: {after}");

            Assert.That(after.IsDarkerThan(before));
        }

        [Test]
        public void Test_Scatter_ErrorLineWidth()
        {
            var plt = new ScottPlot.Plot();

            // start with default settings
            double[] xs = { 1, 2, 3, 4 };
            double[] ys = { 1, 4, 9, 16 };
            double[] xErr = { .15, .15, .5, .5 };
            double[] yErr = { .5, .5, 1, 1 };
            var splt = new ScatterPlot(xs, ys, xErr, yErr) { };

            plt.Add(splt);
            var bmp1 = TestTools.GetLowQualityBitmap(plt);

            // change the plottable
            splt.ErrorLineWidth += 1;
            var bmp2 = TestTools.GetLowQualityBitmap(plt);

            // measure what changed
            //TestTools.SaveFig(bmp1, "1");
            //TestTools.SaveFig(bmp2, "2");
            var before = new MeanPixel(bmp1);
            var after = new MeanPixel(bmp2);
            Console.WriteLine($"Before: {before}");
            Console.WriteLine($"After: {after}");

            Assert.That(after.IsDarkerThan(before));
        }

        [Test]
        public void Test_Scatter_ErrorCapSize()
        {
            var plt = new ScottPlot.Plot();

            // start with default settings
            double[] xs = { 1, 2, 3, 4 };
            double[] ys = { 1, 4, 9, 16 };
            double[] xErr = { .15, .15, .5, .5 };
            double[] yErr = { .5, .5, 1, 1 };
            var splt = new ScatterPlot(xs, ys, xErr, yErr) { };

            plt.Add(splt);
            var bmp1 = TestTools.GetLowQualityBitmap(plt);

            // change the plottable
            splt.ErrorCapSize += 1;
            var bmp2 = TestTools.GetLowQualityBitmap(plt);

            // measure what changed
            //TestTools.SaveFig(bmp1, "1");
            //TestTools.SaveFig(bmp2, "2");
            var before = new MeanPixel(bmp1);
            var after = new MeanPixel(bmp2);
            Console.WriteLine($"Before: {before}");
            Console.WriteLine($"After: {after}");

            Assert.That(after.IsDarkerThan(before));
        }

        [Test]
        public void Test_Scatter_MarkerSize()
        {
            var plt = new ScottPlot.Plot();

            // start with default settings
            double[] xs = { 1, 2, 3, 4 };
            double[] ys = { 1, 4, 9, 16 };
            double[] xErr = { .15, .15, .5, .5 };
            double[] yErr = { .5, .5, 1, 1 };
            var splt = new ScatterPlot(xs, ys, xErr, yErr) { };

            plt.Add(splt);
            var bmp1 = TestTools.GetLowQualityBitmap(plt);

            // change the plottable
            splt.MarkerSize += 1;
            var bmp2 = TestTools.GetLowQualityBitmap(plt);

            // measure what changed
            //TestTools.SaveFig(bmp1, "1");
            //TestTools.SaveFig(bmp2, "2");
            var before = new MeanPixel(bmp1);
            var after = new MeanPixel(bmp2);
            Console.WriteLine($"Before: {before}");
            Console.WriteLine($"After: {after}");

            Assert.That(after.IsDarkerThan(before));
        }

        [Test]
        public void Test_Scatter_MarkerShape()
        {
            var plt = new ScottPlot.Plot();

            // start with default settings
            double[] xs = { 1, 2, 3, 4 };
            double[] ys = { 1, 4, 9, 16 };
            var splt = new ScatterPlot(xs, ys)
            {
                MarkerSize = 20,
                MarkerShape = MarkerShape.filledCircle
            };

            plt.Add(splt);
            var bmp1 = TestTools.GetLowQualityBitmap(plt);

            // change the plottable
            splt.MarkerShape = MarkerShape.openCircle;
            var bmp2 = TestTools.GetLowQualityBitmap(plt);

            // measure what changed
            //TestTools.SaveFig(bmp1, "1");
            //TestTools.SaveFig(bmp2, "2");
            var before = new MeanPixel(bmp1);
            var after = new MeanPixel(bmp2);
            Console.WriteLine($"Before: {before}");
            Console.WriteLine($"After: {after}");

            Assert.That(after.IsLighterThan(before));
        }

        [Test]
        public void Test_Scatter_Step()
        {
            var plt = new ScottPlot.Plot();

            // start with default settings
            double[] xs = { 1, 2, 3, 4 };
            double[] ys = { 1, 4, 9, 16 };
            var splt = new ScatterPlot(xs, ys) { };

            plt.Add(splt);
            var bmp1 = TestTools.GetLowQualityBitmap(plt);

            // change the plottable
            splt.StepDisplay = true;
            var bmp2 = TestTools.GetLowQualityBitmap(plt);

            // measure what changed
            //TestTools.SaveFig(bmp1, "1");
            //TestTools.SaveFig(bmp2, "2");
            var before = new MeanPixel(bmp1);
            var after = new MeanPixel(bmp2);
            Console.WriteLine($"Before: {before}");
            Console.WriteLine($"After: {after}");

            Assert.That(after.IsDarkerThan(before));
        }

        [Test]
        public void Test_Scatter_Arrow()
        {
            var plt = new ScottPlot.Plot();

            // start with default settings
            double[] xs = { 1, 2, 3, 4 };
            double[] ys = { 1, 4, 9, 16 };
            var splt = new ScatterPlot(xs, ys) { };

            plt.Add(splt);
            var bmp1 = TestTools.GetLowQualityBitmap(plt);

            // change the plottable
            splt.ArrowheadLength = 5;
            splt.ArrowheadWidth = 5;
            var bmp2 = TestTools.GetLowQualityBitmap(plt);

            // measure what changed
            //TestTools.SaveFig(bmp1, "1");
            //TestTools.SaveFig(bmp2, "2");
            var before = new MeanPixel(bmp1);
            var after = new MeanPixel(bmp2);
            Console.WriteLine($"Before: {before}");
            Console.WriteLine($"After: {after}");

            Assert.That(after.IsDarkerThan(before));
        }

        [Test]
        public void Test_Scatter_Color()
        {
            var plt = new ScottPlot.Plot();

            // start with default settings
            double[] xs = { 1, 2, 3, 4 };
            double[] ys = { 1, 4, 9, 16 };
            var splt = new ScatterPlot(xs, ys) { };

            plt.Add(splt);
            var bmp1 = TestTools.GetLowQualityBitmap(plt);

            // change the plottable
            splt.Color = System.Drawing.Color.Gray;
            var bmp2 = TestTools.GetLowQualityBitmap(plt);

            // measure what changed
            //TestTools.SaveFig(bmp1, "1");
            //TestTools.SaveFig(bmp2, "2");
            var before = new MeanPixel(bmp1);
            var after = new MeanPixel(bmp2);
            Console.WriteLine($"Before: {before}");
            Console.WriteLine($"After: {after}");

            Assert.That(after.IsLighterThan(before));
        }

        [Test]
        public void Test_Scatter_LineStyle()
        {
            var plt = new ScottPlot.Plot();

            // start with default settings
            double[] xs = { 1, 2, 3, 4 };
            double[] ys = { 1, 4, 9, 16 };
            var splt = new ScatterPlot(xs, ys) { };

            plt.Add(splt);
            var bmp1 = TestTools.GetLowQualityBitmap(plt);

            // change the plottable
            splt.LineStyle = LineStyle.Dash;
            var bmp2 = TestTools.GetLowQualityBitmap(plt);

            // measure what changed
            //TestTools.SaveFig(bmp1, "1");
            //TestTools.SaveFig(bmp2, "2");
            var before = new MeanPixel(bmp1);
            var after = new MeanPixel(bmp2);
            Console.WriteLine($"Before: {before}");
            Console.WriteLine($"After: {after}");

            Assert.That(after.IsLighterThan(before));
        }

        [Test]
        public void Test_Scatter_Highlight()
        {
            var plt = new ScottPlot.Plot(400, 300);

            // start with default settings
            double[] xs = { 1, 2, 3, 4 };
            double[] ys = { 1, 4, 9, 16 };
            var splt = new ScatterPlotHighlight(xs, ys) { highlightedMarkerSize = 20, highlightedColor = System.Drawing.Color.Black };

            plt.Add(splt);
            var bmp1 = TestTools.GetLowQualityBitmap(plt);

            // change the plottable
            splt.HighlightPointNearest(2.1, 4.1);
            var bmp2 = TestTools.GetLowQualityBitmap(plt);

            // measure what changed
            //TestTools.SaveFig(bmp1, "1");
            //TestTools.SaveFig(bmp2, "2");
            var before = new MeanPixel(bmp1);
            var after = new MeanPixel(bmp2);
            Console.WriteLine($"Before: {before}");
            Console.WriteLine($"After: {after}");

            Assert.That(after.IsDarkerThan(before));
        }
    }
}
