using Base;
using CurumimClient.Classe;
using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace CurumimGameForms
{
    public partial class GameChatBatlleForms : Form
    {
        private MoveForms moveForms = new MoveForms();
        private List<string> history = new List<string>();

        private int Cont = 0;
        public GameChatBatlleForms()
        {
            InitializeComponent();
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            if(MessageValidate())
            {
                if(Cont % 2 == 0)
                {
                    NewMessagem(this.rbxMessage.Text);
                    Cont++;
                }
                else
                {
                    string teste = this.rbxMessage.Text;
                    System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(() =>
                    {
                        NewMessagem(teste);
                    }));
                    Cont++;
                    thread.Start();
                }

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
                        this.rbxHitory.AppendText(Environment.NewLine + $":{message}");
                        this.rbxHitory.SelectionAlignment = HorizontalAlignment.Right;
                        break;
                    case 2:
                        this.rbxHitory.AppendText(Environment.NewLine + $":{message}");
                        this.rbxHitory.SelectionAlignment = HorizontalAlignment.Left;
                        break;
                }
                this.history.Add($"{Type}:{message}");
            }
        }

        private void GameChatBatlleForms_Load(object sender, EventArgs e)
        {
            foreach (string his in this.history)
            {
                string[] ToSeparate = his.Split(':');
                NewMessagem(ToSeparate[1], Convert.ToInt32(ToSeparate[0]));
            }
        }
    }
}
