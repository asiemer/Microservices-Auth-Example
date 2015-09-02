using System;
using Microsoft.Owin.Hosting;
using Thinktecture.IdentityServer.Core.Logging;

namespace IdentityServer
{
    class Program
    {
        static void Main(string[] args)
        {
            LogProvider.SetCurrentLogProvider(new DiagnosticsTraceLogProvider());

            using (WebApp.Start<Startup>("https://localhost:44333"))
            {
                Console.WriteLine("server running...");
                Console.ReadLine();
            }
        }
    }
}
