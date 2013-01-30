using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace IsimonWorld
{
    public static class PseudoAlea
    {

        private static Random r = new Random((int)DateTime.Now.Ticks);

        private static double nb = 0.0;

        private static bool old = false;

        public static int GetInt(int min, int max)
        {
            return r.Next(min, max+1);       
        }

        public static double GetDouble()
        {
            return r.NextDouble();
        }


        static double boxMuller(double inMoyenne, double inEcartType)
        {
            nb = 0.0;
            old = false;
            if (!old)
            {
                double x, y, r;
                do
                {
                    x = 2.0 * GetDouble() - 1;
                    y = 2.0 * GetDouble() - 1;
                    r = x * x + y * y;
                }
                while (r == 0.0 || r > 1.0);
                {
                    double d = Math.Sqrt(-2.0 * Math.Log(r) / r);
                    double n = x * d;
                    nb = y * d;
                    double res = n * inEcartType + inMoyenne;
                    old = true;
                    return res;
                }
            }
            else
            {
                old = false;
                return nb * inEcartType + inMoyenne;
            }

        }



        static int tableDeRepartition(int inNombreClasse, int[] inTabEffectif)
        {

            int i, j, total = inTabEffectif[0];
            double[] table = new double[inNombreClasse];
            double random;

            table[0] = inTabEffectif[0];

            for (i = 1; i < inNombreClasse; i++)
            {
                table[i] = inTabEffectif[i] + table[i - 1];
                total += inTabEffectif[i];
            }

            for (i = 0; i < inNombreClasse; i++)
                table[i] /= total;

            random = GetDouble();

            for (j = 0; j < inNombreClasse; j++)
            {
                if (random < table[j])
                    return j;
            }
            return j;
        }






    }
}
