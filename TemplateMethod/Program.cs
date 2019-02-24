using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
	// İçiçe onlarca if bloğu yazmaktansa, hızlıca bir şablon olusturup o şablonun soyutlanması ve o soyuta somutların atanması seklinde gerceklesen design.
	class Program
	{
		static void Main(string[] args)
		{
			ScoringAlgorithm algorithm;
			Console.WriteLine("Men");
			algorithm = new MenScoringAlgorith();
			Console.WriteLine(algorithm.GenerateScore(10,new TimeSpan(0, 2, 34)));

			Console.WriteLine("Women");
			algorithm = new WomenScoringAlgorith();
			Console.WriteLine(algorithm.GenerateScore(10, new TimeSpan(0, 2, 34)));

			Console.WriteLine("Children");
			algorithm = new ChildrenScoringAlgorith();
			Console.WriteLine(algorithm.GenerateScore(10, new TimeSpan(0, 2, 34)));

			Console.ReadLine();
		}
	}

	abstract class ScoringAlgorithm
	{
		// Template Methodumuz
		public int GenerateScore(int hits, TimeSpan time)
		{
			int score = CalculateBaseScore(hits);
			int reduction = CalculateReduction(time);

			return CalculateOverallScore(score, reduction);
		}

		public abstract int CalculateOverallScore(int score, int reduction);

		public abstract int CalculateReduction(TimeSpan time);		

		public abstract int CalculateBaseScore(int hits);		
	}

	class MenScoringAlgorith : ScoringAlgorithm
	{
		public override int CalculateBaseScore(int hits)
		{
			return hits * 100;
		}

		public override int CalculateOverallScore(int score, int reduction)
		{
			return score - reduction;
		}

		public override int CalculateReduction(TimeSpan time)
		{
			return Convert.ToInt32(time.TotalSeconds / 5);
		}
	}

	class WomenScoringAlgorith : ScoringAlgorithm
	{
		public override int CalculateBaseScore(int hits)
		{
			return hits * 100;
		}

		public override int CalculateOverallScore(int score, int reduction)
		{
			return score - reduction;
		}

		public override int CalculateReduction(TimeSpan time)
		{
			return Convert.ToInt32(time.TotalSeconds / 3);
		}
	}

	class ChildrenScoringAlgorith : ScoringAlgorithm
	{
		public override int CalculateBaseScore(int hits)
		{
			return hits * 90;
		}

		public override int CalculateOverallScore(int score, int reduction)
		{
			return score - reduction;
		}

		public override int CalculateReduction(TimeSpan time)
		{
			return Convert.ToInt32(time.TotalSeconds / 2);
		}
	}
}
