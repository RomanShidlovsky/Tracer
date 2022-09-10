using System.Xml.Serialization;
using Tracer.Serialization.Abstractions;
using Tracer.Core.Models;
using Xml.Dtos;
using System.Xml;

namespace Xml
{
    public class XmlTraceResultSerializer : ITraceResultSerializer
    {
        public string Extension { get; } = "xml";

        public void Serialize(TraceResult traceResult, Stream to)
        {
            var dto = traceResult.ToDto();
            var xmlSettings = new XmlWriterSettings();
            xmlSettings.Indent = true;
            //xmlSettings.NewLineHandling = NewLineHandling.
                
            using(var xmlWriter = XmlWriter.Create(to, xmlSettings))
            {
                var serializer = new XmlSerializer(typeof(TraceResultXmlDto));
                serializer.Serialize(xmlWriter, dto);
            }
            
        }
    }
}
