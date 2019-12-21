using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace Microsoft.VisualStudio.TestTools.UnitTesting
{
    public class TestLogger<T> : ILogger<T>, IDisposable
    {
        public IDisposable BeginScope<TState>(TState state) => this;

        readonly TextWriter writer;

        public TestLogger()
            : this (Console.Out)
        {

        }

        public TestLogger(TextWriter writer)
        {
            this.writer = writer;
        }

        public void Dispose()
        {
        }

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
            => writer.WriteLine(formatter(state, exception));
    }
}
