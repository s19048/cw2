using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;


namespace APBD2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var log = @"C:\Users\asobiczewski\source\repos\APBD2\APBD2\log.txt"; try
            {
                var path = @"C:\Users\asobiczewski\source\repos\APBD2\APBD2\dane.csv";
                var XMLDestination = @"C:\Users\asobiczewski\source\repos\APBD2\APBD2\result.xml";
                var JSONDestination = @"C:\Users\asobiczewski\source\repos\APBD2\APBD2\result.json";
                var lines = File.ReadLines(path);

                var hash = new HashSet<Student>(new OwnComparer());
                var hash1 = new HashSet<ActiveStudies>(new StudiesComparer());
                FileStream writer = new FileStream(XMLDestination, FileMode.Create);
                XmlSerializer serializer = new XmlSerializer(typeof(Uczelnia), new XmlRootAttribute());

                foreach (var line in lines)
                {

                    var list = line.Split(',');

                    if (list.Length == 9)
                    {
                        bool error = false;
                        foreach (var s in list)
                        {

                            // if (s.Trim() == string.Empty)
                            if (string.IsNullOrEmpty(s))
                            {
                                if (string.IsNullOrWhiteSpace(s))
                                {
                                    error = true;
                                }

                            }
                        }
                        if (error == true)
                        {

                            String ErrorLine = "";
                            foreach (String ss in list)
                            {
                                ErrorLine += ss + " ";
                            }
                            new Errors(ErrorLine, log);
                        }
                        else
                        {
                            var studia1 = new Studies
                            {
                                Name = list[2],
                                Mode = list[3],
                            };

                            var stud1 = new Student
                            {
                                FirstName = list[0],
                                LastName = list[1],
                                Index = list[4],
                                studies = studia1,
                                Birthday = list[5],
                                Email = list[6],
                                MothersName = list[7],
                                FathersName = list[8]
                            };

                            if (!hash.Add(stud1))
                            {
                                new Errors(stud1.ToString(), log);
                            }
                            else
                            {
                                var activeStudies = new ActiveStudies(studia1.Name);
                                hash1.Add(activeStudies);
                                foreach (ActiveStudies acc in hash1)
                                {
                                    if (acc.name.Equals(stud1.studies.Name))
                                    {
                                        acc.numberOfStudents++;
                                    }
                                }

                            }

                        }
                    }
                }
                var ListOfStudents = hash.ToList();
                var ListOfStudies = hash1.ToList();

                var uczelnia = new Uczelnia
                {
                    studenci = ListOfStudents,
                    author = "Nina Sobiczewska",
                    activeStudies = ListOfStudies
                };
                serializer.Serialize(writer, uczelnia);

                var jsonString = (string)JsonSerializer.Serialize(uczelnia);
                File.WriteAllText(JSONDestination, jsonString);

            }
            catch (FileNotFoundException f)
            {
                Console.WriteLine("Plik nazwa nie istnieje");
                Errors errors = new Errors("Plik nazwa nie istnieje", log);
            }
            catch (ArgumentException a)
            {
                Console.WriteLine("Podana ścieżka jest niepoprawna");
                Errors errors = new Errors("Podana ścieżka jest niepoprawna", log);
            }
            catch (DirectoryNotFoundException d)
            {
                new Errors("Nie ma takiej ścieżki", log);
                Console.WriteLine("Nie ma takiej ścieżki", log);
            }
        }
    }
}