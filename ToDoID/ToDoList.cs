using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoID
{
    class ToDoList
    {


        //props
        public string TaskName { get; set; }
        public string TaskFor { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string DueDate { get; set; }
        public int Count { get; set; }

        //construct
        public ToDoList()
        {

        }

        public ToDoList(string taskname, string taskfor, string description, string status, string duedate)
        {
            TaskName = taskname;
            TaskFor = taskfor;
            Description = description;
            Status = status;
            DueDate = duedate;
        }

        public void ShowList()
        {
            {   //output format
                Console.WriteLine("_________________________________________________");
                Console.WriteLine("Task Number " + (Count) + "]  Team member: " + TaskFor + "");
                Console.WriteLine("Task: "+TaskName+"   Description: " + Description);
                Console.WriteLine("Due Date: " + DueDate + "   Status: " + Status);
                Console.WriteLine("_________________________________________________");
            }
        }

        public static List<ToDoList> DoList(List<ToDoList> list)
        {
            foreach(ToDoList toDo in list)
            {
                toDo.ShowList();
            }
            return list;
        }

        //sets value to user input
        public static string Get(string prompt)
        {
            Console.WriteLine(prompt);
            string inputPrompted = Console.ReadLine();
            return inputPrompted;
        }

        //lets the user edit the status of the task selected
        public static List<ToDoList> StatusIs(string input, int number, List<ToDoList> statusUpdate)
        {
            //if y: user wants to mark complete
            if (input.ToLower() == "yes" || input.ToLower() == "y")
            {
                //find the task # the user wants to change to get status index
                statusUpdate[number - 1].Status = "[X] Complete";
                return statusUpdate;
            }
            //if n: user wants to mark not complete
            if (input.ToLower() == "no" || input.ToLower() == "n")
            {
                statusUpdate[number - 1].Status = "[ ] Not Complete";
                return statusUpdate;
            }
            return statusUpdate;
        }
    }
}
