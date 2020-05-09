namespace Base
{
	public abstract class Thread
	{
		private System.Threading.Thread thread;

		protected bool IsRunning { set; get; }

		public Thread()
		{
			this.thread = new System.Threading.Thread(this.Run);
		}

		public void Start()
		{
			this.IsRunning = true;
			this.thread.Start();
		}

		public void Stop()
		{
			this.IsRunning = false;
		}

		protected abstract void Run();
	}
}
