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
            private static string filename;
            public static string Filename
            {
                get { return filename; }
                set { filename = value; }
            }

            protected static void makeFile(bool renew = false)
            {
                if (!File.Exists(Filename) || renew == true)
                {
                    File.Create(Filename);
                }
            }

            protected static string[] readFromFile()
            {
                return File.ReadAllLines(Filename);
            }

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
        class TrafficController : BestandController
        {

            public static Dictionary<String, Double> Initialiseer()
            {
                makeFile();
                return new Dictionary<String, Double>();
            }

            public static void Simuleer()
            {

            }

        }
        static void Main(string[] args)
        {
            TrafficController.Filename = "fileData.txt";
            TrafficController.Simuleer();
            TrafficController.Initialiseer();
            Console.WriteLine(TrafficController.Filename);
            Console.WriteLine("Hello World!");
        }
    }
}
