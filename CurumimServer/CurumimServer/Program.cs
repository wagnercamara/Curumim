using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Linq.Expressions;
using Base;
using System.Threading;
using Microsoft.VisualBasic;

namespace CurumimServer
{
    class Program
    {
        static List<ThreadClient> Login_threadClients = new List<ThreadClient>();
        static Dictionary<int, ThreadClient> MessegeOnLine = new Dictionary<int, ThreadClient>();
        static Dictionary<int, List<dynamic>> BuyPlayers = new Dictionary<int, List<dynamic>>(); //carrinho de cada jogador.
        static Dictionary<string, ThreadClient>[] Rooms = new Dictionary<string, ThreadClient>[8]; //jogadoes em espera.
        static Dictionary<string, ThreadClient> BattlePlayers = new Dictionary<string, ThreadClient>(); //jogadores em batalha.

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
        private const int MESSAGE_TYPE_GET_MESSAGES = 10;
        private const int MESSAGE_TYPE_SEVER = 11;
        private const int MESSAGE_TYPE_SEND_NEW_MESSAGE = 12;
        private const int MESSAGE_TYPE_READ_NEW_MESSAGE = 13;
        private const int MESSAGE_TYPE_READ_ERRO = 14;

        //
        private const int MESSAGE_TYPE_SET_PLAYER_OFF_LINE = 15;
        private const int MESSAGE_TYPE_SET_PLAYER_ON_LINE = 16;
        private const int MESSAGE_TYPE_SET_PLAYER_ON_LINE_ERRO = 17;
        private const int MESSAGE_TYPE_SET_PLAYER_ON_LINE_SUCCESS = 18;

        //
        private const int MESSAGE_TYPE_GET_SEARCH_PLAYER = 19;
        private const int MESSAGE_TYPE_GET_SEARCH_PLAYER_ERRO = 20;
        private const int MESSAGE_TYPE_GET_SEARCH_PLAYER_SUCCESS = 21;

        //
        private const int MESSAGE_TYPE_GET_CONTACTS = 22;
        private const int MESSAGE_TYPE_GET_CONTACTS_SUCCESS = 23;
        private const int MESSAGE_TYPE_GET_CONTACTS_ERRO = 24;
        private const int MESSAGE_TYPE_NEW_MESSAGE_ONLINE = 25;

        //
        private const int MESSAGE_TYPE_GET_MESSAGE_BOX = 26;
        private const int MESSAGE_TYPE_GET_MESSAGE_BOX_SUCCESS = 27;

        //type Store
        private const int STORE_TYPE_GET_ITEM = 28;
        private const int STORE_TYPE_GET_ITEM_SUCCESS = 29;
        private const int STORE_TYPE_GET_ITEM_ERRO = 30;

        //Type Arsenal
        private const int ARSENAL_TYPE_GET_ITEM = 31;
        private const int ARSENAL_TYPE_GET_ITEM_SUCCESS = 32;
        private const int ARSENAL_TYPE_GET_ITEM_ERRO = 33;

        //BuyStore
        private static List<dynamic> BuyList;
        private const int STORE_TYPE_SET_BUY = 34;
        private const int STORE_TYPE_SET_BUY_SUCCESS = 35;
        private const int STORE_TYPE_SET_BUY_ERRO = 36;

        //
        private const int PLAYER_TYPE_GET_POSITION = 37;
        private const int PLAYER_TYPE_GET_POSITION_SUCCESS = 38;
        private const int PLAYER_TYPE_GET_POSITION_ERRO = 39;

        //
        private const int PROGRESSBAR_TYPE_NEXT = 40;
        //CHAT BATTLE
        private const int NEW_MESSAGE_CHAT_BATTLE = 41;
        private const int NEW_MESSAGE_CHAT_BATTLE_SUCESS = 42;
        private const int NEW_MESSAGE_CHAT_BATTLE_ERRO = 43;

        //ChatGlobal_RankingJogadores.
        private const int GET_INFO_GAME = 44;
        private const int GET_INFO_GAME_SUCESS = 45;
        private const int GET_INFO_GAME_ERRO = 46;
        private const int SET_MESSAGE_GLOBAL = 47;



        //BATTLE
        private const int BATTLE_TYPE_ENTERED_BATTLE = 50;
        private const int BATTLE_TYPE_ENTERED_BATTLE_SUCCESS = 51;
        private const int BATTLE_TYPE_EXIT_BATTLE = 52;
        private const int BATTLE_TYPE_GET_FIELDS = 53;
        private const int BATTLE_TYPE_GET_FIELDS_SUCCESS = 54;
        private const int BATTLE_TYPE_GET_FIELDS_ERROR = 55;
        private const int BATTLE_TYPE_SET_DESTROYED_SIDE = 56;
        private const int BATTLE_TYPE_SET_DESTROYED_SIDE_SUCECSS = 57;
        private const int BATTLE_TYPE_SET_DESTROYED_SIDE_ERROR = 58;
        private const int BATTLE_TYPE_SET_WINNER_PLAYER = 59;
        private const int BATTLE_TYPE_SYNC_LOCAL_INDIAN = 60;
        private const int BATTLE_TYPE_SYNC_LOCAL_INDIAN_SUCCESS = 61;

        static void Main(string[] args)
        {
            Server server = new Server("127.0.0.1", 5000);

            server.Start(OnClientConnect, OnClientReceiveMessage);
        }
        private static void GetProfilePlayer(ThreadClient client, string login, string password)
        {
            SQLQuery sQLQuery = new SQLQuery();
            dynamic dynamic = sQLQuery.LoginGetPlayer(login, password);
            client.SendMessage(dynamic);
        }
        private static void GetListContacts(ThreadClient client, int idPlayer)
        {
            SQLQuery sQLQuery = new SQLQuery();
            List<dynamic> dynamics = sQLQuery.SqlGetContacts(idPlayer);
            foreach (dynamic din in dynamics)
            {
                client.SendMessage(din);
            }
        }
        private static void GetMessageChat(ThreadClient client, int sender, int receiver)
        {
            SQLQuery sQLQuery = new SQLQuery();
            List<dynamic> dynamics = sQLQuery.SqlGetMessage(sender, receiver);
            foreach (dynamic din in dynamics)
            {
                client.SendMessage(din);
            }
        }
        private static void GetItemStore(ThreadClient client)
        {
            SQLQuery sQLQuery = new SQLQuery();
            List<dynamic> dynamics = sQLQuery.SqlGetItemStore();
            foreach (dynamic din in dynamics)
            {
                client.SendMessage(din);
            }
        }
        private static void GetItemArsenal(ThreadClient client, int idPlayer)
        {
            SQLQuery sQLQuery = new SQLQuery();
            List<dynamic> dynamics = sQLQuery.SqlGetItemArsenal(idPlayer);
            foreach (dynamic din in dynamics)
            {
                client.SendMessage(din);
            }
        }
        private static void GetSearchPlayer(ThreadClient client, string login, bool v)
        {
            SQLQuery sQLQuery = new SQLQuery();
            dynamic dynamic = sQLQuery.GetSearchPlayer(login, v);
            client.SendMessage(dynamic);
        }
        private static void GetPlayerPosition(ThreadClient client, int idPlayer)
        {
            SQLQuery sQLQuery = new SQLQuery();
            dynamic dynamic = sQLQuery.GetPlayerPosition(idPlayer);
            client.SendMessage(dynamic);
        }
        private static void GetMessageGLobal(ThreadClient client)
        {
            SQLQuery sQLQuery = new SQLQuery();
            List<dynamic> dynamics = sQLQuery.SqlGetMessageGlobal();
            foreach (dynamic din in dynamics)
            {
                client.SendMessage(din);
            }
        }
        private static void GetRankig(ThreadClient client)
        {
            SQLQuery sQLQuery = new SQLQuery();
            List<dynamic> dynamics = sQLQuery.SqlGetRanking();
            foreach (dynamic din in dynamics)
            {
                client.SendMessage(din);
            }
        }
        private static void SetNewPlayer(ThreadClient client, string fullNamePlayer, string loginPlayer, string passwordPlayer, string secretPhresePlayer, string avatarPlayer)
        {
            SQLQuery sQLQuery = new SQLQuery();
            Boolean OK = sQLQuery.SqlSetNewPlayer(fullNamePlayer, loginPlayer, passwordPlayer, secretPhresePlayer, avatarPlayer);
            switch (OK)
            {
                case true:
                    client.SendMessage(new
                    {
                        Type = REGISTER_TYPE_RETURN_SUCCESS
                    });
                    break;
                case false:
                    client.SendMessage(new
                    {
                        Type = REGISTER_TYPE_RETURN_ERROR
                    });
                    break;
            }
        }
        private static void SetNewMessage(ThreadClient client, int sender_id_tbPlayer, int receiver_id_tbPlayer, string messageMessage, DateTime dateTimeMessage, string loginSender)
        {
            SQLQuery sQLQuery = new SQLQuery();
            Boolean OkSend = sQLQuery.SqlInsertMenssage(sender_id_tbPlayer, receiver_id_tbPlayer, messageMessage, dateTimeMessage);
            Boolean OK = MessegeOnLine.ContainsKey(receiver_id_tbPlayer);
            switch (OkSend)
            {
                case true:
                    switch (OK)
                    {
                        case true:
                            ThreadClient receiver = MessegeOnLine[receiver_id_tbPlayer];
                            string format = "yyyy/MM/dd HH:mm:ss";
                            string date = dateTimeMessage.ToString(format);
                            receiver.SendMessage(new
                            {
                                Type = MESSAGE_TYPE_NEW_MESSAGE_ONLINE,
                                loginSender,
                                sender_id_tbPlayer,
                                messageMessage,
                                date

                            });
                            break;
                        case false:
                            client.SendMessage(new
                            {
                                Type = MESSAGE_TYPE_SEVER,
                                message = "Server: Client está Offline, sua mensagem foi gravada",
                            });
                            break;
                    }
                    break;
                case false:
                    client.SendMessage(new
                    {
                        Type = MESSAGE_TYPE_SEVER,
                        message = "Server Log: Erro ao gravar mensagem no banco de dados",
                    });
                    break;
            }
        }
        private static void NewMessageChatGlobal(ThreadClient client, int sender_id_tbPlayer, string messageMessage, DateTime dateTimeMessage, string loginSender)
        {
            SQLQuery sQLQuery = new SQLQuery();
            Boolean OkSend = sQLQuery.SqlInsertMenssageGlobal(sender_id_tbPlayer, messageMessage, dateTimeMessage);

            switch (OkSend)
            {
                case true:
                    foreach (ThreadClient threadClient in Login_threadClients)
                    {
                        string sender = loginSender;
                        string message = messageMessage;
                        string date = dateTimeMessage.ToString();
                        threadClient.SendMessage(new {Type = GET_INFO_GAME_SUCESS, Function = "message", sender, message, date });
                    }
                    break;
                case false:
                    client.SendMessage(new
                    {
                        Type = GET_INFO_GAME_ERRO
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
                            if (MessegeOnLine.ContainsKey(idPlayer) == false)
                            {
                                MessegeOnLine.Add(idPlayer, client);
                                client.SendMessage(new
                                {
                                    Type = MESSAGE_TYPE_SET_PLAYER_ON_LINE_SUCCESS
                                });
                            }
                            else
                            {
                                MessegeOnLine.Remove(idPlayer);

                                MessegeOnLine.Add(idPlayer, client);
                                client.SendMessage(new
                                {
                                    Type = MESSAGE_TYPE_SET_PLAYER_ON_LINE_SUCCESS
                                });
                            }
                            break;
                        case 0:
                            Console.WriteLine("Client OFFLINE");
                            if (MessegeOnLine.ContainsKey(idPlayer) == true)
                            {
                                MessegeOnLine.Remove(idPlayer);
                            }
                            break;
                    }
                    break;
                case false:
                    Console.WriteLine("status não gravado.");
                    client.SendMessage(new { Type = MESSAGE_TYPE_SET_PLAYER_ON_LINE_ERRO });
                    break;
            }
            UpdateStatus(idPlayer);


        }
        private static void SetRoomPlayer(ThreadClient client, string loginPlayer, int typeRoom, int betRoom, bool waiting)
        {
            switch (waiting)
            {
                case true:
                    if (Rooms[typeRoom] == null)
                    {
                        Rooms[typeRoom] = new Dictionary<string, ThreadClient>();
                    }
                    Console.WriteLine($"Client Enter Room {typeRoom}");
                    if (Rooms[typeRoom].ContainsKey(loginPlayer) == false)
                    {
                        Rooms[typeRoom].Add(loginPlayer, client);
                        if (Rooms[typeRoom].Count() < 2)
                        {
                            client.SendMessage(new { Type = BATTLE_TYPE_ENTERED_BATTLE_SUCCESS });
                        }
                        if (Rooms[typeRoom].Count() == 2)
                        {
                            CreateBattle(typeRoom, betRoom);
                        }
                    }
                    break;
                case false:
                    Console.WriteLine($"Client Exit Room { typeRoom}");
                    if (Rooms[typeRoom].ContainsKey(loginPlayer) == true)
                    {
                        Rooms[typeRoom].Remove(loginPlayer);
                    }
                    break;
            }
        }
        private static Boolean SetEmeraldUpdatePlayer(ThreadClient client, int idPlayer, int emerald)
        {
            SQLQuery sQLQuery = new SQLQuery();
            return sQLQuery.SqlUpdateEmaraldPlayer(idPlayer, emerald);
        }
        private static void SetItemPurchase(ThreadClient client, Int32 idPlayer, Int32 id_tbItem, Int32 amountItemPurchase, Int32 valueUnitItemPurchase, Int32 valueTotalItemPurchase, Int32 listSize, int emerald)
        {
            List<dynamic> DinBuy;
            if (BuyPlayers.ContainsKey(idPlayer) == false)
            {
                BuyList = new List<dynamic>();
                BuyPlayers.Add(idPlayer, BuyList);//dicionario
                DinBuy = BuyPlayers[idPlayer];
                DinBuy.Add(new
                {
                    id_tbItem,
                    amountItemPurchase,
                    valueUnitItemPurchase,
                    valueTotalItemPurchase
                });
                InsertBuyItem(DinBuy, client, idPlayer, listSize, emerald);
            }
            else
            {
                DinBuy = BuyPlayers[idPlayer];
                DinBuy.Add(new
                {
                    id_tbItem,
                    amountItemPurchase,
                    valueUnitItemPurchase,
                    valueTotalItemPurchase
                });
                InsertBuyItem(DinBuy, client, idPlayer, listSize, emerald);
            }
        }
        private static void InsertBuyItem(List<dynamic> DinBuy, ThreadClient client, Int32 idPlayer, Int32 listSize, int emerald)
        {
            if (DinBuy.Count == listSize)
            {
                bool InsertSucess = false;
                Int32 id_tbItem = 0;
                Int32 amountItemPurchase = 0;
                Int32 valueUnitItemPurchase = 0;
                Int32 valueTotalItemPurchase = 0;
                DateTime dateTime = DateTime.Now;
                SQLQuery sQLQuery = new SQLQuery();
                Int32? idPuchese = sQLQuery.SqlSetPurchase(dateTime, idPlayer);

                if (idPuchese != null)
                {
                    foreach (dynamic dynBuy in BuyList)
                    {
                        id_tbItem = dynBuy.id_tbItem;
                        amountItemPurchase = dynBuy.amountItemPurchase;
                        valueUnitItemPurchase = dynBuy.valueUnitItemPurchase;
                        valueTotalItemPurchase = dynBuy.valueTotalItemPurchase;

                        InsertSucess = sQLQuery.SqlSetItemPuchase((Int32)idPuchese, id_tbItem, amountItemPurchase, valueUnitItemPurchase, valueTotalItemPurchase);
                        if (InsertSucess == false)
                        {
                            break;
                        }
                    }
                    switch (InsertSucess)
                    {
                        case true:
                            UpdateArsenal(client, idPlayer, DinBuy, emerald);
                            break;
                        case false:
                            BuyPlayers.Remove(idPlayer);
                            client.SendMessage(new { Type = STORE_TYPE_SET_BUY_ERRO });
                            break;
                    }
                }
                else
                {
                    BuyPlayers.Remove(idPlayer);
                    client.SendMessage(new { Type = STORE_TYPE_SET_BUY_ERRO });
                }
            }
            else
            {
                client.SendMessage(new { Type = PROGRESSBAR_TYPE_NEXT });
            }
        }
        private static void UpdateArsenal(ThreadClient client, int idPlayer, List<dynamic> DinBuy, int emerald)
        {
            Console.WriteLine("ARSENAL_TYPE_GET_ITEM");
            Boolean InsertSucess = false;
            Int32 id_tbItem = 0;
            Int32 amountItemPurchase = 0;
            SQLQuery sQLQuery = new SQLQuery();

            foreach (dynamic dynBuy in BuyList)
            {
                id_tbItem = dynBuy.id_tbItem;
                amountItemPurchase = dynBuy.amountItemPurchase;

                InsertSucess = sQLQuery.SqlSetOrUpdateArsenal(idPlayer, id_tbItem, amountItemPurchase);
                if (InsertSucess == false)
                {
                    break;
                }
            }
            if (InsertSucess == true)
            {
                BuyPlayers.Remove(idPlayer);
                if (SetEmeraldUpdatePlayer(client, idPlayer, emerald) == true)
                {
                    GetItemArsenal(client, idPlayer);
                    client.SendMessage(new { Type = STORE_TYPE_SET_BUY_SUCCESS });
                }
                else
                {
                    client.SendMessage(new { Type = ARSENAL_TYPE_GET_ITEM_ERRO });
                }
            }
            else
            {
                client.SendMessage(new { Type = ARSENAL_TYPE_GET_ITEM_ERRO });
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
        private static void UpdateStatus(int idPlayer)
        {
            int id = 0;
            ThreadClient client = null;
            foreach (var clients in MessegeOnLine)
            {
                id = (int)clients.Key;
                client = (ThreadClient)clients.Value;
                if (idPlayer != id)
                {
                    GetListContacts(client, id);
                }
            }
        }
        private static void CreateBattle(int typeRoom, int betRoom)
        {
            GameBattle gameBattle = new GameBattle(typeRoom, Rooms[typeRoom].ElementAt(0).Key, Rooms[typeRoom].ElementAt(1).Key);
            if (typeRoom == 7)
            {
                gameBattle.SetPremiumEsmeraldCrazy(betRoom);
            }

            BattlePlayers.Add(gameBattle.GetIdPlayer1(), Rooms[typeRoom][gameBattle.GetIdPlayer1()]);
            BattlePlayers.Add(gameBattle.GetIdPlayer2(), Rooms[typeRoom][gameBattle.GetIdPlayer2()]);

            Rooms[typeRoom].Remove(gameBattle.GetIdPlayer1());
            Rooms[typeRoom].Remove(gameBattle.GetIdPlayer2());

            BattlePlayers[gameBattle.GetIdPlayer1()].SendMessage(new
            {
                Type = BATTLE_TYPE_GET_FIELDS,
                fieldLeft = gameBattle.GetFieldLeft(),
                fieldRight = gameBattle.GetFieldRight(),
                premiumEsmerald = gameBattle.GetPremimEsmerald(),
                premiumScore = gameBattle.GetPremimScore(),
                loginPlayer1 = gameBattle.GetIdPlayer1(),
                loginPlayer2 = gameBattle.GetIdPlayer2(),
                typeRoom
            });
            BattlePlayers[gameBattle.GetIdPlayer2()].SendMessage(new
            {
                Type = BATTLE_TYPE_GET_FIELDS,
                fieldLeft = gameBattle.GetFieldLeft(),
                fieldRight = gameBattle.GetFieldRight(),
                premiumEsmerald = gameBattle.GetPremimEsmerald(),
                premiumScore = gameBattle.GetPremimScore(),
                loginPlayer1 = gameBattle.GetIdPlayer1(),
                loginPlayer2 = gameBattle.GetIdPlayer2(),
                typeRoom
            });
        }

        private static void DestroyedButton(int[] locals, string loginPlayerEnemy, int typeItem)
        {
            ThreadClient clientee = BattlePlayers[loginPlayerEnemy];
            clientee.SendMessage(new
            {
                Type = BATTLE_TYPE_SET_DESTROYED_SIDE_SUCECSS,
                locals,
                typeItem
            });
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
        private static void NewMessagechatBattle(ThreadClient client, string messageMessage, string login, string loginPlayerEnemy)
        {
            if (BattlePlayers.ContainsKey(login))
            {
                ThreadClient thread = BattlePlayers[loginPlayerEnemy];
                thread.SendMessage(new { Type = NEW_MESSAGE_CHAT_BATTLE_SUCESS, messageMessage = $"{login}: {messageMessage}" });
            }
            else
            {
                client.SendMessage(new { Type = NEW_MESSAGE_CHAT_BATTLE_ERRO });
            }

        }
        private static void SyncLocalIndian(int newLocal, int oldLocal, string loginPlayer)
        {
            if (BattlePlayers.ContainsKey(loginPlayer))
            {
                ThreadClient thread = BattlePlayers[loginPlayer];
                thread.SendMessage(new { Type = BATTLE_TYPE_SYNC_LOCAL_INDIAN_SUCCESS, oldLocal, newLocal });
            }
        }
        private static void OnClientReceiveMessage(object sender, EventArgs e) //
        {
            MessageEventArgs messageEventArgs = e as MessageEventArgs;
            ThreadClient client = sender as ThreadClient;

            string fullNamePlayer, loginPlayer, passwordPlayer, secretPhresePlayer, avatarPlayer, messageMessage;
            int sender_id_tbPlayer, receiver_id_tbPlayer, idPlayer, id_tbItem, amountItemPurchase, valueUnitItemPurchase, valueTotalItemPurchase, listSize, emerald;

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
                        sender_id_tbPlayer = messageEventArgs.Message.GetInt32("sender_id_tbPlayer");
                        receiver_id_tbPlayer = messageEventArgs.Message.GetInt32("receiver_id_tbPlayer");
                        messageMessage = messageEventArgs.Message.GetString("messageMessage");
                        loginPlayer = messageEventArgs.Message.GetString("name_Sender");

                        DateTime dateTime = DateTime.Now;

                        SetNewMessage(client, sender_id_tbPlayer, receiver_id_tbPlayer, messageMessage, dateTime, loginPlayer);
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
                    case MESSAGE_TYPE_GET_CONTACTS:
                        Console.WriteLine("MESSAGE_TYPE_GET_CONTACTS");
                        idPlayer = messageEventArgs.Message.GetInt32("idPlayer");
                        GetListContacts(client, idPlayer);
                        break;
                    case MESSAGE_TYPE_GET_MESSAGES:
                        Console.WriteLine("MESSAGE_TYPE_GET_MESSAGES");
                        sender_id_tbPlayer = messageEventArgs.Message.GetInt32("idSender");
                        receiver_id_tbPlayer = messageEventArgs.Message.GetInt32("idReceiver");
                        GetMessageChat(client, sender_id_tbPlayer, receiver_id_tbPlayer);
                        break;
                    case MESSAGE_TYPE_GET_SEARCH_PLAYER:
                        Console.WriteLine("MESSAGE_TYPE_GET_SEARCH_PLAYER");
                        loginPlayer = messageEventArgs.Message.GetString("loginPlayer");
                        GetSearchPlayer(client, loginPlayer, false);
                        break;
                    case MESSAGE_TYPE_GET_MESSAGE_BOX:
                        Console.WriteLine("MESSAGE_TYPE_GET_MESSAGE_BOX");
                        loginPlayer = messageEventArgs.Message.GetString("loginPlayer");
                        GetSearchPlayer(client, loginPlayer, false);
                        break;
                    case STORE_TYPE_GET_ITEM:
                        Console.WriteLine("STORE_TYPE_GET_ITEM");
                        GetItemStore(client);
                        break;
                    case ARSENAL_TYPE_GET_ITEM:
                        Console.WriteLine("ARSENAL_TYPE_GET_ITEM");
                        idPlayer = messageEventArgs.Message.GetInt32("idPlayer");
                        GetItemArsenal(client, idPlayer);
                        break;
                    case STORE_TYPE_SET_BUY:
                        Console.WriteLine("STORE_TYPE_SET_BUY");
                        idPlayer = messageEventArgs.Message.GetInt32("idPlayer");
                        id_tbItem = messageEventArgs.Message.GetInt32("id_tbItem");
                        amountItemPurchase = messageEventArgs.Message.GetInt32("amountItemPurchase");
                        valueUnitItemPurchase = messageEventArgs.Message.GetInt32("valueUnitItemPurchase");
                        valueTotalItemPurchase = messageEventArgs.Message.GetInt32("valueTotalItemPurchase");
                        emerald = messageEventArgs.Message.GetInt32("ValueWallet");
                        listSize = messageEventArgs.Message.GetInt32("listSize");

                        SetItemPurchase(client, idPlayer, id_tbItem, amountItemPurchase, valueUnitItemPurchase, valueTotalItemPurchase, listSize, emerald);
                        break;
                    case PLAYER_TYPE_GET_POSITION:
                        Console.WriteLine("PLAYER_TYPE_GET_POSITION");
                        idPlayer = messageEventArgs.Message.GetInt32("idPlayer");
                        GetPlayerPosition(client, idPlayer);
                        break;

                    case BATTLE_TYPE_ENTERED_BATTLE:
                        Console.WriteLine("BATTLE_TYPE_ENTERED_BATTLE");
                        loginPlayer = messageEventArgs.Message.GetString("loginPlayer");
                        int typeRoom = messageEventArgs.Message.GetInt32("typeBattle");
                        int betRoom = messageEventArgs.Message.GetInt32("betRoom");
                        SetRoomPlayer(client, loginPlayer, typeRoom, betRoom, true);
                        break;
                    case BATTLE_TYPE_EXIT_BATTLE:
                        Console.WriteLine("BATTLE_TYPE_EXIT_BATTLE");
                        loginPlayer = messageEventArgs.Message.GetString("loginPlayer");
                        typeRoom = messageEventArgs.Message.GetInt32("typeBattle");
                        betRoom = messageEventArgs.Message.GetInt32("betRoom");
                        SetRoomPlayer(client, loginPlayer, typeRoom, betRoom, false);
                        break;
                    case BATTLE_TYPE_SET_DESTROYED_SIDE:
                        int[] locals = messageEventArgs.Message.GetSingleDimArrayInt32("locals");
                        string loginPlayerEnemy = messageEventArgs.Message.GetString("loginPlayer");
                        int typeItem = messageEventArgs.Message.GetInt32("typeItem");
                        DestroyedButton(locals, loginPlayerEnemy, typeItem);
                        break;
                    case BATTLE_TYPE_SYNC_LOCAL_INDIAN:
                        int newLocal = messageEventArgs.Message.GetInt32("newLocal");
                        loginPlayer = messageEventArgs.Message.GetString("loginPlayer");
                        int oldLocal = messageEventArgs.Message.GetInt32("oldLocal");
                        SyncLocalIndian(newLocal, oldLocal, loginPlayer);
                        break;
                    case NEW_MESSAGE_CHAT_BATTLE:
                        Console.WriteLine("NEW_MESSAGE_CHAT_BATTLE");
                        messageMessage = messageEventArgs.Message.GetString("messageMessage");
                        loginPlayer = messageEventArgs.Message.GetString("loginPlayer");
                        loginPlayerEnemy = messageEventArgs.Message.GetString("loginPlayerEnemy");
                        NewMessagechatBattle(client, messageMessage, loginPlayer, loginPlayerEnemy);
                        break;
                    case GET_INFO_GAME:
                        string Function = messageEventArgs.Message.GetString("Function");
                        Console.WriteLine($"GET_INFO_GAME: { Function }");
                        if (Function == "message")
                        {
                            GetMessageGLobal(client);
                        }
                        else if(Function == "ranking" )
                        {
                            GetRankig(client);
                        }
                        else
                        {
                            GetMessageGLobal(client);
                            GetRankig(client);
                        }
                        break;
                    case SET_MESSAGE_GLOBAL:
                        {
                            sender_id_tbPlayer = messageEventArgs.Message.GetInt32("sender_id_tbPlayer");
                            messageMessage = messageEventArgs.Message.GetString("messageMessage");
                            loginPlayer = messageEventArgs.Message.GetString("name_Sender");

                            DateTime dateT = DateTime.Now;

                            NewMessageChatGlobal(client, sender_id_tbPlayer, messageMessage, dateT, loginPlayer);
                        }
                        break;
                }
            }
        }
    }
}
