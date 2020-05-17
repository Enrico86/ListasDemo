using System;
using System.Collections.Generic;
using System.Text;

namespace ListasDemo.Model
{
    public class Contactos
    {
        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        private string Phone;

        public string _phone
        {
            get { return Phone; }
            set { Phone = value; }
        }

        private string Email;

        public string _email
        {
            get { return Email; }
            set { Email = value; }
        }


    }
}

