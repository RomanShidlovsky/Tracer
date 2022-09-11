using Tracer.Core.Models;
using Yaml.Dtos;

namespace Yaml
{
    public static class DtoExtension
    {
        public static MethodInfoYamlDto ToDto(this MethodInfo methodInfo)
        {
            return new MethodInfoYamlDto()
            {
                Name = methodInfo.Name,
                ClassName = methodInfo.ClassName,
                Time = $"{methodInfo.Time}ms"
            };
        }

        public static ThreadInfoYamlDto ToDto(this ThreadInfo threadInfo)
        {
            var methodDto = new MethodInfoYamlDto();
            var methodsRoot = new MethodInfo((List<MethodInfo>)threadInfo.Methods);
            CopyMethods(methodsRoot, methodDto);

            return new ThreadInfoYamlDto()
            {
                ThreadId = threadInfo.ThreadId,
                Time = $"{threadInfo.Time}ms",
                Methods = methodDto.Methods
            };

        }

        public static TraceResultYamlDto ToDto(this TraceResult traceResult)
        {
            return new TraceResultYamlDto(traceResult.Threads.Select(x => x.ToDto()).ToList());
        }

        public static void CopyMethods(MethodInfo methodInfo, MethodInfoYamlDto dto)
        {
            dto.Methods = methodInfo.Methods.Select(x => x.ToDto()).ToList();

            for (var i = 0; i < dto.Methods.Count; i++)
            {
                CopyMethods(methodInfo.Methods[i], dto.Methods[i]);
            }
        }
    }
}
