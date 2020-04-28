using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CurumimGameForms
{
    public partial class GameAboutForms : Form
    {
        string fileAbout = "";
        public GameAboutForms()
        {
            InitializeComponent();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Metodo para carregar o Arquivo About.txt
        private Boolean UploadFile()
        {
            try
            {
                string[] lines = File.ReadAllLines(this.fileAbout + @"About.txt", Encoding.UTF8);
                foreach (var line in lines)
                {
                    this.rbxAbot.AppendText(Environment.NewLine + $"{line}");
                }
                return true;
            }
            catch
            {
                return false;
            }

        }
        private void GameAboutForms_Load(object sender, EventArgs e)
        {
            this.fileAbout = Application.StartupPath + @"\About\";

            if (UploadFile() == false)
            {
                lblErro.Text = ("Erro ao Carregar Arquivo, verifique se o mesmo está na pasta About na raiz do progrma.");
            }
        }
    }
}
