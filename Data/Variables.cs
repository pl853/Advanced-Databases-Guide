using Advanced_Databases.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Advanced_Databases.Data
{
    class Variables
    {
        public static Student[] GetStudentTable =
        {
            new Student(0, "a", "b"),
            new Student(1, "c", "d"),
            new Student(2, "e", "f"),
            new Student(3, "g", "h"),
            new Student(4, "i", "j"),
            new Student(5, "k", "l"),
            new Student(6, "m", "n"),
            new Student(7, "o", "p")
        };

        public static Classes[] GetClassesTable =
        {
            new Classes("INF1A", "ROMA"),
            new Classes("INF1B", "TONIR"),
            new Classes("INF1C", "ROMA"),
            new Classes("INF1D", "SLINM"),
            new Classes("INF1E", "ABBAM"),
            new Classes("INF1F", "AMEML"),
            new Classes("INF2F", "AMMMQ")
        };

        public static StudentAndClasses[] GetStudentAndClassesTable =
        {
            new StudentAndClasses(0, "INF1A"),
            new StudentAndClasses(1, "INF1A"),
            new StudentAndClasses(2, "INF1B"),
            new StudentAndClasses(3, "INF1C"),
            new StudentAndClasses(4, "INF1C"),
            new StudentAndClasses(5, "INF1D"),
            new StudentAndClasses(6, "INF1D"),
            new StudentAndClasses(7, "INF1E")
        };

        public static Schedule[] GetScheduleTable =
        {
            new Schedule(0, "Intro 1", 2),
            new Schedule(1, "Dev3", 4),
            new Schedule(2, "ANL3", 3),
            new Schedule(3, "Dev6b", 1),
            new Schedule(4, "Dev6a", 2),
            new Schedule(5, "ANL2", 8),
            new Schedule(6, "BNND", 5),
            new Schedule(7, "DIN", 8)
        };

        public static ClassAndSchedule[] GetClassAndScheduleTable =
        {
            new ClassAndSchedule("INF1A",0),
            new ClassAndSchedule("INF1B",0),
            new ClassAndSchedule("INF1D",0),

            new ClassAndSchedule("INF1A",1),
            new ClassAndSchedule("INF1B",2),
            new ClassAndSchedule("INF1B",3),

            new ClassAndSchedule("INF1E",4),
            new ClassAndSchedule("INF1E",5),
            new ClassAndSchedule("INF1E",6),

            new ClassAndSchedule("INF1A",4),
            new ClassAndSchedule("INF1F",7)
        };
    }
}
