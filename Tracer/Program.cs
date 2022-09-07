namespace Tracer.Core
{
    class Program
    {
        static void Main()
        {
            Tracer tracer = new Tracer();
            C test = new C(tracer);

            test.M0();

            Thread.Sleep(1000);

            TraceResult res = tracer.GetTraceResult();
            
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
                Thread thr1 = new Thread(M1);
                thr1.Start();
                
                Thread thr2 = new Thread(M2);   
                thr2.Start();
            }

            private void M1()
            {
                _tracer.StartTrace();
                Thread.Sleep(100);
                _tracer.StopTrace();      
            }

            private void M2()
            {
                _tracer.StartTrace();
                Thread.Sleep(50);
                _tracer.StopTrace();
            }

            private void M3()
            {
                _tracer.StartTrace();
                Thread.Sleep(50);
                _tracer.StopTrace();
            }
        }
    }
}