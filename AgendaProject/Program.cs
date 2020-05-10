using System;
using System.Text;

namespace AgendaProject
{
    class Program
    {
        static Control control = new Control(new Agenda());
        static void Main(string[] args)
        {
            string choice = "";

            do
            {
                Console.Clear();
                Console.WriteLine("Contacts Agenda");
                PrintMenu();
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        control.SeeContacts();
                        break;
                    case "2":
                        control.AddContact();
                        break;
                    case "3":
                        control.DeleteContact();
                        break;
                    case "4":
                        control.SearchByName();
                        break;
                    case "5":
                        break;
                    default:
                        Console.WriteLine("Not valid option");
                        break;
                }
            } while (choice != "5");
       
        }

        static void PrintMenu()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("1. See contacts");
            sb.AppendLine("2. Add contact");
            sb.AppendLine("3. Delete a contact");
            sb.AppendLine("4. Search contact by name");
            sb.AppendLine("5. Exit");
            sb.AppendLine("Choise one option: ");

            Console.Write(sb);
        }
    }
}
