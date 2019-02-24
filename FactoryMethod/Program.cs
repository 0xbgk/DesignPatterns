using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
	class Program
	{
		// GÜNÜMÜZ DESİGN PATTERNLAR İCİNDE EN SIK KULLANILAN PATTERN
		// AMAC YAZILIMDA DEĞİŞİMİ KONTROL ALTINDA TUTMAKTIR.
		// 
		static void Main(string[] args)
		{
			CustomerManager _customerManager = new CustomerManager(new LoggerFactory());
			_customerManager.Save();

			Console.ReadLine();
		}
	}

	// BİR CLASS CIPLAK DURUYORSA YANLIS BİR DAVRANISTIR.
	public class LoggerFactory : ILoggerFactory
	{
		public ILogger CreateLogger()
		{
			// Burada bir iş geliştirip duruma göre return new verilir...!!
			// Business to decide factory
			return new bgkLogger();
		}
	}

	public class LoggerFactory2 : ILoggerFactory
	{
		public ILogger CreateLogger()
		{
			// Bu fabrika baska bir mantıkla calısıyor olaiblir.
			return new bgkLogger();
		}
	}

	public class bgkLogger : ILogger
	{
		public void Log()
		{
			Console.WriteLine("Logged with bgkLogger");
		}
	}

	public class CustomerManager
	{

		private ILoggerFactory _loggerFactory;

		public CustomerManager(ILoggerFactory loggerFactory)
		{
			_loggerFactory = loggerFactory;
		}

		public void Save()
		{
			Console.WriteLine("SAVED");
			ILogger logger = _loggerFactory.CreateLogger();
			//ILogger logger = new LoggerFactory().CreateLogger();   ESKİ
			logger.Log();
		}
	}
}
