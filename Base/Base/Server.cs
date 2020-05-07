using System;
using System.Net;
using System.Net.Sockets;

namespace Base
{
	public class Server
	{
		private string ip;
		private int port;

		public Server(string ip, int port)
		{
			this.ip = ip;
			this.port = port;
		}

		public void Start(EventHandler OnClientConnect, EventHandler OnClientReceiveMessage)
		{
			int clientNumber = 1;//TODO: trocar por um hash

			bool isRunning = true;

			TcpListener tcpListener = new TcpListener(IPAddress.Parse(this.ip), this.port);

			tcpListener.Start();

			Socket socket;
			ThreadClient threadClient;

			while (isRunning == true)
			{
				socket = tcpListener.AcceptSocket();

				threadClient = new ThreadClient(clientNumber, socket);

				threadClient.OnReceiveMessage += OnClientReceiveMessage;

				OnClientConnect.Invoke(this, new ConnectEventArgs()
				{
					Client = threadClient
				});

				threadClient.Start();

				clientNumber++;
			}
		}

		public void SendMessage(ThreadClient client, dynamic message)
		{
			client.SendMessage(message);
		}
	}
}
