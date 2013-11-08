using System;
using ServiceStack.Configuration;
using selfhostserviceinterface;
using Mono.Unix;
using Mono.Unix.Native;
using ServiceStack.Text;

namespace selfhostconsole
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var appHost = new AppHost();
		    int port = 8080;
		    if (args.Length > 1)
		    {
		        port = Convert.ToInt32(args[0]);
		    }

		    var url = "http://*:{0}/".Fmt(port);
            Console.WriteLine("Listening on: {0}".Fmt(url));

			appHost.Init();
			appHost.Start(url);

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
