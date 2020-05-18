using Base;
using CurumimClient.BtnEventArgs;
using CurumimClient.Classe;
using CurumimClient.EventArgsForms;
using CurumimClient.pbxEventArgs;
using CurumimClient.PbxEventArgs;
using CurumimGameForms.BtnEventArgs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace CurumimGameForms
{
    public partial class GameBaseForms : Form
    {
        //Server
        Client client;

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

        //Store
        private Dictionary<string, GameWeaponsClasse> StoreItem = new Dictionary<string, GameWeaponsClasse>();
        //type Store
        private const int STORE_TYPE_GET_ITEM = 28;
        private const int STORE_TYPE_GET_ITEM_SUCCESS = 29;
        private const int STORE_TYPE_GET_ITEM_ERRO = 30;
        //Arsenal
        private Dictionary<string, GameWeaponsClasse> ArsenalItem = new Dictionary<string, GameWeaponsClasse>();
        //Type Arsenal
        private const int ARSENAL_TYPE_GET_ITEM = 31;
        private const int ARSENAL_TYPE_GET_ITEM_SUCCESS = 32;
        private const int ARSENAL_TYPE_GET_ITEM_ERRO = 33;

        ///taylor
        ///
        //Froms
        GameLoginForms gameLoginForms = null;
        GameForgotPasswordForms gameForgotPasswordForms = null;
        GameAvatarForms gameAvatarForms = null;
        GameChatPlayerFroms gameChatPlayerForms = null;
        GamePlayerForms gamePlayerFormsFoms = null;
        GameProfileForms gameProfileForms = null;
        GameRoomsForms gameRoomsForms = null;
        GameArsenalForms gameArsenalForms = null;
        GameStoreForms gameStoreForms = null;

        //Classe
        GameProfileClasse gameProfile = null;

        //Atributos
        string rooms = "";

        //Delegate
        private delegate void LoadDelegate(MessageEventArgs messageEventArgs);
        private delegate void LoadChatPlayerDelegate();

        public GameBaseForms()
        {
            InitializeComponent();
        }

        private void GameBaseForms_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            Boolean controlConneted = false;
            Boolean logon = false;
            Int32 countConnection = 0;

            while (controlConneted == false)
            {
                controlConneted = ConectionServer();

                if (controlConneted == true)
                {
                    logon = true;
                }
                if (countConnection > 2)
                {
                    MessageBox.Show("Server is unavailable", "Check your internet or try again later");
                    controlConneted = true;
                }
                countConnection++;
            }

            if (logon == true)
            {
                GetItemStore();
                this.gameLoginForms = new GameLoginForms(BtnRegisterOnClick, BtnLoginOnClick, BtnLoginRepleceOnClick, SelectAvatarOn, LoginSucessEvent);
                gameLoginForms.ShowDialog();
            }
        }
        private Boolean ConectionServer()
        {
            Boolean x = false;
            try
            {
                this.client = new Client("127.0.0.1", 5000);
                this.client.Connect(OnReceiveMessage);
                x = true;
            }
            catch
            {
                DialogResult result = MessageBox.Show("Server connection error ", " Do you want to try again", MessageBoxButtons.YesNo);
                switch (result)
                {
                    case DialogResult.Yes:
                        x = false;
                        break;
                    case DialogResult.No:
                        Application.Exit();
                        break;
                }
            }
            return x;
        }
        private void LoadClassePlayer(MessageEventArgs messageEventArgs)
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new LoadDelegate(LoadClassePlayer), new object[] { messageEventArgs });
            }
            else
            {
                this.gameLoginForms = null;
                string fullNamePlayer = messageEventArgs.Message.GetString("fullNamePlayer");//
                string loginPlayer = messageEventArgs.Message.GetString("loginPlayer");//
                string avatarPlayer = messageEventArgs.Message.GetString("avatarPlayer");//
                string levelPlayer = messageEventArgs.Message.GetString("levelPlayer");//

                Int32 idPlayer = messageEventArgs.Message.GetInt32("idPlayer");//
                Int32 punctuationPlayer = messageEventArgs.Message.GetInt32("punctuationPlayer");//
                Int32 rankingPlayer = messageEventArgs.Message.GetInt32("rankingPlayer");//
                Int32 victoryPlayer = messageEventArgs.Message.GetInt32("victoryPlayer");//
                Int32 totalBatllesPlayer = messageEventArgs.Message.GetInt32("totalBatllesPlayer");//
                Int32 esmeraldPlayer = messageEventArgs.Message.GetInt32("esmeraldPlayer");//

                gameProfile = new GameProfileClasse(idPlayer, fullNamePlayer, loginPlayer, avatarPlayer);

                gameProfile.SetLevelPlayer(levelPlayer);
                gameProfile.SetPunctuationPlayer(punctuationPlayer);
                gameProfile.SetRankingPlayer(rankingPlayer);
                gameProfile.SetVictoryPlayer(victoryPlayer);
                gameProfile.SetTotalBatllesPlayer(totalBatllesPlayer);
                gameProfile.SetEsmeraldPlayer(esmeraldPlayer);
                GetItemArsenal();
                CreatGamePlayer();
            }

        }
        private void GetItemStore()
        {
            client.SendMessage(new { Type = STORE_TYPE_GET_ITEM });
        }
        private void SetItemStore(MessageEventArgs messageEventArgs)
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new LoadDelegate(SetItemStore), new object[] { messageEventArgs });
            }
            else
            {
                Int32 idItem = messageEventArgs.Message.GetInt32("idItem");
                string nameItem = messageEventArgs.Message.GetString("nameItem");
                Int32 levelItem = messageEventArgs.Message.GetInt32("levelItem");
                Int32 valueUnitItem = messageEventArgs.Message.GetInt32("valueUnitItem");
                Int32 destructionAreaItem = messageEventArgs.Message.GetInt32("destructionAreaItem");
                Int32 spaceHit = messageEventArgs.Message.GetInt32("spaceHit");
                Int32 reach = messageEventArgs.Message.GetInt32("reach");
                Int32 typeItem = messageEventArgs.Message.GetInt32("typeItem");

                if (this.StoreItem.ContainsKey(nameItem) == false)
                {
                    this.StoreItem.Add(nameItem, new GameWeaponsClasse(
                      idItem
                    , levelItem
                    , valueUnitItem
                    , destructionAreaItem
                    , spaceHit
                    , reach
                    , typeItem));
                }
            }
        }
        private void GetItemArsenal()
        {
            client.SendMessage(new
            {
                Type = ARSENAL_TYPE_GET_ITEM,
                idPlayer = gameProfile.GetIdPlayer()
            });
        }
        private void SetItemArsenal(MessageEventArgs messageEventArgs)
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new LoadDelegate(SetItemArsenal), new object[] { messageEventArgs });
            }
            else
            {
                string nameItem = messageEventArgs.Message.GetString("nameItem");
                Int32 amountArsenal = messageEventArgs.Message.GetInt32("amountArsenal");

                if (this.ArsenalItem.ContainsKey(nameItem) == false)
                {
                    GameWeaponsClasse g = this.StoreItem[nameItem];
                    g.SetAmountWeapons(amountArsenal);
                    this.ArsenalItem.Add(nameItem, g);
                }
                else
                {
                    this.ArsenalItem.Remove(nameItem);

                    GameWeaponsClasse g = this.StoreItem[nameItem];
                    g.SetAmountWeapons(amountArsenal);
                    this.ArsenalItem.Add(nameItem, g);
                }
            }
        }
        private Boolean CloseGameCurumim()
        {
            Boolean x = true;
            if (gameLoginForms != null) { x = false; }
            if (gameForgotPasswordForms != null) { x = false; }
            if (gameAvatarForms != null) { x = false; }
            if (gameChatPlayerForms != null) { x = false; }
            if (gamePlayerFormsFoms != null) { x = false; }
            if (gameProfileForms != null) { x = false; }
            if (gameRoomsForms != null) { x = false; }
            if (gameArsenalForms != null) { x = false; }
            if (gameStoreForms != null) { x = false; }
            return x;
        }
        private void LoginSucessEvent(object sender, EventArgs e)
        {
            LoginSucessEventArgs loginSucessEventArgs = e as LoginSucessEventArgs;
            if (loginSucessEventArgs.MessageEventArgs != null)
            {
                this.gameLoginForms.Close();
                LoadClassePlayer(loginSucessEventArgs.MessageEventArgs);
            }
            else
            {
                MessageBox.Show("Error Opening Login");
            }
        }
        private void CreatGamePlayer()
        {
            gamePlayerFormsFoms = new GamePlayerForms(PbxProfileOnClick, PbxChatPlayerOpenOnClick, RoomsOpenOnClick, PbxOpenArsenalOnClick, PbxOpenStoreOnClick, CloseGameOnClick);
            gamePlayerFormsFoms.Show();
        }
        private void CloseGameOnClick(object sender, EventArgs e)
        {
            PbxFormsCloseEventeArgs pbxFormsCloseEventeArgs = e as PbxFormsCloseEventeArgs;
            if (pbxFormsCloseEventeArgs != null)
            {
                if (pbxFormsCloseEventeArgs.Close == true)
                {
                    if (CloseGameCurumim() == true)
                    {
                        gamePlayerFormsFoms.Close();
                        Application.Exit();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("It was not possible to close the game with windows open and you need shutters", "Attention", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Error Clouse GameCurumim");
            }
        }
        private void PbxProfileOnClick(object sender, EventArgs e) // Chama o ptofile do player
        {
            PbxFormsOpenEventeArgs pbxFormsOpenEventeArgs = e as PbxFormsOpenEventeArgs;
            if (pbxFormsOpenEventeArgs != null)
            {
                if (pbxFormsOpenEventeArgs.Open == true)
                {
                    if (this.gameProfileForms != null)
                    {
                        this.gameProfileForms.Show();
                        //Application.OpenForms["gameProfileForms"].BringToFront(); // traz um forms já criado pra fente novamente.
                    }
                    else
                    {
                        this.gameProfileForms = new GameProfileForms(this.gameProfile, PbxProfileClouseOnClick);
                        this.gameProfileForms.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Error Opening Profile");
                }

            }
        }
        private void RoomsOpenOnClick(object sender, EventArgs e)
        {
            PbxFormsOpenEventeArgs pbxFormsOpenEventeArgs = e as PbxFormsOpenEventeArgs;
            if (pbxFormsOpenEventeArgs != null)
            {
                if (pbxFormsOpenEventeArgs.Open == true) { this.gameRoomsForms = new GameRoomsForms(); this.gameRoomsForms.Show(); }
            }
            else
            {
                MessageBox.Show("Error Opening Rooms");
            }
        }
        private void PbxProfileClouseOnClick(object sender, EventArgs e)
        {
            PbxFormsCloseEventeArgs pbxFormsCloseEventeArgs = e as PbxFormsCloseEventeArgs;
            if (pbxFormsCloseEventeArgs != null)
            {
                if (pbxFormsCloseEventeArgs.Close == true)
                {
                    gameProfileForms = null;
                }
            }
            else
            {
                MessageBox.Show("Error Close Profile");
            }
        }
        private void BtnLoginOnClick(object sender, EventArgs e) //Logar no jogo
        {
            BtnLoginOnClickEventArgs btnLoginOnClickEventArgs = e as BtnLoginOnClickEventArgs;
            if (btnLoginOnClickEventArgs != null)
            {
                client.SendMessage(new
                {
                    Type = LOGIN_TYPE_GET_PLAYER,
                    btnLoginOnClickEventArgs.loginPlayer,
                    btnLoginOnClickEventArgs.passwordPlayer
                });
            }
            else
            {
                MessageBox.Show("Error Send Login");
            }
        }
        private void BtnRegisterOnClick(object sender, EventArgs e) // mandar informações ao servidor
        {
            BtnRegisterOnClickEventArgs btnRegisterOnClickEventArgs = e as BtnRegisterOnClickEventArgs;
            if (btnRegisterOnClickEventArgs != null)
            {
                client.SendMessage(new
                {
                    Type = REGISTER_TYPE_SET_NEW_PLAYER,
                    btnRegisterOnClickEventArgs.fullNamePlayer,
                    btnRegisterOnClickEventArgs.loginPlayer,
                    btnRegisterOnClickEventArgs.passwordPlayer,
                    btnRegisterOnClickEventArgs.secretPhresePlayer,
                    btnRegisterOnClickEventArgs.avatarPlayer
                });
            }
            else
            {
                MessageBox.Show("Error Send Register");
            }
        }
        private void SelectAvatarOn(object sender, EventArgs e) //chamar forms avatar
        {
            BtnAvatarEventArgs btnAvatarEventArgs = e as BtnAvatarEventArgs;
            if (btnAvatarEventArgs != null)
            {
                if (btnAvatarEventArgs.avatar == true)
                {
                    this.gameAvatarForms = new GameAvatarForms(BtnAvatarSelectOnClick);
                    this.gameAvatarForms.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Error Opening Avatar");
            }
        }
        private void BtnLoginRepleceOnClick(object sender, EventArgs e)//chamar forms para trocar de senha
        {
            BtnForgotPaswordOnClickEventArgs btnForgotPaswordOnClickEventArgs = e as BtnForgotPaswordOnClickEventArgs;
            if (btnForgotPaswordOnClickEventArgs != null)
            {
                if (btnForgotPaswordOnClickEventArgs.newGameReplece == true)
                {
                    this.gameForgotPasswordForms = new GameForgotPasswordForms(BtnRepleceOnClick);
                    this.gameForgotPasswordForms.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Error Opening Replece");
            }
        }
        private void BtnRepleceOnClick(object sender, EventArgs e)//mandar senha nova ao servidor
        {
            BtnReplaceOnClickEventArgs btnReplaceOnClickEventArgs = e as BtnReplaceOnClickEventArgs;
            if (btnReplaceOnClickEventArgs != null)
            {
                client.SendMessage(new
                {
                    Type = FORGOT_PASSWORD_TYPE_SET_NEW_PASSWORD,
                    btnReplaceOnClickEventArgs.loginPlayer,
                    btnReplaceOnClickEventArgs.passwordPlayer,
                    btnReplaceOnClickEventArgs.secretPhresePlayer
                });
            }
            else
            {
                MessageBox.Show("Error Send Replece Password");
            }
        }
        private void BtnAvatarSelectOnClick(object sender, EventArgs e) // setar avatar do cliente
        {
            BtnAvatarSelectEventArgs btnAvatarSelectEventArgs = e as BtnAvatarSelectEventArgs;
            if (btnAvatarSelectEventArgs != null)
            {
                this.gameLoginForms.SetAvatar(btnAvatarSelectEventArgs.avatarPlayer);
                this.gameLoginForms.RegisterDB();
            }
            else
            {
                MessageBox.Show("Error Set Avatar Player");
            }
        }
        private void PbxChatPlayerOpenOnClick(object sender, EventArgs e) // Chama o chat do player
        {
            PbxFormsOpenEventeArgs pbxFormsOpenEventeArgs = e as PbxFormsOpenEventeArgs;
            if (pbxFormsOpenEventeArgs != null)
            {
                if (pbxFormsOpenEventeArgs.Open == true)
                {

                    if (this.gameChatPlayerForms != null)
                    {
                        //Application.OpenForms["gameChatPlayer"].BringToFront(); // traz um forms já criado pra fente novamente.
                        this.gameChatPlayerForms.Show();
                    }
                    else
                    {
                        this.gameChatPlayerForms = new GameChatPlayerFroms(this.gameProfile, this.PbxChatPlayerCloseOnClick, this.MessageSendMessageOnClik, this.LoadContactsOnLoad, this.GetMessageOnLoad, this.GetSearchPlayer);
                        this.gameChatPlayerForms.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Error Opening Chat Player");
                }
            }
            else
            {
                MessageBox.Show("Error Opening Chat Player");
            }
        }
        private void GetSearchPlayer(object sender, EventArgs e)
        {
            GetSearchPlayerEventArgs getSearchPlayerEventArgs = e as GetSearchPlayerEventArgs;
            if (getSearchPlayerEventArgs != null)
            {
                if (getSearchPlayerEventArgs.typeSearch == true)
                {
                    client.SendMessage(new
                    {
                        Type = MESSAGE_TYPE_GET_MESSAGE_BOX,
                        getSearchPlayerEventArgs.loginPlayer
                    });
                }
                else
                {
                    client.SendMessage(new
                    {
                        Type = MESSAGE_TYPE_GET_SEARCH_PLAYER,
                        getSearchPlayerEventArgs.loginPlayer
                    });
                }
            }
        }
        private void GetMessageOnLoad(object sender, EventArgs e)
        {
            BtnGetMessagePlayerChatEventArgs btnGetMessage = e as BtnGetMessagePlayerChatEventArgs;
            if (btnGetMessage != null)
            {
                client.SendMessage(new
                {
                    Type = MESSAGE_TYPE_GET_MESSAGES,
                    btnGetMessage.idSender,
                    btnGetMessage.idReceiver
                });
            }
        }
        private void LoadContactsOnLoad(object sender, EventArgs e) // seta o player para oline e offline
        {
            LoadContactsEventArgs loadContacts = e as LoadContactsEventArgs;

            if (loadContacts != null)
            {
                if (loadContacts.loadContacts == true)
                {
                    this.client.SendMessage(new
                    {
                        Type = MESSAGE_TYPE_GET_CONTACTS,
                        idPlayer = gameProfile.GetIdPlayer()
                    });
                }
                else
                {
                    this.client.SendMessage(new
                    {
                        Type = MESSAGE_TYPE_SET_PLAYER_ON_LINE,
                        idPlayer = gameProfile.GetIdPlayer()
                    });
                }
            }
            else
            {
                MessageBox.Show("Error getting contacts");
            }
        }
        private void MessageSendMessageOnClik(object sender, EventArgs e) //manda a mensagem para um receiver.
        {
            PbxMessageSendMessageEventArgs pbxMessageSendMessageEventArgs = e as PbxMessageSendMessageEventArgs;
            if (pbxMessageSendMessageEventArgs != null)
            {
                this.client.SendMessage(new
                {
                    Type = MESSAGE_TYPE_SEND_NEW_MESSAGE,
                    pbxMessageSendMessageEventArgs.receiver_id_tbPlayer,
                    pbxMessageSendMessageEventArgs.sender_id_tbPlayer,
                    pbxMessageSendMessageEventArgs.messageMessage,
                    pbxMessageSendMessageEventArgs.name_Sender
                });
            }
            else
            {
                MessageBox.Show("Error Send new Message");
            }
        }
        private void PbxChatPlayerCloseOnClick(object sender, EventArgs e) // fecha o chat no servidor.
        {
            PbxFormsCloseEventeArgs pbxFormsCloseEventeArgs = e as PbxFormsCloseEventeArgs;
            if (pbxFormsCloseEventeArgs != null)
            {
                if (pbxFormsCloseEventeArgs.Close == true)
                {
                    this.gameChatPlayerForms = null;
                    this.client.SendMessage(new
                    {
                        Type = MESSAGE_TYPE_SET_PLAYER_OFF_LINE,
                        idPlayer = gameProfile.GetIdPlayer()
                    });
                }
                else
                {
                    MessageBox.Show("Error Close Chat Player");
                }
            }
        }
        private void PbxOpenArsenalOnClick(object sender, EventArgs e)
        {
            PbxFormsOpenEventeArgs pbxFormsOpenEventeArgs = e as PbxFormsOpenEventeArgs;
            if (pbxFormsOpenEventeArgs != null)
            {
                if (pbxFormsOpenEventeArgs.Open == true)
                {
                    OpenArsenal(false);
                }
                else
                {
                    MessageBox.Show("Error Opening Arsenal");
                }
            }
            else
            {
                MessageBox.Show("Error Opening Arsenal");
            }
        }
        private void PbxCloseArsenal(object sender, EventArgs e)
        {
            PbxFormsCloseEventeArgs pbxFormsCloseEventeArgs = e as PbxFormsCloseEventeArgs;
            if (pbxFormsCloseEventeArgs != null)
            {
                if (pbxFormsCloseEventeArgs.Close == true)
                {
                    this.gameArsenalForms.Close();
                    this.gameArsenalForms = null;
                }
            }
            else
            {
                MessageBox.Show("Error Clouse Arsenal");
            }
        }
        private void PbxOpenStoreOnClick(object sender, EventArgs e)
        {
            PbxFormsOpenEventeArgs pbxFormsOpenEventeArgs = e as PbxFormsOpenEventeArgs;
            if (pbxFormsOpenEventeArgs != null)
            {
                if (pbxFormsOpenEventeArgs.Open == true)
                {
                    Int32 valueWallet = gameProfile.GetEsmeraldPlayer();
                    this.gameStoreForms = new GameStoreForms(PbxCloseStore, this.StoreItem, valueWallet);
                    this.gameStoreForms.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Error Opening Store");
                }
            }
            else
            {
                MessageBox.Show("Error Opening Store");
            }
        }
        private void PbxCloseStore(object sender, EventArgs e)
        {
            PbxFormsCloseEventeArgs pbxFormsCloseEventeArgs = e as PbxFormsCloseEventeArgs;
            if (pbxFormsCloseEventeArgs != null)
            {
                if (pbxFormsCloseEventeArgs.Close == true)
                {
                    this.gameStoreForms.Close();
                    this.gameStoreForms = null;
                }
            }
            else
            {
                MessageBox.Show("Error Clouse Store");
            }
        }
        private void BtnOpenRoomsOnClick(object sender, EventArgs e)
        {
            BtnSelectRoomsEventArgs btnSelectRoomsEventArgs = e as BtnSelectRoomsEventArgs;
            if (btnSelectRoomsEventArgs.Open == true)
            {
                SelectRooms(btnSelectRoomsEventArgs.TypeRooms);
            }
            else
            {
                MessageBox.Show("Error Opening Rooms");
            }
        }
        private void SelectRooms(string Room)
        {
            Boolean x = false;
            switch (Room)
            {
                case "1":
                    this.rooms = Room;
                    x = true;
                    break;
            }
            OpenArsenal(true);
        }
        private void OpenArsenal(Boolean Type)
        {
            string avatar = gameProfile.GetAvatarPlayer();
            this.gameArsenalForms = new GameArsenalForms(Type, avatar, this.ArsenalItem, PbxCloseArsenal);
            this.gameArsenalForms.ShowDialog();
        }
        private void OnReceiveMessage(object sender, EventArgs e) //
        {
            MessageEventArgs messageEventArgs = e as MessageEventArgs;

            int sender_id_tbPlayer, status, idPlayer, receiver_id_tbPlayer;
            string message, dateTime, login;

            if (messageEventArgs != null)
            {
                switch (messageEventArgs.Message.GetInt32("Type"))
                {   //Login
                    case LOGIN_TYPE_RETURN_SUCCESS:
                        this.gameLoginForms.LoginSucess(messageEventArgs);
                        break;
                    case LOGIN_TYPE_RETURN_ERROR:
                        this.gameLoginForms.LoginErro();
                        break;
                    //Novo Player
                    case REGISTER_TYPE_RETURN_SUCCESS:
                        this.gameLoginForms.RegisterSucess();
                        break;

                    case REGISTER_TYPE_RETURN_ERROR:
                        this.gameLoginForms.RegisterErro();
                        break;
                    //Troca de senha 
                    case FORGOT_PASSWORD_TYPE_RETURN_SUCCESS:
                        this.gameForgotPasswordForms.RepleceSucess();
                        break;

                    case FORGOT_PASSWORD_TYPE_RETURN_ERROR:
                        this.gameForgotPasswordForms.RepleceErro();
                        break;

                    //Chat PLayer
                    case MESSAGE_TYPE_READ_NEW_MESSAGE:
                        login = messageEventArgs.Message.GetString("sender");
                        message = messageEventArgs.Message.GetString("message");
                        dateTime = messageEventArgs.Message.GetString("date");
                        receiver_id_tbPlayer = messageEventArgs.Message.GetInt32("receiver_id_tbPlayer");

                        if (this.gameChatPlayerForms != null) { this.gameChatPlayerForms.ReceiverMessage(login, message, dateTime, receiver_id_tbPlayer); }
                        break;

                    case MESSAGE_TYPE_READ_ERRO:
                        if (this.gameChatPlayerForms != null) { MessageBox.Show("Erro ao Carregar msg"); }//altarar
                        break;

                    case MESSAGE_TYPE_SET_PLAYER_ON_LINE_ERRO:
                        if (this.gameChatPlayerForms != null) { this.gameChatPlayerForms.ReceiverOline(false); }
                        break;

                    case MESSAGE_TYPE_SET_PLAYER_ON_LINE_SUCCESS:
                        if (this.gameChatPlayerForms != null) { this.gameChatPlayerForms.ReceiverOline(true); }
                        break;

                    case MESSAGE_TYPE_GET_CONTACTS_SUCCESS:
                        sender_id_tbPlayer = messageEventArgs.Message.GetInt32("idPlayer");
                        login = messageEventArgs.Message.GetString("login");
                        status = messageEventArgs.Message.GetInt32("status");
                        if (status == 1)
                        {
                            if (this.gameChatPlayerForms != null) { this.gameChatPlayerForms.InsertDatagrid(sender_id_tbPlayer, login, "OnLine"); }
                        }
                        else
                        {
                            if (this.gameChatPlayerForms != null) { this.gameChatPlayerForms.InsertDatagrid(sender_id_tbPlayer, login, "OffLine"); }
                        }

                        break;

                    case MESSAGE_TYPE_GET_CONTACTS_ERRO:
                        if (this.gameChatPlayerForms != null) { this.gameChatPlayerForms.InsertDatagrid(0, "login does not exist", "OffLine"); }
                        break;

                    case MESSAGE_TYPE_SEVER:
                        message = messageEventArgs.Message.GetString("message");
                        if (this.gameChatPlayerForms != null) { this.gameChatPlayerForms.SetMessageServer(message); }
                        break;

                    case MESSAGE_TYPE_NEW_MESSAGE_ONLINE:
                        login = messageEventArgs.Message.GetString("loginSender");
                        sender_id_tbPlayer = messageEventArgs.Message.GetInt32("sender_id_tbPlayer");
                        message = messageEventArgs.Message.GetString("messageMessage");
                        dateTime = messageEventArgs.Message.GetString("date");

                        if (this.gameChatPlayerForms != null) { this.gameChatPlayerForms.ReceiverMessage(login, message, dateTime, sender_id_tbPlayer); }
                        break;

                    case MESSAGE_TYPE_GET_SEARCH_PLAYER_ERRO:
                        if (this.gameChatPlayerForms != null) { this.gameChatPlayerForms.ResultGetErro("login does not exist"); }
                        break;

                    case MESSAGE_TYPE_GET_SEARCH_PLAYER_SUCCESS:
                        sender_id_tbPlayer = messageEventArgs.Message.GetInt32("idPlayer");
                        login = messageEventArgs.Message.GetString("loginPlayer");
                        status = messageEventArgs.Message.GetInt32("OffOnPlayer");
                        if (status == 1)
                        {
                            if (this.gameChatPlayerForms != null) { this.gameChatPlayerForms.ResulteGetSearch(sender_id_tbPlayer, login, "OnLine"); }
                        }
                        else
                        {
                            if (this.gameChatPlayerForms != null) { this.gameChatPlayerForms.ResulteGetSearch(sender_id_tbPlayer, login, "OffLine"); }
                        }
                        break;

                    case MESSAGE_TYPE_GET_MESSAGE_BOX_SUCCESS:
                        sender_id_tbPlayer = messageEventArgs.Message.GetInt32("idPlayer");
                        login = messageEventArgs.Message.GetString("loginPlayer");
                        status = messageEventArgs.Message.GetInt32("OffOnPlayer");
                        if (status == 1)
                        {
                            if (this.gameChatPlayerForms != null) { this.gameChatPlayerForms.AddNewContactMessageBox(sender_id_tbPlayer, login, "OnLine"); }
                        }
                        else
                        {
                            if (this.gameChatPlayerForms != null) { this.gameChatPlayerForms.AddNewContactMessageBox(sender_id_tbPlayer, login, "OffLine"); }
                        }
                        break;

                    case STORE_TYPE_GET_ITEM_SUCCESS:
                        SetItemStore(messageEventArgs);
                        break;
                    case STORE_TYPE_GET_ITEM_ERRO:
                        MessageBox.Show("Unable to load store items", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    case ARSENAL_TYPE_GET_ITEM_SUCCESS:
                        SetItemArsenal(messageEventArgs);
                        break;
                    case ARSENAL_TYPE_GET_ITEM_ERRO:
                        MessageBox.Show("Unable to load arsenal items", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;

                }
            }
        }
    }
}



