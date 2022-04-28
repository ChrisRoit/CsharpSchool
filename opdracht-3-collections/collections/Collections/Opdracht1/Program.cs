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
        private void VulStack(){
            for (int i = 0; i < this.aantal; i++) {
                Console.WriteLine(String.Format("Geef waarde aan nummer {0}: ",i+1));
                string gekozenString = Console.ReadLine();
                this.customStack.Push(gekozenString);
            }
        }

        private void PrintStack() {
            foreach (string woord in this.customStack) {
                Console.Write(" {0}",woord);
            }
            Console.WriteLine();
        }

        private bool checkStack(string element) {
            return this.customStack.Contains(element);
        }

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
            //Stack<string> customStack = this.VulStack();
            this.VulStack();
            this.PrintStack();
            Console.WriteLine("Voer een woord in en kijk of deze in de stack bestaat.");
            string checkIfElementOnTopOfStack = Console.ReadLine();
            Console.WriteLine(this.checkRemoval(checkIfElementOnTopOfStack));
            Console.WriteLine(String.Format("Na het verwijderen van het element {0} uit de stack ziet de stack er als volgt uit: ", checkIfElementOnTopOfStack));
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
