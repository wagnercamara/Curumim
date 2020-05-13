using Base;
using CurumimClient.BtnEventArgs;
using CurumimClient.Classe;
using CurumimClient.EventArgsForms;
using CurumimClient.PbxEventArgs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CurumimGameForms
{
    public partial class GameChatPlayerFroms : Form
    {
        Dictionary<int, dynamic> listCotacts = new Dictionary<int, dynamic>();
        Dictionary<int, dynamic> messageBox = new Dictionary<int, dynamic>();

        MoveForms moveForms = new MoveForms();

        private GameProfileClasse profileClasse;
        private EventHandler loadContactsOnLoad;
        private EventHandler sendMensage;
        private EventHandler closeChat;
        private EventHandler GetMessageOnLoad;
        private EventHandler GetSearchPlayer;

        private ImageClass ImageClass;
        private int sender_id_tbPlayer { get; set; }
        private int receiver_id_tbPlayer = 0;
        private string name_receiver { get; set; }
        private String dateTimeMessage { get; set; }
        private string myPlayer { get; set; }

        private Boolean openMenuChat = true;

        private bool offline = true;
        private bool boxMessage;
        public GameChatPlayerFroms(GameProfileClasse gameProfileClasse, EventHandler closeChat, EventHandler MessageSendMessageOnClik, EventHandler loadContactsOnLoad, EventHandler GetMessageOnLoad, EventHandler GetSearchPlayer)
        {
            InitializeComponent();
            this.loadContactsOnLoad = loadContactsOnLoad;
            this.profileClasse = gameProfileClasse;
            this.sendMensage = MessageSendMessageOnClik;
            this.closeChat = closeChat;
            this.GetMessageOnLoad = GetMessageOnLoad;
            this.GetSearchPlayer = GetSearchPlayer;
            this.myPlayer = this.profileClasse.GetLoginPlayer();
            this.sender_id_tbPlayer = this.profileClasse.GetIdPlayer();
        }
        private delegate void SideOfTheTextDelegate(string texto, string Send, string dateTime);
        private delegate void ReceiverMessageDelegate(string sender, string message, string date, int receiver);
        private delegate void InsertDatagridDelegate(int IdReceiver, string loginPlayer, string status);
        private delegate void ReceiverOlineDelegate(Boolean Oline);
        private delegate void SetMessageServerDelegate(string message);
        private delegate void LoadDatagridDelegate(Dictionary<int, dynamic> dictionary);

        private void GameChatPlayerFroms_Load(object sender, EventArgs e)
        {
            this.loadContactsOnLoad.Invoke(this, new LoadContactsEventArgs() { loadContacts = false });
            this.ImageClass = new ImageClass();
            DataGridRows();
        }
        private void pnlUp_MouseMove(object sender, MouseEventArgs e)
        {
            moveForms.Move(this.Handle);
        }
        private void btnReceiver2_Click(object sender, EventArgs e)
        {
            if (DatagrSelectReceiver() == true)
            {
                this.rbxHitory.Clear();
                this.GetMessageOnLoad.Invoke(this, new BtnGetMessagePlayerChatEventArgs() { idSender = this.sender_id_tbPlayer, idReceiver = this.receiver_id_tbPlayer });
            }
        }
        private void DataGridRows()
        {
            this.dgvListConversaIniciada.Columns.Add("IdReceiver", "IdReceiver");
            this.dgvListConversaIniciada.Columns[0].Visible = false;

            this.dgvListConversaIniciada.Columns.Add("status", "Status");
            this.dgvListConversaIniciada.Columns[1].Width = 100;
            this.dgvListConversaIniciada.Columns[1].Resizable = DataGridViewTriState.False;

            this.dgvListConversaIniciada.Columns.Add("loginPlayer", "Players");
            this.dgvListConversaIniciada.Columns[2].Width = 150;
            this.dgvListConversaIniciada.Columns[2].Resizable = DataGridViewTriState.False;
        }
        private Boolean DatagrSelectReceiver()
        {
            if (this.dgvListConversaIniciada.SelectedRows.Count > 0)
            {
                DataGridViewRow line = this.dgvListConversaIniciada.SelectedRows[0];


                string loginPlayer = Convert.ToString(line.Cells["loginPlayer"].Value);
                int IdReceiver = Convert.ToInt32(line.Cells["IdReceiver"].Value);
                string status = Convert.ToString(line.Cells["status"].Value);

                this.name_receiver = $">>{loginPlayer}";
                this.receiver_id_tbPlayer = IdReceiver;

                Status(this.lblStatus, status);

                this.lblStatus.Visible = true;
                this.lblNameReceiver.Visible = true;

                this.lblNameReceiver.Text = this.name_receiver;
                if (this.boxMessage == true) { messageBox.Remove(this.receiver_id_tbPlayer); }

                if (this.listCotacts.ContainsKey(receiver_id_tbPlayer) == false)
                {
                    this.listCotacts.Add(IdReceiver, (new { status, loginPlayer }));
                }

                PainelCLose();
                return true;
            }
            else
            {
                MessageBox.Show("Not line select");
                return false;
            }
        }
        private void pbxClouse_Click(object sender, EventArgs e)
        {
            this.closeChat.Invoke(this, new PbxFormsCloseEventeArgs() { Close = true });
            this.Close();
        }
        private void pbxSend_Click(object sender, EventArgs e)
        {
            if (receiver_id_tbPlayer != 0)
            {
                this.lblServer.Text = "";
                DateTime time = DateTime.Now;
                string format = "yyyy/MM/dd HH:mm:ss";


                this.dateTimeMessage = time.ToString(format);

                this.sendMensage.Invoke(this, new PbxMessageSendMessageEventArgs()
                {
                    sender_id_tbPlayer = this.sender_id_tbPlayer,
                    receiver_id_tbPlayer = this.receiver_id_tbPlayer,
                    messageMessage = this.rbxMessage.Text,
                    name_Sender = this.myPlayer
                });

                SideOfTheText(this.rbxMessage.Text, this.profileClasse.GetLoginPlayer(), this.dateTimeMessage);
                this.rbxMessage.Clear();
            }
            else
            {
                MessageBox.Show("You need to select the receiver");
            }

        }
        private void SideOfTheText(string texto, string Send, string dateTime)
        {

            if (myPlayer == Send)
            {
                this.rbxHitory.SelectionColor = Color.Blue;
                this.rbxHitory.SelectionFont = new Font("Arial", 5);
                this.rbxHitory.AppendText(Environment.NewLine + $":{Send}");
                this.rbxHitory.SelectionAlignment = HorizontalAlignment.Right;
                this.rbxHitory.SelectionFont = new Font("Segoe Print", 12);
                this.rbxHitory.AppendText(Environment.NewLine + $"{texto} <");
                this.rbxHitory.SelectionAlignment = HorizontalAlignment.Right;
                this.rbxHitory.SelectionFont = new Font("Arial", 5);
                this.rbxHitory.AppendText(Environment.NewLine + $"{dateTime}:");
                this.rbxHitory.SelectionAlignment = HorizontalAlignment.Right;

            }
            else
            {
                this.rbxHitory.SelectionColor = Color.Green;
                this.rbxHitory.SelectionFont = new Font("Arial", 5);
                this.rbxHitory.AppendText(Environment.NewLine + $":{Send}");
                this.rbxHitory.SelectionAlignment = HorizontalAlignment.Right;
                this.rbxHitory.SelectionFont = new Font("Segoe Print", 12);
                this.rbxHitory.AppendText(Environment.NewLine + $"{texto} <");
                this.rbxHitory.SelectionAlignment = HorizontalAlignment.Right;
                this.rbxHitory.SelectionFont = new Font("Arial", 5);
                this.rbxHitory.AppendText(Environment.NewLine + $"{dateTime}:");
                this.rbxHitory.SelectionAlignment = HorizontalAlignment.Right;
            }
        }
        private void pbxLeft_Click(object sender, EventArgs e)
        {
            if (this.offline == false)
            {
                this.boxMessage = false;
                LoadDatagrid(listCotacts);
                PainelOpen();
            }
            else
            {
                this.loadContactsOnLoad.Invoke(this, new LoadContactsEventArgs() { loadContacts = false });
            }

        }
        private void pbxClosePnl_Click(object sender, EventArgs e)
        {
            PainelCLose();
        }
        private void PainelCLose()
        {
            this.txtSearch.Visible = false;
            this.btnSearch.Enabled = false;
            this.btnSearch.Visible = false;
            this.lblErroSearch.Visible = false;

            this.pbxClosePnl.Visible = false;
            this.dgvListConversaIniciada.Visible = false;
            FunctionPnl(this.openMenuChat, true, 51, 305, this.pnlLeft);
            this.openMenuChat = true;
            this.pbxLeft.Visible = true;
            this.lblServer.Visible = true;

            if (messageBox.Count <= 0)
            {
                this.pbxCaixaMessage.Visible = false;
            }
        }
        private void PainelOpen()
        {
            this.pbxLeft.Visible = false;
            FunctionPnl(this.openMenuChat, true, 51, 307, this.pnlLeft);
            this.openMenuChat = false;
            this.pbxClosePnl.Visible = true;
            this.dgvListConversaIniciada.Visible = true;

            this.txtSearch.Visible = true;
            this.btnSearch.Enabled = true;
            this.btnSearch.Visible = true;
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
        }
        private void Status(Label label, string status)
        {
            if (status == "OnLine")
            {
                label.Text = status;
                label.ForeColor = Color.DarkGreen;
            }
            else
            {
                label.Text = status;
                label.ForeColor = Color.DarkRed;
            }
        }
        private void MessageVisible(Boolean visible)
        {
            this.rbxHitory.Visible = visible;
            this.rbxMessage.Visible = visible;
            this.lblServer.Visible = visible;
        }
        private void rbxMessage_TextChanged(object sender, EventArgs e)
        {
            if (rbxMessage.Text.Trim() != "")
            {
                lblServer.Text = "";
                pbxSend.Visible = true;
            }
            else
            {
                pbxSend.Visible = false;
            }
        }
        public void InsertDatagrid(int IdReceiver, string loginPlayer, string status)
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new InsertDatagridDelegate(InsertDatagrid), new object[] { IdReceiver, loginPlayer, status });
            }
            else
            {
                if (IdReceiver != this.sender_id_tbPlayer)
                {
                    if (IdReceiver == this.receiver_id_tbPlayer)
                    {
                        Status(this.lblStatus, status);
                    }
                    if (this.listCotacts.ContainsKey(IdReceiver) == false)
                    {
                        this.listCotacts.Add(IdReceiver, new { status, loginPlayer });
                    }
                    else
                    {
                        this.listCotacts.Remove(IdReceiver);
                        this.listCotacts.Add(IdReceiver, new { status, loginPlayer });
                    }

                }
            }

        }
        private void LoadDatagrid(Dictionary<int, dynamic> dictionary)
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new LoadDatagridDelegate(LoadDatagrid), new object[] { dictionary });

            }
            else
            {
                dynamic d = null;
                int idReceiver;
                string status = "";
                string loginPlayer = "";

                this.dgvListConversaIniciada.Rows.Clear();

                foreach (KeyValuePair<int, dynamic> p in dictionary)
                {
                    idReceiver = p.Key;
                    d = p.Value;
                    status = d.status;
                    loginPlayer = d.loginPlayer;
                    Console.WriteLine("{0} = {1}", p.Key, p.Value);

                    this.dgvListConversaIniciada.Rows.Add(idReceiver, status, loginPlayer);
                }
            }

        }
        private void AddMessageBox(int idReceiver, string sender)
        {
            if (listCotacts.ContainsKey(idReceiver) == true)
            {
                this.messageBox.Add(idReceiver, listCotacts[idReceiver]);
            }
            else
            {
                this.GetSearchPlayer.Invoke(this, new GetSearchPlayerEventArgs() { typeSearch = true, loginPlayer = sender });
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.lblErroSearch.Visible = false;

            if (this.txtSearch.Text != "")
            {
                this.GetSearchPlayer.Invoke(this, new GetSearchPlayerEventArgs() { typeSearch = false, loginPlayer = this.txtSearch.Text });
                this.txtSearch.Clear();
            }
            else
            {
                MessageBox.Show("The research field is empty");
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
                    pbxClosePnl.Enabled = true;
                    this.offline = false;
                    pbxLeft.Image = this.ImageClass.GetImageGenericIconForms("OlineChat");
                    this.lblSender.Text = profileClasse.GetLoginPlayer();
                    Status(this.lblOnlineSender, "OnLine");
                    this.loadContactsOnLoad.Invoke(this, new LoadContactsEventArgs() { loadContacts = true });
                }
                else
                {
                    pbxClosePnl.Enabled = false;
                    this.offline = true;
                    this.lblSender.Text = profileClasse.GetLoginPlayer();
                    Status(this.lblOnlineSender, "OffLine");
                    pbxLeft.Image = this.ImageClass.GetImageGenericIconForms("OfflineChat");
                }
            }
        }
        public void ReceiverMessage(string sender, string message, string date, int idSender)
        {

            if (this.InvokeRequired == true)
            {
                this.Invoke(new ReceiverMessageDelegate(ReceiverMessage), new object[] { sender, message, date, idSender });
            }
            else
            {
                if (idSender == this.receiver_id_tbPlayer)
                {
                    SideOfTheText(message, sender, date);
                }
                else
                {
                    pbxCaixaMessage.Visible = true;
                    AddMessageBox(idSender, sender);
                }

            }
        }
        public void SetMessageServer(string Message)
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new SetMessageServerDelegate(SetMessageServer), new object[] { Message });
            }
            else
            {
                this.lblServer.Text = Message;
            }
        }
        private void pbxCaixaMessage_Click(object sender, EventArgs e)
        {
            this.boxMessage = true;
            LoadDatagrid(messageBox);
            PainelOpen();
        }
        public void AddNewContactMessageBox(int IdReceiver, string loginPlayer, string status)
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new InsertDatagridDelegate(AddNewContactMessageBox), new object[] { IdReceiver, loginPlayer, status });
            }
            else
            {
                if (this.messageBox.ContainsKey(IdReceiver) == false)
                {
                    this.messageBox.Add(IdReceiver, new { status, loginPlayer });
                }
            }
        }
        public void ResulteGetSearch(int IdReceiver, string loginPlayer, string status)
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new InsertDatagridDelegate(ResulteGetSearch), new object[] { IdReceiver, loginPlayer, status });
            }
            else
            {
                if (this.messageBox.ContainsKey(IdReceiver) == false)
                {
                    this.messageBox.Add(IdReceiver, (new { status, loginPlayer }));
                }
            }
            LoadDatagrid(this.messageBox);
        }
        public void ResultGetErro(string Erro)
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new SetMessageServerDelegate(ResultGetErro), new object[] { Erro });
            }
            else
            {
                this.lblErroSearch.Text = Erro;
                this.lblErroSearch.ForeColor = Color.DarkBlue;
                this.lblErroSearch.Visible = true;
            }
        }
    }
}
