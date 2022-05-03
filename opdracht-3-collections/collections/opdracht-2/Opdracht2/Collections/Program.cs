using System;
using System.IO;
using System.Linq;
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
            //class field
            private static Dictionary<string, double> cars;
            //class field
            private static Queue<string> trafficjam;


            public static string Choice
            {
                get { return choice; }
                set { choice = value; }
            }

                  
            //get/set class property logic
            public static Dictionary<string, double> Cars
            {
                get { return cars; }
                set { cars = value; }
            }

            //get/set class property logic
            public static Queue<string> Trafficjam
            {
                get { return trafficjam; }
                set { trafficjam = value; }
            }


            //method die de keuze van de gebruiker verwerkt. Of dit nou een voertuig in/uit de file toevoegen of verwijderen is. Laat het de gebruiker weten als deze een keuze kiest die niet kan worden verwerkt.
            public static void HaalKeuze() {
                Console.WriteLine("Wilt u een auto toevoegen, verwijderen of wilt u het programma stopzetten? Maak uw keuze: ");
                Choice = Console.ReadLine().ToLower();
                switch (Choice) {
                    case "toevoegen":
                        VoegToe();
                        Console.WriteLine(PrintFileGegevens());
                        break;
                    case "verwijderen":
                        Verwijder();
                        Console.WriteLine(PrintFileGegevens());
                        break;
                    case "stoppen":
                        closeProgram();
                        break;
                    default:
                        Console.WriteLine("U heeft een verkeerde keuze ingevoerd. U kunt kiezen uit: Toevoegen, Verwijderen of stoppen.\n\n");
                        break;
                }
            }

            //method die een voertuig toevoegt aan de file(queue) @returns string
            private static string VoegToe() {
                Console.WriteLine("Typ welk voertuig er in de file moet komen, u kunt alleen vanuit deze lijst kiezen: \n");
                string vehicle = HaalVoertuig();
                Trafficjam.Enqueue(vehicle);
                return String.Format("U heeft {0} toegevoegd aan de file.",Choice);
            }

            //method die alle mogelijke voertuigen laat zien
            private static string HaalVoertuig() {
                foreach (var pair in Cars)
                {
                    Console.WriteLine(pair.Key + "\n");
                }
                return Console.ReadLine();
            }

            //method verwijderd het eerste element uit de queue
            private static string Verwijder() {
                string firstCar = Trafficjam.Peek();
                Trafficjam.Dequeue();
                return String.Format("Het voertuig {0} is uit de file verwijderd\n",firstCar); 
            }

            //method die de file returns @returns string
            private static string Printvoertuigen() {
                string trafficJamContents = "";
                foreach (string car in Trafficjam.ToList()) {
                    trafficJamContents = trafficJamContents + String.Format("[{0}] ", car);
                }
                return trafficJamContents;
            }

            //method die de file laat zien en het aantal voertuigen in de file telt @returns string
            private static string PrintFileGegevens() {
                string trafficJamContents = Printvoertuigen();
                trafficJamContents = trafficJamContents + String.Format("\n\n Aantal voertuigen in de file: {0}\n\n",Trafficjam.Count());
                return trafficJamContents;
            }

            //method die de file in een text bestand op slaat als het programma wordt afgesloten.
            private static string closeProgram() {
                foreach (string car in Trafficjam) {
                    writeToFile(car);
                }
                return "Program closed";
            }

           

        }
        class TrafficController : UserInterFace
        {
            //method die alle benodigde data inlaad en initialiseert (de queue, de beschikbare voertuigen en het aanmaken van het bestand waar de file in wordt opgeslagen als het programma afsluit).
            public static void Initialiseer()
            {
                Filename = "fileData.txt";
                makeFile();
                Trafficjam = new Queue<string>();
                Cars = new Dictionary<string, double>() {
                    { "Audi",1.5},
                    { "BMW",2.2},
                    { "Chevy",3.8},
                    { "Dodge",5.1}

                };
            }

            //method die een file simuleert via een do while loop en constant haalKeuze aanhaalt.
            public static void Simuleer()
            {
                do {
                    HaalKeuze();
                } 
                while (Choice != "stoppen");
            }

        }
        static void Main(string[] args)
        {    
            TrafficController.Initialiseer();
            TrafficController.Simuleer();
            
        }
    }
}
