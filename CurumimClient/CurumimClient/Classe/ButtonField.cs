using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurumimGameForms
{
    internal class ButtonField : Button
    {
        private string fileAppIcon = "";
        private string[] imagens = { @"battleForm\bush1.png", @"battleForm\bush2.png", @"battleForm\bush3.png", @"battleForm\bush4.png", @"battleForm\esmerald.png", @"battleForm\location.png", @"battleForm\Bau.png" };
        private string[] imagensDestr = { @"battleForm\bush1Destr.png", @"battleForm\bush2Destr.png", @"battleForm\bush3Destr.png", @"battleForm\bush4Destr.png" };
        private int type;
        private int img;

        public ButtonField(int img)
        {
            this.img = img;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.fileAppIcon = Application.StartupPath + @"\img\Icon\";
            this.BackgroundImage = Image.FromFile(this.fileAppIcon + imagens[img]);
            this.FlatAppearance.BorderSize = 0;
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(25, 25);
            this.TabIndex = 0;
            this.UseVisualStyleBackColor = true;
        }

        public void DestroyedButton()
        {
            this.BackgroundImage = Image.FromFile(this.fileAppIcon + imagensDestr[this.img]);
        }

        public void EsmeraldButton()
        {
            this.BackgroundImage = Image.FromFile(this.fileAppIcon + imagens[4]);
        }
        public void IndianButton()
        {
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BackgroundImage = Image.FromFile(this.fileAppIcon + imagens[5]);
        }

        public void BauButton()
        {
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BackgroundImage = Image.FromFile(this.fileAppIcon + imagens[6]);
        }

        public void SetTypeButton(int type)
        {
            this.type = type;
        }

        public int GetTypeButton()
        {
            return this.type;
        }
    }
}
