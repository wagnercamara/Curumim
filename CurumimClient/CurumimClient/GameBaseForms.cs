using Base;
using CurumimClient.BtnEventArgs;
using CurumimClient.EventArgsForms;
using CurumimClient.pbxEventArgs;
using CurumimClient.PbxEventArgs;
using CurumimGameForms.BtnEventArgs;
using System;
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

        //Froms
        GameLoginForms gameLoginForms = null;
        GameForgotPasswordForms gameForgotPasswordForms = null;
        GameAvatarForms gameAvatarForms = null;
        GameChatPlayerFroms gameChatPlayer = null;
        GamePlayerForms gamePlayerForms = null;
        GameProfileForms gameProfileForms = null;

        //Classe
        GameProfileClasse gameProfile = null;

        //Atributos

        //Delegate
        private delegate void LoadClassePlayerDelegate(MessageEventArgs messageEventArgs);
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
                    MessageBox.Show("Servidor está indiponivel", "Verifique sua intenet");
                    controlConneted = true;
                }
                countConnection++;
            }

            if (logon == true)
            {
                this.gameLoginForms = new GameLoginForms(BtnRegisterOnClick, BtnLoginOnClick, BtnLoginRepleceOnClick, SelectAvatarOn, LoginSucessEvent);
                gameLoginForms.ShowDialog();
            }
        }
        private Boolean ConectionServer()
        {
            try
            {
                this.client = new Client("127.0.0.1", 5000);
                this.client.Connect(OnReceiveMessage);
                return true;
            }
            catch
            {
                //MessageBox.Show("Erro de conexão com servidor", "Deseja tentar novamente");
            }
            return false;
        }
        private void LoadClassePlayer(MessageEventArgs messageEventArgs)
        {

            if (this.InvokeRequired == true)
            {
                this.Invoke(new LoadClassePlayerDelegate(LoadClassePlayer), new object[] { messageEventArgs });
            }
            else
            {
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

                CreatGamePlayer();
            }

        }
        private void LoginSucessEvent(object sender, EventArgs e)
        {
            LoginSucessEventArgs loginSucessEventArgs = e as LoginSucessEventArgs;
            if (loginSucessEventArgs.MessageEventArgs != null)
            {
                this.gameLoginForms.Close();
                LoadClassePlayer(loginSucessEventArgs.MessageEventArgs);
            }
        }
        private void CreatGamePlayer()
        {
            gamePlayerForms = new GamePlayerForms(PbxProfileOnClick, PbxChatPlayerOpenOnClick);
            gamePlayerForms.Show();
        }//criação do forms da base de guerra
        private void PbxProfileOnClick(object sender, EventArgs e) // Chama o ptofile do player
        {
            PbxFormsOpenEventeArgs pbxFormsOpenEventeArgs = e as PbxFormsOpenEventeArgs;
            if (pbxFormsOpenEventeArgs != null)
            {
                if (pbxFormsOpenEventeArgs.Open == true)
                {
                    if (this.gameProfileForms != null)
                    {
                        Application.OpenForms["gameProfileForms"].BringToFront(); // traz um forms já criado pra fente novamente.
                    }
                    else
                    {
                        this.gameProfileForms = new GameProfileForms(this.gameProfile, PbxProfileClouseOnClick);
                        this.gameProfileForms.Show();
                    }
                }

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
        }
        private void BtnAvatarSelectOnClick(object sender, EventArgs e) // setar avatar do cliente
        {
            BtnAvatarSelectEventArgs btnAvatarSelectEventArgs = e as BtnAvatarSelectEventArgs;
            if (btnAvatarSelectEventArgs != null)
            {
                this.gameLoginForms.SetAvatar(btnAvatarSelectEventArgs.avatarPlayer);
                this.gameLoginForms.RegisterDB();
            }
        }
        private void PbxChatPlayerOpenOnClick(object sender, EventArgs e) // Chama o chat do player
        {
            PbxFormsOpenEventeArgs pbxFormsOpenEventeArgs = e as PbxFormsOpenEventeArgs;
            if (pbxFormsOpenEventeArgs != null)
            {
                if (pbxFormsOpenEventeArgs.Open == true)
                {

                    if (this.gameChatPlayer != null)
                    {
                        Application.OpenForms["gameChatPlayer"].BringToFront(); // traz um forms já criado pra fente novamente.
                    }
                    else
                    {

                        this.gameChatPlayer = new GameChatPlayerFroms(this.gameProfile, this.PbxChatPlayerClouseOnClick, this.OffOnOnCLick, this.MessageSendMessageOnClik, this.MessageOlineLouad);
                        this.gameChatPlayer.Show();
                        //this.gamePlayerForms.Visible = false;
                    }
                }
            }
        }
        private void MessageOlineLouad(object sender, EventArgs e)
        {
            StartMessagemOnLineOrOffLineEventArgs startMessagemOnLineOrOffLineEventArgs = e as StartMessagemOnLineOrOffLineEventArgs;

            if (startMessagemOnLineOrOffLineEventArgs != null)
            {
                if (startMessagemOnLineOrOffLineEventArgs.MessagemOnLineOrOffLine == true)
                {
                    this.client.SendMessage(new
                    {
                        Type = MESSAGE_TYPE_SET_PLAYER_ON_LINE,
                        idPlayer = gameProfile.GetIdPlayer()
                    });
                }
                else
                {
                    this.client.SendMessage(new
                    {
                        Type = MESSAGE_TYPE_SET_PLAYER_OFF_LINE,
                        idPlayer = gameProfile.GetIdPlayer()
                    });
                }
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
                    pbxMessageSendMessageEventArgs.dateTimeMessage
                });
            }
        }
        private void OffOnOnCLick(object sender, EventArgs e) //manda para o servidor o estatus do cliente.
        {
            BtnMessageOff_On_LineEventArgs messageOff_On_LineEventArgs = e as BtnMessageOff_On_LineEventArgs;
            if (messageOff_On_LineEventArgs != null)
            {
                if (messageOff_On_LineEventArgs.Off_On_Line == true)
                {
                    this.client.SendMessage(new
                    {
                        Type = MESSAGE_TYPE_GET_MESSAGES_ON
                    });
                }
                else
                {
                    this.client.SendMessage(new
                    {
                        Type = MESSAGE_TYPE_GET_MESSAGES_OFF
                    });
                }

            }
        }
        private void PbxChatPlayerClouseOnClick(object sender, EventArgs e) // fecha o chat no servidor.
        {
            PbxFormsCloseEventeArgs pbxFormsCloseEventeArgs = e as PbxFormsCloseEventeArgs;
            if (pbxFormsCloseEventeArgs != null)
            {
                if (pbxFormsCloseEventeArgs.Close == true)
                {
                    this.gameChatPlayer = null;
                    //this.gamePlayerForms.Visible = true;
                }
            }
        }

        private delegate void OnReceiverMessageDelegate(object sender, EventArgs e);
        private void OnReceiveMessage(object sender, EventArgs e) //
        {
            MessageEventArgs messageEventArgs = e as MessageEventArgs;
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
                        if (this.gameChatPlayer != null) { this.gameChatPlayer.ReceiverMessage(messageEventArgs); }
                        break;

                    case MESSAGE_TYPE_READ_ERRO:
                        if (this.gameChatPlayer != null) { MessageBox.Show("Erro ao enviar msg"); }//altarar
                        break;

                    case MESSAGE_TYPE_SET_PLAYER_ON_LINE_ERRO:
                        if (this.gameChatPlayer != null) { this.gameChatPlayer.ReceiverOline(false); }
                        break;

                    case MESSAGE_TYPE_SET_PLAYER_ON_LINE_SUCCESS:
                        if (this.gameChatPlayer != null) { this.gameChatPlayer.ReceiverOline(true); }
                        break;

                    case MESSAGE_TYPE_GET_PLAYER_MESSAGE:
                        if (this.gameChatPlayer != null) { this.gameChatPlayer.InsertDatagrid(messageEventArgs); }
                        break;

                }
            }
        }
    }
}



