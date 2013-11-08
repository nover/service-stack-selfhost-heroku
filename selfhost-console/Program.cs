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
			// Set default and see if Heroku is defining something for us...
		    int port = 8080;
			var herokuPort = Environment.GetEnvironmentVariable ("PORT");
			var mode = "web";

			if(!String.IsNullOrEmpty(herokuPort))
			{
				port = Convert.ToInt32 (herokuPort);
			}
		    if (args.Length > 0)
		    {
				mode = args [0];
		    }

			// bootstrap everything and start hosting...
		    var url = "http://*:{0}/".Fmt(port);
            Console.WriteLine("Listening on: {0}".Fmt(url));

			var appHost = new AppHost(mode);
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
