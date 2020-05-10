using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaProject
{
    class Contact : IComparable<Contact>
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public Contact(string name, string phonenumber, string email)
        {
            Name = name;
            PhoneNumber = phonenumber;
            Email = email;
        }

        public Contact()
        {
        }

        public override bool Equals(object obj)
        {
            if(obj == null)
            {
                return false;
            }

            Contact c = obj as Contact; //if it can be casted, then Contact is different from null
             if(c == null)
            {
                return false;
            }

            return (Name == c.Name && PhoneNumber == c.PhoneNumber && Email == c.Email);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashName = (Name != null ? Name.GetHashCode() : 0);
                int hashPhone = (PhoneNumber != null ? PhoneNumber.GetHashCode() : 0);
                int hashEmail = (Email != null ? Email.GetHashCode() : 0);

                return (hashName * 397) * (hashPhone) * (hashEmail);
            }
        }

        public override string ToString()
        {
            return string.Format("Name: {0}\nPhone number: {1}\nEmail: {2}\n", Name, PhoneNumber, Email);
        }

        public int CompareTo(Contact other)
        {
            return Name.CompareTo(other.Name);    
        }          
    }
}
