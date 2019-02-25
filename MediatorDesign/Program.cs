using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorDesign
{
	// Arabulucu deseni
	// Farklı sistemleri birbiriyle görüstürme görevi üstlenen designdır.
	class Program
	{
		static void Main(string[] args)
		{
			Mediator mediator = new Mediator();
			Teacher gorkem = new Teacher(mediator);
			mediator.Teacher = gorkem;

			Student gizem = new Student(mediator);
			gizem.Name = "Gizem";

			Student berk = new Student(mediator);
			berk.Name = "Berk";

			mediator.Students = new List<Student> { gizem, berk };

			gorkem.SendNewImageURL("SLAYT 5");
			gorkem.ReceiveQuestion("Doğru mu", gizem);

			Console.ReadLine();
		}
	}

	abstract class CourseMember
	{
		protected Mediator Mediator;
		protected CourseMember(Mediator mediator)
		{
			Mediator = mediator;
		}
	}

	class Teacher : CourseMember
	{
		public Teacher(Mediator mediator) : base(mediator)
		{

		}

		internal void ReceiveQuestion(string question, Student student)
		{
			Console.WriteLine("Teacher Received Question! from: {0}, {1}", student.Name, question);
		}

		public void SendNewImageURL(string url)
		{
			Console.WriteLine("Teacher sended Image {0}", url);
			Mediator.UpdateImage(url);
		}

		public void AnswerQuestion(string answer, Student student)
		{
			Console.WriteLine("Teacher answered question : {0} from {1}", answer, student.Name);
		}
	}

	class Student : CourseMember
	{
		public string Name { get; internal set; }

		public Student(Mediator mediator) : base(mediator)
		{

		}


		internal void ReceiveImage(string url)
		{
			Console.WriteLine("{1} received image : {0}", url, this.Name);
		}

		internal void ReceiveAnswer(string answer)
		{
			Console.WriteLine("Student received answer : {0}", answer);
		}
	}

	class Mediator
	{
		public Teacher Teacher { get; set; }
		public List<Student> Students { get; set; }

		public void UpdateImage(string url)
		{
			foreach (var student in Students)
			{
				student.ReceiveImage(url);
			}
		}

		public void SendQuestion(string question, Student student)
		{
			Teacher.ReceiveQuestion(question, student);
		}

		public void SendAnswer(string answer, Student student)
		{
			student.ReceiveAnswer(answer);
		}
	}
}
