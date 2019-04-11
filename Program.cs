using System;
using System.Collections.Generic;
using System.Linq;
using Advanced_Databases.Data;
using Advanced_Databases.Data.Models;

namespace Advanced_Databases {
    class Program {
        static Student[] StudentTable = Variables.GetStudentTable;
        static Classes[] ClassesTable = Variables.GetClassesTable;
        static StudentAndClasses[] StudentAndClassesTable = Variables.GetStudentAndClassesTable;
        static Schedule[] ScheduleTable = Variables.GetScheduleTable;
        static ClassAndSchedule[] ClassAndScheduleTable = Variables.GetClassAndScheduleTable;

        static void Main (string[] args) {
            System.Console.WriteLine ("REMEMBER THE PURPOSE OF EACH FUNCTION: \n Map (manipulate data) λ(A) => (B)");
            System.Console.WriteLine(" Reduce (Operation, reduce the data to a smaller data set) λ(B,A) => B \n Join (Condition) λ(A,B) => Bool \n ");

            var map_students_names = StudentTable.Map (studenTable => new { studenTable.FirstName });

            var reduce_students_names = StudentTable.Reduce (
                new List<string> (),
                (studentList, student) => {
                    studentList.Add(student.FirstName);
                    return studentList;
                }
            );

            var map_course_names = ScheduleTable.Map(
                schedule => new {schedule.Course}
            );

            var map_slc_course = ClassesTable.Map(
                (c) => new {c.ClassID,c.SLC}
            );

            var schedule_after_4 = ScheduleTable.Reduce(
                0,
                (x,y) => {
                    if (y.Hour>4)
                    {
                        x++;
                    }
                    return x;
                }
            );

            var schedule_before_4 = ScheduleTable.Reduce(
                0,
                (x,y) =>{
                    if(y.Hour<3)
                    {
                        x++;
                    }
                    return x;
                }
            );

            var student_first_last_name = StudentTable.Map(
                s => new {s.ID,s.FirstName}
            );


            var schedule_hours = ScheduleTable.Map(
                s => new {s.Hour}
            );



            //Query 2:
            // print de namen van alle courses 

            //Query 3:
            // print de namen en slc'ers van alle klassenIEnumerable<int>

            // Query 4:
            // Print het aantal vakken na het 4e uur

            // Query 5:
            // print de voornaam, achternaam en klas van een student

            var q5 = StudentTable.Join (
                StudentAndClassesTable,
                (std, stdc) => std.ID == stdc.StudentID
            ).Map (t => new { t.Item1.FirstName, t.Item1.Surname, t.Item2.ClassID });
            //join

            // Query 6:
            // print de voor en achternaam van alle studenten die in klas "INF1A" zitten.

            //Query 7:
            // print de voor en achternaam van alle studenten die "TONIR" als slc hebben.

            var q7 = StudentTable.Join (
                StudentAndClassesTable,
                (std, stdc) => std.ID == stdc.StudentID).Join (ClassesTable,
                (old, _class) => old.Item2.ClassID == _class.ClassID && _class.SLC == "TONIR").Map (t => new { t.Item1.Item1.FirstName, t.Item1.Item1.Surname });

        }
    

    static void printStringItems (IEnumerable<string> items) {
        foreach (var item in items) {
            System.Console.WriteLine (item);
        }

    }

    static void printIntItem (IEnumerable<int> items)
    {
        foreach (var item in items)
        {
            System.Console.WriteLine(item.ToString());
        }
    }
}
public static class MapReduce {

    public static IEnumerable<T2> Map<T1, T2> (this IEnumerable<T1> collection, Func<T1, T2> transformation) {

        // Create an array (result) with the size of the input collection
        T2[] result = new T2[collection.Count ()];

        for (int i = 0; i < collection.Count (); i++) {

            // Add the result to the same index after the transformation is done to
            // an element of the input collection.
            result[i] = transformation (collection.ElementAt (i));
        }
        return result;
    }

    /// <summary>
    /// Reduce the input collection to a (posible) smaller value/collection.
    /// </summary>
    /// <typeparam name="T1">Input type</typeparam>
    /// <typeparam name="T2">Output type</typeparam>
    /// <param name="collection">Input collection</param>
    /// <param name="init">"collector" object</param>
    /// <param name="operation">Lambda function in which the result (init) is or isnt changed.</param>
    /// <returns></returns>
    public static T2 Reduce<T1, T2> (this IEnumerable<T1> collection, T2 init, Func<T2, T1, T2> operation) {
        // Create a result variable; based on init.
        T2 result = init;
        for (int i = 0; i < collection.Count (); i++) {
            // The result equals the outcome of the opperation. 
            // The result is parsed in as the first parameter.
            result = operation (result, collection.ElementAt (i));
        }
        return result;
    }

    /// <summary>
    /// Join two tables together depending on given attributes.
    /// </summary>
    /// <typeparam name="T1">Input type</typeparam>
    /// <typeparam name="T2">Second input type</typeparam>
    /// <param name="table1">Input table</param>
    /// <param name="table2">Second input table</param>
    /// <param name="condition">Lambda function which returns a boolean</param>
    /// <returns></returns>
    public static IEnumerable<Tuple<T1, T2>> Join<T1, T2> (this IEnumerable<T1> table1, IEnumerable<T2> table2,
        Func<T1, T2, bool> condition) {
        return Reduce (
            table1,
            new List<Tuple<T1, T2>> (),
            (queryResult, table1Element) => {
                List<Tuple<T1, T2>> combination =
                    Reduce (
                        table2,
                        new List<Tuple<T1, T2>> (),
                        (combi, table2Element) => {
                            Tuple<T1, T2> row = new Tuple<T1, T2> (table1Element, table2Element);
                            if (condition (table1Element, table2Element)) {
                                combi.Add (row);
                            }

                            return combi;
                        }
                    );
                queryResult.AddRange (combination);
                return queryResult;
            });
    }
}
}