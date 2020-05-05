using System;

namespace Base
{
	public class ConnectEventArgs : EventArgs
	{
		public ThreadClient Client { set; get; }
	}
}
