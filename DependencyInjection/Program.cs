﻿using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{

	class Program
	{
		static void Main(string[] args)
		{
			IKernel kernel = new StandardKernel();
			kernel.Bind<IProductDal>().To<EfProductDal>().InSingletonScope();

			ProductManager productManager = new ProductManager(kernel.Get<IProductDal>());
			productManager.Save();

			Console.ReadLine();
		}
	}

	interface IProductDal
	{
		void Save();
	}

	class EfProductDal : IProductDal
	{
		public void Save()
		{
			Console.WriteLine("Saved with EntityFramework");
		}
	}

	class NhProductDal : IProductDal
	{
		public void Save()
		{
			Console.WriteLine("Saved with NHFramework");
		}
	}

	class ProductManager
	{
		private IProductDal _productDal;
		public ProductManager(IProductDal productDal)
		{
			_productDal = productDal;
		}
		public void Save()
		{
			// Business Code
			_productDal.Save();
		}
	}
}
