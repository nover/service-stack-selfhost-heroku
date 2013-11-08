using System;
using ServiceStack.ServiceHost;

namespace selfhostmodel
{
	[Route("/hello/{Name}", "GET")]
	public class Hello
	{
		public string Name { get; set; }
	}
}

