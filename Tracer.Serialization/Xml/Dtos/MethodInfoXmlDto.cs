using System.Xml.Serialization;

namespace Xml.Dtos
{
    [Serializable]
    [XmlType(TypeName = "method")]
    public class MethodInfoXmlDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("class")]
        public string ClassName { get; set; }
        [XmlAttribute("time")]
        public string Time { get; set; }
        [XmlElement(ElementName = "method")]
        public List<MethodInfoXmlDto> Methods { get; set; }
    }
}
