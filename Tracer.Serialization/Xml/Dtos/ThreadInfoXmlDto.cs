using System.Xml.Serialization;

namespace Xml.Dtos
{
    [Serializable]
    [XmlType(TypeName = "thread")]
    public class ThreadInfoXmlDto
    {
        [XmlAttribute("id")]
        public int ThreadId { get; set; }
        [XmlAttribute("time")]
        public string Time { get; set; }
        [XmlElement(ElementName = "method")]
        public List<MethodInfoXmlDto> Methods { get; set; }
    }
}
