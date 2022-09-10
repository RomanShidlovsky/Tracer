using Xml.Dtos;
using Tracer.Core.Models;

namespace Xml
{
    internal static class DtoExtension
    {
        public static MethodInfoXmlDto ToDto(this MethodInfo methodInfo)
        {
            return new MethodInfoXmlDto()
            {
                Name = methodInfo.Name,
                ClassName = methodInfo.ClassName,
                Time = $"{methodInfo.Time}ms"
            };
        }

        public static ThreadInfoXmlDto ToDto(this ThreadInfo threadInfo)
        {
            var methodDto = new MethodInfoXmlDto();
            var methodsRoot = new MethodInfo((List<MethodInfo>)threadInfo.Methods);
            CopyMethods(methodsRoot, methodDto);

            return new ThreadInfoXmlDto()
            {
                ThreadId = threadInfo.ThreadId,
                Time = $"{threadInfo.Time}ms",
                Methods = methodDto.Methods
            };

        }

        public static TraceResultXmlDto ToDto(this TraceResult traceResult)
        {
            return new TraceResultXmlDto(traceResult.Threads.Select(x => x.ToDto()).ToList());
        }

        public static void CopyMethods(MethodInfo methodInfo, MethodInfoXmlDto dto)
        {
            dto.Methods = methodInfo.Methods.Select(x => x.ToDto()).ToList();

            for (var i = 0; i < dto.Methods.Count; i++)
            {
                CopyMethods(methodInfo.Methods[i], dto.Methods[i]);
            }
        }
    }
}
