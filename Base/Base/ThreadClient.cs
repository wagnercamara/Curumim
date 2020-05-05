using System;
using System.IO;
using System.Net.Sockets;

namespace Base
{
	public class ThreadClient : Thread
	{
		private Socket socket;
		private int number;
		public event EventHandler OnReceiveMessage;

		public ThreadClient(int number, Socket socket) : base()
		{
			this.number = number;
			this.socket = socket;
		}

		protected override void Run()
		{
			NetworkStream networkStream = new NetworkStream(this.socket);

			while (this.IsRunning)
			{
				try
				{
					this.OnReceiveMessage.Invoke(this, new MessageEventArgs()
					{
						Message = Message.Deserialize(networkStream)
					});
				}
				catch
				{
					this.IsRunning = false;
				}
			}
		}

		public void SendMessage(dynamic message)
		{
			try
			{
				NetworkStream networkStream = new NetworkStream(this.socket);
				BinaryWriter binaryWriter = new BinaryWriter(networkStream);

				binaryWriter.Write(Message.Serialize(message));
			}
			catch
			{
				this.IsRunning = false;
			}
		}

		public int GetNumber()
		{
			return this.number;
		}
	}
}
