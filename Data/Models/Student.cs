using System;
using System.Collections.Generic;
using System.Text;

namespace Advanced_Databases.Data.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }

        public Student(int id, string firstName, string surname)
        {
            ID = id;
            FirstName = firstName;
            Surname = surname;
        }
    }
}
