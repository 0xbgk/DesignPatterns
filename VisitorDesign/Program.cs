using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorDesign
{
	// Birbirine benzeyen veya hiyerarjik nesnelerin aynı methodunun biri üzerinden diğerlerinde de cagrılması..
	class Program
	{
		static void Main(string[] args)
		{
			Manager gorkem = new Manager { Name="Görkem", Salary = 1000};
			Manager gizem = new Manager { Name="Gizem", Salary = 1200};

			Manager berk = new Manager { Name="Berk", Salary = 750};
			Manager duru = new Manager { Name="Duru", Salary = 550};

			gorkem.Subordinates.Add(gizem);
			gizem.Subordinates.Add(berk);
			berk.Subordinates.Add(duru);


			OrganisationalStructure organisationalStructure = new OrganisationalStructure(gorkem);

			PayrollVisitor payrollVisitor = new PayrollVisitor();
			PayriseVisitor payriseVisitor = new PayriseVisitor();

			organisationalStructure.Accept(payrollVisitor);
			organisationalStructure.Accept(payriseVisitor);

			Console.ReadLine();
		}
	}

	class OrganisationalStructure
	{
		public EmployeeBase Employee;

		public OrganisationalStructure(EmployeeBase firstEmployee)
		{
			Employee = firstEmployee;
		}

		public void Accept(VisitorBase visitor)
		{
			Employee.Accept(visitor);
		}
	}

	abstract class VisitorBase
	{
		public abstract void Visit(Worker worker);
		public abstract void Visit(Manager manager);
	}

	abstract class EmployeeBase
	{
		public abstract void Accept(VisitorBase visitor);
		public string Name { get; set; }
		public decimal Salary { get; set; }
	}

	class Manager : EmployeeBase
	{
		public Manager()
		{
			Subordinates = new List<EmployeeBase>();
		}
		public List<EmployeeBase> Subordinates { get; set; }

		public override void Accept(VisitorBase visitor)
		{
			visitor.Visit(this);

			foreach (var employee in Subordinates)
			{
				employee.Accept(visitor);
			}
		}
	}

	class Worker : EmployeeBase
	{
		public override void Accept(VisitorBase visitor)
		{
			visitor.Visit(this);
		}
	}

	class PayrollVisitor : VisitorBase
	{
		public override void Visit(Worker worker)
		{
			Console.WriteLine("{0} paid {1}", worker.Name, worker.Salary);
		}

		public override void Visit(Manager manager)
		{			
			Console.WriteLine("{0} paid {1}", manager.Name, manager.Salary);
		}
	}

	class PayriseVisitor : VisitorBase
	{
		public override void Visit(Worker worker)
		{			
			Console.WriteLine("{0} salary increased to {1}", worker.Name, worker.Salary*(decimal)1.1);
		}

		public override void Visit(Manager manager)
		{			
			Console.WriteLine("{0} salary increased {1}", manager.Name, manager.Salary* (decimal)1.2);
		}
	}
}
