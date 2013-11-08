using System;
using ServiceStack.Configuration;
using selfhostserviceinterface;
using Mono.Unix;
using Mono.Unix.Native;

namespace selfhostconsole
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var settings = new AppSettings();
			var appHost = new AppHost();
			appHost.Init();
			appHost.Start(settings.Get("listen-url", "http://*:8080/"));

			UnixSignal[] signals = new UnixSignal[] { 
				new UnixSignal(Signum.SIGINT), 
				new UnixSignal(Signum.SIGTERM), 
			};

			// Wait for a unix signal
			for (bool exit = false; !exit; )
			{
				int id = UnixSignal.WaitAny(signals);

				if (id >= 0 && id < signals.Length)
				{
					if (signals[id].IsSet) exit = true;
				}
			}
		}
	}
}
