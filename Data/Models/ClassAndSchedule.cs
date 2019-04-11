using System;
using System.Collections.Generic;
using System.Text;

namespace Advanced_Databases.Data.Models
{
    class ClassAndSchedule
    {
        public string ClassID { get; set; }
        public int ScheduleID { get; set; }

        public ClassAndSchedule(string classID, int scheduleID)
        {
            ClassID = classID;
            ScheduleID = scheduleID;
        }
    }
}
