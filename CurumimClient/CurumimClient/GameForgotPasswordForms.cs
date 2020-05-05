using CurumimGameForms.BtnEventArgs;
using System;
using System.Text;
using System.Windows.Forms;

namespace CurumimGameForms
{
    public partial class GameForgotPasswordForms : Form
    {
        private event EventHandler BtnRepleceOnClick;
        public GameForgotPasswordForms(EventHandler BtnRepleceOnClick)
        {
            InitializeComponent();
            this.BtnRepleceOnClick = BtnRepleceOnClick;
        }

        private delegate void GenericDelegate();
        private Boolean RegValidateFields()
        {
            Boolean RegOk = true;
            StringBuilder stringBuilder = new StringBuilder("Preecha os campos; ");

            if (txtRegLogin.Text == "")
            {
                stringBuilder.Append("Login; ");
                RegOk = false;
            }
            if (txtRegPassword.Text == "")
            {
                stringBuilder.Append("Password; ");
                RegOk = false;
            }
            if (txtRegConfPassword.Text == "")
            {
                stringBuilder.Append("Confirm Password; ");
                RegOk = false;
            }
            if (txtRegSecrPhrese.Text == "")
            {
                stringBuilder.Append("Secret Pherese; ");
                RegOk = false;
            }
            if (RegOk == false)
            {
                lblErro.Text = stringBuilder.ToString();
                return RegOk;
            }
            return RegOk;
        }
        private void ClearCapRep()
        {
            txtRegLogin.Text = "";
            txtRegPassword.Text = "";
            txtRegConfPassword.Text = "";
            txtRegSecrPhrese.Text = "";
        }
        private void btnReplace_Click(object sender, EventArgs e)
        {
            if (RegValidateFields() == true)
            {
                if (this.txtRegPassword.Text == this.txtRegConfPassword.Text)
                {
                    this.BtnRepleceOnClick.Invoke(this, new BtnReplaceOnClickEventArgs()
                    {
                        loginPlayer = this.txtRegLogin.Text,
                        passwordPlayer = this.txtRegPassword.Text,
                        secretPhresePlayer = this.txtRegSecrPhrese.Text,
                    });
                   
                }
                else
                {
                    MessageBox.Show("passwords do not match");
                    this.txtRegPassword.Clear();
                    this.txtRegConfPassword.Clear();
                    this.txtRegSecrPhrese.Clear();
                }

            }

        }
        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void RepleceSucess()
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new GenericDelegate(RepleceSucess), new object[] { });
            }
            else
            {
                MessageBox.Show("Successfully registered");
                ClearCapRep();
                this.Close();
            }
        }
        public void RepleceErro()
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new GenericDelegate(RepleceErro), new object[] { });
            }
            else
            {
                MessageBox.Show("It was not possible to register this data, try to change the login and try again");
            }
        }

    }
}
