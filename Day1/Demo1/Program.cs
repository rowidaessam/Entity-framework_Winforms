using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Demo1
{
    class program
    {
        public static void Main()
        {
         List<int>  Numbers = new List<int>() { 2, 4, 6, 8, 1, 2, 3, 1, 6, 2};
            var result = Numbers.Select(x => x).Distinct().OrderBy(p => p).ToList();
            foreach (var num in result)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("-------------------------------");
           for(int i = 0; i < Numbers.Count; i++)
            {
                Console.WriteLine($"( Number = {Numbers[i]}, Muliply = {Numbers[i] * Numbers[i]} )");
            }

            Console.WriteLine("-------------------------------------");
            string[] names = { "Ahmed", "Amr", "Khaled", "Rowida", "Aml", "mai" };
            var result2 = from name in names
                         where name.Length == 3
                         select name;
            foreach (var nam in result2)
            {
                Console.WriteLine(nam);
            }
            Console.WriteLine("-------------------------------");

            var result3 = from name2 in names
                          where name2[0] == 'a' || name2[0] == 'A'
                          orderby name2[1]
                          select name2;


            foreach (var nam in result3)
            {
                Console.WriteLine(nam);
            }
            Console.WriteLine("---------------------------------");


            var result4 = names.Take(2);

            foreach (var nam in result4)
            {
                Console.WriteLine(nam);
            }
            Console.WriteLine("---------------------------------");


            List<Student> students = new List<Student>(){
              new Student ()
              {
                Id=1, FirstName="Ali", LasttName="Mohammed",
                subjects = new Subject[] { 
                new Subject()
                { Code=22, Name="EF"},
                new Subject() {
                Code=33, Name="UML"}
               }},
                new Student ()
                { Id=2, FirstName="Mona", LasttName="Gala",
                subjects = new Subject []{
                  new Subject() { Code=22, Name="EF"},
                  new Subject() { Code=34, Name="XML"},
                  new Subject() { Code=25, Name="JS"}
              }},
                new Student (){ Id=3, FirstName="Yara", LasttName="Yousf",
                subjects = new Subject []{
                 new Subject (){ Code=22, Name="EF"},
                 new Subject (){ Code=25, Name="JS"}
                }},
                new Student (){ Id=1, FirstName="Ali", LasttName="Ali",
                subjects = new Subject []{ 
                    new Subject (){ Code=33, Name="UML"}}},
                };
            var result5 = from std in students
                         select std;
            foreach  (var student in result5)
            {
                Console.WriteLine($"( full Name: {student.FirstName} {student.LasttName}, the Number of Subjects: {student.subjects.Count()})");
            }
            Console.WriteLine("-------------------------------------");
            var result6 = from std2 in students
                          orderby std2.FirstName descending, std2.LasttName
                          select std2;
            foreach  (var student4 in result6)
            {
                Console.WriteLine($"{student4.FirstName} {student4.LasttName}");
            }
            Console.WriteLine("----------------------------------------");


            //var result7 = from FN in students
            //              from SN in FN.FirstName +" "+ FN.LasttName 
            //              select SN;
            // var R = result7.SelectMany(SN => SN.);
            var d = from student in students
                    select student;
            foreach (var student in d)
            {
                Console.Write("Full Name" + " " + student.FirstName + " " + student.LasttName + " ");
                foreach (var subject in student.subjects)
                {
                    Console.WriteLine(subject.Name);
                }

            }

            //var result7 = students.SelectMany(std => std.subjects);
            //foreach (var student9 in result7)
            //{

            //    Console.WriteLine($"( Student Nmae: The Subject Name: {student9.Name} )");
            //}
            Console.WriteLine("-------------------------------------");
            //var result10 = from p in students
            //               group p by p.FirstName + " " + p.LasttName;

            var result10 = students.GroupBy(std => std.FirstName, s=>s.LasttName);
            foreach (var item in result10)
            {
                Console.WriteLine($"{item.Key}");
                foreach (var item2 in item)
                {
                    Console.WriteLine($"...{item2.Count()}");

                    //foreach (var item3 in item2)
                    //{
                    //    Console.WriteLine(item3.name);
                    //}

                }

            }

        }

    }
}
