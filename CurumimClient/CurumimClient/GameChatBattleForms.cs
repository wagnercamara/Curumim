using CurumimClient.Classe;
using CurumimClient.PbxEventArgs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CurumimGameForms
{
    public partial class GameChatBatlleForms : Form
    {
        private MoveForms moveForms = new MoveForms();
        private List<string> history = new List<string>();
        private EventHandler MessageSendMessageOnClik;
        private string myLogin;

        public GameChatBatlleForms(EventHandler MessageSendMessageOnClik, string myLogin)
        {
            InitializeComponent();
            this.MessageSendMessageOnClik = MessageSendMessageOnClik;
            this.myLogin = myLogin;
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            if(MessageValidate())
            {
                this.MessageSendMessageOnClik.Invoke(this, new PbxMessageSendMessageEventArgs()
                {
                    messageMessage = this.rbxMessage.Text
                });
                NewMessagem(this.rbxMessage.Text);
                this.rbxMessage.Clear();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        private void panelUp_MouseMove(object sender, MouseEventArgs e)
        {
            this.moveForms.Move(this.Handle);
        }
        private Boolean MessageValidate()
        {
            if(this.rbxMessage.Text == "")
            {
                MessageBox.Show("Não há messagem a ser enviada");
                return false;
            }
            return true;
        }

        private delegate void NewMessageDelegate(string message, int Type);
        public void NewMessagem(string message, int Type = 1)
        {
            if(this.InvokeRequired == true)
            {
                this.Invoke(new NewMessageDelegate(NewMessagem), new object[] { message, Type = 2});
            }
            else
            {
                switch(Type)
                {
                    case 1:
                        this.rbxHitory.SelectionColor = Color.FromArgb(65, 105, 255);
                        this.rbxHitory.SelectionFont = new Font("Gabriola", 18);
                        this.rbxHitory.AppendText(Environment.NewLine + $"{this.myLogin}: {message}");
                        this.rbxHitory.SelectionAlignment = HorizontalAlignment.Right;
                        break;
                    case 2:
                        this.rbxHitory.SelectionColor = Color.FromArgb(0, 255, 255);
                        this.rbxHitory.SelectionFont = new Font("Gabriola", 18);
                        this.rbxHitory.AppendText(Environment.NewLine + $"{message}");
                        this.rbxHitory.SelectionAlignment = HorizontalAlignment.Left;
                        break;
                }
                this.history.Add($"{Type}|{message}");
            }
        }

        private void GameChatBatlleForms_Load(object sender, EventArgs e)
        {
            int x = this.history.Count;
            for (int i = 0; i < x; i++)
            {
                string[] ToSeparate = this.history[i].Split('|');
                NewMessagem(ToSeparate[1], Convert.ToInt32(ToSeparate[0]));
            }
        }

    }
}
