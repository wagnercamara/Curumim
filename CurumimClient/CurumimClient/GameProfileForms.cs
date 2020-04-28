using CurumimClient.Classe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurumimGameForms
{
    public partial class GameProfileForms : Form
    {
        GameProfileClasse gameProfile { get; set; }
        ImageClass imagemClass { get; set; }

        private Boolean openMenu = true;

        public GameProfileForms(GameProfileClasse gameProfileClasse)
        {
            InitializeComponent();
            this.gameProfile = gameProfileClasse;
        }


        private void pnlInformation_Load(object sender, EventArgs e)
        {
            this.imagemClass = new ImageClass();
            LoadIMageForms();
            LoadTextForms();
        }
        private void LoadIMageForms()
        {
            this.pbxLevel.Image = imagemClass.GetImageIconLevel(gameProfile.GetLevelPlayer());
            this.pbxAvatar.Image = imagemClass.GetImageAvatar(gameProfile.GetAvatarPlayer());
        }
        private void LoadTextForms()
        {
            int battle = gameProfile.GetTotalBattlesPlayer();
            int victory = gameProfile.GetVictoryPlayer();

            lblBatlle.Text = battle.ToString();
            lbldefeat.Text = (battle - victory).ToString();
            lblLevel.Text = gameProfile.GetLevelPlayer();
            lblScore.Text = gameProfile.GetPunctuationPlayer().ToString();
            lblWinner.Text = gameProfile.GetVictoryPlayer().ToString();
            lblName.Text = gameProfile.GetLoginPlayer();

        }
        private void pbxOpenMenu_Click(object sender, EventArgs e)
        {
            if (openMenu == true)
            {
                ProfileVisible(false);

                for (int i = 480; i >= 310; i--)
                {
                    this.lblName.Width = i;
                }

                for (int i = 46; i <= 213; i++)
                {
                    pnlInform.Width = i;
                }

                ProfileVisible(true);
                pbxOpenMenu.Image = imagemClass.GetImageIconForms("righit");
                openMenu = false;
            }
            else
            {
                ProfileVisible(false);

                for (int i = 213; i >= 46; i--)
                {
                    pnlInform.Width = i;
                }
                for (int i = 310; i <= 480; i++)
                {
                    this.lblName.Width = i;
                }
                ProfileVisible(true);
                pbxOpenMenu.Image = imagemClass.GetImageIconForms("left");
                openMenu = true;
            }
        }

        private void ProfileVisible(Boolean visible)
        {
            this.pnlProfileLevel.Visible = visible;
        }
        private void pbxClouse_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
