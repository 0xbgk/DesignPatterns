using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
	// FARKLI SİSTEMLERİN KENDİ SİSTEMLERİMİZE ENTEGRE EDİLMESİ DURUMUNDA BİZİM SİSTEMİMİZ BOZULMADAN FARKLI SİSTEMİN SANKİ BİZİM SİSTEMİMİZMİŞ GİBİ DAVRANMASINI SAGLAYAN DESİGN
	class Program
	{
		static void Main(string[] args)
		{
			ProductManager productManeger = new ProductManager(new Log4NetAdapter());
			productManeger.Save();

			Console.ReadLine();
		}
	}
	// Dışardaki bir servisi kendi sistemimize dahil etmek istiyoruz.
	class ProductManager
	{
		private ILogger _logger;

		public ProductManager(ILogger logger)
		{
			_logger = logger;
		}

		public void Save()
		{
			_logger.Log("User Data");
			Console.WriteLine("Saved");
		}
	}

	interface ILogger
	{
		void Log(string message);
	}

	class bgkLogger : ILogger
	{
		public void Log(string message)
		{
			Console.WriteLine("Logged, " + message);
		}
	}

	//  Biz bu classı nugetten indirdiğimizi varsayalım. yani editleyemiyoruz, inherit edemiyoruz vsvs.
	class Log4Net
	{
		public void LogMessage(string message)
		{
			Console.WriteLine("Logged with Log4Net, " + message);
		}
	}

	class Log4NetAdapter : ILogger
	{
		public void Log(string message)
		{
			Log4Net log4Net = new Log4Net();
			log4Net.LogMessage(message);
		}
	}
}
