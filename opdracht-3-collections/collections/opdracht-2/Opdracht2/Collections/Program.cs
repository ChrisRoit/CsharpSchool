using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Collections
{
    class Program
    {
        class BestandController
        {
            //class field
            private static string filename;

            //class property
            public static string Filename
            {
                get { return filename; }
                set { filename = value; }
            }

            //method die de file aanmaakt. @takes bool. als renew true is maak dan een nieuwe file aan om de huidige file te resetten/leeg te maken.
            protected static void makeFile(bool renew = false)
            {
                if (!File.Exists(Filename) || renew == true)
                {
                    var stream = File.Create(Filename);
                    stream.Close();
                }
            }

            //method die de lines uit de file leest. @returns array. elk element in de array is een line
            protected static string[] readFromFile()
            {
                return File.ReadAllLines(Filename);
            }

            //method die een line in het bestand toevoegd/append @takes string
            protected static void writeToFile(string voertuig)
            {
                if (File.Exists(Filename))
                {
                    using (StreamWriter writer = File.AppendText(Filename))
                    {
                        writer.WriteLine(voertuig);
                        writer.Close();
                    }
                }
            }
        }

        class UserInterFace : BestandController {
            private static string choice;

            public static string Choice
            {
                get { return choice; }
                set { choice = value; }
            }



            public static void HaalKeuze() {
                Console.WriteLine("Wilt u een auto toevoegen, verwijderen of wilt u het programma stopzetten? Maak uw keuze: ");
                Choice = Console.ReadLine().ToLower();
                if (Choice != "toevoegen" && Choice != "verwijderen" && Choice != "stoppen") {
                    Console.WriteLine("U heeft een verkeerde keuze ingevoerd. U kunt kiezen uit: Toevoegen, Verwijderen of stoppen.\n\n");
                    HaalKeuze();
                }
            }

           

        }
        class TrafficController : UserInterFace
        {
            //class field
            private static Dictionary<string, double> cars;

            //get/set class property logic
            public static Dictionary<string, double> Cars
            {
                get { return cars; }
                set { cars = value; }
            }


            //
            public static Dictionary<String, Double> Initialiseer()
            {
                makeFile();
                Dictionary<string, double> trafficjam = new Dictionary<string, double>();
                

                foreach (string car in readFromFile()) {
                    Console.WriteLine(car);
                }
                return new Dictionary<String, Double>();
            }

            //
            public static void Simuleer()
            {

            }

        }
        static void Main(string[] args)
        {
            TrafficController.Cars = new Dictionary<string,double>();
            TrafficController.Filename = "fileData.txt";
            TrafficController.Simuleer();
            TrafficController.Initialiseer();
            Console.WriteLine(TrafficController.Filename);
            Console.WriteLine("Hello World!");
        }
    }
}
