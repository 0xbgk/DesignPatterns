using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype_Design
{
	// PROTOTYPE designında amac NESNE ÜRETİM MALİYETLERİNİ MİNİMİZE ETMEKTİR.
	// PERFORMANS OLARAK NEWLEME METHOTLARINI MİNİMİZE ETMEMİZİ SAGLAR
	class Program
	{
		static void Main(string[] args)
		{
			Customer customer1 = new Customer { Id = 1, FirstName = "Görkem", LastName = "Kızılok", City = "İzmir" };
			

			var customer2 = (Customer)customer1.Clone();
			customer2.FirstName = "Ahmet";

			Console.WriteLine(customer1.FirstName);
			Console.WriteLine(customer2.FirstName);


			Console.ReadLine();
		}
	}
	// Temel nesneyi prototype deseni yapabilmek icin onun soyut bir klon methodundan besleniyor olması gerekir.
	public abstract class Person
	{
		public abstract Person Clone();

		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}

	public class Customer : Person
	{
		public string City { get; set; }

		public override Person Clone()
		{
			return (Person)MemberwiseClone();
		}
	}

	public class Employee : Person
	{
		public decimal Salary { get; set; }

		public override Person Clone()
		{
			return (Person)MemberwiseClone();
		}
	}
}
