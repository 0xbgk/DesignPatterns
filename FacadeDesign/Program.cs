﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadeDesign
{
	class Program
	{
		static void Main(string[] args)
		{
			CustomerManager manager = new CustomerManager();
			manager.Save();

			Console.ReadLine();
		}
	}

	class Logging : ILogging
	{
		public void Log()
		{
			Console.WriteLine("Logged");
		}
	}

	internal interface ILogging
	{
		void Log();
	}

	class Caching : ICaching
	{
		public void Cache()
		{
			Console.WriteLine("Cached");
		}
	}

	internal interface ICaching
	{
		void Cache();
	}

	class Authorize : IAuthorize
	{
		public void CheckUser()
		{
			Console.WriteLine("User Checked");
		}
	}

	internal interface IAuthorize
	{
		void CheckUser();
	}

	class CustomerManager
	{
		// BURDA BUNLARI BÖYLE YAZMAKTANSA
		//private ILogging _logging;
		//private ICaching _caching;
		//private IAuthorize _authorize;

		//public CustomerManager(ILogging logging, ICaching caching, IAuthorize authorize)
		//{
		//	_logging = logging;
		//	_caching = caching;
		//	_authorize = authorize;
		//}

		//public void Save()
		//{
		//	_logging.Log();
		//	_caching.Cache();
		//	_authorize.CheckUser();
		//	Console.WriteLine("Saved");
		//}

		private CrossCuttingConcernsFacade _concerns;

		public CustomerManager()
		{
			_concerns = new CrossCuttingConcernsFacade();
		}

		public void Save()
		{
			_concerns.Logging.Log();
			_concerns.Caching.Cache();
			_concerns.Authorize.CheckUser();

			Console.WriteLine("Saved");
		}
	}

	class CrossCuttingConcernsFacade
	{
		public ILogging Logging;
		public ICaching Caching;
		public IAuthorize Authorize;

		public CrossCuttingConcernsFacade()
		{
			Logging = new Logging();
			Caching = new Caching();
			Authorize = new Authorize();
		}
	}
}
