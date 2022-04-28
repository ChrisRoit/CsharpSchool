using System;
using System.Collections;
using System.Collections.Generic;


namespace Opdracht1
{
    class StackManager {
        protected Stack<string> customStack;
        protected int aantal;
        public StackManager(int aantalElements) {
            customStack = new Stack<string>();
            aantal = aantalElements;
        }

        //method die de stack met waardes die de user invult vult.
        private void VulStack(){
            for (int i = 0; i < this.aantal; i++) {
                Console.WriteLine(String.Format("Geef waarde aan nummer {0}: ",i+1));
                string gekozenString = Console.ReadLine();
                this.customStack.Push(gekozenString);
            }
        }

        //method die de stack values uitprint
        private void PrintStack() {
            foreach (string woord in this.customStack) {
                Console.Write(" {0}",woord);
            }
            Console.WriteLine();
        }

        //method die kijkt of het gekozen element in de stack bestaat @takes string @retuns bool
        private bool checkStack(string element) {
            return this.customStack.Contains(element);
        }

        //method die kijkt of de gekozen string in de stack bestaat, of deze boven aan de stack staat en zoja deze uit de stack verwijderd @takes string returns @string
        private string checkRemoval(string element) {
            if (this.checkStack(element) != true) {
                return String.Format("De string {0} bestaat niet in deze stack.", element);
            }
            if (this.customStack.Peek() != null && this.customStack.Peek() != element) {
                return String.Format("De string {0} bestaat in deze stack maar staat niet boven aan.",element);
            }
            return String.Format("De string {0} bestaat in deze stack en staat boven aan de stack. De string wordt van de stack verwijderd.",this.customStack.Pop());
        }

        public void execute(Stack<string> stapel) {
            //vul de stack
            this.VulStack();
            //print de stack contents
            this.PrintStack();
            Console.WriteLine("Voer een woord in en kijk of deze in de stack bestaat.");
            //user input string waarvan we gaan kijken of deze in de stack bestaat en of of deze string zich boven aan de stack bevindt.
            string checkIfElementOnTopOfStack = Console.ReadLine();
            //kijk of de user input string in de stack bestaat en of deze boven aan de stack staat. Zoja verwijder dan dit element uit de stack(pop)
            Console.WriteLine(this.checkRemoval(checkIfElementOnTopOfStack));
            //output die laat zien hoe de stack er nu uit ziet.
            Console.WriteLine(String.Format("Na het verwerken van het element {0} ziet de stack er als volgt uit: ", checkIfElementOnTopOfStack));
            this.PrintStack();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            StackManager customStack = new StackManager(2);
            customStack.execute(new Stack<string>());
        }
    }
}
