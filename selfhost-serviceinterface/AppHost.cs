using System;
using ServiceStack.WebHost.Endpoints;
using Funq;

namespace selfhostserviceinterface
{
	public class AppHost : AppHostHttpListenerBase
	{
		//Tell Service Stack the name of your application and where to find your web services
		public AppHost() : base("Mono Self host Hello World", typeof(HelloService).Assembly) { }

		public override void Configure(Container container)
		{
		}
	}
}

