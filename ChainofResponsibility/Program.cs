using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainofResponsibility
{
	// Belli sarta göre bizim devreye hangi nesneyi koyacagımızı gösterir.
	// Bu nesneler arasında hiyerarjik bir yapı olması bu desenin en temel özelliğidir.
	class Program
	{
		static void Main(string[] args)
		{
			Manager manager = new Manager();
			VicePresident vicePresident = new VicePresident();
			President president = new President();

			manager.SetSuccessor(vicePresident);
			vicePresident.SetSuccessor(president);

			Expense expense = new Expense();
			expense.Detail = "Training";
			expense.Amount = 18;

			manager.HandleExpenses(expense);

			Console.ReadLine();
		}
	}

	class Expense
	{
		public string Detail { get; set; }
		public decimal Amount { get; set; }
	}

	abstract class ExpenseHandlerBase
	{
		protected ExpenseHandlerBase Successor;

		public abstract void HandleExpenses(Expense expense);

		public void SetSuccessor(ExpenseHandlerBase successor)
		{
			Successor = successor;
		}
	}

	class Manager : ExpenseHandlerBase
	{
		public override void HandleExpenses(Expense expense)
		{
			if (expense.Amount <= 100)
			{
				Console.WriteLine("Manager handled the Expense!");
			}
			else if(Successor != null)
			{
				Successor.HandleExpenses(expense);
			}
		}
	}

	class VicePresident : ExpenseHandlerBase
	{
		public override void HandleExpenses(Expense expense)
		{
			if (expense.Amount > 100 && expense.Amount <= 1000)
			{
				Console.WriteLine("Vice President handled the Expense!");
			}
			else if (Successor != null)
			{
				Successor.HandleExpenses(expense);
			}
		}
	}

	class President : ExpenseHandlerBase
	{
		public override void HandleExpenses(Expense expense)
		{
			if (expense.Amount > 1000)
			{
				Console.WriteLine("President handled the Expense!");
			}
			// İleriye dönük olarak tekrar değiştirilebilir alt kısım...
			else if (Successor != null)
			{
				Successor.HandleExpenses(expense);
			}
		}
	}
}
