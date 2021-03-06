﻿using CurumimClient.Classe;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurumimGameForms
{
    internal class ButtonField : Button
    {
        private ImageClass ImageClass = new ImageClass(); //inceri esse cara.

        private string[] imagens = { "bush1", "bush2", "bush3", "bush4", "esmerald", "location", "Bau" }; //simplifiquei os nomes.
        private string[] imagensDestr = { "bush1Destr", "bush2Destr", "bush3Destr", "bush4Destr" };
        private int type;
        private int img;
        private int idButton;

        public ButtonField(int img, int idButton)
        {
            this.img = img;
            this.idButton = idButton;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BackColor = Color.Transparent;
            this.BackgroundImage = this.ImageClass.GetImageIconBattleForms(imagens[img]); // troquei aqui taylor
            this.FlatAppearance.BorderSize = 0;
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(25, 25);
            this.TabIndex = 0;
            this.UseVisualStyleBackColor = true;
        }

        public void DestroyedButton()
        {
            this.BackgroundImage = this.ImageClass.GetImageIconBattleForms(imagensDestr[this.img]);
            this.BackColor = Color.Transparent;
        }

        public void EsmeraldButton()
        {
            this.BackgroundImage = this.ImageClass.GetImageIconBattleForms(imagens[4]);
            this.BackColor = Color.Transparent;
        }
        public void IndianButton()
        {
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BackgroundImage = this.ImageClass.GetImageIconBattleForms(imagens[5]);
            this.BackColor = Color.Transparent;
        }

        public void BauButton()
        {
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BackgroundImage = this.ImageClass.GetImageIconBattleForms(imagens[6]);
            this.BackColor = Color.Transparent;
        }

        public void SetTypeButton(int type)
        {
            this.type = type;
        }

        public int GetTypeButton()
        {
            return this.type;
        }

        public int GetIdButton()
        {
            return this.idButton;
        }

        public void RestorButton()
        {
            this.BackgroundImage = this.ImageClass.GetImageIconBattleForms(imagens[this.img]);
            this.BackColor = Color.Transparent;
            this.type = 0;
        }
    }
}
