using System;
using System.Collections.Generic;
using System.Text;

namespace Legyen_Ön_Is_Milliomos
{
    class Kerdes
    {
        public int nehezseg;
        public string kerdes;
        public string valaszA;
        public string valaszB;
        public string valaszC;
        public string valaszD;
        public string helyesValasz;
        public bool menthetoE;
        

        public Kerdes(int nehezseg, string kerdes, string valaszA, string valaszB, string valaszC, string valaszD, string helyesValasz, bool menthetoE)
        {
            this.nehezseg = nehezseg;
            this.kerdes = kerdes;
            this.valaszA = valaszA;
            this.valaszB = valaszB;
            this.valaszC = valaszC;
            this.valaszD = valaszD;
            this.helyesValasz = helyesValasz;
            this.menthetoE = menthetoE;
        }
        public override string ToString()
        {
            return $"Kerdes: {kerdes} \n A:{valaszA} \t B:{valaszB} \n C:{valaszC} \t D:{valaszD}";
        }
    }
}
