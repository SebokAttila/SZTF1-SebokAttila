using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Legyen_Ön_Is_Milliomos
{
    class Feltoltes
    {        
        public static Kerdes[] kerdesFeltoltes(string fajlNev)
        {
            StreamReader kerdesek = new StreamReader(fajlNev, Encoding.Default);
            Kerdes[] kerdesTomb = new Kerdes[15];
            int i = 0;
            while (!kerdesek.EndOfStream)
            {
                string[] segedTomb = kerdesek.ReadLine().Split('|');
                kerdesTomb[i] = new Kerdes(int.Parse(segedTomb[0]), segedTomb[1], segedTomb[2], segedTomb[3], segedTomb[4], segedTomb[5], segedTomb[6], segedTomb[7] == "true" ? true : false); //segedTomb[7] == "true"?true:false
                i++;
            }
            return kerdesTomb;
        }
        public static void EredmenyFeltoltes(string nev, int x, int penz)
        {
            StreamWriter eredmenyek = new StreamWriter("Rangsor.txt", true, Encoding.Default);
            eredmenyek.WriteLine($"{nev}|{x}|{penz}$");
            eredmenyek.Close();
        }
        public static Eredmeny[] EredmenyRendezes()
        {

            int szamlalo = 0;
            string egesz = "";
            StreamReader sr = new StreamReader("Rangsor.txt", Encoding.Default );
            while (!sr.EndOfStream)
            {
                egesz += sr.ReadLine();
                szamlalo++;
            }
            string[] sorok = egesz.Split('$');
            Eredmeny[] eredmenyek = new Eredmeny[szamlalo];
            for (int i = 0; i < szamlalo; i++)
            {
                string sor = sorok[i];
                string[] sordarabok = sor.Split('|');
                eredmenyek[i] = new Eredmeny(sordarabok[0], int.Parse(sordarabok[1]), sordarabok[2]);
            }

            return eredmenyek;
        }
        public static void Rangsorolas(Eredmeny[] eredmenyTomb)
        {
            for (int i = 0; i < eredmenyTomb.Length; i++)
            {
                for (int j = 0; j < eredmenyTomb.Length; j++)
                {
                    if (eredmenyTomb[i].Pont > eredmenyTomb[j].Pont)
                    {
                        int tmp = eredmenyTomb[i].Pont;
                        eredmenyTomb[i].Pont = eredmenyTomb[j].Pont;
                        eredmenyTomb[j].Pont = tmp;
                        string tmp2 = eredmenyTomb[i].Nev;
                        eredmenyTomb[i].Nev = eredmenyTomb[j].Nev;
                        eredmenyTomb[j].Nev = tmp2;
                        string tmp3 = eredmenyTomb[i].Penz;
                        eredmenyTomb[i].Penz = eredmenyTomb[j].Penz;
                        eredmenyTomb[j].Penz = tmp3;
                    }
                }
                
            }
            for (int i = 0; i < eredmenyTomb.Length; i++)
            {
                Console.WriteLine($"Név: {eredmenyTomb[i].Nev}\t Pontok: {eredmenyTomb[i].Pont} \t Pénz: {eredmenyTomb[i].Penz}");
            }
            
        }
    }
    class Eredmeny
    {
        public string Nev { get; set; }
        
        public int Pont { get; set; }
        public string Penz { get; set; }

        public Eredmeny(string nev, int pont, string penz)
        {
            this.Nev = nev;
            this.Pont = pont;
            this.Penz = penz;
            
        }
    }
}
