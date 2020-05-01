using CurumimClient.PbxEventArgs;
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
        GameProfileClasse profileClasse;
        EventHandler sendMensage;
        EventHandler closeChat;

        private Boolean openMenuChat = true;
        public GameChatPlayerFroms(GameProfileClasse gameProfileClasse, EventHandler CloseChat)
        {
            InitializeComponent();
            this.profileClasse = gameProfileClasse;
            this.closeChat = CloseChat;
        }
        private void pbxClouse_Click(object sender, EventArgs e)
        {
            this.closeChat.Invoke(this, new PbxFormsCloseEventeArgs() { Close = true });
            this.Close();
        }

        private void pbxSend_Click(object sender, EventArgs e)
        {
            SideOfTheText(this.rbxMessage.Text, "Wagner");
        }
        private void SideOfTheText(string texto, string nome)
        {

            if (nome == "Wagner")
            {
                rbxHitory.SelectionColor = Color.AliceBlue;   // = Color.Blue;
                rbxHitory.AppendText(Environment.NewLine + $">{nome}< {texto}");
                rbxHitory.SelectionAlignment = HorizontalAlignment.Right;

            }
            else
            {
                rbxHitory.SelectionColor = Color.Green;
                rbxHitory.AppendText(Environment.NewLine + $">{nome}< {texto}");
                rbxHitory.SelectionAlignment = HorizontalAlignment.Left;
            }

        }
        private void pbxLeft_Click(object sender, EventArgs e)
        {
            this.pbxLeft.Visible = false;
            FunctionPnl(this.openMenuChat, true, 51, 307, this.pnlLeft);
            this.dgvListConversaIniciada.Visible = true;
            this.openMenuChat = false;
            this.pbxClosePnl.Visible = true;

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



        private void pbxOffline_Click_1(object sender, EventArgs e)
        {
            pbxOnline.BorderStyle = BorderStyle.None;
            pbxOffline.BorderStyle = BorderStyle.FixedSingle;
        }

        private void pbxOnline_Click(object sender, EventArgs e)
        {
            pbxOnline.BorderStyle = BorderStyle.FixedSingle;
            pbxOffline.BorderStyle = BorderStyle.None;
        }
    }
}
