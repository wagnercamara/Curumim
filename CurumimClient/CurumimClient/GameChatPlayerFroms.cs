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
        Dictionary<int, dynamic> ListCotacts = new Dictionary<int, dynamic>();

        MoveForms moveForms = new MoveForms();

        private GameProfileClasse profileClasse;
        private EventHandler loadContactsOnLoad;
        private EventHandler sendMensage;
        private EventHandler closeChat;
        private EventHandler GetMessageOnLoad;

        private ImageClass ImageClass;
        private int sender_id_tbPlayer { get; set; }
        private int receiver_id_tbPlayer = 0;
        private string name_receiver { get; set; }
        private String dateTimeMessage { get; set; }
        private string myPlayer { get; set; }

        private Boolean openMenuChat = true;

        private bool offline = true;
        public GameChatPlayerFroms(GameProfileClasse gameProfileClasse, EventHandler closeChat, EventHandler MessageSendMessageOnClik, EventHandler loadContactsOnLoad, EventHandler GetMessageOnLoad)
        {
            InitializeComponent();
            this.loadContactsOnLoad = loadContactsOnLoad;
            this.profileClasse = gameProfileClasse;
            this.sendMensage = MessageSendMessageOnClik;
            this.closeChat = closeChat;
            this.GetMessageOnLoad = GetMessageOnLoad;
            this.myPlayer = this.profileClasse.GetLoginPlayer();
            this.sender_id_tbPlayer = this.profileClasse.GetIdPlayer();
        }
        private delegate void SideOfTheTextDelegate(string texto, string Send, string dateTime);
        private delegate void ReceiverMessageDelegate(string sender, string message, string date, int receiver);
        private delegate void InsertDatagridDelegate(int IdReceiver, string loginPlayer, string status);
        private delegate void ReceiverOlineDelegate(Boolean Oline);
        private delegate void SetMessageServerDelegate(string message);

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

        //private void txtSearch_Enter(object sender, EventArgs e)
        //{
        //    if (txtSearch.Text == "Search by Login")
        //    {
        //        txtSearch.Text = "";
        //        txtSearch.ForeColor = Color.Black;
        //        txtSearch.BorderStyle = BorderStyle.FixedSingle;
        //        txtSearch.BackColor = Color.LightGray;
        //    }
        //}

        //private void txtSearch_Leave(object sender, EventArgs e)
        //{
        //    if (txtSearch.Text.Trim() == "")
        //    {
        //        txtSearch.Text = "";
        //        txtSearch.ForeColor = Color.Silver;
        //        txtSearch.BorderStyle = BorderStyle.None;
        //        txtSearch.BackColor = Color.Gray;
        //    }
        //}
        private void btnReceiver2_Click(object sender, EventArgs e)
        {
            if (DatagrSelectReceiver() == true)
            {
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

                this.name_receiver = $">  {Convert.ToString(line.Cells["loginPlayer"].Value)}";
                this.receiver_id_tbPlayer = Convert.ToInt32(line.Cells["IdReceiver"].Value);
                string status = Convert.ToString(line.Cells["status"].Value);

                Status(this.lblStatus,status);

                this.lblStatus.Visible = true;
                this.lblNameReceiver.Visible = true;

                this.lblNameReceiver.Text = this.name_receiver;
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


                this.dateTimeMessage = time.ToString(format) ;

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
        private void pbxLeft_Click(object sender, EventArgs e)
        {
            if (this.offline == false)
            {
                LoadDatagrid();
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
            this.pbxClosePnl.Visible = false;
            this.dgvListConversaIniciada.Visible = false;
            FunctionPnl(this.openMenuChat, true, 51, 305, this.pnlLeft);
            this.openMenuChat = true;
            this.pbxLeft.Visible = true;
            this.lblServer.Visible = true;
        }
        private void PainelOpen()
        {
            this.pbxLeft.Visible = false;
            FunctionPnl(this.openMenuChat, true, 51, 307, this.pnlLeft);
            this.openMenuChat = false;
            this.pbxClosePnl.Visible = true;
            this.dgvListConversaIniciada.Visible = true;
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
            this.pbxSend.Visible = visible;
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
                        Status(this.lblStatus,status);
                    }
                    if(this.ListCotacts.ContainsKey(IdReceiver) == false)
                    {
                        this.ListCotacts.Add(IdReceiver, new { status, loginPlayer });
                    }
                    else
                    {
                        this.ListCotacts.Remove(IdReceiver);
                        this.ListCotacts.Add(IdReceiver, new { status, loginPlayer });
                    }
                    
                }
            }

        }
        private void LoadDatagrid()
        {
            dynamic d = null;
            int idReceiver;
            string status = "";
            string loginPlayer = "";


            this.dgvListConversaIniciada.Rows.Clear();

            for (int i = 0; i < this.ListCotacts.Count; i++)
            {
                idReceiver = GetID(i);
                d = GetDynamic(i);
                status = d.status;
                loginPlayer = d.loginPlayer;

                this.dgvListConversaIniciada.Rows.Add(idReceiver, status, loginPlayer);
            }

        }
        private dynamic GetDynamic(int index)
        {

            ICollection valorColecao = ListCotacts.Values;
            dynamic[] mValores = new dynamic[ListCotacts.Count];
            valorColecao.CopyTo(mValores, 0);

            return mValores[index];
        }
        private int GetID(int index)
        {
            ICollection chaveColecao = ListCotacts.Keys;
            int[] mChaves = new int[ListCotacts.Count];
            chaveColecao.CopyTo(mChaves, 0);

            return mChaves[index];
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
        public void ReceiverMessage(string sender, string message, string date, int receiver)
        {

            if (this.InvokeRequired == true)
            {
                this.Invoke(new ReceiverMessageDelegate(ReceiverMessage), new object[] { sender, message, date , receiver});
            }
            else
            {
                if (receiver == this.receiver_id_tbPlayer)
                {
                    SideOfTheText(message, sender, date);
                }
                else
                {
                    //fazer algo aqui para mostrar que tem msg de outro cliente.
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

    }
}
