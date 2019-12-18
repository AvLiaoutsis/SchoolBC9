using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1st
{
    class Trainer
    {
        public int ID { get; set; }

        private string firstName;
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = Function.CheckEmpty(value);
            }
        }
        private string lastName;
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = Function.CheckEmpty(value);
            }
        }
        public string Subject { get; set; }

        public List<Course> courses;
        public Trainer(int id ,string firstname,string lastname, string subject)
        {
            ID = id;
            FirstName = firstname;
            LastName = lastname;
            Subject = subject;
        }

        public override string ToString()
        {
            return $"Trainer:\nFirst Name : {FirstName}\nLast Name : {LastName}\nSubject : {Subject}\n";
        }
    }
}
