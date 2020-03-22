using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace APBD2
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Birthday { get; set; }
        public string Email { get; set; }
        public string MothersName { get; set; }
        public string FathersName { get; set; }
        public Studies studies { get; set; }
        [XmlAttribute]
        public string Index { get; set; }

        public override string ToString()
        {
            return FirstName + " " + LastName + " " +
                   studies.Name + " " + studies.Mode + " " + Index + " " + Birthday + " " + 
                   Email + " " + MothersName + " " + FathersName;
        }
    }
    public class Studies
    {
        public string Name { get; set; }
        public string Mode { get; set; }
    }
}
