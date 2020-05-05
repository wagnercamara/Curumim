using Base;
using CurumimClient.EventArgsForms;
using CurumimGameForms.BtnEventArgs;
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CurumimGameForms
{
    public partial class GameLoginForms : Form
    {
        //Event
        private event EventHandler BtnRegisterOnClick;
        private event EventHandler BtnLoginOnClick;
        private event EventHandler SelectAvatarOn;
        private event EventHandler BtnLoginRepleceOnClick;
        private event EventHandler LoginSucessEvent;

        //atributos
        private string avatarPlayer = string.Empty;
        private int forgotPassword { get; set; }
        private Boolean registerOrLogin = true;
        public GameLoginForms(EventHandler BtnRegisterOnClick, EventHandler BtnLoginOnClick, EventHandler BtnLoginRepleceOnClick, EventHandler SelectAvatarOn, EventHandler LoginSucessEvent)
        {
            InitializeComponent();
            this.BtnRegisterOnClick = BtnRegisterOnClick;
            this.BtnLoginOnClick = BtnLoginOnClick;
            this.BtnLoginRepleceOnClick = BtnLoginRepleceOnClick;
            this.SelectAvatarOn = SelectAvatarOn;
            this.LoginSucessEvent = LoginSucessEvent;
        }
        //delegate
        private delegate void SetAvatarDelegate(string avatar);
        private delegate void LoginSucessDelegate(MessageEventArgs messageEventArgs);
        private delegate void GenericDelegate();
        //
        //
        // Login
        //
        //
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
            return;
        }
        private Boolean LogValidateFields()
        {
            Boolean RegOk = true;
            StringBuilder stringBuilder = new StringBuilder("Preecha os campos; ");

            if (txtUser.Text == "")
            {
                stringBuilder.Append("Login; ");
                RegOk = false;
            }
            if (txtPassword.Text == "")
            {
                stringBuilder.Append("Password; ");
                RegOk = false;
            }
            if (RegOk == false)
            {
                lblErro.Enabled = true;
                lblErro.Text = stringBuilder.ToString();
                return RegOk;
            }
            return RegOk;
        }
        private void btnOpen_Click(object sender, EventArgs e)
        {
            forgotPassword++;

            if (forgotPassword > 3)
            {
                lblChangePassword.Visible = true;
                btnReplecePassword.Enabled = true;
                btnReplecePassword.Visible = true;
                forgotPassword = 0;
            }
            else
            {
                lblChangePassword.Visible = false;
                btnReplecePassword.Enabled = false;
                btnReplecePassword.Visible = false;
            }

            if (LogValidateFields() == true)
            {
                this.BtnLoginOnClick.Invoke(this, new BtnLoginOnClickEventArgs()
                {

                    loginPlayer = this.txtUser.Text,
                    passwordPlayer = this.txtPassword.Text

                });
            }

        }

        //
        //
        //Register
        //
        //
        private Boolean RegValidateFields()
        {
            Boolean RegOk = true;
            StringBuilder stringBuilder = new StringBuilder("Preecha os campos; ");

            if (txtRegFullName.Text == "")
            {
                stringBuilder.Append("Full Name; ");
                RegOk = false;
            }
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
                lblRegErro.Text = stringBuilder.ToString();
                return RegOk;
            }
            return RegOk;
        }

        private void btnNewRegister_Click(object sender, EventArgs e)
        {
            if (RegValidateFields() == true)
            {
                if (this.txtRegPassword.Text == this.txtRegConfPassword.Text)
                {
                    this.SelectAvatarOn.Invoke(this, new BtnAvatarEventArgs() { avatar = true });
                    ClearCapReg();
                }
                else
                {
                    MessageBox.Show("passwords do not match");
                    this.txtRegPassword.Clear();
                    this.txtRegSecrPhrese.Clear();
                }

            }

        }
        private void ClearCapReg()
        {
            txtRegFullName.Text = "";
            txtRegLogin.Text = "";
            txtRegPassword.Text = "";
            txtRegConfPassword.Text = "";
            txtRegSecrPhrese.Text = "";
        }

        //
        //
        //funcionalidade paineis Login e Register.
        //
        //
        private void pbxDownLogin_Click(object sender, EventArgs e)
        {
            txtUser.Focus();
            PnlRegisterLogon();
        }

        private void pbxUpRegister_Click(object sender, EventArgs e)
        {
            txtRegFullName.Focus();
            PnlRegisterLogon();
        }

        private void PnlRegisterLogon()
        {
            if (this.registerOrLogin == true)
            {
                for (int i = 41; i <= 510; i++)
                {
                    pnlRegister.Height = i;
                }
                lblUpRegister.Visible = false;
                pbxUpRegister.Visible = false;

                lblDownLogin.Visible = true;
                pbxDownLogin.Visible = true;

                this.registerOrLogin = false;
                LoginVisible(false);
            }
            else
            {
                for (int i = 510; i >= 40; i--)
                {
                    pnlRegister.Height = i;
                }
                LoginVisible(true);
                lblDownLogin.Visible = false;
                pbxDownLogin.Visible = false;

                lblUpRegister.Visible = true;
                pbxUpRegister.Visible = true;


                this.registerOrLogin = true;
            }
        }

        private void LoginVisible(Boolean visible)
        {
            pbxLogoCurumim.Visible = visible;
            lblLogin.Visible = visible;
            lblPassword.Visible = visible;
            lblErro.Visible = visible;
            txtPassword.Visible = visible;
            txtUser.Visible = visible;
            btnBaseLogin.Visible = visible;
            btnBasePassword.Visible = visible;
            btnOpen.Visible = visible;
            btnExit.Visible = visible;
        }

        //Return Base
        private void btnReplecePassword_Click(object sender, EventArgs e)
        {
            this.BtnLoginRepleceOnClick.Invoke(this, new BtnForgotPaswordOnClickEventArgs()
            {
                newGameReplece = true
            });
        }
        public void LoginSucess(MessageEventArgs messageEventArgs)
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new LoginSucessDelegate(LoginSucess), new object[] { messageEventArgs });
            }
            else
            {
                this.LoginSucessEvent.Invoke(this, new LoginSucessEventArgs() { MessageEventArgs = messageEventArgs });
            }
        }

        public void LoginErro()
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new GenericDelegate(LoginErro), new object[] { });
            }
            else
            {
                MessageBox.Show("Invalid password or login");
            }
        }
        public void RegisterSucess()
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new GenericDelegate(RegisterSucess), new object[] { });
            }
            else
            {
                PnlRegisterLogon();
                MessageBox.Show("Successfully registered");
            }
        }

        public void RegisterErro()
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new GenericDelegate(RegisterErro), new object[] { });
            }
            else
            {
                MessageBox.Show("It was not possible to register this data, try to change the login and try again");
            }
        }
        public void SetAvatar(string avatar)
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new SetAvatarDelegate(SetAvatar), new object[]
                {
                    avatar
                });
            }
            else
            {
                this.avatarPlayer = avatar;
            }
        }
        public void RegisterDB()
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new GenericDelegate(RegisterDB), new object[] { });
            }
            else
            {
                BtnRegisterOnClick.Invoke(this, new BtnRegisterOnClickEventArgs()
                {
                    fullNamePlayer = this.txtRegFullName.Text,
                    loginPlayer = this.txtRegLogin.Text,
                    passwordPlayer = this.txtRegPassword.Text,
                    secretPhresePlayer = this.txtRegSecrPhrese.Text,
                    avatarPlayer = this.avatarPlayer
                });
            }
        }


    }
}
