using System;
using System.Collections.Generic;
using System.Linq;
using Advanced_Databases.Data.Models;
using Advanced_Databases.Data;

namespace Advanced_Databases
{
    public static class MapReduce {
        public static void init () {
            Variables vars = new Variables();
            Student[] StudentTable = vars.GetStudentTable;
            Classes[] ClassesTable = vars.GetClassesTable;
            StudentAndClasses[] StudentAndClassesTable = vars.GetStudentAndClassesTable;
            Schedule[] ScheduleTable = vars.GetScheduleTable;
            ClassAndSchedule[] ClassAndScheduleTable = vars.GetClassAndScheduleTable;
        }

        // Map Queries
        public static IEnumerable<T2> Map<T1, T2>(this IEnumerable<T1> collection, Func<T1, T2> transformation)
        {
            // Create an array (result) with the size of the input collection
            T2[] result = new T2[collection.Count()];
            for (int i = 0; i < collection.Count(); i++)
            {
                // Add the result to the same index after the transformation is done to
                // an element of the input collection.
                result[i] = transformation(collection.ElementAt(i));
            }
            return result;
        }

        // Reduce Queries


        // Join Queries
    }
}
