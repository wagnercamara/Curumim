using CurumimClient.Classe;
using System;
using System.Windows.Forms;

namespace CurumimClient
{
    public partial class GameWinOrLoserForms : Form
    {
        private int QtdBau { get; set; }
        private int QtdEsm { get; set; }
        private int QtdScore { get; set; }
        private int WinOrLoser { get; set; }

        private ImageClass ImageClass = new ImageClass();
        public GameWinOrLoserForms(
        int WInOrLoser,
        int QtdBau = 0,
        int QtdEsm = 0,
        int QtdScore = 0 )
        {
            InitializeComponent();
            this.QtdBau = QtdBau;
            this.QtdEsm = QtdEsm;
            this.QtdScore = QtdScore;
            this.WinOrLoser = WInOrLoser;
        }

        private void GameWinOrLoserForms_Load(object sender, EventArgs e)
        {
            if(this.WinOrLoser == 0)
            {
                LoadImageStatus("defeat");
            }
            else
            {
                LoadImageStatus("Winner");
                LoadAwards();
            }
        }
        private void LoadImageStatus(string nameSatatus)
        {
            pbxStatus.Image = ImageClass.GetImageIconForms(nameSatatus);
        }
        private void LoadAwards()
        {
            this.lblBau.Text = this.QtdBau.ToString();
            this.lblEsm.Text = this.QtdEsm.ToString();
            this.lblScore.Text = this.QtdScore.ToString();
        }
    }
}
