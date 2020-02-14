using System;

namespace ToDoID
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //display sample task list 


            bool yes = true;
            while (yes)
            {
                //options
                Console.WriteLine("[ 1 ] List Tasks\n[ 2 ] Add Task\n[ 3 ] Delete Task\n" +
                                  "[ 4 ] Mark Task Complete\n[ 5 ] Quit");
                //check input is valid
                int navNum = TryCatchInput("");

                //nav options
                switch (navNum)
                {
                    //list all(if null use sample)
                    case 1:

                        break;
                    //add new task
                    case 2:

                        break;
                    //delete task(IF owner)
                    case 3:

                        break;
                    //mark complete
                    case 4:

                        break;
                    //exit loop
                    case 5:
                        Console.WriteLine("Okay, Goodbye.");
                        Console.ReadLine();
                        yes = false;
                        break;

                    default:
                        Console.WriteLine("Sorry, thats not an option.");
                        yes = true;
                        break;
                }

            }

        }
        //checks input is valid & provides error message
        public static int TryCatchInput(string message)
        {
            string input = ToDoList.Get(message);
            try
            {
                int userInput = int.Parse(input);
                return userInput;
            }
            catch (FormatException)
            {
                return TryCatchInput("That was not a number. Please enter a number.");
            }
        }
    }
}
