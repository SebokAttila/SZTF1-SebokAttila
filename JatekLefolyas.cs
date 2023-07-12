using System;
using System.Collections.Generic;
using System.Text;

namespace Legyen_Ön_Is_Milliomos
{
    class JatekLefolyas
    {
        public bool start;
        public string nev;
        public Kerdes[] kerdesek;
        public JatekLefolyas(string nev, bool start)
        {
            this.start = start;
            this.nev = nev;
            this.kerdesek = Feltoltes.kerdesFeltoltes("TextFile1.txt");            
        }
        public void ujJatek()
        {
            int x = 0;
            int penz = 0;
            if (start == true)
            {
                bool telefonos = true;
                bool felezes = true;
                bool kozonseg = true;
                bool helyes = true;
                string elso = "1: Telefonos segítség";
                string masodik = "2: Felezés";
                string harmadik = "3: Közönség megkérdezése";
                while (helyes != false && x < 15)
                {
                    Console.WriteLine(kerdesek[x].ToString());
                    Console.WriteLine("Szeretne segítséget használni? igen|nem");
                    string igenNem = Console.ReadLine();
                    if (igenNem == "igen")
                    {
                        Console.WriteLine($"{elso} \t {masodik} \t {harmadik}");
                        int kerEsegitseget = int.Parse(Console.ReadLine());
                        string valaszSegitseggel = "";                                           
                        if (kerEsegitseget == 1)
                        {
                            if (telefonos == true)
                            {
                                valaszSegitseggel = telefonosSegitseg(kerdesek, x);
                                Console.WriteLine("A helyes válasz: " + valaszSegitseggel);
                                elso = "";
                                telefonos = false;                            
                            }
                            else
                            {
                                Console.WriteLine("Ez a segítség már nem elérhető!");
                            }                        
                        }
                        else if (kerEsegitseget == 2)
                        {
                            if (felezes == true)
                            {
                                Felezes(kerdesek, x);
                                masodik = "";
                                felezes = false;                           
                            }
                            else
                            {
                                Console.WriteLine("Ez a segítség már nem elérhető!");
                            }                       
                        }
                        else if (kerEsegitseget == 3)
                        {
                            if (kozonseg == true)
                            {
                                kozonsegSegitsege(kerdesek, x);
                                harmadik = "";
                                kozonseg = false;   
                            }
                            else
                            {
                                Console.WriteLine("Ez a segítség már nem elérhető!");
                            }                       
                        }
                        else
                        {
                            Console.WriteLine("Értelmezhetetlen bemenet!");
                        }                        
                    }
                    else
                    {
                    }
                    string valasz = Console.ReadLine().ToUpper();                   
                    if (valasz == Convert.ToString(kerdesek[x].helyesValasz[0]))
                    {
                        if (kerdesek[x].nehezseg < 5)
                        {
                            penz = 0;
                        }
                        else if (kerdesek[x].nehezseg < 10)
                        {
                            penz = 5000;
                        }
                        else if (kerdesek[x].nehezseg < 15)
                        {
                            penz = 10000;
                        }
                        else if (kerdesek[x].nehezseg == 15)
                        {
                            penz = 20000;
                        }
                        else
                        {
                        }
                        
                        x++;
                    }
                    else
                    {
                        helyes = false;
                    }
                    Console.Clear();                    
                }
                Feltoltes.EredmenyFeltoltes(nev, x, penz);
                if (helyes == false)
                {
                    Console.WriteLine($"Rossz válasz. \nElért eredménye: {penz} Forint \n{x}. kérdésig jutott a 15-ből");

                }
                else
                {
                    Console.WriteLine($"Gratulálunk! Megnyerte a {penz} összegű főnyereményt!");
                }
            }
            else
            {
                Console.WriteLine("Kilépés megtörtént.");
            }
        }
        public string telefonosSegitseg(Kerdes[] kerdesek, int x)
        {
            string helyesValasz = kerdesek[x].helyesValasz;
            return helyesValasz;
        }
        public void kozonsegSegitsege(Kerdes[] kerdesek, int x)
        {
            double helyes = 15 - x;
            double helyesValoszinuseg = (helyes  / 15) * 100;
            double maradek = 100 - helyesValoszinuseg;
            Random r = new Random();
            double[] maradekTomb = { 0, 0, 0, 0 };
            double negyed = maradek / 4;            
            for (int i = 0; i < maradekTomb.Length; i++)
            {
                int seged = r.Next(0, 4);
                if (seged == 0)
                {
                    maradekTomb[0] += negyed;                    
                }
                else if (seged == 1)
                {
                    maradekTomb[1] += negyed;
                }
                else if (seged == 2)
                {
                    maradekTomb[2] += negyed;
                }
                else
                {
                    maradekTomb[3] += negyed;
                }
            }
            if (kerdesek[x].helyesValasz == "A")
            {
                Console.WriteLine($"A: {(helyesValoszinuseg + maradekTomb[0]).ToString("#.##")}  \tB: {maradekTomb[1].ToString("#.##")}  \tC: {maradekTomb[2].ToString("#.##")} \t D: {maradekTomb[3].ToString("#.##")}");
            }
            else if (kerdesek[x].helyesValasz == "B")
            {
                Console.WriteLine($"A: {maradekTomb[0].ToString("#.##")}  \tB:{(helyesValoszinuseg+ maradekTomb[1]).ToString("#.##")}  \tC: {maradekTomb[2].ToString("#.##")} \t D: {maradekTomb[3].ToString("#.##")}");
            }
            else if (kerdesek[x].helyesValasz == "C")
            {
                Console.WriteLine($"A: {maradekTomb[0].ToString("#.##")}  \tB: {maradekTomb[1].ToString("#.##")} \tC:{(helyesValoszinuseg + maradekTomb[2]).ToString("#.##")}  \t D: {maradekTomb[3].ToString("#.##")}");
            }
            else
            {
                Console.WriteLine($"A: {maradekTomb[0].ToString("#.##")}  \tB: {maradekTomb[1].ToString("#.##")} \tC: {maradekTomb[2].ToString("#.##")} \t D:{(helyesValoszinuseg + maradekTomb[3]).ToString("#.##")}");
            }            
        }
        public void Felezes(Kerdes[] kerdesek, int x)
        {
            string[] meghagyottValaszok = {"","" };
            char[] valaszBetui = { '0', '0' };
            Random r = new Random();
            int seged = r.Next(0, 3);
            if (kerdesek[x].helyesValasz == "A")
            {
                meghagyottValaszok[0] = kerdesek[x].valaszA;
                valaszBetui[0] = 'A';
                if (seged == 0)
                {                   
                    meghagyottValaszok[1] = kerdesek[x].valaszB;
                    valaszBetui[1] = 'B';
                }
                else if (seged == 1)
                {
                    meghagyottValaszok[1] = kerdesek[x].valaszC;
                    valaszBetui[1] = 'C';
                }
                else
                {
                    meghagyottValaszok[1] = kerdesek[x].valaszD;
                    valaszBetui[1] = 'D';
                }
            }
            else if (kerdesek[x].helyesValasz == "B")
            {
                meghagyottValaszok[0] = kerdesek[x].valaszB;
                valaszBetui[0] = 'B';
                if (seged == 0)
                {
                    meghagyottValaszok[1] = kerdesek[x].valaszA;
                    valaszBetui[1] = 'A';
                }
                else if (seged == 1)
                {
                    meghagyottValaszok[1] = kerdesek[x].valaszC;
                    valaszBetui[1] = 'C';
                }
                else
                {
                    meghagyottValaszok[1] = kerdesek[x].valaszD;
                    valaszBetui[1] = 'D';
                }
            }
            else if (kerdesek[x].helyesValasz == "C")
            {
                meghagyottValaszok[0] = kerdesek[x].valaszC;
                valaszBetui[0] = 'C';
                if (seged == 0)
                {
                    meghagyottValaszok[1] = kerdesek[x].valaszB;
                    valaszBetui[1] = 'B';
                }
                else if (seged == 1)
                {
                    meghagyottValaszok[1] = kerdesek[x].valaszA;
                    valaszBetui[1] = 'B';
                }
                else
                {
                    meghagyottValaszok[1] = kerdesek[x].valaszD;
                    valaszBetui[1] = 'D';
                }
            }
            else 
            {
                meghagyottValaszok[0] = kerdesek[x].valaszD;
                valaszBetui[0] = 'D';
                if (seged == 0)
                {
                    meghagyottValaszok[1] = kerdesek[x].valaszB;
                    valaszBetui[1] = 'B';
                }
                else if (seged == 1)
                {
                    meghagyottValaszok[1] = kerdesek[x].valaszC;
                    valaszBetui[1] = 'C';
                }
                else
                {
                    meghagyottValaszok[1] = kerdesek[x].valaszA;
                    valaszBetui[1] = 'A';
                }
            }
            Console.WriteLine($"{valaszBetui[0]}: {meghagyottValaszok[0]} \t {valaszBetui[1]}: {meghagyottValaszok[1]}");
        }
        
    }
}
