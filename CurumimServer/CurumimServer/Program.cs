using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Linq.Expressions;
using Base;

namespace CurumimServer
{
    class Program
    {
        static List<ThreadClient> Login_threadClients = new List<ThreadClient>();
        static Dictionary<int, ThreadClient> MessegaOnLine = new Dictionary<int, ThreadClient>();

        //Types
        //Types Login
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

        //Types Message
        private const int MESSAGE_TYPE_GET_MESSAGES_ON = 10;
        private const int MESSAGE_TYPE_GET_MESSAGES_OFF = 11;
        private const int MESSAGE_TYPE_SEND_NEW_MESSAGE = 12;
        private const int MESSAGE_TYPE_READ_NEW_MESSAGE = 13;
        private const int MESSAGE_TYPE_READ_ERRO = 14;

        //
        private const int MESSAGE_TYPE_SET_PLAYER_OFF_LINE = 15;
        private const int MESSAGE_TYPE_SET_PLAYER_ON_LINE = 16;
        private const int MESSAGE_TYPE_SET_PLAYER_ON_LINE_ERRO = 17;
        private const int MESSAGE_TYPE_SET_PLAYER_ON_LINE_SUCCESS = 18;
        private const int MESSAGE_TYPE_GET_PLAYER_MESSAGE = 19;


        static void Main(string[] args)
        {
            Server server = new Server("127.0.0.1", 5000);

            server.Start(OnClientConnect, OnClientReceiveMessage);
        }
        private static void GetProfilePlayer(ThreadClient client,string login, string password)
        {
            SQLQuery sQLQuery = new SQLQuery();
            dynamic dynamic = sQLQuery.LoginPlayer(login, password);
            client.SendMessage(dynamic);
        }
        private static void GetPlayerOffOnLine(ThreadClient client,Int32 offOnLine)
        {
            SQLQuery sQLQuery = new SQLQuery();
            List<dynamic> dynamics = sQLQuery.SqlSelectPlayerOffline(offOnLine);
            foreach (dynamic din in dynamics)
            {
                client.SendMessage(din);
            }

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
        private static void SendNewMessage(ThreadClient client,int sender_id_tbPlayer,int  receiver_id_tbPlayer,string messageMessage, string dateTimeMessage)
        {
            SQLQuery sQLQuery = new SQLQuery();
            Boolean OkSend = sQLQuery.SqlInsertMenssage(sender_id_tbPlayer, receiver_id_tbPlayer, messageMessage, dateTimeMessage);
            switch(OkSend)
            {
                case true:
                    Boolean OK = MessegaOnLine.ContainsKey(receiver_id_tbPlayer);
                    ThreadClient receiver = MessegaOnLine[receiver_id_tbPlayer];
                    switch (OK)
                    {
                        case true:
                            receiver.SendMessage(new
                            {
                                Type = MESSAGE_TYPE_READ_NEW_MESSAGE,
                                sender_id_tbPlayer,
                                messageMessage,
                                dateTimeMessage
                            });
                            break;
                        case false:
                            client.SendMessage(new
                            {
                                Type = MESSAGE_TYPE_READ_ERRO,
                                messageMessage = "Client offLine, Sua mensagem ficará gravada e ele receberar na proxima vez que entrar oline"
                            });
                            break;
                    }
                    break;
                case false:
                    client.SendMessage(new
                    {
                        Type = MESSAGE_TYPE_READ_ERRO,
                        messageMessage = "Erro Servidor Indisponivel"
                    });
                    break;  
            }

        }
        private static void SetOffOrOnPlayer(ThreadClient client, int idPlayer, int OffOn)
        {
            SQLQuery sQLQuery = new SQLQuery();
            Boolean OK = sQLQuery.SqlSetOffOnLine(idPlayer, OffOn);

            switch (OK)
            {
                case true:
                    Console.WriteLine("Status Gravado");
                    switch (OffOn)
                    {
                        case 1:
                            Console.WriteLine("Client ONLINE");
                            if (MessegaOnLine.ContainsKey(idPlayer) == false)
                            {
                                MessegaOnLine.Add(idPlayer, client);
                                client.SendMessage(new
                                {
                                    Type = MESSAGE_TYPE_SET_PLAYER_ON_LINE_SUCCESS
                                });
                            }
                            else
                            {
                                MessegaOnLine.Remove(idPlayer);

                                MessegaOnLine.Add(idPlayer, client);
                                client.SendMessage(new
                                {
                                    Type = MESSAGE_TYPE_SET_PLAYER_ON_LINE_SUCCESS
                                });
                            }
                            break;
                        case 0:
                            Console.WriteLine("Client OFFLINE");
                            if (MessegaOnLine.ContainsKey(idPlayer) == true)
                            {
                                MessegaOnLine.Remove(idPlayer);
                            }
                            break;
                    }
                    break;
                case false:
                    Console.WriteLine("status não gravado.");
                    client.SendMessage(new { Type = MESSAGE_TYPE_SET_PLAYER_ON_LINE_ERRO });
                    break;
            }
        }
        private static void OnClientConnect(object sender, EventArgs e)
        {
            ConnectEventArgs connectEventArgs = e as ConnectEventArgs;


            if (connectEventArgs != null)
            {
                ThreadClient client = connectEventArgs.Client;

                Login_threadClients.Add(client);
                Console.WriteLine("Client conected");
            }
        }
        private static void OnClientReceiveMessage(object sender, EventArgs e) //
        {
            MessageEventArgs messageEventArgs = e as MessageEventArgs;
            ThreadClient client = sender as ThreadClient;

            string fullNamePlayer, loginPlayer, passwordPlayer, secretPhresePlayer, avatarPlayer, messageMessage, dateTimeMessage;
            int sender_id_tbPlayer, receiver_id_tbPlayer, idPlayer;

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

                    case MESSAGE_TYPE_SEND_NEW_MESSAGE:
                        Console.WriteLine("MESSAGE_TYPE_SEND_NEW_MESSAGE");
                        sender_id_tbPlayer = messageEventArgs.Message.GetInt32("messageMessage");
                        receiver_id_tbPlayer = messageEventArgs.Message.GetInt32("messageMessage");
                        messageMessage = messageEventArgs.Message.GetString("messageMessage");
                        dateTimeMessage = messageEventArgs.Message.GetString("dateTimeMessage");

                        SendNewMessage(client,sender_id_tbPlayer, receiver_id_tbPlayer, messageMessage, dateTimeMessage);
                        break;

                    case MESSAGE_TYPE_GET_MESSAGES_ON:
                        Console.WriteLine("MESSAGE_TYPE_GET_MESSAGES_ON");
                        GetPlayerOffOnLine(client, 1);
                        break;
                    case MESSAGE_TYPE_GET_MESSAGES_OFF:
                        Console.WriteLine("MESSAGE_TYPE_GET_MESSAGES_OFF");
                        GetPlayerOffOnLine(client, 0);
                        break;

                    case MESSAGE_TYPE_SET_PLAYER_ON_LINE:
                        Console.WriteLine("MESSAGE_TYPE_SET_PLAYER_ON_LINE");
                        idPlayer = messageEventArgs.Message.GetInt32("idPlayer");
                        SetOffOrOnPlayer(client, idPlayer, 1);

                        break;
                    case MESSAGE_TYPE_SET_PLAYER_OFF_LINE:
                        Console.WriteLine("MESSAGE_TYPE_SET_PLAYER_OFF_LINE");
                        idPlayer = messageEventArgs.Message.GetInt32("idPlayer");
                        SetOffOrOnPlayer(client, idPlayer, 0);

                        break;
                }
            }
        }
    }
}
