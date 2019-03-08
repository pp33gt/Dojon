using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Dojon.Utils
{
    internal class StopWatch
    {
        public Stopwatch StopWatchProp { get; } = new Stopwatch();

        public void Start()
        {
            StopWatchProp.Start();
        }

        public void Stop()
        {
            StopWatchProp.Stop();
        }

        public override string ToString()
        {
            return string.Format($"StopWatch: från Start Till Stopp tog {StopWatchProp.ElapsedMilliseconds} millisekunder");
        }
    }
}
