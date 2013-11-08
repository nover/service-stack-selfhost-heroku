using System;
using ServiceStack.ServiceInterface;
using selfhostmodel;

namespace selfhostserviceinterface
{
	public class HelloService : Service
	{
		public object Any(Hello request)
		{
			return new
			{
				Name = request.Name
			};
		}
	}
}

