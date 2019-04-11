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
            System.Console.WriteLine ("REMEMBER THE PORPUSE OF EACH FUNCTION: \n Map (manipulate data) λ(A) => (B) \n Reduce (Operation, reduce the data to a smaller data set) λ(B,A) => B \n Join (Condition) λ(A,B) => Bool ");
            //Query 1:
            // print de voornamen van alle studenten (met map en een keer met reduce).
            var q1 = StudentTable.Map(studentTable => new {studentTable.FirstName});

            var q2 = StudentTable.Reduce(new List<Student>(),(studentList,student) => 
            {
                return studentList;
            }).Map(s => s.FirstName);

            printItems(q2);
            


            //Query 2:
            // print de namen van alle courses

            var q3 = ClassesTable.Map(classes => new {classes.ClassID});

            //Query 3:
            // print de namen en slc'ers van alle klassen

            // Query 4:
            // Print het aantal vakken na het 4e uur

            // Query 5:
            // print de voornaam, achternaam en klas van een student

            // Query 6:
            // print de voor en achternaam van alle studenten die in klas "INF1A" zitten.

            //Query 7:
            // print de voor en achternaam van alle studenten die "TONIR" als slc hebben.

            // En nu?...
            // Wat wil je nog meer weten over de data? 
            // Maak je eigen data?!
        }

        static void printItems(IEnumerable<string> items)
        {
            foreach (var item in items)
            {
                System.Console.WriteLine(item);
            }

        }

        static void printReducedItems(IEnumerable<string> items){
            foreach (var item in items)
            {
                System.Console.WriteLine(item);
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