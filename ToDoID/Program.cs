using System;
using System.Collections.Generic;

namespace ToDoID
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to your new task menu!\nCreate a new task that needs to be done.");
            //display sample task list to create and edit
            int i = 1;
            List<ToDoList> sampleList = new List<ToDoList>
                {
                    new ToDoList{Count=i++, TaskName="Example Task", TaskFor="You", Description="This is a sample task description.", DueDate="Today", Status="[ ]"}
                       
            };
            ToDoList.DoList(sampleList);

            //newList made by user can be deleted
            List<ToDoList> newList=new List<ToDoList> { };

            bool yes = true;
            while (yes)
            {
                //options
                Console.WriteLine("\n[ 1 ] List Tasks\n[ 2 ] Add Task\n[ 3 ] Delete Task\n" +
                                  "[ 4 ]Update Status \n[ 5 ] Quit");
                //check input is valid
                int navNum = TryCatchInput("");

                //nav options
                switch (navNum)
                {
                    //list all(if null use sample)
                    case 1:
                        if (newList.Count == 0)
                        {
                        ToDoList.DoList(sampleList);
                        }
                        else
                        {
                            ToDoList.DoList(newList);
                        }
                        break;
                    //add new task: string taskname, string taskfor, string description, string status, string duedate, taskid for edit/delete
                    case 2:
                        
                        newList.Add(
                        new ToDoList { Count = newList.Count, TaskName = ToDoList.Get("Enter the task title."), TaskFor = ToDoList.Get("Enter the name of the person this task is for. They will need to enter this name to mark complete."), 
                        Description=ToDoList.Get("Describe the task with and details it may require."), DueDate= ToDoList.Get("Enter the date or time the task should be completed by."), Status="[ ]", 
                            TaskId= ToDoList.Get("Enter a phrase you'll need to enter to edit or delete this task.")
                        });
                        break;
                    //delete task(IF owner:taskId)
                    case 3:
                        //makes sure user has created one first
                        if (newList.Count == 0)
                        {
                            Console.WriteLine("Sorry, first you need to create a task before you can delete one.");
                        }
                        else
                        {
                            ToDoList.DoList(newList);
                        int thisTask = TryCatchInput("Enter the task number you want to delete")-1;
                        string ownerCheck = ToDoList.Get("To delete "+ (thisTask+1)+" task the phrase that you created with it must be entered");
                            //checks the task # in list for the taskid index matches the users input before its deleted
                            if (thisTask >= 0 && thisTask <= newList.Count && newList[thisTask].TaskId == ownerCheck)
                            {
                                newList.RemoveAt(thisTask);
                            }
                            else
                            {
                                Console.WriteLine("Sorry, '"+ownerCheck+"' was not the correct phase created with task"+(thisTask+1)+" : "+newList[thisTask].TaskName+"\n" +
                                    "Please try again or ask the user who created this task for the phrase");
                            }
                        }

                        break;
                    //mark complete(IF taskFor == name input)
                    case 4:
                        ToDoList.DoList(newList);
                        //checks for null list
                        if (newList.Count == 0)
                        {
                            Console.WriteLine("Before you can change a tasks status you have to create a task.");
                            break;
                        }
                        int statusNum = TryCatchInput("\nEnter the number of the task you'd like to mark complete.")-1;
                        string nameCheck = ToDoList.Get("Before you can change the status, please enter your name to validate this task was for you.");
                        //is a match
                        if (nameCheck == newList[statusNum].TaskFor)
                        {
                            string input = ToDoList.Get("Would you like this task to be marked as complete? [Yes] [No]");
                            ToDoList.StatusIs(input, statusNum, newList);
                        }

                        //task isnt for that name
                        else
                        {
                            Console.WriteLine("Sorry, the person this task was created for does not match that name.");
                        }
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
