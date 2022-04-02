using System;
using System.Collections.Generic;

namespace Opdracht2
{
    class Program
    {
        //method that checks if the user input is a whole number
        public static bool IsNummer(string userInput)
        {
            
            try
            {   //convert the user input to an int
                Convert.ToInt32(userInput);
                //return true
                return true;
            }
            //if an error happens that means the input is not a whole number
            catch (System.FormatException e) {
                //return false
                return false;
            }
        }

       
        //method die een kaart gebaseerd op de key value geeft dat een nr is @takes int @returns string
        private static string GeefKaart(int kaartNummer) {
            //dictionary(assoc array) met alle data van de kaarten
            IDictionary<int,string> kaartKeuzes = new Dictionary<int, string>() { { 1,"ruiten"},{ 2,"harten"},{ 3,"klaveren"},{ 4,"schoppen"} };
            //de kaart die getrokken is
            string kaartKeuze = kaartKeuzes[kaartNummer];
            //return de string output
            return String.Format("U heeft {0} gekozen. Dat is {1}",kaartNummer,kaartKeuze);
        }

        //method that runs the program and handles the do loop etc @void
        public static void runProgram()
        {
            //pre declared string var
            string nummer;
            //pre declared int var
            int intNummer;
            //run this code at least once
            do
            {
                Console.WriteLine("Voer een nummer vanaf 1 tm 4 in");
                //pak de user input
                nummer = Console.ReadLine();
                //als het geen heel nummer is
                if (IsNummer(nummer) == false)
                {
                    //stel intNummer in zodat de loop geen error gooit
                    intNummer = 0;
                    //geef de warning message
                    Console.WriteLine("{0} is geen geldig nummer vanaf 1 tm 4 probeer het opnieuw!", nummer);
                }
                //als de user input wel een heel nummer is
                else
                {
                    //convert de string om naar int
                    intNummer = Convert.ToInt32(nummer);
                    //als het nummer buiten de range van de keys voor de te kiezen kaarten valt
                    if (intNummer < 1 || intNummer > 4)
                    {
                        //laat de warning message zien
                        Console.WriteLine("{0} is geen geldig nummer vanaf 1 tm 4 probeer het opnieuw!", intNummer);
                        //continue de loop naar de volgende iteration. Zodat de user opnieuw een input moet invoeren
                        continue;
                    }
                    //als het nummer binnen de range van de keys voor de te kiezen kaarten valt
                    else
                    {
                        //kies de kaart die gekoppeld staat aan het kaartnummer wat de user heeft ingevoerd.
                        Console.WriteLine(GeefKaart(intNummer));
                    }
                }
            //zolang intNummer buiten de te kiezen key range van de kaarten valt blijf deze loop runnen
            } while (intNummer < 1 || intNummer > 4);
        }
        static void Main(string[] args)
        {
            //start het programma om een kaart te kiezen
            runProgram();
        }
    }
}
