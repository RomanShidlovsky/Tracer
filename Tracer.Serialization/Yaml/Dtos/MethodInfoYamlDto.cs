using YamlDotNet.Serialization;

namespace Yaml.Dtos
{
    [Serializable]
    public class MethodInfoYamlDto
    {
        [YamlMember(Alias = "name")]
        public string Name { get; set; }
        [YamlMember(Alias = "class")]
        public string ClassName { get; set; }
        public string Time { get; set; }
        public List<MethodInfoYamlDto> Methods { get; set; }
    }
}
