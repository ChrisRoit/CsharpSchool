using System;

namespace Opdracht2
{
    class Program
    {
        //method die met het gekozen aantal rows en columns een 2d array aanmaakt en deze vult met 1 tm de range van het totaal aantal rows van alle columns bij elkaar. @takes int,int @returns 2d array
        public static int[,] fill2dArray(int numberOfRows=3, int numberOfColumns=3) {
            //maak een 2d array aan en declare van te voren hoeveel rows en columns er per row zullen zijn. deze zijn in de params ingesteld.
            int[,] customArray = new int[numberOfRows, numberOfColumns];
            //stel counter in als 1
            int counter = 1;
            //iterate zoveel keer als in de range van numberOfRows wat dus uiteindelijk een row wordt.
            for (int row = 0; row < numberOfRows; row++)
            {
                //iterate zoveel keer als in de range van numberOfColumns wat dus uiteindelijk aan column in de huidige row wordt.
                for (int column = 0; column < numberOfColumns; column++)
                {
                    //stel de huidige column in de huidige row in als de value van counter
                    customArray[row, column] = counter;
                    //increment counter bij 1
                    counter++;
                }
            }
            //return de 2d array 
            return customArray;
        }

        //method die een 2d array omzet naar een leesbare string waardoor de 2d array visueel kan worden bekeken. @takes 2d int array @returns string
        public static string visualizeArray(int[,]custom2dArray) {
            //de string die de array moet visualiseren.
            string visualizedArray = "";
            //kijk hoeveel rows de array heeft
            int rowLength = custom2dArray.GetLength(0);
            //kijk hoeveel columns er in een row zijn
            int columnLength = custom2dArray.GetLength(1);
            //voor elke row in de 2d array
            for (int row = 0; row < rowLength; row++) {
                //voor elke column in de huidige row
                for (int column = 0; column < columnLength; column++) {
                    //voeg de column value toe aan de visualizedArray string var en voeg een spatie aan het einde toe om het mooier te maken.
                    visualizedArray = visualizedArray + custom2dArray[row,column] + " ";
                }
                //aan het einde van de row voeg een new line toe aan de string
                visualizedArray = visualizedArray + "\n";
            }
            //return de string wat een visuele presentatie is van de 2d array.
            return visualizedArray;
        }
        static void Main(string[] args)
        {
            //maak de 2d array aan
            int[,] customArray = fill2dArray();
            //laat de 2d array visueel in de console zien.
            Console.WriteLine(visualizeArray(customArray));

        }
    }
}
