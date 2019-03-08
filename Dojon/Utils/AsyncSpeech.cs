using System;
using System.Threading;

namespace Dojon.Utils
{
    internal class AsyncSpeech
    {
        private delegate void MethodDelegate(string words, out int iExecThread);

        private Speech Speech { get; }

        public AsyncSpeech()
        {
            Speech = new Speech();
        }

        public void Say(string words, out int iExecThread)
        {
            Speech.Say(words);
            iExecThread = Thread.CurrentThread.ManagedThreadId;
        }
        
        public void Say(string words)
        {
            MethodDelegate dlgt = new MethodDelegate(Say);
            
            // Initiate the asynchronous call.
            IAsyncResult ar = dlgt.BeginInvoke(words, out int iExecThread, null, null);
        }
    }
}
