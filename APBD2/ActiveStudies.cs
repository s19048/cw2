using System.Xml.Serialization;

namespace APBD2
{
    public class ActiveStudies
    {
        [XmlAttribute("name")]
        [JsonPropertyName("name")]
        public string name { get; set; }

        [XmlAttribute("numberOfStudents")]
        [JsonPropertyName("numberOfStudents")]
        public int numberOfStudents { get; set; }

        public ActiveStudies(string name)
        {
            this.name = name;
            numberOfStudents = 1;
        }
        public ActiveStudies()
        {

        }
    }
}
