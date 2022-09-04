namespace Tracer.Core
{
    class Program
    {
        static void Main()
        {
            Tracer tracer = new Tracer();
            C test = new C(tracer);

            test.M0();
            
        }

        public class C
        {
            private ITracer _tracer;

            public C(ITracer tracer)
            {
                _tracer = tracer;
            }

            public void M0()
            {
                M1();
                M2();
            }

            private void M1()
            {
                _tracer.StartTrace();
                Thread.Sleep(100);
                _tracer.StopTrace();
                TraceResult res = _tracer.GetTraceResult();
                Console.WriteLine(res.Time);
            }

            private void M2()
            {
                _tracer.StartTrace();
                Thread.Sleep(200);
                _tracer.StopTrace();
                TraceResult res = _tracer.GetTraceResult();
                Console.WriteLine(res.Time);
            }
        }
    }
}