﻿//created by Redko Pavlo K-27 in JetBrains Rider

using System;
using System.Collections.Generic;

namespace Task2
{
    class Program
    {

        abstract class Student
        {
            public Student(string name)
            {
                Name = name;
                State = "";
            }

            abstract public void Study();

            public void Read()
            {
                State += " Read";
            }

            public void Write()
            {
                State += " Write";
            }

            public void Relax()
            {
                State += " Relax";
            }

            public string Name { get; protected set; }
            public string State { get; protected set; }

        }

        class GoodStudent : Student
        {
            public GoodStudent(string name) : base(name)
            {
                State += "good";
            }

            public override void Study()
            {
                Read();
                Write();
                Read();
                Write();
                Relax();
            }
        }

        class BadStudent : Student
        {
            public BadStudent(string name) : base(name)
            {
                Name = name;
                State += "bad";
            }

            public override void Study()
            {
                Relax();
                Relax();
                Relax();
                Relax();
                Read();
            }
        }

        class Group
        {
            public Group(string groupName)
            {
                GroupName = groupName;
            }

            public void AddStudent(Student st)
            {
                students.Add(st);
            }

            public void GetInfo()
            {
                Console.Write("Group {0} has students: ", GroupName);

                int counter = 0;
                foreach (Student student in students)
                {
                    Console.Write("{0}", student.Name);
                    if (++counter < students.Count)
                        Console.Write(", ");
                }

                Console.Write("\n");
            }

            public void GetFullInfo()
            {
                Console.Write("Group: {0} has students: ", GroupName);

                int counter = 0;
                foreach (Student student in students)
                {
                    Console.Write("{0} student {1}", student.State, student.Name);
                    if (++counter < students.Count)
                        Console.Write(", ");
                }

                Console.Write("\n");
            }

            public List<Student> GetStudents()
            {
                return students;
            }
            
            public string GroupName { get; }
            private List<Student> students = new List<Student>();
        }

        static void Main()
        {
            List<Group> groups = new List<Group>();
            string help = "List of commands:\n" +
                          "Study - you can use this if exist student" +
                          "AddGroup - you can add group, firstly you can only call this\n" +
                          "AddStudent - adds student to group that you insert\n" +
                          "GetInfo - gives you short info about group\n" +
                          "GetFullInfo - gives you full info about group\n" +
                          "End - if you want finish" +
                          "Help - gives you list of available commands\n";

            string command;

            Console.WriteLine(help);
            
            while (true)
            {
                Console.WriteLine("Enter what action you want:");
                command = Console.ReadLine();

                if (command == "Study")
                {
                    Console.WriteLine("There are list of available groups:");
                    foreach (Group group in groups)
                    {
                        Console.WriteLine("{0}", group.GroupName);
                    }
                    Console.WriteLine("In what group you want to find student to study?");
                    
                    string groupName = Console.ReadLine();
                    
                    if (groups.Exists(x => x.GroupName == groupName))
                    {
                        Console.WriteLine("Great choice!\n" +
                                          "What is the student name?");
                        string studentName = Console.ReadLine();
                        groups.Find(x => x.GroupName == groupName).GetStudents().Find(s => s.Name == studentName).Study();
                    }
                }
                
                else if (command == "End")
                { break; }
                else if (command == "Help")
                {
                    Console.WriteLine(help + "\nEnter what action you want:");
                }
                else if (command == "AddGroup")
                {
                    Console.WriteLine("Enter group name:");
                    string groupName = Console.ReadLine();
                    groups.Add(new Group(groupName));
                }
                else if (command == "AddStudent")
                {
                    if (groups.Count == 0)
                    {
                        Console.WriteLine("There are no groups yet. Try later");
                        continue;
                    }
                    Console.WriteLine("In what group you want to add student?\n" +
                                      "There are list of available groups:");
                    foreach (Group group in groups)
                    {
                        Console.WriteLine("{0}", group.GroupName);
                    }

                    string groupName = Console.ReadLine();

                    if (groups.Exists(x => x.GroupName == groupName))
                    {
                        Console.WriteLine("Great choice!\n" +
                                          "What is the student name?");
                        string studentName = Console.ReadLine();

                        Console.WriteLine("'bad' or 'good' student is? (enter bad or good)");

                        string condition = Console.ReadLine();

                        if (condition == "bad")
                        {
                            groups.Find(x => x.GroupName == groupName).AddStudent(new BadStudent(studentName));
                        }
                        else if (condition == "good")
                        {
                            groups.Find(x => x.GroupName == groupName).AddStudent(new GoodStudent(studentName));
                        }
                        else
                        {
                            Console.WriteLine("Incorrect format");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error: Group {0} doesn't exists", groupName);
                    }


                }
                else if (command == "GetInfo")
                {
                    if (groups.Count == 0)
                    {
                        Console.WriteLine("There are no groups yet. Try later");
                        continue;
                    }
                    Console.WriteLine("What group are you looking for?\n" +
                                      "There are list of available groups:");

                    foreach (Group group in groups)
                    {
                        Console.WriteLine("{0}", group.GroupName);
                    }

                    string groupName = Console.ReadLine();

                    if (groups.Exists(x => x.GroupName == groupName))
                    {
                        groups.Find(x => x.GroupName == groupName).GetInfo();
                    }
                }
                else if (command == "GetFullInfo")
                {
                    if (groups.Count == 0)
                    {
                        Console.WriteLine("There are no groups yet. Try later");
                        continue;
                    }
                    Console.WriteLine("What group are you looking for?\n" +
                                      "There are list of available groups:");
                    foreach (Group group in groups)
                    {
                        Console.WriteLine("{0}", group.GroupName);
                    }

                    string groupName = Console.ReadLine();

                    if (groups.Exists(x => x.GroupName == groupName))
                    {
                        groups.Find(x => x.GroupName == groupName).GetFullInfo();
                    }
                }
                else
                {
                    Console.WriteLine("Error: {0} is unknown command", command);
                }
            }
        }
    }
}