using YamlDotNet.Serialization;

namespace Yaml.Dtos
{
    [Serializable]
    public class ThreadInfoYamlDto
    {
        [YamlMember( Alias = "id")]
        public int ThreadId { get; set; }
        public string Time { get; set; }
        public List<MethodInfoYamlDto> Methods { get; set; }
    }
}
