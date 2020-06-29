using Base;
using CurumimClient;
using CurumimClient.BtnEventArgs;
using CurumimClient.Classe;
using CurumimClient.EventArgsForms;
using CurumimClient.pbxEventArgs;
using CurumimClient.PbxEventArgs;
using CurumimGameForms.BtnEventArgs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        //BuyStore
        private const int STORE_TYPE_SET_BUY = 34;
        private const int STORE_TYPE_SET_BUY_SUCCESS = 35;
        private const int STORE_TYPE_SET_BUY_ERRO = 36;
        //
        private const int PLAYER_TYPE_GET_POSITION = 37;
        private const int PLAYER_TYPE_GET_POSITION_SUCCESS = 38;
        private const int PLAYER_TYPE_GET_POSITION_ERRO = 39;
        //
        private const int PROGRESSBAR_TYPE_NEXT = 40;
        //chat Battle
        private const int NEW_MESSAGE_CHAT_BATTLE = 41;
        private const int NEW_MESSAGE_CHAT_BATTLE_SUCESS = 42;
        private const int NEW_MESSAGE_CHAT_BATTLE_ERRO = 43;
        //ChatGlobal_RankingJogadores.
        private const int GET_INFO_GAME = 44;
        private const int GET_INFO_GAME_SUCESS = 45;
        private const int GET_INFO_GAME_ERRO = 46;
        private const int SET_MESSAGE_GLOBAL = 47;







        ///taylor
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


        //Froms
        GameLoginForms gameLoginForms = null;
        GameForgotPasswordForms gameForgotPasswordForms = null;
        GameAvatarForms gameAvatarForms = null;
        GameChatPlayerFroms gameChatPlayerForms = null;
        GamePlayerForms gamePlayerForms = null;
        GameProfileForms gameProfileForms = null;
        GameRoomsForms gameRoomsForms = null;
        GameArsenalForms gameArsenalForms = null;
        GameStoreForms gameStoreForms = null;
        GameAboutForms gameAboutForms = null;
        GameLoadForms gameLoadForms = null;
        GameBattleForms gameBattleForms = null;
        GameChatBatlleForms gameChatBatlleForms = null;
        //Classe
        GameProfileClasse gameProfile = null;

        //Atributos
        string rooms = "";
        int contBuy = 0;
        List<dynamic> ListItem = new List<dynamic>();

        //Delegate
        private delegate void LoadDelegate(MessageEventArgs messageEventArgs);
        private delegate void LoadNotParameterDelegate();
        private delegate void UpdateDelegate(Int32 value);
        private delegate void StartBattleDelegate(int[] Left, int[] Right, int typeRoom, int premiumScore, int premiumEsmerald, string loginPlayer1, string loginPlayer2);

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
                this.client = new Client("127.0.0.1", 5000); // trocar a porta depois.
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
                        this.Close();
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

                Int32 idPlayer = messageEventArgs.Message.GetInt32("idPlayer");//
                Int32 punctuationPlayer = messageEventArgs.Message.GetInt32("punctuationPlayer");//
                Int32 victoryPlayer = messageEventArgs.Message.GetInt32("victoryPlayer");//
                Int32 totalBatllesPlayer = messageEventArgs.Message.GetInt32("totalBatllesPlayer");//
                Int32 esmeraldPlayer = messageEventArgs.Message.GetInt32("esmeraldPlayer");//

                gameProfile = new GameProfileClasse(idPlayer, fullNamePlayer, loginPlayer, avatarPlayer);

                gameProfile.SetPunctuationPlayer(punctuationPlayer);
                gameProfile.SetVictoryPlayer(victoryPlayer);
                gameProfile.SetTotalBatllesPlayer(totalBatllesPlayer);
                gameProfile.SetEsmeraldPlayer(esmeraldPlayer);
                GetItemArsenal();

                CreatGamePlayer();
            }

        }
        private void SetEmeralPlayer(int ValueWallet)
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new UpdateDelegate(SetEmeralPlayer), new object[] { ValueWallet });
            }
            else
            {
                gameProfile.SetEsmeraldPlayer(ValueWallet);
                MessageBox.Show("Purchase completed successfully", "Congratulations");
            }
        }
        private void GetPlayerPosition(int position)
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new UpdateDelegate(GetPlayerPosition), new object[] { position });
            }
            else
            {
                gameProfile.SetRankingPlayer(position);
                this.gameProfileForms = new GameProfileForms(this.gameProfile, PbxProfileClouseOnClick);
                this.gameProfileForms.ShowDialog();
            }
        }
        private void GetItemStore()
        {
            client.SendMessage(new { Type = STORE_TYPE_GET_ITEM });
        }
        private void SetItemStore(MessageEventArgs messageEventArgs) // CARREGA OS ITENS DO ARSENAL E CHAMA O METODO DE CARREGAR O RAKING E CHATGLOBAL
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
        private void GetInfoGame()//CHAT GLOBAL E RANKING
        {
            client.SendMessage(new { Type = GET_INFO_GAME, Function = "full" });
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
                    GameWeaponsClasse g = this.StoreItem[nameItem];
                    g.SetAmountWeapons(amountArsenal);
                    //this.ArsenalItem.Add(nameItem, g);
                    this.ArsenalItem[nameItem].SetAmountWeapons(amountArsenal);
                }
                //GetInfoGame(); // tirar daki
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
        private Boolean CloseGameCurumim()
        {
            Boolean x = true;
            if (gameChatPlayerForms != null) { x = false; }
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
            gamePlayerForms = new GamePlayerForms(PbxProfileOnClick, PbxChatPlayerOpenOnClick, RoomsOpenOnClick, PbxOpenArsenalOnClick, PbxOpenStoreOnClick, CloseGameOnClick, OpenAboutOnClick,SendMessageOnCLick,GetRankingOnCLick, this.gameProfile.GetLoginPlayer(), this.gameProfile.GetIdPlayer() );
            gamePlayerForms.Show();
        }
        private void GetRankingOnCLick(object sender, EventArgs e)
        {
            PbxFormsOpenEventeArgs pbxFormsOpenEventeArgs = e as PbxFormsOpenEventeArgs;

            if(pbxFormsOpenEventeArgs != null)
            {
                if(pbxFormsOpenEventeArgs.Open == true)
                {
                    client.SendMessage(new {Type = GET_INFO_GAME , Function = "full"});
                }
            }
        }
        private void SendMessageOnCLick(object sender, EventArgs e)
        {
            PbxMessageSendMessageEventArgs pbxMessageSendMessageEventArgs = e as PbxMessageSendMessageEventArgs;
            if (pbxMessageSendMessageEventArgs != null)
            {
                this.client.SendMessage(new
                {
                    Type = SET_MESSAGE_GLOBAL,
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
        private void CloseGameOnClick(object sender, EventArgs e)
        {
            PbxFormsCloseEventeArgs pbxFormsCloseEventeArgs = e as PbxFormsCloseEventeArgs;
            if (pbxFormsCloseEventeArgs != null)
            {
                if (pbxFormsCloseEventeArgs.Close == true)
                {
                    if (CloseGameCurumim() == true)
                    {
                        gamePlayerForms.Close();
                        this.Close();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("It was not possible to close the game with windows open and you need shutters", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Error Clouse GameCurumim");
            }
        }
        private void OpenAboutOnClick(object sender, EventArgs e)
        {
            PbxFormsOpenEventeArgs pbxFormsOpenEventeArgs = e as PbxFormsOpenEventeArgs;
            if (pbxFormsOpenEventeArgs != null)
            {
                if (pbxFormsOpenEventeArgs.Open == true)
                {
                    this.gameAboutForms = new GameAboutForms(CloseAboutOnClick);
                    this.gameAboutForms.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Error Opening About");
            }
        }
        private void CloseAboutOnClick(object sender, EventArgs e)
        {
            PbxFormsCloseEventeArgs pbxFormsCloseEventeArgs = e as PbxFormsCloseEventeArgs;
            if (pbxFormsCloseEventeArgs != null)
            {
                if (pbxFormsCloseEventeArgs.Close == true)
                {
                    this.gameAboutForms.Close();
                    this.gameAboutForms = null;
                }
            }
            else
            {
                MessageBox.Show("Error Close Profile");
            }
        }
        private void PbxProfileOnClick(object sender, EventArgs e) //possição do player no ranking
        {
            PbxFormsOpenEventeArgs pbxFormsOpenEventeArgs = e as PbxFormsOpenEventeArgs;
            if (pbxFormsOpenEventeArgs != null)
            {
                if (pbxFormsOpenEventeArgs.Open == true)
                {
                    this.client.SendMessage(new { Type = PLAYER_TYPE_GET_POSITION, idPlayer = this.gameProfile.GetIdPlayer() });
                }
                else
                {
                    MessageBox.Show("Error Opening Profile");
                }
            }
        }
        private void RoomsOpenOnClick(object sender, EventArgs e)//chama o forms das Salas.
        {
            PbxFormsOpenEventeArgs pbxFormsOpenEventeArgs = e as PbxFormsOpenEventeArgs;
            if (pbxFormsOpenEventeArgs != null)
            {
                if (pbxFormsOpenEventeArgs.Open == true)
                {
                    this.gameRoomsForms = new GameRoomsForms(pbxFormsOpenEventeArgs.Open, this.gameProfile, ClouseRoomsOnClick, InformationRoomLoad);
                    this.gameRoomsForms.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Error Opening Rooms");
            }
        }
        private void InformationRoomLoad(object sender, EventArgs e) //carregar informações da sala (taylor)
        {
            BtnRoomsInformationEventArgs btnRoomsInformationEventArgs = e as BtnRoomsInformationEventArgs;
            if (btnRoomsInformationEventArgs != null)
            {
                int[] values = btnRoomsInformationEventArgs.valuesRoom;

                this.client.SendMessage(new
                {
                    Type = BATTLE_TYPE_ENTERED_BATTLE,
                    loginPlayer = gameProfile.GetLoginPlayer(),
                    typeBattle = values[0],
                    betRoom = values[1]
                });
            }
            else
            {
                MessageBox.Show("Error to Load Battle");
            }
        }
        private void NewMessageChatBattleOnClik(object sender, EventArgs e) //manda a mensagem durante a batalha.
        {
            PbxMessageSendMessageEventArgs pbxMessageSendMessageEventArgs = e as PbxMessageSendMessageEventArgs;
            if (pbxMessageSendMessageEventArgs != null)
            {
                this.client.SendMessage(new
                {
                    Type = NEW_MESSAGE_CHAT_BATTLE,
                    pbxMessageSendMessageEventArgs.messageMessage,
                    loginPlayer = gameProfile.GetLoginPlayer(),
                    loginPlayerEnemy = this.gameBattleForms.GetLoginEnemy()
                }) ;
            }
            else
            {
                MessageBox.Show("Error Send new Message");
            }
        }
        private void ClouseRoomsOnClick(object sender, EventArgs e)// facha o forms das salas
        {
            PbxFormsCloseEventeArgs pbxFormsCloseEventeArgs = e as PbxFormsCloseEventeArgs;
            if (pbxFormsCloseEventeArgs != null)
            {
                if (pbxFormsCloseEventeArgs.Close == true)
                {
                    this.gameRoomsForms.Close();
                    this.gameRoomsForms = null;
                }
            }
            else
            {
                MessageBox.Show("Error Close Rooms");
            }
        }

        private void CloseBattleOnClick(object sender, EventArgs e)// facha o forms da batalha
        {
            PbxFormsCloseEventeArgs pbxFormsCloseEventeArgs = e as PbxFormsCloseEventeArgs;
            if (pbxFormsCloseEventeArgs != null)
            {
                if (pbxFormsCloseEventeArgs.Close == true)
                {
                    this.gameBattleForms.Close();
                    this.gameBattleForms = null;
                    this.gameChatBatlleForms.Close();
                    this.gameChatBatlleForms = null;
                }
            }
            else
            {
                MessageBox.Show("Error Close Battle");
            }
        }

        private void PbxProfileClouseOnClick(object sender, EventArgs e)
        {
            PbxFormsCloseEventeArgs pbxFormsCloseEventeArgs = e as PbxFormsCloseEventeArgs;
            if (pbxFormsCloseEventeArgs != null)
            {
                if (pbxFormsCloseEventeArgs.Close == true)
                {
                    this.gameProfileForms.Close();
                    this.gameProfileForms = null;
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
        private void GetSearchPlayer(object sender, EventArgs e)// Pesquisar por jogadores no jogo
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
        private void GetMessageOnLoad(object sender, EventArgs e)//Carrega as mensagem entre dois jogadores
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
        } //abrir o forms do ARSENAL
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
        }//fechar forms ARSENAL
        private void PbxOpenStoreOnClick(object sender, EventArgs e) // abrir forms STORE
        {
            PbxFormsOpenEventeArgs pbxFormsOpenEventeArgs = e as PbxFormsOpenEventeArgs;
            if (pbxFormsOpenEventeArgs != null)
            {
                if (pbxFormsOpenEventeArgs.Open == true)
                {
                    Int32 valueWallet = gameProfile.GetEsmeraldPlayer();
                    this.gameStoreForms = new GameStoreForms(PbxCloseStore, this.StoreItem, this.gameProfile, BuyItemOnCLick);
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
        private void BuyItemOnCLick(object sender, EventArgs e)
        {
            PbxItemsEventArgs pbxBuyItemCartEventArgs = e as PbxItemsEventArgs;
            if (pbxBuyItemCartEventArgs != null)
            {
                this.ListItem = pbxBuyItemCartEventArgs.Items;
                this.gameLoadForms = new GameLoadForms(this.ListItem.Count);
                NextItemBuy();
                this.gameLoadForms.ShowDialog();
            }
            else
            {
                MessageBox.Show("Error Buy Store");
            }
        }
        private void NextItemBuy()
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new LoadNotParameterDelegate(NextItemBuy), new object[] { });
            }
            else
            {
                if (this.contBuy <= this.ListItem.Count - 1)
                {
                    int listSize = this.ListItem.Count;
                    int idPlayer = gameProfile.GetIdPlayer();
                    Int32 id_tbItem = this.ListItem[this.contBuy].id_tbItem;
                    Int32 amountItemPurchase = this.ListItem[this.contBuy].amountItemPurchase;
                    Int32 valueUnitItemPurchase = this.ListItem[this.contBuy].valueUnitItemPurchase;
                    Int32 valueTotalItemPurchase = this.ListItem[this.contBuy].valueTotalItemPurchase;
                    Int32 ValueWallet = this.ListItem[this.contBuy].ValueWallet;

                    client.SendMessage(new
                    {
                        Type = STORE_TYPE_SET_BUY,
                        idPlayer,
                        id_tbItem,
                        amountItemPurchase,
                        valueUnitItemPurchase,
                        valueTotalItemPurchase,
                        ValueWallet,
                        listSize
                    });
                }
            }
        }
        private void ClosePogressBar()
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new LoadNotParameterDelegate(ClosePogressBar), new object[] { });
            }
            else
            {
                this.gameLoadForms.Close();
                this.contBuy = 0;
                this.ListItem.Clear();
                this.gameLoadForms = null;
            }
        }
        private void PbxCloseStore(object sender, EventArgs e)//fechar forms Loja
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
            OpenArsenal(x);
        }

        private void StartBattle(object sender, EventArgs e)
        {
            PbxStartBattleEventArgs pbxStartBattleEventArgs = e as PbxStartBattleEventArgs;
            if (pbxStartBattleEventArgs != null)
            {
                this.gameBattleForms.SetWeaponsBattle(pbxStartBattleEventArgs.battleList);
                this.gameArsenalForms.Close();
                this.gameArsenalForms = null;
                this.gameBattleForms.Show();
                this.gameChatBatlleForms.Show();
                this.gameChatBatlleForms.Visible = false;
            }
            else
            {
                MessageBox.Show("Error Start Battle");
            }
        }

        private void OpenBattle(int[] Left, int[] Right, int typeRoom, int premiumScore, int premiumEsmerald, string loginPlayer1, string loginPlayer2)
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new StartBattleDelegate(OpenBattle), new object[] { Left, Right, typeRoom, premiumScore, premiumEsmerald, loginPlayer1, loginPlayer2 });
            }
            else
            {
                if (typeRoom != 0)
                {
                    this.gameChatBatlleForms = new GameChatBatlleForms(NewMessageChatBattleOnClik, this.gameProfile.GetLoginPlayer());
                    this.gameBattleForms = new GameBattleForms(typeRoom, Right, Left, loginPlayer1, loginPlayer2, CloseBattleOnClick, OnDestroyedButton, this.gameChatBatlleForms, SyncLocalIndian);
                    this.gameBattleForms.SetSideField(gameProfile.GetLoginPlayer());
                    this.gameBattleForms.SetPremiumBattle(premiumEsmerald, premiumScore);
                    OpenArsenal(true);
                }
                else
                {
                    this.gameChatBatlleForms = new GameChatBatlleForms(NewMessageChatBattleOnClik, this.gameProfile.GetLoginPlayer());
                    this.gameBattleForms = new GameBattleForms(typeRoom, Right, Left, loginPlayer1, loginPlayer2, CloseBattleOnClick, OnDestroyedButton, this.gameChatBatlleForms, SyncLocalIndian);
                    this.gameBattleForms.SetSideField(gameProfile.GetLoginPlayer());
                    this.gameBattleForms.Show();
                }
            }
        }
        private void OpenArsenal(Boolean Type)
        {
            string avatar = gameProfile.GetAvatarPlayer();
            this.gameArsenalForms = new GameArsenalForms(Type, avatar, this.ArsenalItem, PbxCloseArsenal, StartBattle);
            this.gameArsenalForms.ShowDialog();
        }

        private void DestroyedButton(int[] locals, int typeItem )
        {
            this.gameBattleForms.DestroyedButton(locals, true, typeItem);
        }
        private void SyncEnemyIndianLocal(int newLocal, int oldLocal)
        {
            this.gameBattleForms.SyncIndianLocal(newLocal, oldLocal);
        }

        private void OnDestroyedButton(object sender, EventArgs e)
        {
            BtnDestroyedsEventArgs btnDestryedEventArgs = e as BtnDestroyedsEventArgs;
            if (btnDestryedEventArgs != null)
            {
                int[] locals = btnDestryedEventArgs.locals;

                this.client.SendMessage(new
                {
                    Type = BATTLE_TYPE_SET_DESTROYED_SIDE,
                    locals,
                    loginPlayer = btnDestryedEventArgs.loginPlayer,
                    typeItem = btnDestryedEventArgs.typeItem
                });
            }
            else
            {
                MessageBox.Show("Error to Load Attack");
            }
        }

        private void SyncLocalIndian(object sender, EventArgs e)
        {
            SyncLocalIndianEventArgs syncLocalIndianEventArgs = e as SyncLocalIndianEventArgs;
            if (syncLocalIndianEventArgs != null)
            {
                this.client.SendMessage(new
                {
                    Type = BATTLE_TYPE_SYNC_LOCAL_INDIAN,
                    newLocal = syncLocalIndianEventArgs.newLocal,
                    loginPlayer = syncLocalIndianEventArgs.loginPlayer,
                    oldLocal = syncLocalIndianEventArgs.oldLocal
            });
            }
            else
            {
                MessageBox.Show("Error to Load Sync Local Indian");
            }
        }

        private void WaitingOpponent()
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new LoadNotParameterDelegate(WaitingOpponent), new object[] { });
            }
            else
            {
                MessageBox.Show("Waiting for next opponent...");
            }
        }
        protected override void OnClosing(CancelEventArgs e) => Close();
        private void OnReceiveMessage(object sender, EventArgs e) // receiver
        {
            MessageEventArgs messageEventArgs = e as MessageEventArgs;

            int sender_id_tbPlayer, status, receiver_id_tbPlayer, position;
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
                    case STORE_TYPE_SET_BUY_SUCCESS:
                        this.contBuy++;
                        this.gameLoadForms.SetValueProgessBar(this.contBuy);
                        ClosePogressBar();
                        this.gameStoreForms.BuySucess();
                        break;
                    case STORE_TYPE_SET_BUY_ERRO:
                        MessageBox.Show("Unable to load items buy", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ClosePogressBar();
                        break;
                    case PROGRESSBAR_TYPE_NEXT:
                        this.contBuy++;
                        this.gameLoadForms.SetValueProgessBar(this.contBuy);
                        NextItemBuy();
                        break;
                    case PLAYER_TYPE_GET_POSITION_SUCCESS:
                        position = messageEventArgs.Message.GetInt32("position");
                        GetPlayerPosition(position);
                        break;
                    case PLAYER_TYPE_GET_POSITION_ERRO:
                        MessageBox.Show("Unable to load position", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    case BATTLE_TYPE_GET_FIELDS:
                        int[] left = messageEventArgs.Message.GetSingleDimArrayInt32("fieldLeft");
                        int[] right = messageEventArgs.Message.GetSingleDimArrayInt32("fieldRight");
                        int premiumEsmerald = messageEventArgs.Message.GetInt32("premiumEsmerald");
                        int premiumScore = messageEventArgs.Message.GetInt32("premiumScore");
                        string loginPlayer1 = messageEventArgs.Message.GetString("loginPlayer1");
                        string loginPlayer2 = messageEventArgs.Message.GetString("loginPlayer2");
                        int typeRoom = messageEventArgs.Message.GetInt32("typeRoom");
                        OpenBattle(left, right, typeRoom, premiumScore, premiumEsmerald, loginPlayer1, loginPlayer2);
                        break;
                    case BATTLE_TYPE_ENTERED_BATTLE_SUCCESS:
                        WaitingOpponent();
                        break;
                    case BATTLE_TYPE_SET_DESTROYED_SIDE_SUCECSS:
                        int[] locals = messageEventArgs.Message.GetSingleDimArrayInt32("locals");
                        int typeItem = messageEventArgs.Message.GetInt32("typeItem");
                        this.DestroyedButton(locals, typeItem);
                        break;
                    case BATTLE_TYPE_SYNC_LOCAL_INDIAN_SUCCESS:
                        int oldLocal = messageEventArgs.Message.GetInt32("oldLocal");
                        int newLocal = messageEventArgs.Message.GetInt32("newLocal");
                        this.SyncEnemyIndianLocal(newLocal, oldLocal);
                        break;
                    case NEW_MESSAGE_CHAT_BATTLE_SUCESS:
                        message = messageEventArgs.Message.GetString("messageMessage");
                        this.gameChatBatlleForms.NewMessagem(message, 2);
                        break;
                    case NEW_MESSAGE_CHAT_BATTLE_ERRO:
                        MessageBox.Show("Message cannot be delivered", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    case GET_INFO_GAME_SUCESS:
                        string Function = messageEventArgs.Message.GetString("Function");

                        if (Function == "message")
                        {
                            login = messageEventArgs.Message.GetString("sender");
                            message = messageEventArgs.Message.GetString("message");
                            dateTime = messageEventArgs.Message.GetString("date");
                            this.gamePlayerForms.NewMessage(login,message, dateTime);
                        }
                        else if (Function == "ranking")
                        {
                            string infomation = messageEventArgs.Message.GetString("infomation");
                            this.gamePlayerForms.LoadRankig(infomation);
                        }
                        break;
                    case GET_INFO_GAME_ERRO:
                        MessageBox.Show("Could not load game information.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }
            }
        }
    }
}



