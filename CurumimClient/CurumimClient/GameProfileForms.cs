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
        private string fileAppIcon = "";
        private string fileAppAvatar = "";
        private Boolean openMenu = true;
        public GameProfileForms()
        {
            InitializeComponent();
            this.fileAppIcon = Application.StartupPath + @"\img\Icon\";
            this.fileAppAvatar = Application.StartupPath + @"\img\Avatar\";
        }


        private void pnlInformation_Load(object sender, EventArgs e)
        {
            this.pbxLevel.Image = Image.FromFile(fileAppIcon + @"level\96x96\Curumim.png");
            this.pbxAvatar.Image = Image.FromFile(fileAppAvatar + @"Thaynara.PNG");
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
                pbxOpenMenu.Image = Image.FromFile(fileAppIcon + @"player\righit.png");
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
                pbxOpenMenu.Image = Image.FromFile(fileAppIcon + @"player\left.png");
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
