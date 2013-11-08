using System;
using ServiceStack.WebHost.Endpoints;
using Funq;

namespace selfhostserviceinterface
{
	public class AppHost : AppHostHttpListenerBase
	{
		private readonly string _mode;
		//Tell Service Stack the name of your application and where to find your web services
		public AppHost(string mode) : base("Mono Self host Hello World", typeof(HelloService).Assembly) 
		{
			_mode = mode;
		}

		public override void Configure(Container container)
		{
			// TODO all servicestack configuration goes here.
			//
			//

			// if worker we could do other stuff too.
			if(_mode.Equals("worker"))
			{
				//TODO do some stuff here, i.e bind message queue handlers, which should not be running in web mode...
			}

		}
	}
}

