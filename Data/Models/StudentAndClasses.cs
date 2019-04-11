using System;
using System.Collections.Generic;
using System.Text;

namespace Advanced_Databases.Data.Models
{
    class StudentAndClasses
    {
        public int StudentID { get; set; }
        public string ClassID { get; set; }

        public StudentAndClasses(int studentID, string classID )
        {
            StudentID = studentID;
            ClassID = classID;
        }
    }
}
