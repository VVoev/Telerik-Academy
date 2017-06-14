using Ninject.Extensions.Interception;
using System;
using System.Diagnostics;

namespace SchoolSystem.Cli.Interceptor
{
    public class PerformanceWatch : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var watch = new Stopwatch();
            watch.Start();

            invocation.Proceed();

            Console.WriteLine($"Time elapsed {watch.Elapsed.Milliseconds}");
            watch.Stop();

        }
    }
}
