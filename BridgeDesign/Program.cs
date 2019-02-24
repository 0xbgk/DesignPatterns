using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeDesign
{
	// Bir nesnenin icinde soyutlanabilir bir kısım varsa onları soyutlama teknikleri ile gerceklestirip tekrar kullanma designı..
	class Program
	{	
		static void Main(string[] args)
		{
			CustomerManager customerManager = new CustomerManager();
			customerManager.MessageSenderBase = new SmsSender();
			customerManager.UpdateCustomer();

			Console.ReadLine();
		}
	}

	abstract class MessageSenderBase
	{
		public void Save()
		{
			Console.WriteLine("Message Saved");
		}

		// Bu 2 methodda SEND IN islevidir. Dolayısıyla böyle yapmaktansa
		// Bir BRIDGE yardımıyla yapılabilir
		//public void SendSms()
		//{
		//}
		//public void SendEmail()
		//{
		//}

		public abstract void Send(Body body);		
	}

	public class Body
	{
		public string Title { get; set; }
		public string Text { get; set; }
	}

	class MailSender : MessageSenderBase
	{
		public override void Send(Body body)
		{
			Console.WriteLine("{0} was send via MailSender", body.Title);
		}
	}

	class SmsSender : MessageSenderBase
	{
		public override void Send(Body body)
		{
			Console.WriteLine("{0} was send via SmsSender", body.Title);
		}
	}

	// Burası daha arttırılabilir...

	class CustomerManager
	{
		public MessageSenderBase MessageSenderBase { get; set; }

		public void UpdateCustomer()
		{
			MessageSenderBase.Send(new Body { Title = "About to Course"});
			Console.WriteLine("Customer Updated");
		}
	}
}
