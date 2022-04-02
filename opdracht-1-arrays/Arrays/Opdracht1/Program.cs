using System;

namespace Opdracht1
{
    class Program
    {
        //method die de eerste een laatste element van een string typed array met elkaar verwisseld @takes string array @return string array
        public static string[] flipArrayValues(string[] ArrayElement) {
            //als de array element lengte 0 heeft
            if (ArrayElement.Length == 0) {
                //return de lege array
                return ArrayElement;
            }
            //pak het eerste element van de string array
            string firstElement = ArrayElement[0];
            //vervang het eerste element van de array met die van de laatste
            ArrayElement[0] = ArrayElement[ArrayElement.Length - 1];
            //vervang het laatste element van de array met de hier boven gepakte eerste element
            ArrayElement[ArrayElement.Length - 1] = firstElement;
            //return de string array
            return ArrayElement;
        }

        //method die de elementen van een array in een string veranderd @takes string array , bool @returns string als de bool als true wordt insgesteld dan moeten de eerste en laatste elementen van de array met elkaar worden verwisseld
        public static string MaakZin(string[] zinArray, bool flipString = false)
        {
            //de string waar de elementen aan worden toegevoegd
            string zin = "";

            //als flipString true is call dan de method die de eerste en laatste elementen van de array met elkaar verwisselen
            if (flipString == true) {
                zinArray = flipArrayValues(zinArray);
            }
            //voor elk woord in de array voeg deze aan de zin string toe met een spatie er achter
            foreach (string woord in zinArray) {
                zin += woord + " ";
            }
            //return de zin string
            return zin;
        }
        static void Main(string[] args)
        {
            //verander de array in een string zonder de eerste en laatste elementen om te wisselen
            Console.WriteLine(MaakZin(new string[] { "Peter", "is" ,"de" ,"broer", "van","Hans"}));
            //verander de array in een string en verwissel de eerste en laatste elementen van de array
            Console.WriteLine(MaakZin(new string[] { "Peter", "is", "de", "broer", "van", "Hans" },true));

        }
    }
}
