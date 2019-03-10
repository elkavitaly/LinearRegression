using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace LinearRegression
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			CreateChart();
		}

		private void CreateChart()
		{
			double[][] matr = Read();
			double[] a1 = new double[matr.Length];
			double[] a2 = new double[matr.Length];
			for (int i = 0; i < matr.Length; i++)
			{
				a1[i] = matr[i][0];
				a2[i] = matr[i][1];
			}
			//double[] a1 = new double[] { 3, 5, 4, 10, 4.6, 8.5, 6.2, 7.9, 1, 2.8 };
			//double[] a2 = new double[] { 6, 8.3, 5.8, 17.6, 6.5, 9.7, 10.2, 16, 2.7, 5.5 };
			Regression r = new Regression(a1, a2);
			textBox1.Text = "Коэффициент детерминации: " + r.Determinate + "\nОстаточная дисперсия: " + r.MaxRest;
			Series series1 = new Series();
			series1.ChartType = SeriesChartType.Point;
			series1.Palette = ChartColorPalette.Fire;
			for (int i = 0; i < r.Length; i++)
				series1.Points.AddXY(r.X[i], r.Y[i]);
			chart.Series.Add(series1);
			Series series = new Series();
			series.ChartType = SeriesChartType.Line;
			series.Palette = ChartColorPalette.Berry;
			for (int i = 0; i < r.Length; i++)
				series.Points.AddXY(r.X[i], r.RegPoints[i]);
			chart.Series.Add(series);
		}

		private double[][] Read()
		{
			List<string> list = new List<string>();
			using (StreamReader r = new StreamReader(@"fgh.txt")) 
			{
				string l;
				while ((l = r.ReadLine()) != null)
				{
					list.Add(l);
				}
			}
			double[][] matr = new double[list.Count][];
			for (int i = 0; i < matr.Length; i++)
			{
				string[] a1 = list[i].Split(',');
				matr[i] = new double[2];
				string s1 = a1[0].Replace('.', ',');
				string s2 = a1[2].Replace('.', ',');
				matr[i][0] = Convert.ToDouble(s1)/2;
				matr[i][1] = Convert.ToDouble(s2)/2;
			}
			return matr;
		}
	}
}
