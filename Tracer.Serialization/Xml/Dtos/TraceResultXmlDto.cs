using System.Xml.Serialization;

namespace Xml.Dtos
{
    [Serializable]
    [XmlType(TypeName = "root")]
    public class TraceResultXmlDto
    {
        [XmlElement(ElementName = "thread")]
        public List<ThreadInfoXmlDto> Threads { get; set; }

        public TraceResultXmlDto()
        {

        }

        public TraceResultXmlDto(List<ThreadInfoXmlDto> threads)
        {
            Threads = threads;
        }

    }
}
