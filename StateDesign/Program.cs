using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDesign
{
	// Bir nesnenin bir olayın mevcut durumunu kontrol etmek icin tasarlanan sistemdir.
	// Modified, Deleted, Added Stateleri buna örnek olarak verilebilir.
	class Program
	{
		static void Main(string[] args)
		{
			Context context = new Context();

			ModifiedState modified = new ModifiedState();
			modified.DoAction(context);

			DeleetedState deleted = new DeleetedState();
			deleted.DoAction(context);

			Console.WriteLine(context.GetState());
			Console.ReadLine();
		}
	}

	interface IState
	{
		void DoAction(Context context);
	}

	class ModifiedState : IState
	{
		public void DoAction(Context context)
		{
			Console.WriteLine("STATE : Modified");
			context.SetState(this);
		}

		public override string ToString()
		{
			return "Modified";
		}
	}

	class DeleetedState : IState
	{
		public void DoAction(Context context)
		{
			Console.WriteLine("STATE : Deleted");
			context.SetState(this);
		}

		public override string ToString()
		{
			return "Deleted";
		}
	}

	class AddedState : IState
	{
		public void DoAction(Context context)
		{
			Console.WriteLine("STATE : Added");
			context.SetState(this);
		}

		public override string ToString()
		{
			return "Added";
		}
	}

	class Context
	{
		private IState _state;

		public void SetState(IState state)
		{
			_state = state;
		}

		public IState GetState()
		{
			return _state;
		}
	}


}
