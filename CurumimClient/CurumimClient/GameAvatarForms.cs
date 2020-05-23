using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CurumimGameForms.BtnEventArgs;
using CurumimClient.Classe;

namespace CurumimGameForms
{
    public partial class GameAvatarForms : Form
    {
        ImageClass classeImage = new ImageClass();
        private EventHandler BtnAvatarSelectOnClick = null;
        private string fileAppImg = "";
        private string[] names { get; set; }
        private int contImage { get; set; }
        private Dictionary<string, Image> imagens = new Dictionary<string, Image>();
        public GameAvatarForms(EventHandler BtnAvatarSelectOnClick)
        {
            InitializeComponent();
            this.BtnAvatarSelectOnClick = BtnAvatarSelectOnClick;
        }

        private void GameAvatarForms_Load(object sender, EventArgs e)
        {
            this.fileAppImg =  "../../img/Avatar/";

            if (UploadFile(this.fileAppImg) == false)
            {
                MessageBox.Show("Erro ao Carregar imagens, Verifique o aquivo Index", "Erro Carregamento de Image,");
            }

            this.lblOptions.Text = GetName(0);
            this.pbxAvatar.Image = GetImage(0);
            //this.BackColor = HexaForColor("#ffffff");
        }
        private void pbxReturn_Click(object sender, EventArgs e)
        {
            NexImage("Return");
        }

        private void pbxNext_Click(object sender, EventArgs e)
        {
            NexImage("Next");
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.BtnAvatarSelectOnClick.Invoke(this, new BtnAvatarSelectEventArgs() { avatarPlayer = GetName(contImage) });
            this.Close();
        }
        //dois metodos abaixo retornam o nome ou a imagem do dicionario desde que vc passe o index para ele.
        private Image GetImage(int index)
        {

            ICollection valorColecao = imagens.Values;
            Image[] mValores = new Image[imagens.Count];
            valorColecao.CopyTo(mValores, 0);

            return mValores[index];
        }
        private string GetName(int index)
        {
            ICollection chaveColecao = imagens.Keys;
            String[] mChaves = new String[imagens.Count];
            chaveColecao.CopyTo(mChaves, 0);

            return mChaves[index];
        }

        //Método para colar imagem na PictureBox
        private void NexImage(string type)
        {
            if (type == "Next")
            {
                if (contImage < names.Length - 1)
                {
                    contImage++;
                    this.lblOptions.Text = GetName(contImage);
                    this.pbxAvatar.Image = GetImage(contImage);
                }
                else
                {
                    contImage = 0;
                    this.lblOptions.Text = GetName(contImage);
                    this.pbxAvatar.Image = GetImage(contImage);
                }
            }
            else
            {

                if (contImage > 0)
                {
                    contImage--;
                    this.lblOptions.Text = GetName(contImage);
                    this.pbxAvatar.Image = GetImage(contImage);
                }
                else
                {
                    contImage = names.Length - 1;
                    this.lblOptions.Text = GetName(contImage);
                    this.pbxAvatar.Image = GetImage(contImage);
                }
            }

        }
        //Metodo para carregar o Arquivo index.txt
        private Boolean UploadFile(string location)
        {
            Image image = null;
            try
            {
                this.names = File.ReadAllLines(location + @"Index.txt", Encoding.UTF8);

                foreach (var nameimage in names)
                {
                    image = classeImage.GetImageAvatar(nameimage);
                    this.imagens.Add(nameimage, image);
                }
                return true;
            }
            catch
            {
                return false;
            }

        }


    }
}
