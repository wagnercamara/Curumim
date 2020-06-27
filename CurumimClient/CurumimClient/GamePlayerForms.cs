using CurumimClient.Classe;
using CurumimClient.pbxEventArgs;
using CurumimClient.PbxEventArgs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CurumimGameForms
{
    public partial class GamePlayerForms : Form
    {
        MoveForms moveForms = new MoveForms();
        private EventHandler profileOPenOnCLick { get; set; }
        private EventHandler chatPlayerOpenOnCLick { get; set; }
        private EventHandler roomsOpen { get; set; }
        private EventHandler pbxArsenalOpen { get; set; }
        private EventHandler pbxStoreOpen { get; set; }
        private EventHandler exitOnClick { get; set; }
        private EventHandler openAboutOnClick { get; set; }
        private EventHandler SendMessageOnCLick { get; set; }
        private EventHandler GetRankingOnCLick { get; set; }

        private ImageClass ImageClass = new ImageClass();
        private string controlLocation = "";
        private Boolean OpemMenu = true;
        private Random random = new Random();
        private string namePlayer { get; set; }
        private int idPlayer { get; set; }

        public GamePlayerForms(EventHandler profileOPenOnCLick,
            EventHandler chatPlayerOpenOnCLick,
            EventHandler RoomsOpen,
            EventHandler PbxArsenalOpen,
            EventHandler PbxStoreOpen,
            EventHandler ExitOnClick,
            EventHandler OpenAboutOnClick,
            EventHandler SendMessageOnCLick,
            EventHandler GetRankingOnCLick,
            string namePlayer,
            int idPlayer)
        {
            InitializeComponent();
            this.profileOPenOnCLick = profileOPenOnCLick;
            this.chatPlayerOpenOnCLick = chatPlayerOpenOnCLick;
            this.roomsOpen = RoomsOpen;
            this.pbxArsenalOpen = PbxArsenalOpen;
            this.pbxStoreOpen = PbxStoreOpen;
            this.exitOnClick = ExitOnClick;
            this.openAboutOnClick = OpenAboutOnClick;
            this.SendMessageOnCLick = SendMessageOnCLick;
            this.GetRankingOnCLick = GetRankingOnCLick;
            this.namePlayer = namePlayer;
            this.idPlayer = idPlayer;
        }
        private void pbxArsenal_Click(object sender, EventArgs e)
        {
            this.pbxArsenalOpen.Invoke(this, new PbxFormsOpenEventeArgs { Open = true });
        }

        private void pbxChat_Click(object sender, EventArgs e)
        {
            this.chatPlayerOpenOnCLick.Invoke(this, new PbxFormsOpenEventeArgs()
            {
                Open = true
            });
        }

        private void pbxHome_Click(object sender, EventArgs e)
        {
            this.profileOPenOnCLick.Invoke(this, new PbxFormsOpenEventeArgs()
            {
                Open = true
            });
        }

        private void pbxStore_Click(object sender, EventArgs e)
        {
            this.pbxStoreOpen.Invoke(this, new PbxFormsOpenEventeArgs { Open = true });
        }

        private void pbxBatlle_Click(object sender, EventArgs e)
        {
            this.roomsOpen.Invoke(this, new PbxFormsOpenEventeArgs() { Open = true });
        }

        // Funcionalidaes do menu superior.

        private void SetLocation(PictureBox pictureBox)
        {
            pictureBox.Image = this.ImageClass.GetImageIconForms("location");
        }
        private void ClearLocation()
        {
            switch (this.controlLocation)
            {
                case "Home":
                    this.pbxHome.Image = null;
                    break;
                case "Batlle":
                    this.pbxBatlle.Image = null;
                    break;
                case "Chat":
                    this.pbxChat.Image = null;
                    break;
                case "Store":
                    this.pbxStore.Image = null;
                    break;
                case "Arsenal":
                    this.pbxArsenal.Image = null;
                    break;
            }
            this.controlLocation = "";
        }
        private void lblHome_Click(object sender, EventArgs e)
        {
            if (this.pbxHome.Image == null)
            {
                ClearLocation();
                this.controlLocation = "Home";
                SetLocation(this.pbxHome);
            }
            else
            {
                ClearLocation();
            }
        }
        private void lblLocationArsenal_Click(object sender, EventArgs e)
        {
            if (this.pbxArsenal.Image == null)
            {
                ClearLocation();
                this.controlLocation = "Arsenal";
                SetLocation(this.pbxArsenal);
            }
            else
            {
                ClearLocation();
            }
        }

        private void lblLocationChat_Click(object sender, EventArgs e)
        {
            if (this.pbxChat.Image == null)
            {
                ClearLocation();
                this.controlLocation = "Chat";
                SetLocation(this.pbxChat);
            }
            else
            {
                ClearLocation();
            }
        }

        private void lblLocaitionStore_Click(object sender, EventArgs e)
        {
            if (this.pbxStore.Image == null)
            {
                ClearLocation();
                this.controlLocation = "Store";
                SetLocation(this.pbxStore);
            }
            else
            {
                ClearLocation();
            }
        }

        private void lblLocationBatlle_Click(object sender, EventArgs e)
        {
            if (this.pbxBatlle.Image == null)
            {
                ClearLocation();
                this.controlLocation = "Batlle";
                SetLocation(this.pbxBatlle);
            }
            else
            {
                ClearLocation();
            }
        }
        private void pbxUpDown_Click(object sender, EventArgs e)
        {
            this.txtBoxRanking.Clear();
            if (this.OpemMenu == true)
            {
                //ranking
                this.GetRankingOnCLick.Invoke(this, new PbxFormsOpenEventeArgs() { Open = true });

                //abrir painel
                this.pnlUp.Height = 500;
                this.pnlInfoGame.Height = 455;
                VisibleSpectator(true);
                this.pbxUpDown.Image = this.ImageClass.GetImageIconForms("up_W");
                this.OpemMenu = false;
            }
            else
            {
                VisibleSpectator(false);
                this.pnlUp.Height = 35;
                this.pnlInfoGame.Height = 3;
                this.pbxUpDown.Image = this.ImageClass.GetImageIconForms("down_W");
                this.OpemMenu = true;
            }
        }
        private void VisibleSpectator(Boolean visible)
        {
            this.pnlInfoGame.Visible = visible;
        }
        private void lblAbout_Click(object sender, EventArgs e)
        {
            this.openAboutOnClick.Invoke(this, new PbxFormsOpenEventeArgs() { Open = true });
        }
        private void lblExit_Click(object sender, EventArgs e)
        {
            this.exitOnClick.Invoke(this, new PbxFormsCloseEventeArgs() { Close = true });
        }
        private void pnlUp_MouseMove(object sender, MouseEventArgs e)
        {
            moveForms.Move(this.Handle);
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            if (this.tbxMessage.Text != "")
            {
                this.SendMessageOnCLick.Invoke(this, new PbxMessageSendMessageEventArgs()
                {
                    messageMessage = this.tbxMessage.Text,
                    name_Sender = this.namePlayer,
                    sender_id_tbPlayer = this.idPlayer
                });
                this.tbxMessage.Text = "";
            }
            else
            {
                MessageBox.Show("The message field is empty", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void ShowMessage(string name, string message, string date)
        {
            if (name == this.namePlayer)
            {
                this.rbxHistoryMessage.SelectionColor = Color.FromArgb(65, 105, 255);
                this.rbxHistoryMessage.SelectionFont = new Font("Gabriola", 18);
                this.rbxHistoryMessage.AppendText(Environment.NewLine + $"{message}");
                this.rbxHistoryMessage.SelectionAlignment = HorizontalAlignment.Right;

                this.rbxHistoryMessage.SelectionColor = Color.FromArgb(65, 105, 255);
                this.rbxHistoryMessage.SelectionFont = new Font("Gabriola", 10);
                this.rbxHistoryMessage.AppendText(Environment.NewLine + $"{name}: {date}");
                this.rbxHistoryMessage.SelectionAlignment = HorizontalAlignment.Right;
            }
            else
            {
                this.rbxHistoryMessage.SelectionColor = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
                this.rbxHistoryMessage.SelectionFont = new Font("Gabriola", 18);
                this.rbxHistoryMessage.AppendText(Environment.NewLine + $"{message}");
                this.rbxHistoryMessage.SelectionAlignment = HorizontalAlignment.Left;

                this.rbxHistoryMessage.SelectionColor = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
                this.rbxHistoryMessage.SelectionFont = new Font("Gabriola", 10);
                this.rbxHistoryMessage.AppendText(Environment.NewLine + $"{name}: {date}");
                this.rbxHistoryMessage.SelectionAlignment = HorizontalAlignment.Left;
            }
        }
        private void ShowRanking(string information)
        {
            this.txtBoxRanking.ForeColor = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
            this.txtBoxRanking.AppendText(Environment.NewLine + information);
        }
        //public 
        private delegate void NewMessageDelegate(string name, string message, string date);
        private delegate void LoadRankingDelegate(string information);
        public void NewMessage(string name, string message, string date)
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new NewMessageDelegate(NewMessage), new object[] { name, message, date });
            }
            else
            {
                ShowMessage(name, message, date);
            }
        }
        public void LoadRankig(string information)
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new LoadRankingDelegate(LoadRankig), new object[] { information });
            }
            else
            {
                ShowRanking(information);
            }
        }
    }
}
