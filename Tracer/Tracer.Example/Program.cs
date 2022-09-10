using System.Reflection;
using Tracer.Example.Classes;
using Tracer.Serialization.Abstractions;

const string pluginPath = "../../../Plugins";
const string resultPath = "../../../TraceResults/TraceResult";
var interfaceType = typeof(ITraceResultSerializer);


var tracer = new Tracer.Core.Tracers.Tracer();
var foo = new Foo(tracer);
var bar = new Bar(tracer);

var task = Task.Run(() => foo.PublicMethod());
foo.PublicMethod();
bar.InnerMethod();
Console.WriteLine(Environment.CurrentManagedThreadId);
task.Wait();

var result = tracer.GetTraceResult();

var files = Directory.GetFiles(pluginPath);
foreach (var file in files)
{
    var assembly = Assembly.LoadFrom(file);

    var types = assembly.GetTypes()
        .Where(x => x.GetInterfaces().Contains(interfaceType));

    foreach (var type in types)
    {
        var serializer = (ITraceResultSerializer)Activator.CreateInstance(type)!;
        using (var fileStream = new FileStream($"{resultPath}.{serializer.Extension}", FileMode.Create))
        {
            serializer.Serialize(result, fileStream);
        }
    }
}