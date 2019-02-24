using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
	class Program
	{
		static void Main(string[] args)
		{
			var customerManeger = CustomerManager.CreateAsSingleton();
			customerManeger.Save();

			Console.ReadLine();
		}
	}

	class CustomerManager
	{
		private static CustomerManager _customerManager;
		static object _lockObject = new object();

		private CustomerManager()
		{

		}

		public static CustomerManager CreateAsSingleton()
		{
			lock (_lockObject)
			{
				if (_customerManager == null)
				{
					_customerManager = new CustomerManager();
				}

			}
			return _customerManager;

			// Yukarıdaki kod blogu yerine yalnızca
			// return _customerManager ?? (_customerManager = new CustomerManager());
			// yazabilirdik.
		}

		public void Save()
		{
			Console.WriteLine("Saved");
		}
	}
}
