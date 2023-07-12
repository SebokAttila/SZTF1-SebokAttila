using System;

namespace Legyen_Ön_Is_Milliomos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Adja meg a nevét");
            string nev = Console.ReadLine();
            Console.WriteLine("1: Új játék \t 2: Rangsor \t 3: Kilépés");
            int seged = int.Parse(Console.ReadLine());
            Console.Clear();
            bool start = false;
            if (seged == 1)
            {
                start = true;
                JatekLefolyas ujJatek = new JatekLefolyas(nev, start);
                ujJatek.ujJatek();
            }
            else if (seged == 2)
            {
                Eredmeny[] eredmenyek = Feltoltes.EredmenyRendezes();
                Feltoltes.Rangsorolas(eredmenyek);
            }
            else if (seged == 3)
            {
                start = false;
                JatekLefolyas ujJatek = new JatekLefolyas(nev, start);
                ujJatek.ujJatek();
            }
            else
            {

            }
            Console.ReadKey();
        }
    }
}
