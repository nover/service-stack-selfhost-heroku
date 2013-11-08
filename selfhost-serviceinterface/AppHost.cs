using System;
using ServiceStack.WebHost.Endpoints;
using Funq;

namespace selfhostserviceinterface
{
	public class AppHost : AppHostHttpListenerLongRunningBase
	{
		//Tell Service Stack the name of your application and where to find your web services
		public AppHost() : base("Mofomo Accounting Services", typeof(HelloService).Assembly) { }

		public override void Configure(Container container)
		{
		}
	}
}

