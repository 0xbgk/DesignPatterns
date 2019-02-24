using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverDesign
{
	// Kendisine abone olan sistemlerin bir işlem olduğunda devreye girmesini sağlayan sistemdir.
	class Program
	{
		static void Main(string[] args)
		{
			ProductManager _productManager = new ProductManager();
			_productManager.Attach(new EmployeeObserver());
			_productManager.Attach(new CustomerObserver());
			_productManager.UpdatePrice();

			Console.ReadLine();
		}
	}

	class ProductManager
	{
		List<Observer> _observers = new List<Observer>();

		public void UpdatePrice()
		{
			Console.WriteLine("Product price changed!");
			Notify();
		}
		// Bu tasarım deseninin önerdiği yapı bu sekildedir:
		public void Attach(Observer observer)
		{
			_observers.Add(observer);
		}

		public void Detach(Observer observer)
		{
			_observers.Remove(observer);
		}

		private void Notify()
		{
			foreach (var observer in _observers)
			{
				observer.Update();
			}
		}
	}

	abstract class Observer
	{
		public abstract void Update();
	}

	class CustomerObserver : Observer
	{
		public override void Update()
		{
			Console.WriteLine("Message to customer : Product price changed");
		}
	}

	class EmployeeObserver : Observer
	{
		public override void Update()
		{
			Console.WriteLine("Message to employee : Product price changed");
		}
	}
}
