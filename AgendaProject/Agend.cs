using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AgendaProject
{
    class Agenda
    {
        private const int SIZE = 10; //size of the agenda`s array
        private Contact[] _contacts;
        private int _index;

        public int ContactNumber
        {
            get
            {
                return _index;
            }
        }
        public Agenda()
        {
            _index = 0;
            _contacts = new Contact[SIZE];
        }

        public void AddContact(Contact contact)
        {
            //if agenda is not full
            if(_index < SIZE)
            {
                _contacts[_index] = contact;
                _index++;
            }
            else
            {
                Console.WriteLine("The agenda is full");
            }
        }

        public void DeleteContact(string name)
        {
            var contactToDelete = _contacts.FirstOrDefault(contact => contact.Name == name);
 
            if(_index > 0)
            {
                if (contactToDelete != null )
                {
                    int index = Array.IndexOf(_contacts, contactToDelete);
                    _contacts[index] = null;
                    _index--;
                }                          
            }
            else
            {
                Console.WriteLine("The agenda is already emtpy");
            }
        }

        private bool IsEmpty()
        {
            if(_index == 0)
            {
                return true;
            }

            return false;
        }

        public void ShowContactsSorted(string input)
        {
            if (IsEmpty() != true && (input == "A" || input == "D"))
            {
                Contact[] sortedContacts = new Contact[_index];
                Array.Copy(_contacts, sortedContacts, _index);             
                Array.Sort(sortedContacts);              
                 if(input == "D")
                {
                    Array.Reverse(sortedContacts);
                }
                Console.WriteLine(ContactsChain(sortedContacts));
            }
            else if(IsEmpty())
            {
                Console.WriteLine("The agenda is empty");
            }
          
        }

        public Contact SearchByName(string name)
        {
            foreach (Contact contact in _contacts)
            {
                if(contact != null && contact.Name == name)
                {
                    return contact;
                }
            }

            return null;
        }

        //It calls the ToString method of the instance
        public void ShowContacts()
        {
            Console.WriteLine(this);
        }

        public override string ToString()
        {
            return ContactsChain(_contacts);
        }

        //Iterates through the contacts and parse them one by one to string and add the position
        private string ContactsChain(Contact[] contacts)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _index; i++)
            {
                if(contacts[i] != null)
                {
                    string data = string.Format("{0}. {1}", i + 1, contacts[i]);
                    sb.AppendLine(data);
                }              
            }

            return sb.ToString();
        }
   
    }
}
