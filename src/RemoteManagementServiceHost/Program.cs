using Microsoft.AzureStack.Services.RemoteManagement.CoreLib;
using System;
using System.Net;

namespace RemoteManagementServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                var cfg = Utils.ConfigurationUtils.GetLocalConfig();
                RemoteManagementService.Initialize(cfg);
                RemoteManagementService.Start();

                do
                {
                    while (!Console.KeyAvailable)
                    {
                    }

                    ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
                    if (consoleKeyInfo.Key == ConsoleKey.D)
                    {
                        // disable
                        RemoteManagementService.Stop();
                    }
                    else if (consoleKeyInfo.Key == ConsoleKey.E)
                    {
                        // enable
                        RemoteManagementService.Start();
                    }
                    else if (consoleKeyInfo.Key == ConsoleKey.Escape)
                    {
                        break;
                    }

                } while (true);
            }
            finally
            {
                RemoteManagementService.Stop();
            }

        }
    }
}
