using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;

namespace Program
{
    public class Class1
    {
        /// <summary>
        /// Losuje tablicę n liczb double z przedziału [min, max].
        /// </summary>
        private static double[] LosujTabliceDouble(int n, double min, double max)
        {
            var rng = new Random();
            double[] arr = new double[n];
            double zakres = max - min;

            for (int i = 0; i < n; i++)
            {
                // NextDouble() -> [0,1), skalujemy do [min, max]
                arr[i] = min + rng.NextDouble() * zakres;
            }

            return arr;
        }

        /// <summary>
        /// Sortuje bombelkowo tablice
        /// </summary>
        /// <param name="tab"></param>
        static void SortowanieBombelkowe(double[] tab)
        {
            double n = tab.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (tab[j] > tab[j + 1])
                    {
                        double temp = tab[j];
                        tab[j] = tab[j + 1];
                        tab[j + 1] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// Sortuje przez wstawianie tablice
        /// </summary>
        /// <param name="tab"></param>
        static void SortowaniePrzezWstawianie(double[] tab)
        {
            for (int i = 1; i < tab.Length; i++)
            {
                double klucz = tab[i];
                int j = i - 1;

                while (j >= 0 && tab[j] > klucz)
                {
                    tab[j + 1] = tab[j];
                    j--;
                }

                tab[j + 1] = klucz;
            }
        }




        /// <summary>
        /// Metoda, która wykonuje zadanie 1 (rozwiązywanie równania kwadratowego)
        /// </summary>
        public static void Zadanie1()
        {
            Console.WriteLine("Zadanie 1\n");
            Console.WriteLine("Podaj a:");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Podaj b:");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Podaj c:");
            double c = Convert.ToDouble(Console.ReadLine());

            if (a != 0)
            {
                double delta = (b * b) - (4 * a * c);

                if (delta < 0)
                {
                    Console.WriteLine("Brak rozwiązań w zbiorze liczb rzeczywistych");
                }
                else if (delta > 0)
                {
                    double x1 = (-b - Math.Sqrt(delta)) / (2 * a);
                    double x2 = (-b + Math.Sqrt(delta)) / (2 * a);
                    Console.WriteLine($"Dwa rozwiązania: x1 = {x1}, x2 = {x2}");
                }
                else
                {
                    double x1 = -b / (2 * a);
                    Console.WriteLine($"Jedno rozwiązanie: x = {x1}");
                }
            }
            else
            {
                Console.WriteLine("To nie jest równanie kwadratowe (a = 0)");
            }
        }

        /// <summary>
        /// Metoda, która wykonuje zadanie 2 (operacje na tablicy)
        /// </summary>
        public static void Zadanie2()
        {
            Console.WriteLine("Zadanie 2\n");
            double[] losowe = LosujTabliceDouble(10, 1, 10);

            int[] numbers = losowe.Select(x => (int)Math.Round(x)).ToArray();

            int sum = numbers.Sum();
            int product = 1;
            foreach (int number in numbers)
            {
                product *= number;
            }

            Console.WriteLine("Wylosowane liczby: " + string.Join(", ", numbers));
            Console.WriteLine($"Suma: {sum}");
            Console.WriteLine($"Iloczyn: {product}");
            Console.WriteLine($"Średnia: {(double)sum / numbers.Length}");
            Console.WriteLine($"Wartość minimalna: {numbers.Min()}");
            Console.WriteLine($"Wartość maksymalna: {numbers.Max()}");
        }

        public static void Zadanie3()
        {
            Console.WriteLine("Zadanie 3\n");
            int[] excluded = { 2, 6, 9, 15, 19 };
            for (int i = 20; i > 0; i--)
            {
                if (excluded.Contains(i)) continue;
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }
        public static void Zadanie4()
        {
            List<int> numbers = new List<int>();
            int temp;
            Console.WriteLine("Zadanie 4\n");
            Console.WriteLine("Podawaj liczby całkowite. Liczba mniejsza od 0 kończy program.");

            while (true)
            {
                Console.Write("Podaj liczbę: ");

                if (int.TryParse(Console.ReadLine(), out temp))
                {
                    if (temp < 0)
                    {
                        break;
                    }
                    else
                    {
                        numbers.Add(temp);
                    }
                }
                else
                {
                    Console.WriteLine("Błędne dane. To nie jest liczba całkowita.");
                }
            }

            Console.WriteLine("Wprowadzone liczby (bez ujemnej): " + string.Join(", ", numbers));
        }
        public static void Zadanie5()
        {
            Console.WriteLine("Zadanie 5\n");
            Console.WriteLine("Ile liczb do posortowania (zostaną wylosowane):");

            int howMany;
            if (!int.TryParse(Console.ReadLine(), out howMany) || howMany <= 0)
            {
                Console.WriteLine("Błędna ilość.");
                return;
            }

            double[] numbers = LosujTabliceDouble(howMany, 0, 100);

            Console.WriteLine("\nWylosowana tablica: " + string.Join(", ", numbers));

            Console.WriteLine("\n1.Sortowanie bąbelkowe");
            Console.WriteLine("2. Sortowanie przez wstawianie");


            int action;
            int.TryParse(Console.ReadLine(), out action);

            switch (action)
            {
                case 1:
                    Console.WriteLine("Sortuję bąbelkowo...");
                    SortowanieBombelkowe(numbers);
                    break;
                case 2:
                    Console.WriteLine("Sortuję przez wstawianie...");
                    SortowaniePrzezWstawianie(numbers);
                    break;
                default:
                    Console.WriteLine("Nieodpowiedni wybór. Tablica nieposortowana.\n");
                    break;
            }

            Console.WriteLine("Posortowana tablica: " + string.Join(", ", numbers));
        }

        public static void Zadanie6()
        {
            Console.WriteLine("Zadanie 6\n");

            Osoba osoba1 = new Osoba("Jan", "Kowalski", 30);
            osoba1.WyswietlInformacje();

            Console.WriteLine();
            Osoba osoba2 = new Osoba("X", "Nowak", 25);
            osoba2.WyswietlInformacje();

            Console.WriteLine();
            Osoba osoba3 = new Osoba("Anna", "Zet", -5);
            osoba3.WyswietlInformacje();

            Console.WriteLine("\nPo próbie zmiany danych:");
            osoba1.Wiek = -10;
            osoba1.Imie = "A";
            osoba1.WyswietlInformacje();
        }

        public static void Zadanie7()
        {
            Console.WriteLine("Zadanie 7\n");

            BankAccount konto = new BankAccount("Jan Kowalski", 1000);
            Console.WriteLine($"Utworzono konto. Właściciel: {konto.Wlasciciel}, Saldo: {konto.Saldo:C}");

            konto.Wplata(500);
            konto.Wyplata(200);
            konto.Wyplata(2000);
            konto.Wplata(-100);

            Console.WriteLine($"Końcowe saldo: {konto.Saldo:C}");
        }

        public static void Zadanie8()
        {
            Console.WriteLine("Zadanie 8\n");

            Student student = new Student("Adam", "Małysz");
            Console.WriteLine($"Student: {student.Imie} {student.Nazwisko}");
            Console.WriteLine($"Średnia (przed ocenami): {student.SredniaOcen}");

            student.DodajOcene(5);
            student.DodajOcene(4);
            student.DodajOcene(3);
            student.DodajOcene(5);
            student.DodajOcene(7);
            student.DodajOcene(1);

            Console.WriteLine($"Średnia (po ocenach): {student.SredniaOcen:F2}");
        }

        public static void Zadanie9()
        {
            Console.WriteLine("Zadanie 9\n");

            Licz liczba1 = new Licz(100);
            Licz liczba2 = new Licz(5.5);

            Console.WriteLine("Stan początkowy:");
            liczba1.WypiszStan();
            liczba2.WypiszStan();

            liczba1.Dodaj(50);
            liczba2.Odejmij(10);

            Console.WriteLine("\nStan po operacjach:");
            liczba1.WypiszStan();
            liczba2.WypiszStan();
        }

        public static void Zadanie10()
        {
            Console.WriteLine("Zadanie 10\n");

            int[] dane = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Sumator sumator = new Sumator(dane);

            Console.WriteLine($"Ilość elementów: {sumator.IleElementow()}");
            sumator.WypiszElementy();

            Console.WriteLine($"Suma: {sumator.Suma()}");
            Console.WriteLine($"Suma podzielnych przez 2: {sumator.SumaPodziel2()}");

            Console.WriteLine("\nTestowanie zakresów:");
            sumator.WypiszElementyZakres(3, 6);
            sumator.WypiszElementyZakres(-2, 2);
            sumator.WypiszElementyZakres(8, 100);
        }
    }

    /// <summary>
    /// Zadanie 6: Przechowuje informacje o osobie
    /// </summary>
    public class Osoba
    {
        private string _imie;
        private string _nazwisko;
        private int _wiek;

        public string Imie
        {
            get { return _imie; }
            set
            {
                if (value.Length < 2)
                {
                    Console.WriteLine("Błąd: Imię musi mieć co najmniej 2 znaki.");
                    _imie = "N/A";
                }
                else
                {
                    _imie = value;
                }
            }
        }

        public string Nazwisko
        {
            get { return _nazwisko; }
            set
            {
                if (value.Length < 2)
                {
                    Console.WriteLine("Błąd: Nazwisko musi mieć co najmniej 2 znaki.");
                    _nazwisko = "N/A";
                }
                else
                {
                    _nazwisko = value;
                }
            }
        }

        public int Wiek
        {
            get { return _wiek; }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Błąd: Wiek musi być liczbą dodatnią.");
                    _wiek = 1;
                }
                else
                {
                    _wiek = value;
                }
            }
        }

        public Osoba(string imie, string nazwisko, int wiek)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Wiek = wiek;
        }

        public void WyswietlInformacje()
        {
            Console.WriteLine($"Osoba: {Imie} {Nazwisko}, Wiek: {Wiek}");
        }
    }

    /// <summary>
    /// Zadanie 7: Symuluje konto bankowe
    /// </summary>
    public class BankAccount
    {
        public decimal Saldo { get; private set; }
        public string Wlasciciel { get; private set; }

        public BankAccount(string wlasciciel, decimal poczatkoweSaldo)
        {
            Wlasciciel = wlasciciel;
            if (poczatkoweSaldo > 0)
            {
                Saldo = poczatkoweSaldo;
            }
            else
            {
                Saldo = 0;
            }
        }

        public void Wplata(decimal kwota)
        {
            if (kwota <= 0)
            {
                Console.WriteLine("Kwota wpłaty musi być dodatnia.");
                return;
            }
            Saldo += kwota;
            Console.WriteLine($"Wpłacono: {kwota:C}. Nowe saldo: {Saldo:C}");
        }

        public void Wyplata(decimal kwota)
        {
            if (kwota <= 0)
            {
                Console.WriteLine("Kwota wypłaty musi być dodatnia.");
                return;
            }

            if (kwota > Saldo)
            {
                Console.WriteLine("Brak wystarczających środków na koncie.");
            }
            else
            {
                Saldo -= kwota;
                Console.WriteLine($"Wypłacono: {kwota:C}. Nowe saldo: {Saldo:C}");
            }
        }
    }

    /// <summary>
    /// Zadanie 8: Przechowuje dane studenta i jego oceny
    /// </summary>
    public class Student
    {
        public string Imie { get; private set; }
        public string Nazwisko { get; private set; }
        private List<int> oceny;

        public double SredniaOcen
        {
            get
            {
                if (oceny.Count == 0)
                {
                    return 0;
                }
                return oceny.Average();
            }
        }

        public Student(string imie, string nazwisko)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            oceny = new List<int>();
        }

        public void DodajOcene(int ocena)
        {
            if (ocena >= 1 && ocena <= 6)
            {
                oceny.Add(ocena);
                Console.WriteLine($"Dodano ocenę: {ocena}");
            }
            else
            {
                Console.WriteLine($"Błędna ocena: {ocena}. Oceny muszą być w zakresie 1-6.");
            }
        }
    }

    /// <summary>
    /// Zadanie 9: Klasa do operacji na liczbie
    /// </summary>
    public class Licz
    {
        private double value;

        public Licz(double initialValue)
        {
            this.value = initialValue;
        }

        public void Dodaj(double val)
        {
            this.value += val;
        }

        public void Odejmij(double val)
        {
            this.value -= val;
        }

        public void WypiszStan()
        {
            Console.WriteLine($"Aktualna wartość: {this.value}");
        }
    }

    /// <summary>
    /// Zadanie 10: Klasa do sumowania tablicy
    /// </summary>
    public class Sumator
    {
        private int[] Liczby;

        public Sumator(int[] liczby)
        {
            this.Liczby = liczby;
        }

        public int Suma()
        {
            return Liczby.Sum();
        }

        public int SumaPodziel2()
        {
            int suma = 0;
            foreach (int l in Liczby)
            {
                if (l % 2 == 0)
                {
                    suma += l;
                }
            }
            return suma;
        }

        public int IleElementow()
        {
            return Liczby.Length;
        }

        public void WypiszElementy()
        {
            Console.WriteLine("Elementy tablicy: " + string.Join(", ", Liczby));
        }

        public void WypiszElementyZakres(int lowIndex, int highIndex)
        {
            Console.Write($"Elementy od indeksu {lowIndex} do {highIndex}: ");
            for (int i = lowIndex; i <= highIndex; i++)
            {
                if (i >= 0 && i < Liczby.Length)
                {
                    Console.Write(Liczby[i] + " ");
                }
            }
            Console.WriteLine();
        }
    }
}