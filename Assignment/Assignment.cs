using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1st
{
    class Assignment 
    {
        public int ID { get; set; }
        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = Function.CheckEmpty(value);
            }
        }
        public string Description { get; set; }

        private DateTime subDateTime;
        public DateTime SubDateTime
        {
            get
            { 
                return subDateTime; 
            }
            set
            {
                if (value > DateTime.Now)
                {
                    if ((value.DayOfWeek == DayOfWeek.Saturday) || (value.DayOfWeek == DayOfWeek.Sunday))
                    {
                        throw new Exception("You have to submit a Date from Monday to Friday");

                    }
                    else
                    {
                        subDateTime = value;
                    }
                }
                else
                {
                    throw new Exception("Wrong Date,You have to submit a Future Date!");
                }
            }
        }
        public float OralMark { get; set; }
        public float TotalMark { get; set; }
        public Assignment(int id, string title, string description, DateTime subDateTime)
        {
            ID = id;
            Title = title;
            Description = description;
            SubDateTime = subDateTime;
        }
        public override string ToString()
        {
            return $"Assignment : {Title}\nDescription : {Description}\nSubmission Date : {SubDateTime}\n";
        }
    }
}
