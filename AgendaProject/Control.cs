using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace AgendaProject
{
    /*Class which uses an agenda´s instance as a property and call
    the agenda´s method based on the user´s input by keyboard*/
    class Control
    {
        //Agenda´s instance is a property of the class
        private Agenda _agenda;

        public Control(Agenda agenda)
        {
            _agenda = agenda;
        }

        public void SeeContacts()
        {
            Clear();
            ShowSortMenu();

            string choice = Console.ReadLine().ToUpper();
            Console.WriteLine();
            Clear();

            switch(choice)
            {
                case "A":
                    Console.WriteLine("Contacts shown in ascendant order:");
                    Console.WriteLine();
                    _agenda.ShowContactsSorted(choice);
                    break;
                case "D":
                    Console.WriteLine("Contacts shown in descendant order:");
                    Console.WriteLine();
                    _agenda.ShowContactsSorted(choice);
                    break;
                case "E":
                    return;
                default:
                    Console.WriteLine("Choice not recognized");
                    break;
            }
            PressToContinue();
        }

        public void ShowSortMenu()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("A. Show ascendant order");
            sb.AppendLine("D. Show descendant order");
            sb.AppendLine("E. Return to main menu");
            sb.AppendLine("Choose an option");

            Console.WriteLine(sb.ToString());
        }

        public void AddContact()
        {
            Clear();
            Console.WriteLine("Add new contact");

            Contact contact = new Contact();
            Console.WriteLine("Name");
            contact.Name = Console.ReadLine();
            Console.WriteLine("Phone Number");
            contact.PhoneNumber = Console.ReadLine();
            Console.WriteLine("Email");
            contact.Email = Console.ReadLine();

            _agenda.AddContact(contact);
            Clear();
            Console.WriteLine("Contact succesfully added ");
            PressToContinue();
        }

        public void DeleteContact()
        {
            Clear();

            Console.WriteLine("Enter the name of the contact");
            string name = Console.ReadLine();

            try
            {
                _agenda.DeleteContact(name);
                Clear();
                Console.WriteLine("Contact {0} succesfully deleted", name);
            } catch(Exception e)
            {
                Clear();
                Console.WriteLine("The contact {0} does not exist", name);
            }
         

            PressToContinue();
        }

        public void SearchByName()
        {
            Clear();

            Console.WriteLine("Search contact");
            Console.WriteLine("Enter the name");
            string name = Console.ReadLine();
            Clear();

            Contact contact = _agenda.SearchByName(name);
            if(contact != null)
            {
                Console.WriteLine("Contact is \n" + contact);
            }
            else
            {
                Console.WriteLine("Contact not found");
            }

            PressToContinue();
        }

        private static void Clear()
        {
            Console.Clear();
        }
        
        private static void PressToContinue()
        {
            Console.WriteLine("Press to continue");
            Console.ReadKey();
        }
    }
}
