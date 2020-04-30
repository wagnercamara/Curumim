using CurumimClient.Classe;
using CurumimClient.pbxEventArgs;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CurumimGameForms
{
    public partial class GamePlayerForms : Form
    {
        private EventHandler profileOPenOnCLick { get; set; }

        private ImageClass ImageClass;
        private string controlLocation = "";
        private Boolean OpemMenu = true;

        public GamePlayerForms(EventHandler profileOPenOnCLick)
        {
            InitializeComponent();
            this.profileOPenOnCLick = profileOPenOnCLick;
            this.ImageClass = new ImageClass();
        }
        private void pbxSpectador_Click(object sender, EventArgs e)
        {
            GameSpectatorForms gameSpectatorForms = new GameSpectatorForms();
            gameSpectatorForms.Show();
        }
        private void pbxArsenal_Click(object sender, EventArgs e)
        {
            GameArsenalForms gameArsenalForms = new GameArsenalForms();
            gameArsenalForms.Show();
        }

        private void pbxChat_Click(object sender, EventArgs e)
        {
            GameChatPlayerFroms gameChatPlayerFroms = new GameChatPlayerFroms();
            gameChatPlayerFroms.Show();
        }

        private void pbxHome_Click(object sender, EventArgs e)
        {
            this.profileOPenOnCLick.Invoke(this, new PbxProfileOpenEventeArgs()
            {
                OpenFormsProfile = true
            }) ;
        }

        private void pbxStore_Click(object sender, EventArgs e)
        {
            GameStoreForms gameStoreForms = new GameStoreForms();
            gameStoreForms.Show();
        }

        private void pbxBatlle_Click(object sender, EventArgs e)
        {
            //GameBattleForms gameBattleForms = new GameBattleForms();
            //gameBattleForms.Show();
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
            //if (gameAboutForms != null)
            //{
            //    Application.OpenForms["gameAboutForms"].BringToFront(); // traz um forms já criado pra fente novamente.
            //}
            //else
            //{
            //    gameAboutForms = new GameAboutForms();
            //    gameAboutForms.Show();
            //}
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
            return;
        }

    }
}
