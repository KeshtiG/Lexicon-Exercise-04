/* Svar på frågor:
 * 
 * 1. (Se bild "Images/Fråga1.png")
 * Stacken är ett snabbt korttidsminne där varje metod lagras enligt
 * First In Last Out-principen. Efter att metoden har körts tas den bort
 * ur stacken, och nästa metod i turordning körs. Minnet rensas automatiskt.
 * 
 * Heapen är ett långsammare långtidsminne där objekt lagras i olika
 * minnesplatser. Man kan komma åt vilket objekt som helst i heapen, vilket
 * gör den mer flexibel, men också mer resurskrävande. Heapen rensas inte
 * automatiskt utan behöver någon typ av manuell rensning (garbage collection).
 * 
 * 
 * 2. En value type är en datatyp som lagras i stacken och lagrar värdet direkt
 * i exempelvis en variabel, alltså en egen version av ett värde.
 * 
 * En reference type är en datatyp som pekar på en minnesadress i heapen där
 * värdet lagras. Två reference types kan peka på samma minnesadress, och en 
 * förändring av värdet i den ena påverkar därför även den andra.
 * 
 * 
 * 3. I metod nr. 2 anropas (vad som ser ut som) en klass vilken lagras på heapen,
 * eftersom det är en referenstyp. Även fast man tilldelar x och y olika
 * instanser av klassen med "new", så pekas sedan y om till adressen för x
 * med "y = x". "y.MyValue" och "x.MyValue" pekar därför nu på samma objekt på
 * heapen, vilket innebär att "y.MyValue = 4" även ändrar värdet på "x.MyValue".
 * 
 */


using System;

namespace SkalProj_Datastrukturer_Minne;

class Program
{
    /// <summary>
    /// The main method, vill handle the menues for the program
    /// </summary>
    /// <param name="args"></param>
    static void Main()
    {

        while (true)
        {
            Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                + "\n1. Examine a List"
                + "\n2. Examine a Queue"
                + "\n3. Examine a Stack"
                + "\n4. CheckParenthesis"
                + "\n0. Exit the application");
            char input = ' '; //Creates the character input to be used with the switch-case below.
            try
            {
                input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
            }
            catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
            {
                Console.Clear();
                Console.WriteLine("Please enter some input!");
            }
            switch (input)
            {
                case '1':
                    ExamineList();
                    break;
                case '2':
                    ExamineQueue();
                    break;
                case '3':
                    ExamineStack();
                    break;
                case '4':
                    CheckParanthesis();
                    break;
                /*
                 * Extend the menu to include the recursive 
                 * and iterative exercises.
                 */
                case '0':
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                    break;
            }
        }
    }

    /// <summary>
    /// Examines the datastructure List
    /// </summary>
    static void ExamineList()
    {
        bool done = false;

        // Create a new empty list (with a count and capacity of 0)
        List<string> theList = new();

        Console.WriteLine("Enter '+ your item' to add an item to the list.");
        Console.WriteLine("Enter '- your item' to remove an item from the list.");
        Console.WriteLine("Enter 0 to exit to main menu.");

        do
        {
            Console.Write("Enter your input: ");
            string input = Console.ReadLine() ?? "";

            // Assign the first character to nav and convert it to
            // lowercase (to handle both 'Q' and 'q')
            char nav = char.ToLower(input[0]);

            // Get the rest of the input and trim any whitespace
            string value = input.Substring(1).Trim();

            switch (nav)
            {
                case '+':

                    /* SVAR PÅ FRÅGOR, övning 1:
                     * 
                     * 2 & 3. När en tom lista skapas har den kapacitet 0. När ett element läggs till
                     * ökas kapaciteten till 4. Varje gång listan överskrider den aktuella kapaciteten
                     * dubbleras kapaciteten och den underliggande arrayen kopieras över till en ny,
                     * större array.
                     * 
                     * 4. Min gissning till att kapaciteten dubbleras istället för att
                     * bara utökas med antal element är att det tar för mycket minne att kopiera
                     * elementen till en array varje gång ett element läggs till, och att man därför
                     * tjänar på att dubblera kapaciteten istället. Vill man minska storleken på en
                     * array som har blivit för stor så såg jag att man kan använda "TrimExcess()"
                     * som minskar till antalet element i listan. Hur mycket eller när man tjänar på
                     * det vet kräver dock mer undersökning!
                     * 
                     * 5. Nej, kapaciteten minskas inte när man tar bort ett element.
                     * 
                     * 6. Jag tänker att om man vet i förväg hur många element man vill ha i sin lista,
                     * samt inte behöver använda sig av List-klassens mer komplexa funktionalitet så är
                     * det bättre rent prestandamässigt att använda sig av en array.
                     * 
                     */

                    theList.Add(value);
                    Console.WriteLine($"Added {value} to the list.");

                    // Show how many items the list currently has
                    Console.WriteLine($"List length: {theList.Count}");

                    // Show how many items the list can hold before it needs to resize
                    Console.WriteLine($"List capacity: {theList.Capacity}{Environment.NewLine}");

                    break;

                case '-':
                    // Try to remove the item with the entered value from the list
                    if (theList.Remove(value))
                    {
                        Console.WriteLine($"Removed {value} from the list.");

                        // Show how many items the list currently has
                        Console.WriteLine($"List length: {theList.Count}");

                        // Show how many items the list can hold before it needs to resize
                        Console.WriteLine($"List capacity: {theList.Capacity}{Environment.NewLine}");
                    }

                    // If the item was not found, inform the user
                    else
                    {
                        Console.WriteLine($"{value} not found in the list.");
                    }
                    break;

                case '0':
                    done = true;
                    break;

                default:
                    Console.WriteLine("Use + or - to add or remove items from the list " +
                        "(or 0 to exit to main menu).");
                    break;
            }

        }
        while (!done);
    }

    /// <summary>
    /// Examines the datastructure Queue
    /// </summary>
    static void ExamineQueue()
    {
        Console.WriteLine("Enter 1 for adding an item to the queue.");
        Console.WriteLine("Enter 2 for removing an item from the queue.");
        Console.WriteLine($"Enter 0 to exit to main menu.{Environment.NewLine}");

        // Create a new empty queue
        Queue<string> theQueue = new();

        // Create a done flag
        bool done = false;

        do
        {
            Console.Write("Enter choice: ");
            int choice = int.Parse(Console.ReadLine() ?? "");

            switch (choice)
            {
                // Add an item to the queue
                case 1:
                    Console.Write("Enter an item to add: ");
                    string inputString = Console.ReadLine() ?? "";

                    // Add the item to the queue
                    theQueue.Enqueue(inputString);

                    break;

                // Remove an item from the queue
                case 2:
                    // Check if the queue is empty before trying to dequeue
                    if (theQueue.Count > 0)
                    {
                        // Peek at the first item in the queue
                        Console.WriteLine($"Removed the {theQueue.Peek()} from the queue.");

                        // Dequeue the first item in the queue
                        theQueue.Dequeue();

                        // Show which items the queue currently contains
                        if (theQueue.Count > 0)
                            Console.WriteLine($"The queue: {string.Join(", ", theQueue)}");

                        //Show a message when the queue is empty
                        else
                            Console.WriteLine("The queue is now empty.");
                    }
                    else
                        Console.WriteLine("There are no items in the queue.");
                    
                    break;

                // Exit to main menu
                case 0:
                    done = true;
                    Console.WriteLine("");
                    break;

                default:
                    Console.WriteLine("Please enter a valid choice (1, 2 or 0).");
                    break;
            }
        }
        while (!done);
    }

    /// <summary>
    /// Examines the datastructure Stack
    /// </summary>

    /* Svar på fråga 3.2:
     * En stack fungerar dåligt i en struktur där man vill att saker ska ske
     * i turordning, som i en ICA-kö (det hade varit väldigt orättvist och
     * resulterat i många missnöjda kunder). */
    static void ExamineStack()
    {
        Console.WriteLine("Enter 1 to input a sentence.");
        Console.WriteLine("Enter 2 to display the reversed sentence.");
        Console.WriteLine($"Enter 0 to exit to main menu.{Environment.NewLine}");

        // Create a new empty stack to hold letters
        Stack<char> letterStack = new();

        // Create a done flag
        bool done = false;

        do
        {
            Console.Write("Enter choice: ");
            int choice = int.Parse(Console.ReadLine() ?? "");

            switch (choice)
            {
                // Add an item to the stack
                case 1:
                    Console.Write("Enter a string: ");
                    string inputString = Console.ReadLine() ?? "";

                    // Loop through each character in the input string and
                    // push it onto the stack
                    foreach (char character in inputString)
                    {
                        letterStack.Push(character);
                    }

                    break;

                // Remove an item from the stack
                case 2:
                    // Create an empty string for the reversed string
                    string reversedStr = string.Empty;

                    // Loop through the stack, pop each character and add it
                    // to the reversed string
                    while (letterStack.Count > 0)
                    {
                        reversedStr += letterStack.Pop();
                    }

                    // Print the reversed string
                    Console.WriteLine($"Reversed string: {reversedStr}{Environment.NewLine}");
                    break;

                case 0:
                    done = true;
                    Console.WriteLine("");
                    break;

                default:
                    Console.WriteLine("Please enter a valid choice (1, 2 or 0).");
                    break;
            }
        }
        while (!done);
    }

    static void CheckParanthesis()
    {
        // Create a dictionary to hold the parenthesis pairs
        Dictionary<char, char> paranthesis = new()
        {
            { '(', ')' },
            { '{', '}' },
            { '[', ']' }
        };

        Console.Write("Enter a string: ");
        string input = Console.ReadLine() ?? "";

        // Create a stack to hold the opening paranthesis
        Stack<char> charStack = new();

        bool isCorrect = true;

        // Loop through each character in the input string
        foreach (char character in input)
        {

            // Check if the character is an opening paranthesis
            if (paranthesis.ContainsKey(character))
            {
                // If so, add it to the stack
                charStack.Push(character);
            }

            // Check if the character is a closing paranthesis
            else if (paranthesis.ContainsValue(character))
            {
                // If so, check if the stack is empty (which would mean there are no
                // opening paranthesis to try to match with)
                if (charStack.Count == 0)
                {
                    // If the stack is empty, set the flag to false and break the loop
                    isCorrect = false;
                    break;
                }

                // If the stack is not empty, pop the last opening paranthesis
                char charToCheck = charStack.Pop();

                // Check if the popped opening paranthesis does NOT match the closing
                // paranthesis (as defined in the dictionary)
                if (paranthesis[charToCheck] != character)
                {
                    // If it does not match, set the flag to false and break the loop
                    isCorrect = false;
                    break;
                }
            }
        }

        /* If the flag is set to true (which means no parenthesis were mismatched)
         * and the stack is empty (all parenthesis found their match), tell the user
         * that the test passed */
        if (isCorrect && charStack.Count == 0)
        {
            Console.WriteLine("All parenthesis found their matches, the string was " +
                "correctly formatted. Well done!");
            Console.WriteLine("");
        }

        // If the flag is set to false or the stack is not empty, one or more paranthesis
        // were incorrectly matched, which means the test failed
        else
        {
            Console.WriteLine("The test failed: One or more parenthesis did not match.");
            Console.WriteLine("");
        }
    }

}

