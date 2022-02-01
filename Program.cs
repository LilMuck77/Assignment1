
using System;
using System.IO;

namespace Program;


class Program
{
    static void Main(string[] args)
    {
        string file = "tickets.txt";
        string usersChoice;
        do
        {
            Console.WriteLine("1) Read the data from file.");
            Console.WriteLine("2) Create file from users data.");
            Console.WriteLine("Enter anything else to exit.");

            usersChoice = Console.ReadLine();

            if (usersChoice == "1")
            {
                if (File.Exists(file))
                {
                    StreamReader sr = new StreamReader(file);
                    string readFirstLine = sr.ReadLine();
                    while (!sr.EndOfStream)
                    {
                        string data = sr.ReadLine();
                        string[] arrayData = data.Split(',');
                        Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}", arrayData[0], arrayData[1], arrayData[2], arrayData[3], arrayData[4], arrayData[5], arrayData[6]);
                        //string watching = arrayData[6];

                    }
                    sr.Close();
                }
                else
                {
                    Console.WriteLine("File does not exist");
                }
            }
            else if (usersChoice == "2") 
            {
                StreamWriter StreamWriter = new StreamWriter(file);

                Console.WriteLine("Enter the TicketID:");
                string TicketID = Console.ReadLine();

                Console.WriteLine("Enter the summary:");
                string Summary = Console.ReadLine();

                Console.WriteLine("Enter the status:");
                string Status = Console.ReadLine();

                Console.WriteLine("Enter the priority:");
                string Priority = Console.ReadLine();

                Console.WriteLine("Enter the name of the submitter:");
                string Submitter = Console.ReadLine();

                Console.WriteLine("Enter who it's assigned to:");
                string Assigned = Console.ReadLine();


                Console.WriteLine("How many are watching?");
                string numbersOfWatchers = Console.ReadLine();
               int num =  Int32.Parse(numbersOfWatchers);
                string [] watching;
                List<string> list = new List<string>();
                for (int i = 0; i < num; i++)
                {
                    

                    Console.WriteLine("Name of person " + (i + 1));
                    string person = Console.ReadLine();
                    
                    list.Add(person);
               //string[] watching = Console.ReadLine();
                
                }
                watching = list.ToArray();
                string Watchers = string.Join('|', watching);
                StreamWriter.WriteLine("TicketID,Summary,Status,Priority,Submitter,Assigned,Watching");
                StreamWriter.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}", TicketID, Summary, Status, Priority, Submitter, Assigned, Watchers);

                Console.WriteLine("File successfully created...");
                Console.WriteLine("Reading File now...");
              
                StreamWriter.Close();
               
            }
            
        } while (usersChoice == "1" || usersChoice == "2");


    }

}
