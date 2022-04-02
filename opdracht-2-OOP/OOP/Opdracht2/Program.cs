using System;
using Personen;
using System.Collections.Generic;
using static System.Console;

namespace Opdracht2
{
    class PersonenController
    {
        //de private list alleen toegankelijk via deze class
        private static List<Persoon> _personen;
        //de public static list die ingesteld kan worden met een private set
        public static List<Persoon> personen { get { return _personen; } private set { _personen = value; } }
        //de constructor
        public PersonenController()
        {
            //als de class wordt initialized stel dan personen in als de nieuwe lijst
            personen = new List<Persoon>();
        }

        //method die elk persoon zijn gegevens invult @void
        private void Invullen()
        {
            //string array met de 2 geslachten
            string[] genders = { "M", "V" };
            for (int i = 0; i < 8; i++)
            {
                //maak een new random obj
                var random = new Random();
                //kies een random index van de genders array
                int chosenIndex = random.Next(genders.Length);
                //maak een nieuw persoon object
                Persoon person = new Persoon();
                //stel de voornaam string in gebruik string formatting
                person.voornaam = String.Format("Person{0}", i);
                //stel de achternaam string in gebruik string formatting
                person.achternaam = String.Format("Haxotor{0}", i);
                //de geboortedatum string
                person.geboortedatum = "1/2/1998";
                //pak de geslacht string via de random gekozen index uit de genders array
                person.geslacht = genders[chosenIndex];
                //voeg de persoon object met de gekozen persoon data toe aan de personen list
                personen.Add(person);
            }
        }

        //method die de personen lijst weergeeft @void
        private void PersonenWeergeven()
        {
            //de string waar de persoon data op de juiste plek wordt ingevoerd via string formatting
            string persoonLayout = "----------\n\n Voornaam: {0}\nAchternaam: {1}\nGeboorteDatum: {2}\nGeslacht:{3}\n\n----------\n\n\n\n";
            //voor elk persoon object in de personen list
            foreach (Persoon person in personen)
            {
                //output de data
                Console.WriteLine(String.Format(persoonLayout, person.voornaam, person.achternaam, person.geboortedatum, person.geslacht));
            }

        }

        //method die de bovenste methods in de juiste volgorde laat af gaan @void
        public void execute() {
            this.Invullen();
            this.PersonenWeergeven();

        }
    }
    
    class Program
    {
        //de private list alleen toegankelijk via deze class
        private static List<Persoon> _personen;

        //de public static list die ingesteld kan worden
        public static List<Persoon> personen { 
            get { return _personen; } 
            set { _personen = value; } 
        }

        //method die elk persoon zijn gegevens invult @void
        private static void Invullen()
        {
            //string array met de 2 geslachten
            string[] genders = { "M", "V" };
            for (int i = 0; i < 8; i++)
            {
                //maak een new random obj
                var random = new Random();
                //kies een random index van de genders array
                int chosenIndex = random.Next(genders.Length);
                //maak een nieuw persoon object
                Persoon person = new Persoon();
                //stel de voornaam string in gebruik string formatting
                person.voornaam = String.Format("Person{0}", i);
                //stel de achternaam string in gebruik string formatting
                person.achternaam = String.Format("Haxotor{0}", i);
                //de geboortedatum string
                person.geboortedatum = "1/2/1998";
                //pak de geslacht string via de random gekozen index uit de genders array
                person.geslacht = genders[chosenIndex];
                //voeg de persoon object met de gekozen persoon data toe aan de personen list
                personen.Add(person);
            }
        }

        //method die de personen lijst weergeeft @void
        private static void PersonenWeergeven()
        {
            //de string waar de persoon data op de juiste plek wordt ingevoerd via string formatting
            string persoonLayout = "----------\n\n Voornaam: {0}\nAchternaam: {1}\nGeboorteDatum: {2}\nGeslacht:{3}\n\n----------\n\n\n\n";
            //voor elk persoon object in de personen list
            foreach (Persoon person in personen)
            {
                //output de data
                Console.WriteLine(String.Format(persoonLayout, person.voornaam, person.achternaam, person.geboortedatum, person.geslacht));
            }

        }


        static void Main(string[] args)
        {
            //DE NON STATIC MANIER VIA EEN ANDERE CLASS
            //PersonenController nietStatic = new PersonenController();
            //nietStatic.execute();
            //DE STATIC MANIER VIA DE CLASS ZELF ZONDER EEN OBJECT TE INITIALISEREN
            personen = new List<Persoon>();
            Invullen();
            PersonenWeergeven();
        }
    }
}
