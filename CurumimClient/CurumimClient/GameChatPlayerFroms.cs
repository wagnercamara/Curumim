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
    public partial class GameChatPlayerFroms : Form
    {
        private Boolean openMenu = true;
        public GameChatPlayerFroms()
        {
            InitializeComponent();
        }
        private void pbxClouse_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbxSend_Click(object sender, EventArgs e)
        {
            rbxHitory.AppendText(Environment.NewLine + $"{rbxMessage.Text}");
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void pbxLeft_Click(object sender, EventArgs e)
        {
            if (openMenu == true)
            {
                MessageVisible(false);
                for (int i = 51; i <= 367; i++)
                {
                    this.pnlLeft.Width = i;
                }
                this.openMenu = false;
                MessageVisible(true);
            }
            else
            {
                MessageVisible(false);
                for (int i = 367; i >= 51; i--)
                {
                    this.pnlLeft.Width = i;
                }
                MessageVisible(true);
                this.openMenu = true;
            }
        }
        private void MessageVisible(Boolean visible)
        {
            this.rbxHitory.Visible = visible;
            this.rbxMessage.Visible = visible;
            this.btnBax.Visible = visible;
            this.btnUp.Visible = visible;
        }
    }
}
