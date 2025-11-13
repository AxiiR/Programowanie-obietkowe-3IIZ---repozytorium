using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates; // potrzebne do Min() i Max()

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
            // Wylosuj 10 liczb typu double
            double[] losowe = LosujTabliceDouble(10, 1, 10);

            // Zamień na inty (np. zaokrąglając)
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
                if (i == excluded[i]) continue;
                Console.Write($"{i} ");
            }
        }
        public static void Zadanie4()
        {
            List<int> numbers = new List<int>();
            int temp;
            Console.WriteLine("Zadanie 4\n");
            while (true)
            {
                temp = Console.Read();
                if (temp < 0) break;
                else numbers.Add(temp);
            }
        }
        public static void Zadanie5()
        {
            Console.WriteLine("Zadanie 5\n");
            Console.WriteLine("Ile liczb do posortowania:");
            int howMany = Console.Read();
            double[] numbers = new double[howMany];
            numbers = LosujTabliceDouble(howMany, 0, 100);
            Console.WriteLine("1.Sortowanie bąbelkowe");
            Console.WriteLine("2. Sortowanie przez wstawianie");

            
            int action = Console.Read();
            switch (action)
            {
                case 1: SortowanieBombelkowe(numbers); break;
                case 2: SortowaniePrzezWstawianie(numbers); break;
                default: Console.WriteLine("Nieodpowiedni wybór\n");  break;
            }

            Console.WriteLine($"Posortowana tablica {numbers}");
        }
    }
}
