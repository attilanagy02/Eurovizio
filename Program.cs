using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
	class Euro
	{
		public int ev;
		public string orsz;
		public string nev;
		public string cim;
		public int hely;
		public int pont;
		public Euro(string s)
		{
			string[] sor = s.Split(';');
			ev = int.Parse(sor[0]);
			orsz = sor[1];
			nev = sor[2];
			cim = sor[3];
			hely = int.Parse(sor[4]);
			pont = int.Parse(sor[5]);
		} 

	}
	class Fest
	{
		List<Euro> lista;
		public Fest(string sz)
		{
			StreamReader sr = new StreamReader(sz);
			lista = new List<Euro>();
			while (!sr.EndOfStream)
			{
				lista.Add(new Euro(sr.ReadLine()));
			}
		}
		public void F1()
		{
			/*foreach (var item in lista)
			{
				Console.WriteLine(item.ev + ";" + item.nev + ";" + item.cim + ";" + item.pont + ";" + item.hely);
			}
			Console.WriteLine();*/
			foreach (var item in lista)
			{
				if (item.ev > 2000)
				{
					Console.WriteLine(item.nev + ";" +item.cim + ";" + item.ev);
				}
			}
		}
		public void F2()
		{
			foreach (var item in lista)
			{
				if (item.orsz == "Magyarország")
				{
					Console.WriteLine(item.nev + "\t" + item.cim + "\t" + item.pont + "\t" + item.hely);
				}
			}
		}
		public void F3()
		{
			foreach (var item in lista)
			{
				if (item.ev == 2013)
				{
					Console.WriteLine("Az akkori évi győztes: " + item.nev + item.cim + " című dallal " + item.pont + " pontot ért el.");
				}
			}
		}
		public void F4()
		{
			Euro min = lista[0];
			foreach (var item in lista)
			{
				if (item.ev < min.ev)
				{
					min = item;
					Console.WriteLine("Az első év fellépője: " + min.nev + "a" + min.cim + " című számmal.");
					min = lista[0];
				}
			}
			
		}
		public void F5()
		{
			bool nincs = false;
			foreach (var item in lista)
			{
				if (item.pont == 0)
				{
					Console.WriteLine("0 pontot ért el: " + item.nev);
				}
				else
				{
					nincs = true;
				}
			}
			if (nincs)
			{
				Console.WriteLine("Nincs benne!");
			}
		}
		public void F6()
		{
			int db0 = 0;
			int db1 = 0;
			int db2 = 0;
			int db3 = 0;
			int db4 = 0;
			int db5 = 0;
			foreach (var item in lista)
			{
				if (item.ev == 2000)
				{
					db0++;
				}
				else if (item.ev == 2001)
				{
					db1++;
				}
				else if (item.ev == 2002)
				{
					db2++;
				}
				else if (item.ev == 2003)
				{
					db3++;
				}
				else if (item.ev == 2004)
				{
					db4++;
				}
				else if (item.ev == 2005)
				{
					db5++;
				}
			}
			Console.WriteLine("2000-ben " + db0 + "db versenyző indult.");
			Console.WriteLine("2001-ben " + db1 + "db versenyző indult.");
			Console.WriteLine("2002-ben " + db2 + "db versenyző indult.");
			Console.WriteLine("2003-ben " + db3 + "db versenyző indult.");
			Console.WriteLine("2004-ben " + db4 + "db versenyző indult.");
			Console.WriteLine("2005-ben " + db5 + "db versenyző indult.");
		}
		public void F7()
		{
			int mo = 0;
			int no = 0;
			foreach (var item in lista)
			{
				if (item.ev < 2000 && item.orsz == "Magyarország")
				{
					mo += item.pont;
				}
				else if (item.ev < 2000 && item.orsz == "Németország")
				{
					no += item.pont;
				}
			}
			if (mo > no)
			{
				Console.WriteLine("Magyarország szerzett több pontot!");
			}
			else
			{
				Console.WriteLine("Németország szerzett több pontot!");
			}
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			Fest eu = new Fest("eurovizio.txt");
			eu.F1();
			eu.F2();
			eu.F3();
			eu.F4();
			eu.F5();
			eu.F6();
			eu.F7();
		}
	}
}
