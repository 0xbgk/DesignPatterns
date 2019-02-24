using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDesign
{
	// Bir strategy belirleyip, o strategy ye göre methodun calıstırılma olayıdır.
	class Program
	{
		static void Main(string[] args)
		{
			CustomerManager customerManager = new CustomerManager();
			customerManager.CreditCalculatorBase = new After2010CreditCalcultor();
			customerManager.SaveCredit();


			customerManager.CreditCalculatorBase = new Before2010CreditCalcultor();
			customerManager.SaveCredit();

			Console.ReadLine();
		}
	}

	abstract class CreditCalculatorBase
	{
		public abstract void Calculate();
	}

	class Before2010CreditCalcultor : CreditCalculatorBase
	{
		public override void Calculate()
		{			
			Console.WriteLine("Credit Calculated using before 2010");
		}
	}

	class After2010CreditCalcultor : CreditCalculatorBase
	{
		public override void Calculate()
		{
			Console.WriteLine("Credit Calculated using after 2010");
		}
	}

	class CustomerManager
	{
		public CreditCalculatorBase CreditCalculatorBase { get; set; }

		public void SaveCredit()
		{
			Console.WriteLine("Customer manager business");
			CreditCalculatorBase.Calculate();
		}
	}
}
