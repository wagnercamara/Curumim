using System;
using Base;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace CurumimServer
{
    class Program
    {
        static List<ThreadClient> Login_threadClients = new List<ThreadClient>();

        //Type Login;
        private const int LOGIN_TYPE_GET_PLAYER = 1;
        private const int LOGIN_TYPE_RETURN_SUCCESS = 2;
        private const int LOGIN_TYPE_RETURN_ERROR = 3;

        //Types Register;
        private const int REGISTER_TYPE_SET_NEW_PLAYER = 4;
        private const int REGISTER_TYPE_RETURN_SUCCESS = 5;
        private const int REGISTER_TYPE_RETURN_ERROR = 6;

        //Types ForgotPassword;
        private const int FORGOT_PASSWORD_TYPE_SET_NEW_PASSWORD = 7;
        private const int FORGOT_PASSWORD_TYPE_RETURN_SUCCESS = 8;
        private const int FORGOT_PASSWORD_TYPE_RETURN_ERROR = 9;
        static void Main(string[] args)
        {
            new Server("127.0.0.1", 5000).Start(OnClientConnect, OnClientReceiveMessage);
        }
        private static void GetProfilePlayer(ThreadClient client,string login, string password)
        {
            SQLQuery sQLQuery = new SQLQuery();
            dynamic dynamic = sQLQuery.LoginPlayer(login, password);
            client.SendMessage(dynamic);
        }
        private static void SetNewPlayer(ThreadClient client,string fullNamePlayer, string loginPlayer, string passwordPlayer, string secretPhresePlayer, string avatarPlayer)
        {
            SQLQuery sQLQuery = new SQLQuery();
            Boolean OK = sQLQuery.SqlSetNewPlayer(fullNamePlayer, loginPlayer, passwordPlayer, secretPhresePlayer, avatarPlayer);
            switch(OK)
            {
                case true:
                    client.SendMessage(new
                    {
                        Type = REGISTER_TYPE_RETURN_SUCCESS
                    }) ;
                    break;
                case false:
                    client.SendMessage(new
                    {
                        Type = REGISTER_TYPE_RETURN_ERROR
                    });
                    break;
            }
        }
        private static void UpdatePlayer(ThreadClient client, string loginPlayer, string passwordPlayer, string secretPhresePlayer)
        {
            SQLQuery sQLQuery = new SQLQuery();
            Boolean OK = sQLQuery.SqlUpdatePassword(loginPlayer, passwordPlayer, secretPhresePlayer);

            switch (OK)
            {
                case true:
                    client.SendMessage(new
                    {
                        Type = FORGOT_PASSWORD_TYPE_RETURN_SUCCESS
                    });
                    break;
                case false:
                    client.SendMessage(new
                    {
                        Type = FORGOT_PASSWORD_TYPE_RETURN_ERROR
                    });
                    break;
            }
        }
        private static void OnClientConnect(object sender, EventArgs e)
        {
            ConnectEventArgs connectEventArgs = e as ConnectEventArgs;

            Console.WriteLine("Client conected");
            if (connectEventArgs != null)
            {
                ThreadClient client = connectEventArgs.Client;

                Login_threadClients.Add(client);
            }
        }
        private static void OnClientReceiveMessage(object sender, EventArgs e) //
        {
            MessageEventArgs messageEventArgs = e as MessageEventArgs;
            ThreadClient client = sender as ThreadClient;

            string fullNamePlayer, loginPlayer, passwordPlayer, secretPhresePlayer, avatarPlayer;

            if (messageEventArgs != null)
            {
                switch (messageEventArgs.Message.GetInt32("Type"))
                {
                    case LOGIN_TYPE_GET_PLAYER:
                        Console.WriteLine("LOGIN_TYPE_GET_PLAYER");
                        string login = messageEventArgs.Message.GetString("loginPlayer");
                        string password = messageEventArgs.Message.GetString("passwordPlayer");

                        GetProfilePlayer(client, login, password);
                        break;
                    case REGISTER_TYPE_SET_NEW_PLAYER:

                        Console.WriteLine("REGISTER_TYPE_SET_NEW_PLAYER");
                        fullNamePlayer = messageEventArgs.Message.GetString("fullNamePlayer");
                        loginPlayer = messageEventArgs.Message.GetString("loginPlayer");
                        passwordPlayer = messageEventArgs.Message.GetString("passwordPlayer");
                        secretPhresePlayer = messageEventArgs.Message.GetString("secretPhresePlayer");
                        avatarPlayer = messageEventArgs.Message.GetString("avatarPlayer");

                        SetNewPlayer(client, fullNamePlayer, loginPlayer, passwordPlayer, secretPhresePlayer, avatarPlayer);

                        break;
                    case FORGOT_PASSWORD_TYPE_SET_NEW_PASSWORD:

                        Console.WriteLine("FORGOT_PASSWORD_TYPE_SET_NEW_PASSWORD");
                        loginPlayer = messageEventArgs.Message.GetString("loginPlayer");
                        passwordPlayer = messageEventArgs.Message.GetString("passwordPlayer");
                        secretPhresePlayer = messageEventArgs.Message.GetString("secretPhresePlayer");

                        UpdatePlayer(client, loginPlayer, passwordPlayer, secretPhresePlayer);
                        break;
                }
            }

        }
    }
}
