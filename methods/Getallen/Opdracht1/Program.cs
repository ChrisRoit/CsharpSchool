using System;

namespace Opdracht1
{
    class Program
    {
        private static int LeesHeelGetal()
        {
            //probeer deze code te runnen. zal moeten lukken als het een heel getal is
            try
            {
                //console output
                Console.WriteLine("Voer een getal in.");
                //user input die van string naar int32 wordt omgezet
                int getal = Convert.ToInt32(Console.ReadLine());
                //laat de gebruiker weten dat hun invoer een heel getal is
                Console.WriteLine(getal + " is een heel getal.");
            }
            //als de bovenste try clausule niet lukt dan is de ingevoerde data geen heel getal
            catch (System.FormatException e) {
                Console.WriteLine("De invoer is geen heel getal!");
            }
            //return is bij deze method niet nodig? waarom heeft deze method een return type integer? de output op het scherm is het data type string, had beter een string kunnen returnen of void kunnen zijn.
            return 1;
        }

        //method die de som van 2 getalen berekend
        private static string Som(int getal1, int getal2) {
            int som = getal1 + getal2;
            return String.Format("De som van {0} en {1} is {2}", getal1, getal2, som);

        }

        //method die het verschil tussen 2 getalen berekend
        private static string Verschil(int getal1, int getal2){
            //bereken het verschil door altijd het grootste getal - het kleinste getal uit te rekenen
            int verschil = Math.Max(getal1, getal2) - Math.Min(getal1,getal2);
            //format de string
            return String.Format("Het verschil tussen {0} en {1} is {2}",getal1,getal2,verschil);
        }

        //method die een vermenigvuldiging van de twee getalen uitrekent
        private static string Product(int getal1, int getal2) {
            int vermenigvuldiging = getal1 * getal2;
            return String.Format("Het product van {0} en {1} is {2}",getal1,getal2,vermenigvuldiging);
        }
        static void Main(string[] args)
        {
            //call leesHeelGetal method
            //LeesHeelGetal();
            //Console.WriteLine(Som(15, 3));
            //Console.WriteLine(Verschil(2,20));
            Console.WriteLine(Product(37, 22));

        }
    }
}
