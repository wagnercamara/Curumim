using System.IO;

namespace Base
{
	public class ThreadWrite : Thread
	{
		private BinaryWriter binaryWriter;
		private dynamic message;

		public ThreadWrite(BinaryWriter binaryWriter) : base()
		{
			this.binaryWriter = binaryWriter;
		}

		protected override void Run()
		{
			while (this.IsRunning)
			{
				try
				{
					if (this.message != null)
					{
						this.binaryWriter.Write(Message.Serialize(this.message));
						this.message = null;
					}
				}
				catch
				{
					this.IsRunning = false;
				}
			}
		}

		public void SendMessage(dynamic message)
		{
			this.message = message;
		}
	}
}
