using System;

namespace testing
{


    public class Samochod//.......................................................................................................
    {
        
			private string marka;
			private string model;
			private int iloscDrzwi;
			private double pojemnoscSilnika;
			private double srednieSpalanie;
			private static int iloscSamochodow = 0;


			public Samochod() //konstruktor domyślny 
			{
				marka = "nieznana";
				model = "nieznany";
				iloscDrzwi = 0;
				pojemnoscSilnika = 0.0;
				srednieSpalanie = 0.0;
				iloscSamochodow++;
			}

			public Samochod(string marka_, string model_, int iloscDrzwi_, double pojemnoscSilnika_, double srednieSpalanie_) //konstruktor przyjmujący paramtery 
			{
				marka = marka_;
				model = model_;
				iloscDrzwi = iloscDrzwi_;
				pojemnoscSilnika = pojemnoscSilnika_;
				srednieSpalanie = srednieSpalanie_;
				iloscSamochodow++;
			}

			public string Marka
			{
				get { return marka; }
				set { marka = value; }
			}

			public string Model
			{
				get { return model; }
				set { model = value; }
			}

			public int IloscDrzwi
			{
				get { return iloscDrzwi; }
				set { iloscDrzwi = value; }
			}

			public double PojemnoscSilnika
			{
				get { return pojemnoscSilnika; }
				set { pojemnoscSilnika = value; }
			}

			public double SrednieSpalanie
			{
				get { return srednieSpalanie; }
				set { srednieSpalanie = value; }
			}



			private double ObliczSpalanie(double dlugoscTrasy) 
			{
				double spalanie = (srednieSpalanie * dlugoscTrasy) / 100.0;
				return spalanie;
			}


			public double ObliczKosztPrzejazdu(double dlugoscTrasy, double cenaPaliwa)
			{
				double spalanie = ObliczSpalanie(dlugoscTrasy);
				double kosztprzejazdu = spalanie * cenaPaliwa;
				return kosztprzejazdu;
			}


			public void WypiszInfo()
			{
				Console.WriteLine("Marka: " + Marka);
				Console.WriteLine("Model: " + Model);
				Console.WriteLine("Ilość drzwi: " + IloscDrzwi);
				Console.WriteLine("Pojemność silnika: " + PojemnoscSilnika);
				Console.WriteLine("Średnie spalanie: " + SrednieSpalanie);
			}


			public static void WypiszIloscSamochodow()
			{
				Console.WriteLine("Ilość samochodów: " + iloscSamochodow);
			}


	}//............................

    class Tester //>>>> Klasa TESTUJACA <<<< ....................................................................................................
    {
        
        static void Main1(string[] args)
        {
              Console.WriteLine("Zadanie 1- Sprawdzenie.............................................................. ");
              Samochod s1 = new Samochod();
		      s1.WypiszInfo();
		      s1.Marka = "Fiat";
		      s1.Model = "126p";
		      s1.IloscDrzwi = 2;
		      s1.PojemnoscSilnika = 650;
		      s1.SrednieSpalanie = 6.0;
		      s1.WypiszInfo();
		      Samochod s2 = new Samochod("Syrena", "105", 2, 800, 7.6);
		      s2.WypiszInfo();
		      double kosztPrzejazdu = s2.ObliczKosztPrzejazdu(30.5, 4.85);
		      Console.WriteLine("Koszt przejazdu: " + kosztPrzejazdu);
		      Samochod.WypiszIloscSamochodow();
              Console.WriteLine("Zadanie 1- Koniec Sprawdzenia.............................................................. ");
              Console.ReadKey();





        }

    }  // >>>> Koniec Klasy Testującej <<<< ......................................................................
	public class Garaz
	{
		private string adres;
		private int pojemnosc;
		private int liczbaSamochodow = 0;
		private Samochod[] samochody;

		public Garaz()
		{
			Adres = "nieznany";
			Pojemnosc = 0;
			samochody = null;
		}

		public Garaz(string adres_, int pojemnosc_)
		{
			Adres = adres_;
			Pojemnosc = pojemnosc_;
		}

		public string Adres
		{
			get { return adres; }
			set { adres = value; }
		}
		public int Pojemnosc
		{
			get { return pojemnosc; }
			set
			{
				pojemnosc = value;
				samochody = new Samochod[pojemnosc];
			}
		}

		public void WprowadzSamochod(Samochod samochod)
		{
			if (samochody.Length > liczbaSamochodow)
			{
				samochody[liczbaSamochodow] = samochod;
				liczbaSamochodow++;
			}
			else
			{
				Console.WriteLine("Garaż jest pełny");
			}

		}

		public Samochod WyprowadzSamochod()
		{
			if (liczbaSamochodow > 0)
			{
				liczbaSamochodow--;
				Samochod samochod = samochody[liczbaSamochodow];
				samochody[liczbaSamochodow] = null;
				return samochod;

			}
			else
			{
				Console.WriteLine("Garaż jest pusty");
				return samochody[liczbaSamochodow];
			}
		}

		public void WypiszInfo()
		{
			Console.WriteLine("Adres: " + Adres);
			Console.WriteLine("Pojemnosc: " + Pojemnosc);
			Console.WriteLine("Liczba samochodów: " + liczbaSamochodow);
			Console.WriteLine("Samochody: ");

			for (int i = 0; i < liczbaSamochodow; i++)
			{
				samochody[i].WypiszInfo();
			}
		}
    }//...............................................................................................................................

	class Tester2 //>>>> Klasa TESTUJACA2 <<<< ....................................................................
	{

		static void Main(string[] args)
		{
            Console.WriteLine("Zadanie 2- Sprawdzenie..............................................................");
			Samochod s1 = new Samochod("Fiat", "126p", 2, 650, 6.0);
			Samochod s2 = new Samochod("Syrena", "105", 2, 800, 7.6);
			Garaz g1 = new Garaz();
			g1.Adres = "ul. Garażowa 1";
			g1.Pojemnosc = 1;
			Garaz g2 = new Garaz("ul. Garażowa 2", 2);
			g1.WprowadzSamochod(s1);
			g1.WypiszInfo();
			g1.WprowadzSamochod(s2);
			g2.WprowadzSamochod(s2);
			g2.WprowadzSamochod(s1);
			g2.WypiszInfo();
			g2.WyprowadzSamochod();
			g2.WypiszInfo();
			g2.WyprowadzSamochod();
			g2.WyprowadzSamochod();
			Console.WriteLine("Zadanie 2- Koniec Sprawdzenia.............................................................. ");
			Console.ReadKey();
		}

	}  // >>>> Koniec Klasy Testującej <<<< ......................................................................





}

