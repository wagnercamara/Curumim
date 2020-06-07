using Base;
using CurumimClient.Classe;
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
        private int[] typesFieldRight;
        private int[] typesFieldLeft;
        private Dictionary<int, PbxWeaponBattle> pbxWeapons = new Dictionary<int, PbxWeaponBattle>();
        private GameWeaponsClasse selectedWeapon;
        private int sizeField = 300;
        private int fieldHeight = 15;
        private int fieldWidth = 20;
        private int premiumScore;
        private int premiumEsmerald;
        private int typeBattle;
        private EventHandler OnClickButtonField;
        private Random random = new Random();
        private string loginPlayer1;
        private string loginPlayer2;

        public GameBattleForms(int typeBattle, int[] typesFieldRight, int[] typesFieldLeft, string loginPlayer1, string loginPlayer2)
        {
            this.typeBattle = typeBattle;
            this.loginPlayer1 = loginPlayer1;
            this.loginPlayer2 = loginPlayer2;
            this.typesFieldRight = typesFieldRight;
            this.typesFieldLeft = typesFieldLeft;

            InitializeComponent();

            this.OnClickButtonField = OnClick_ButtonField;
            
        }

        private void GameBattleForms_Load(object sender, EventArgs e)
        {
            LoadWeaponsBattle();
            LoadFieldLeft();
            LoadFieldRight();
        }

        private void LoadWeaponsBattle()
        {
            if (this.typeBattle != 1)//se não for tipo 1(sala inicial),  carrega na tela as armas escolhidas pelo jogador.
            {
                int x = 60;
                foreach (PbxWeaponBattle weapon in this.pbxWeapons.Values)
                {
                    weapon.Parent = this.pnlBattle;
                    weapon.Location = new Point(x, 467);
                    weapon.Show();
                    x += 64;
                }
            }
            else
            {
                PbxWeaponBattle stone = new PbxWeaponBattle(1001);
                stone.Parent = this.pnlBattle;
                stone.Location = new Point(60, 467);
                stone.Show();

                PbxWeaponBattle crossbow3 = new PbxWeaponBattle(1007);
                crossbow3.Parent = this.pnlBattle;
                crossbow3.Location = new Point(124, 467);
                crossbow3.Show();
            }
        }

        public void SetWeaponsBattle(Dictionary<string, GameWeaponsClasse> weapons = null)
        {
            foreach (GameWeaponsClasse weapon in weapons.Values)
            {
                this.pbxWeapons.Add(weapon.GetIdItem(), new PbxWeaponBattle(weapon.GetIdItem()));
            }
        }



        private void LoadFieldLeft()
        {
            int image = 0;
            int img = 0;
            for (int i = 0; i < this.sizeField; i++)
            {
                while (image == img)
                {
                    img = this.random.Next(0, 4);
                }
                ButtonField btn = new ButtonField(img);
                btn.SetTypeButton(this.typesFieldLeft[i]);
                image = img;
                buttonFieldLefts.Add(i, btn);
            }

            int x = 2;
            int y = 2;
            int button = 0;
            for (int i = 0; i < this.fieldHeight; i++)
            {
                for (int j = 0; j < this.fieldWidth; j++)
                {
                    buttonFieldLefts[button].Parent = this.pnlFieldLeft;
                    buttonFieldLefts[button].Location = new Point(x, y);
                    buttonFieldLefts[button].Name = $"Esquerda {button}";
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
            for (int i = 0; i < this.sizeField; i++)
            {
                while (image == img)
                {
                    img = this.random.Next(0, 4);
                }
                ButtonField btn = new ButtonField(img);
                btn.SetTypeButton(this.typesFieldRight[i]);
                image = img;
                buttonFieldRights.Add(i, btn);
            }

            int x = 12;
            int y = 2;
            int button = 0;
            for (int i = 0; i < this.fieldHeight; i++)
            {
                for (int j = 0; j < this.fieldWidth; j++)
                {
                    buttonFieldRights[button].Parent = this.pnlFieldRight;
                    buttonFieldRights[button].Location = new Point(x, y);
                    buttonFieldRights[button].Name = $"Direita {button}";
                    buttonFieldRights[button].Click += OnClickButtonField;
                    buttonFieldRights[button].Show();
                    x += 25;
                    button++;
                }
                y += 27;
                x = 12;
            }
        }

        public void SetSideField(string loginPlayer)
        {
            if (this.loginPlayer1 == loginPlayer)
            {
                pnlFieldRight.Enabled = false;
            }
            else
            {
                pnlFieldLeft.Enabled = false;
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

        private void OnClick_PbxWeaponBattle(object sender, EventArgs e)
        {
            PbxWeaponBattle weapon = sender as PbxWeaponBattle;

        }

        public void SetPremiumBattle(int premiumEsmerald, int premiumScore)
        {
            this.premiumEsmerald = premiumEsmerald;
            this.premiumScore = premiumScore;
        }

        private void Win()
        {
            MessageBox.Show($"  You Received a Premium of\n              {this.premiumEsmerald} emeralds\n                  {this.premiumScore} points");
            this.Close();
        }
    }
}
