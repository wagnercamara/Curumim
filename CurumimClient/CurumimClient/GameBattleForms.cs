using Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurumimGameForms
{
    public partial class GameBattleForms : Form
    {
        private Dictionary<int, ButtonField> buttonFieldLefts = new Dictionary<int, ButtonField>();
        private Dictionary<int, ButtonField> buttonFieldRights = new Dictionary<int, ButtonField>();
        private int sizeField = 300;
        private int fieldHeight = 15;
        private int fieldWidth = 20;
        private int premiumScore;
        private int premiumEsmerald;
        private int singleEsmeralds;
        private int typeBattle;
        private EventHandler OnClickButtonField;
        private Random random = new Random();
        public GameBattleForms(int typeBattle)
        {
            this.typeBattle = typeBattle;
            InitializeComponent();

            OnClickButtonField = OnClick_ButtonField;

            if (this.random.Next(0, 2) == 1)
            {
                pnlFieldLeft.Enabled = false;
            }
            else
            {
                pnlFieldRight.Enabled = false;
            }

        }

        private void GameBattleForms_Load(object sender, EventArgs e)
        {
            LoadTypeBattle();
            LoadWeaponsBattle();
            LoadFieldLeft();
            LoadFieldRight();
        }

        private void LoadWeaponsBattle()
        {

        }

        private void LoadTypeBattle()
        {
            switch (this.typeBattle)
            {
                case 1:
                    this.singleEsmeralds = 0;
                    this.premiumEsmerald = 100;
                    this.premiumScore = 5;
                    break;
                case 2:
                    this.singleEsmeralds = 50;
                    this.premiumEsmerald = 100;
                    this.premiumScore = 20;
                    break;
                case 3:
                    this.singleEsmeralds = 60;
                    this.premiumEsmerald = 250;
                    this.premiumScore = 40;
                    break;
                case 4:
                    this.singleEsmeralds = 70;
                    this.premiumEsmerald = 500;
                    this.premiumScore = 60;
                    break;
                case 5:
                    this.singleEsmeralds = 80;
                    this.premiumEsmerald = 1000;
                    this.premiumScore = 100;
                    break;
                case 6:
                    this.singleEsmeralds = 90;
                    this.premiumEsmerald = 2500;
                    this.premiumScore = 250;
                    break;
                case 7:
                    this.singleEsmeralds = 150;
                    this.premiumEsmerald = 5000;
                    this.premiumScore = 500;
                    break;
                case 8:
                    this.singleEsmeralds = this.random.Next(100, 401);
                    this.premiumScore = this.premiumEsmerald / 5;
                    break;
            }
        }

        private void SetPremiumEsmeraldCrazy(int premiumEsmeraldCrazy)
        {
            this.premiumEsmerald = premiumEsmeraldCrazy;
        }

        private void LoadFieldLeft()
        {
            int image = 0;
            int img = 0;
            int localIndian = this.random.Next(1, 301);
            int localchest = -1;
            if (this.typeBattle != 1) { localchest = this.random.Next(1, 301); }
            int singleEsmeraldsLeft = 0;

            for (int i = 1; i <= this.sizeField; i++)
            {
                while (image == img)
                {
                    img = this.random.Next(0, 4);
                }
                ButtonField btn = new ButtonField(img);
                if (singleEsmeraldsLeft < this.singleEsmeralds)
                {
                    btn.SetTypeButton(this.random.Next(0, 2));
                    if (btn.GetTypeButton() == 1) { singleEsmeraldsLeft += 1; }
                }
                else { btn.SetTypeButton(0); }
                image = img;
                buttonFieldLefts.Add(i, btn);
            }

            int x = 2;
            int y = 2;
            int button = 1;
            for (int i = 1; i <= this.fieldHeight; i++)
            {
                for (int j = 1; j <= this.fieldWidth; j++)
                {
                    buttonFieldLefts[button].Parent = this.pnlFieldLeft;
                    buttonFieldLefts[button].Location = new Point(x, y);
                    buttonFieldLefts[button].Name = $"Esquerda {button}";
                    if (button == localIndian)
                    {
                        buttonFieldLefts[button].SetTypeButton(3);
                        MessageBox.Show("indio E: " + button);
                    }
                    else if (button == localchest)
                    {
                        buttonFieldLefts[button].SetTypeButton(2);
                        MessageBox.Show("Baú E: " + button);
                    }
                    buttonFieldLefts[button].Click += OnClickButtonField;
                    buttonFieldLefts[button].Show();
                    x += 25;
                    button++;
                }
                y += 27;
                x = 2;
            }
        }

        private void LoadFieldRight()
        {
            int image = 0;
            int img = 0;
            int localIndian = this.random.Next(1, 301);
            int localchest = -1;
            if (this.typeBattle != 1) { localchest = this.random.Next(1, 301); }
            int singleEsmeraldsRight = 0;

            for (int i = 1; i <= this.sizeField; i++)
            {
                while (image == img)
                {
                    img = this.random.Next(0, 4);
                }
                ButtonField btn = new ButtonField(img);
                if (singleEsmeraldsRight < this.singleEsmeralds)
                {
                    btn.SetTypeButton(this.random.Next(0, 2));
                    if (btn.GetTypeButton() == 1) { singleEsmeraldsRight += 1; }
                }
                else { btn.SetTypeButton(0); }
                image = img;
                buttonFieldRights.Add(i, btn);
            }

            int x = 12;
            int y = 2;
            int button = 1;
            for (int i = 1; i <= this.fieldHeight; i++)
            {
                for (int j = 1; j <= this.fieldWidth; j++)
                {
                    buttonFieldRights[button].Parent = this.pnlFieldRight;
                    buttonFieldRights[button].Location = new Point(x, y);
                    buttonFieldRights[button].Name = $"Direita {button}";
                    if (button == localIndian)
                    {
                        buttonFieldRights[button].SetTypeButton(3);
                        MessageBox.Show("indio D:" + button);
                    }
                    else if (button == localchest)
                    {
                        buttonFieldRights[button].SetTypeButton(2);
                        MessageBox.Show("Baú D: " + button);
                    }
                    buttonFieldRights[button].Click += OnClickButtonField;
                    buttonFieldRights[button].Show();
                    x += 25;
                    button++;
                }
                y += 27;
                x = 12;
            }
        }

        private void OnClick_ButtonField(object sender, EventArgs e)
        {
            ButtonField button = sender as ButtonField;
            button.DestroyedButton();
            switch (button.GetTypeButton())
            {
                case 1:
                    button.EsmeraldButton();
                    break;
                case 2:
                    button.BauButton();
                    MessageBox.Show($"{button.Name}\nBaú");
                    break;
                case 3:
                    button.IndianButton();
                    MessageBox.Show($"          {button.Name}\n    Enemy Indian Hit!\n           YOU WON!");
                    Win();
                    break;
            }
            button.Enabled = false;
        }

        private void Win()
        {
            MessageBox.Show($"  You Received a Premium of\n              {this.premiumEsmerald} emeralds\n                  {this.premiumScore} points");
            this.Close();
        }
    }
}
