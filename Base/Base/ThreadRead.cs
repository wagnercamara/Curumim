using System;
using System.Net.Sockets;

namespace Base
{
	public class ThreadRead : Thread
	{
		private NetworkStream networkStream;
		public event EventHandler OnReceiveMessage;

		public ThreadRead(NetworkStream networkStream) : base()
		{
			this.networkStream = networkStream;
		}

		protected override void Run()
		{
			while (this.IsRunning)
			{
				try
				{
					this.OnReceiveMessage.Invoke(this, new MessageEventArgs()
					{
						Message = Message.Deserialize(this.networkStream)
					});
				}
				catch
				{
					this.IsRunning = false;
				}
			}
		}
	}
}
