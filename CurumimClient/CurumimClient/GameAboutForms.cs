using CurumimClient.PbxEventArgs;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CurumimGameForms
{
    public partial class GameAboutForms : Form
    {
        private EventHandler closeAboutOnClick { get; set; }
        string fileAbout = "../../About/";
        public GameAboutForms(EventHandler CloseAboutOnClick)
        {
            InitializeComponent();
            this.closeAboutOnClick = CloseAboutOnClick;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.closeAboutOnClick.Invoke(this, new PbxFormsCloseEventeArgs() { Close = true });
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
            if (UploadFile() == false)
            {
                lblErro.Text = ("Error loading file, check if it is in the About folder at the root of the program.");
            }
        }
    }
}
