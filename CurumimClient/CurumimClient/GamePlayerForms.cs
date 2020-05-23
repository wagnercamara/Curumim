using CurumimClient.Classe;
using CurumimClient.pbxEventArgs;
using CurumimClient.PbxEventArgs;
using System;
using System.Drawing;
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

        private ImageClass ImageClass = new ImageClass();
        private string controlLocation = "";
        private Boolean OpemMenu = true;

        public GamePlayerForms(EventHandler profileOPenOnCLick, EventHandler chatPlayerOpenOnCLick, EventHandler RoomsOpen, EventHandler PbxArsenalOpen, EventHandler PbxStoreOpen, EventHandler ExitOnClick, EventHandler OpenAboutOnClick)
        {
            InitializeComponent();
            this.profileOPenOnCLick = profileOPenOnCLick;
            this.chatPlayerOpenOnCLick = chatPlayerOpenOnCLick;
            this.roomsOpen = RoomsOpen;
            this.pbxArsenalOpen = PbxArsenalOpen;
            this.pbxStoreOpen = PbxStoreOpen;
            this.exitOnClick = ExitOnClick;
            this.openAboutOnClick = OpenAboutOnClick;
        }
        private void pbxSpectador_Click(object sender, EventArgs e)
        {
            GameSpectatorForms gameSpectatorForms = new GameSpectatorForms();
            gameSpectatorForms.Show();
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
            }) ;
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
            if (this.OpemMenu == true)
            {
                this.pnlUp.Height = 330;
                this.pnlSpc.Height = 295;
                VisibleSpectator(true);
                this.pbxUpDown.Image = this.ImageClass.GetImageIconForms("up_W");
                this.OpemMenu = false;
            }
            else
            {
                VisibleSpectator(false);
                this.pnlUp.Height = 35;
                this.pnlSpc.Height = 3;
                this.pbxUpDown.Image = this.ImageClass.GetImageIconForms("down_W");
                this.OpemMenu = true;
            }
        }
        private void VisibleSpectator(Boolean visible)
        {
            this.pbxSpectador.Visible = visible;
            this.lblSpectator.Visible = visible;
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
      
    }
}
