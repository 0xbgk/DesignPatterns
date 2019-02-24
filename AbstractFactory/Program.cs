using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
	class Program
	{
		// FACTORY METHOD DESIGN PATTERNINA EK OLARAK
		// TOPLU NESNE KULLANIMI İHTİYACLARINDA NESNENİN KULLANIMINI KOLAYLASTIRMAK VE
		// STANDART NESNELERE İHTİYAC DUYUYORSAK
		// ONLARA GÖRE MANTIK OLUSTURMAK 
		static void Main(string[] args)
		{
			ProductManager _productManager = new ProductManager(new Factory1());
			_productManager.GetAll();

			Console.ReadLine();
		}

	}
	// LOGLAMA YÖNTEMİMİZ OLABİLİR
	public abstract class Logging
	{
		public abstract void Log(string message);
	}

	public class Log4NetLogger : Logging
	{
		public override void Log(string message)
		{
			Console.WriteLine("Logged with Log4Net");
		}
	}

	public class NLogger : Logging
	{
		public override void Log(string message)
		{
			Console.WriteLine("Logged with Nlogger");
		}
	}

	// CACHELEME YÖNTEMİMİZ OLAİBLİR
	public abstract class Caching
	{
		public abstract void Cache(string data);
	}

	public class MemCache : Caching
	{
		public override void Cache(string data)
		{
			Console.WriteLine("Cached with MemCache");
		}
	}

	public class RedisCache : Caching
	{
		public override void Cache(string data)
		{
			Console.WriteLine("Cached with RedisCache");
		}
	}
	// Bizim fabrikaya ihtiyacımız var

	// Fabrikalar da artabilir.
	public abstract class CrossCuttingConcernsFactory
	{
		public abstract Logging CreateLogger();
		public abstract Caching CreateCaching();
	}

	public class Factory1 : CrossCuttingConcernsFactory
	{
		public override Logging CreateLogger()
		{
			return new Log4NetLogger();
		}
		public override Caching CreateCaching()
		{
			return new MemCache();
		}
	}

	public class Factory2 : CrossCuttingConcernsFactory
	{
		public override Logging CreateLogger()
		{
			return new NLogger();
		}
		public override Caching CreateCaching()
		{
			return new RedisCache();
		}
	}

	public class ProductManager
	{
		CrossCuttingConcernsFactory _cccFactory;

		Logging _logging;
		Caching _caching;

		public ProductManager(CrossCuttingConcernsFactory cccFactory)
		{
			_cccFactory = cccFactory;
			_logging = _cccFactory.CreateLogger();
			_caching = _cccFactory.CreateCaching();
		}

		public void GetAll()
		{
			_logging.Log("Logged");
			_caching.Cache("Cached");
			Console.WriteLine("Products Listed!");
		}
	}
}
