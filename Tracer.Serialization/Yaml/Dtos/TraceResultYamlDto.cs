namespace Yaml.Dtos
{
    [Serializable]
    public class TraceResultYamlDto
    {
        public List<ThreadInfoYamlDto> Threads { get; set; }
        
        public TraceResultYamlDto(List<ThreadInfoYamlDto> threads)
        {
            Threads = threads;
        }
    }
}
