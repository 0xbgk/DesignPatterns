using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeDesign
{
	class Program
	{
		static void Main(string[] args)
		{
			Employee gorkem = new Employee{ Name = "Görkem Kızılok"};
			Employee gizem = new Employee { Name = "Gizem Kızılok"};

			gorkem.AddSubordinate(gizem);

			Employee berk = new Employee { Name = "Berk Kızılok" };

			gorkem.AddSubordinate(berk);

			Contractor ali = new Contractor { Name = "Ali" };
			gizem.AddSubordinate(ali);

			Employee ahmet = new Employee { Name = "Ahmet" };

			berk.AddSubordinate(ahmet);

			Console.WriteLine(gorkem.Name);
			foreach (Employee manager in gorkem)
			{
				Console.WriteLine("  "+manager.Name);

				foreach (IPerson employee in manager)
				{
					Console.WriteLine("    "+employee.Name);
					
				}
			}

			Console.ReadLine();
		}
	}

	interface IPerson
	{
		string Name { get; set; }
	}

	class Contractor : IPerson
	{
		public string Name { get; set ; }

	}

	class Employee : IPerson, IEnumerable<IPerson>
	{
		// IEnumerable kısacası foreachle gezebileceğimiz bir ortam yapmış olduk..

		List<IPerson> _subortidanes = new List<IPerson>();

		public void AddSubordinate(IPerson person)
		{
			_subortidanes.Add(person);
		}

		public void RemoveSubordinate(IPerson person)
		{
			_subortidanes.Remove(person);
		}

		public IPerson GetSubordinate(int index)
		{
			return _subortidanes[index];
		}

		public string Name { get ; set; }

		public IEnumerator<IPerson> GetEnumerator()
		{
			foreach (var subordinate in _subortidanes)
			{
				yield return subordinate;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}
	}
}
