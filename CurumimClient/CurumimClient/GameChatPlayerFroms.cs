using Base;
using CurumimClient.BtnEventArgs;
using CurumimClient.Classe;
using CurumimClient.EventArgsForms;
using CurumimClient.PbxEventArgs;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CurumimGameForms
{
    public partial class GameChatPlayerFroms : Form
    {
        private GameProfileClasse profileClasse;
        private EventHandler MessageOlineLouad;
        private EventHandler sendMensage;
        private EventHandler closeChat;
        private EventHandler off_On;

        private ImageClass ImageClass;
        private int sender_id_tbPlayer { get; set; }
        private int receiver_id_tbPlayer = 0;
        private string name_receiver { get; set; }
        private String dateTimeMessage { get; set; }
        private string myPleyer { get; set; }
        private Boolean openMenuChat = true;

        private bool offline = true;
        public GameChatPlayerFroms(GameProfileClasse gameProfileClasse, EventHandler closeChat, EventHandler off_On, EventHandler MessageSendMessageOnClik, EventHandler MessageOlineLouad)
        {
            InitializeComponent();
            this.MessageOlineLouad = MessageOlineLouad;
            this.profileClasse = gameProfileClasse;
            this.sendMensage = MessageSendMessageOnClik;
            this.closeChat = closeChat;
            this.off_On = off_On;
            this.myPleyer = this.profileClasse.GetLoginPlayer();
            this.sender_id_tbPlayer = this.profileClasse.GetIdPlayer();
        }
        private delegate void SideOfTheTextDelegate(string texto, string Send, string dateTime);
        private delegate void ReceiverMessageDelegate(MessageEventArgs messageEventArgs);
        private delegate void InsertDatagridDelegate(MessageEventArgs messageEventArgs);
        private delegate void ReceiverOlineDelegate(Boolean Oline);

        private void GameChatPlayerFroms_Load(object sender, EventArgs e)
        {
            this.MessageOlineLouad.Invoke(this, new StartMessagemOnLineOrOffLineEventArgs() { MessagemOnLineOrOffLine = true });
            this.ImageClass = new ImageClass();
            DataGridRows();
        }
        private void DataGridRows()
        {
            this.dgvListConversaIniciada.Columns.Add("IdReceiver", "IdReceiver");
            this.dgvListConversaIniciada.Columns[0].Visible = false;

            this.dgvListConversaIniciada.Columns.Add("loginPlayer", "Players");
            this.dgvListConversaIniciada.Columns[1].Width = 200;
            this.dgvListConversaIniciada.Columns[1].Resizable = DataGridViewTriState.False;
        }
        private void btnReceiver2_Click(object sender, EventArgs e)
        {
            DatagrSelectReceiver();
        }
        private void DatagrSelectReceiver()
        {
            if (this.dgvListConversaIniciada.SelectedRows.Count > 0)
            {
                DataGridViewRow line = this.dgvListConversaIniciada.SelectedRows[0];

                this.name_receiver = Convert.ToString(line.Cells["loginPlayer"].Value);
                this.receiver_id_tbPlayer = Convert.ToInt32(line.Cells["IdReceiver"].Value);

                this.lblNameReceiver.Text = this.name_receiver;
            }
            else
            {
                MessageBox.Show("Não a linha selecionadas");
            }
        }
        public void InsertDatagrid(MessageEventArgs messageEventArgs)
        {
            if (messageEventArgs != null)
            {
                if (this.InvokeRequired == true)
                {
                    this.Invoke(new InsertDatagridDelegate(InsertDatagrid), new object[] { messageEventArgs });
                }
                else
                {
                    

                    int IdReceiver = messageEventArgs.Message.GetInt32("idPlayer");
                    if (IdReceiver != this.sender_id_tbPlayer)
                    {
                        string loginPlayer = messageEventArgs.Message.GetString("loginPlayer");
                        this.dgvListConversaIniciada.Rows.Add(IdReceiver, loginPlayer);
                    }
                }
            }

        }
        private void pbxClouse_Click(object sender, EventArgs e)
        {
            this.MessageOlineLouad.Invoke(this, new StartMessagemOnLineOrOffLineEventArgs() { MessagemOnLineOrOffLine = false });
            this.closeChat.Invoke(this, new PbxFormsCloseEventeArgs() { Close = true });
            this.Close();
        }

        private void pbxSend_Click(object sender, EventArgs e)
        {
            if (receiver_id_tbPlayer != 0)
            {
                DateTime dateTime = new DateTime();

                this.dateTimeMessage = dateTime.ToString();

                this.sendMensage.Invoke(this, new PbxMessageSendMessageEventArgs()
                {
                    sender_id_tbPlayer = this.sender_id_tbPlayer,
                    receiver_id_tbPlayer = this.receiver_id_tbPlayer,
                    messageMessage = this.rbxMessage.Text,
                    dateTimeMessage = this.dateTimeMessage
                });

                SideOfTheText(this.rbxMessage.Text, this.profileClasse.GetLoginPlayer(), this.dateTimeMessage);
            }
            else
            {
                MessageBox.Show("Não exite um receiver para está msg");
            }

        }
        public void ReceiverOline(Boolean Oline)
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new ReceiverOlineDelegate(ReceiverOline), new object[] { Oline });
            }
            else
            {
                if (Oline == true)
                {
                    //pbxClosePnl.Enabled = true;
                    this.offline = false;
                    pbxLeft.Image = this.ImageClass.GetImageGenericIconForms("OlineChat");
                }
                else
                {
                    //pbxClosePnl.Enabled = false;
                    this.offline = true;
                    pbxLeft.Image = this.ImageClass.GetImageGenericIconForms("OfflineChat");
                }
            }
        }
        public void ReceiverMessage(MessageEventArgs messageEventArgs)
        {

            if (this.InvokeRequired == true)
            {
                this.Invoke(new ReceiverMessageDelegate(ReceiverMessage), new object[] { messageEventArgs });
            }
            else
            {
                if (messageEventArgs != null)
                {
                    int senderIdPlayer = messageEventArgs.Message.GetInt32("sender_id_tbPlayer");
                    if (senderIdPlayer == this.receiver_id_tbPlayer)
                    {
                        SideOfTheText(messageEventArgs.Message.GetString("messageMessage"), this.name_receiver, messageEventArgs.Message.GetString("dateTimeMessage"));
                    }
                    else
                    {
                        //fazer algo aqui para mostrar que tem msg de outro cliente.
                    }
                }
            }
        }
        private void SideOfTheText(string texto, string Send, string dateTime)
        {

            if (this.InvokeRequired == true)
            {
                this.Invoke(new SideOfTheTextDelegate(SideOfTheText), new object[] { texto, Send });
            }
            else
            {

                if (myPleyer == Send)
                {
                    rbxHitory.SelectionColor = Color.AliceBlue;   // = Color.Blue;
                    rbxHitory.AppendText(Environment.NewLine + $">{texto}:{Send}({dateTime})");
                    rbxHitory.SelectionAlignment = HorizontalAlignment.Right;

                }
                else
                {
                    rbxHitory.SelectionColor = Color.Green;
                    rbxHitory.AppendText(Environment.NewLine + $"({dateTime}){Send}:{texto}");
                    rbxHitory.SelectionAlignment = HorizontalAlignment.Left;
                }
            }
        }
        private void pbxOffline_Click_1(object sender, EventArgs e)
        {
            this.dgvListConversaIniciada.Rows.Clear();
            this.pbxOnline.BorderStyle = BorderStyle.None;
            this.pbxOffline.BorderStyle = BorderStyle.FixedSingle;
            this.off_On.Invoke(this, new BtnMessageOff_On_LineEventArgs() { Off_On_Line = false });
        }

        private void pbxOnline_Click(object sender, EventArgs e)
        {
            this.dgvListConversaIniciada.Rows.Clear();
            this.pbxOnline.BorderStyle = BorderStyle.FixedSingle;
            this.pbxOffline.BorderStyle = BorderStyle.None;
            this.off_On.Invoke(this, new BtnMessageOff_On_LineEventArgs() { Off_On_Line = true });
        }

        private void pbxLeft_Click(object sender, EventArgs e)
        {
            if(offline == true)
            {
                this.MessageOlineLouad.Invoke(this, new StartMessagemOnLineOrOffLineEventArgs() { MessagemOnLineOrOffLine = true });
            }
            else
            {
                this.pbxLeft.Visible = false;
                FunctionPnl(this.openMenuChat, true, 51, 307, this.pnlLeft);
                this.dgvListConversaIniciada.Visible = true;
                this.openMenuChat = false;
                this.pbxClosePnl.Visible = true;
            }
        }
        private void pbxClosePnl_Click(object sender, EventArgs e)
        {
            this.pbxClosePnl.Visible = false;
            FunctionPnl(this.openMenuChat, true, 51, 307, this.pnlLeft);
            this.dgvListConversaIniciada.Visible = false;
            this.openMenuChat = true;
            this.pbxLeft.Visible = true;
        }

        private void FunctionPnl(Boolean OpenForms, Boolean WidtOrHigth, int x, int y, Panel panel)
        {
            switch (WidtOrHigth)
            {
                case true:

                    switch (OpenForms)
                    {
                        case true:
                            MessageVisible(false);
                            for (int i = x; i <= y; i++)
                            {
                                panel.Width = i;
                            }
                            MessageVisible(true);
                            break;
                        case false:
                            MessageVisible(false);
                            for (int i = y; i >= x; i--)
                            {
                                panel.Width = i;
                            }
                            MessageVisible(true);
                            break;
                    }

                    break;
            }
            pbxOffline.BorderStyle = BorderStyle.None;
            pbxOnline.BorderStyle = BorderStyle.None;
        }
        private void MessageVisible(Boolean visible)
        {
            this.rbxHitory.Visible = visible;
            this.rbxMessage.Visible = visible;
        }
        private void rbxMessage_TextChanged(object sender, EventArgs e)
        {
            if (rbxMessage.Text.Trim() != "")
            {
                pbxSend.Visible = true;
            }
            else
            {
                pbxSend.Visible = false;
            }
        }




    }
}
