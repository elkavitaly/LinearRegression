using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearRegression
{
	class Regression
	{
		private double[] x, y, yT;
		private int length;
		private double averageX;
		private double averageY;
		private double k;
		private double b;
		private double covariation;
		private double corelation;
		private double determinate;
		private double restDispercy;

		public double[] RegPoints { get => yT; }
		public double[] X { get => x; }
		public double[] Y { get => y; }
		public int Length { get => length; }
		public double Determinate { get => determinate; }
		public double MaxRest { get => restDispercy; }
			

		public Regression(double[] a1, double[] a2)
		{
			x = a1;
			y = a2;
			length = x.Length;
			//k = Covariation() / DispercyX();
			Coefficient();
			b = averageY - k * averageX;
			RegLine();
			DeterminateCoefficient();
			Rest();
		}

		private double Covariation()
		{
			double sumXY = 0, sumX = 0, sumY = 0;

			for (int i = 0; i < x.Length; i++) 
			{
				sumXY += x[i] * y[i];
				sumX += x[i];
				sumY += y[i];
			}
			averageX = sumX / length;
			averageY = sumY / length;
			return sumXY / length - (averageX * averageY);
		}

		private double DispercyX()
		{
			double sum = 0;
			foreach (double num in x)
				sum += Math.Pow(Convert.ToDouble(num) - averageX, 2);
			return sum / (length - 1);
		}

		private double DispercyY()
		{
			double sum = 0;
			foreach (double num in y)
				sum += Math.Pow(Convert.ToDouble(num) - averageY, 2);
			return sum / (length - 1);
		}

		private void RegLine()
		{
			yT = new double[length];
			for (int i = 0; i < length; i++)
				yT[i] = k * x[i] + b;
		}

		private void Coefficient()
		{
			double sum1 = 0, sum2 = 0;

			double sumX = 0, sumY = 0;

			for (int i = 0; i < x.Length; i++)
			{
				sumX += x[i];
				sumY += y[i];
			}

			averageX = sumX / length;
			averageY = sumY / length;

			for (int i = 0; i < length; i++)
			{
				sum1 += (x[i] - averageX) * (y[i] - averageY);
				sum2 += Math.Pow(x[i] - averageX, 2);
			}

			k = sum1 / sum2;
		}

		private void CovariationCoefficient()
		{
			double sum = 0;
			for (int i = 0; i < length; i++) 
			{
				sum += (x[i] - averageX) * (y[i] - averageY);
			}
			covariation = sum / length;
		}

		private void CorelationCoefficient()
		{
			corelation = covariation / Math.Pow(DispercyX() * DispercyY(), 0.5);
		}

		private void DeterminateCoefficient()
		{
			CovariationCoefficient();
			CorelationCoefficient();
			determinate = Math.Pow(corelation, 2);
		}

		private void Rest()
		{
			double res = 0;
			for (int i = 0; i < length; i++)
			{
				res += Math.Pow(y[i] - k * x[i] - b, 2);
				//double c = y[i] - k * x[i] - b;
				//res = res < c ? c : res;
				//res += Math.Round(y[i] - k * x[i] - b, 5);
			}
			restDispercy = res / (length - 2);
			}
	}
}
