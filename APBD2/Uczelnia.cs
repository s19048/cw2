using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace APBD2
{
    [XmlRootAttribute("uczelnia")]
    public class Uczelnia
    {
        [XmlAttribute]
        public string createdAt { get; set; }
        [XmlAttribute]
        public string author { get; set; }
        public List<Student> studenci { get; set; }

        public List<ActiveStudies> activeStudies { get; set; }
        public Uczelnia()
        {
            createdAt = DateTime.Now.ToShortDateString();
        }
    }
}
