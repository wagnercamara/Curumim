using Base;
using CurumimClient;
using CurumimClient.BtnEventArgs;
using CurumimClient.Classe;
using CurumimClient.PbxEventArgs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurumimGameForms
{
    public partial class GameBattleForms : Form
    {
        private EventHandler PbxCloseBattle { get; set; }
        private delegate void DestroyedButtonDelegate(int[] locals, bool mysidefield, int typeItem);
        private delegate void SyncLocalIndianDelegate(int newLocal, int oldLocal);
        private delegate void SetWeaponsBattleDelegate(Dictionary<string, GameWeaponsClasse> weapons);
        private MoveForms moveForms = new MoveForms();
        private EventHandler OnClickButtonField;
        private EventHandler onDestroyedButton { get; set; }
        private EventHandler SyncLocalIndian { get; set; }
        private Dictionary<int, ButtonField> buttonFieldLefts = new Dictionary<int, ButtonField>();
        private Dictionary<int, ButtonField> buttonFieldRights = new Dictionary<int, ButtonField>();
        private int[] typesFieldRight;
        private int[] typesFieldLeft;
        private Dictionary<int, PbxWeaponBattle> pbxWeapons = new Dictionary<int, PbxWeaponBattle>();
        private Dictionary<int, Label> lblQntWeapons = new Dictionary<int, Label>();
        private Dictionary<int, GameWeaponsClasse> weaponsBattle = new Dictionary<int, GameWeaponsClasse>();
        private GameWeaponsClasse selectedWeapon;
        private List<int> buttonshit = new List<int>();
        private int sizeField = 300;
        private int fieldHeight = 15;
        private int fieldWidth = 20;
        private int premiumScore;
        private int premiumEsmerald;
        private int typeBattle;
        private Random random = new Random();
        private string loginPlayer1;
        private string loginPlayer2;
        private int myside;
        private GameChatBatlleForms gameChatBatlleForms;
        private int myIndian;
        private bool MoveIndian;
        private bool myTurn;
        private int qntChestLeft;
        private int qntChestRight;

        public GameBattleForms(int typeBattle, int[] typesFieldRight, int[] typesFieldLeft, string loginPlayer1, string loginPlayer2, EventHandler PbxCloseBattle, EventHandler onDestroyedButton, GameChatBatlleForms gameChatBatlleForms, EventHandler SyncLocalIndian)
        {
            this.typeBattle = typeBattle;
            this.loginPlayer1 = loginPlayer1;
            this.loginPlayer2 = loginPlayer2;
            this.typesFieldRight = typesFieldRight;
            this.typesFieldLeft = typesFieldLeft;
            this.PbxCloseBattle = PbxCloseBattle;
            this.onDestroyedButton = onDestroyedButton;
            this.gameChatBatlleForms = gameChatBatlleForms;
            this.SyncLocalIndian = SyncLocalIndian;

            InitializeComponent();

            this.OnClickButtonField = OnClick_ButtonField;

        }

        private void GameBattleForms_Load(object sender, EventArgs e)
        {
            if (this.typeBattle == 0)
            {
                LoadWeaponsBattle();
            }
            this.lblPlayer1Name.Text = loginPlayer1;
            this.lblPlayer2Name.Text = loginPlayer2;
            this.lblQntChest.Text = "0";
            this.lblQntEsmrld.Text = "0";
            this.lblTurn.Text = "";
            LoadFieldLeft();
            LoadFieldRight();
        }

        private void LoadWeaponsBattle()
        {
            if (this.typeBattle != 0)//se não for tipo 1(sala inicial),  carrega na tela as armas escolhidas pelo jogador.
            {
                int x = 60;
                foreach (PbxWeaponBattle weapon in this.pbxWeapons.Values)
                {
                    weapon.Parent = this.pnlBattle;
                    weapon.Location = new Point(x, 496);
                    weapon.Click += this.OnClick_PbxWeaponBattle;
                    Label lblqntWeapon = new Label();
                    lblqntWeapon.Size = new Size(60, 15);
                    lblqntWeapon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    lblqntWeapon.ForeColor = System.Drawing.SystemColors.ButtonFace;
                    lblqntWeapon.Name = $"{weapon.GetIdItem()}";
                    lblqntWeapon.Text = weapon.GetQntItem() == -1 ? "" : Convert.ToString(weapon.GetQntItem());
                    lblqntWeapon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    lblqntWeapon.Location = new Point(x, 546);
                    this.pnlBattle.Controls.Add(lblqntWeapon);
                    this.lblQntWeapons.Add(weapon.GetIdItem(), lblqntWeapon);
                    weapon.Show();
                    x += 64;
                }
            }
            else
            {
                PbxWeaponBattle stone = new PbxWeaponBattle(1001, -1);
                stone.Parent = this.pnlBattle;
                stone.Location = new Point(60, 496);
                stone.Click += this.OnClick_PbxWeaponBattle;
                stone.Show();
                GameWeaponsClasse wstone = new GameWeaponsClasse(1001, 1, 0, 1, 1, 20, 1);
                this.weaponsBattle.Add(wstone.GetIdItem(), wstone);

                PbxWeaponBattle crossbow3 = new PbxWeaponBattle(1007, 1);
                crossbow3.Parent = this.pnlBattle;
                crossbow3.Location = new Point(124, 496);
                crossbow3.Click += this.OnClick_PbxWeaponBattle;
                crossbow3.Show();
                GameWeaponsClasse wcrossbow3 = new GameWeaponsClasse(1007, 3, 40, 8, 8, 20, 1);
                this.weaponsBattle.Add(wcrossbow3.GetIdItem(), wcrossbow3);
            }
        }

        public void SetWeaponsBattle(Dictionary<string, GameWeaponsClasse> weapons)
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new SetWeaponsBattleDelegate(SetWeaponsBattle), new object[] { weapons });
            }
            else
            {
                GameWeaponsClasse wstone = new GameWeaponsClasse(1001, 1, 0, 1, 1, 20, 1);
                this.weaponsBattle.Add(wstone.GetIdItem(), wstone);
                this.pbxWeapons.Add(1001, new PbxWeaponBattle(1001, -1));

                GameWeaponsClasse wrope = new GameWeaponsClasse(1011, 1, 0, 1, 1, 20, 0);
                this.weaponsBattle.Add(wrope.GetIdItem(), wrope);
                this.pbxWeapons.Add(1011, new PbxWeaponBattle(1011, -1));

                foreach (GameWeaponsClasse weapon in weapons.Values)
                {
                    this.weaponsBattle.Add(weapon.GetIdItem(), weapon);
                    this.pbxWeapons.Add(weapon.GetIdItem(), new PbxWeaponBattle(weapon.GetIdItem(), weapon.GetAmountWeapons()));
                }
                LoadWeaponsBattle();
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
                ButtonField btn = new ButtonField(img, i);
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
                    buttonFieldLefts[button].BackColorChanged += GameBattleForms_BackColorChanged;
                    if ((buttonFieldLefts[button].GetTypeButton() == 3) && myside == 0)
                    {
                        buttonFieldLefts[button].IndianButton();
                        this.myIndian = button;
                    }
                    if (buttonFieldLefts[button].GetTypeButton() == 3)
                    {
                        this.qntChestLeft += 1;
                    }
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
                ButtonField btn = new ButtonField(img, i);
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
                    buttonFieldRights[button].BackColorChanged += GameBattleForms_BackColorChanged;
                    if ((buttonFieldRights[button].GetTypeButton() == 3) && myside == 1)
                    {
                        buttonFieldRights[button].IndianButton();
                        this.myIndian = button;
                    }
                    if (buttonFieldRights[button].GetTypeButton() == 3)
                    {
                        this.qntChestRight += 1;
                    }
                    buttonFieldRights[button].Show();
                    x += 25;
                    button++;
                }
                y += 27;
                x = 12;
            }
        }
        private void panelUp_MouseMove(object sender, MouseEventArgs e)
        {
            this.moveForms.Move(this.Handle);
        }
        private void GameBattleForms_BackColorChanged(object sender, EventArgs e)
        {
            ButtonField button = sender as ButtonField;
            if (button.BackColor == Color.Red)
            {
                this.buttonshit.Add(button.GetIdButton());
            }
        }

        public void SetSideField(string loginPlayer)
        {
            if (this.loginPlayer1 == loginPlayer)
            {
                pnlFieldLeft.Enabled = false;
                this.myside = 0;
                this.myTurn = true;
            }
            else
            {
                pnlFieldRight.Enabled = false;
                this.myside = 1;
                this.myTurn = false;
            }
        }

        public void SyncIndianLocal(int newLocal, int oldLocal)
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new SyncLocalIndianDelegate(SyncIndianLocal), new object[] { newLocal, oldLocal });
            }
            else
            {
                if (myside == 0)
                {
                    buttonFieldRights[oldLocal].SetTypeButton(0);
                    buttonFieldRights[newLocal].SetTypeButton(3);
                }
                else
                {
                    buttonFieldLefts[oldLocal].SetTypeButton(0);
                    buttonFieldLefts[newLocal].SetTypeButton(3);
                }
            }
        }

        public void DestroyedButton(int[] locals, bool mysidefield, int typeItem)
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new DestroyedButtonDelegate(DestroyedButton), new object[] { locals, mysidefield, typeItem });
            }
            else
            {
                if (this.myside == 0)
                {
                    if (mysidefield)
                    {
                        for (int i = 0; i < locals.Length; i++)
                        {
                            this.buttonFieldLefts[locals[i]].DestroyedButton();
                            switch (this.buttonFieldLefts[locals[i]].GetTypeButton())
                            {
                                case 0:
                                    this.buttonFieldLefts[locals[i]].Enabled = false;
                                    break;
                                case 1:
                                    if (typeItem == 0)
                                        this.buttonFieldLefts[locals[i]].EsmeraldButton();
                                    this.buttonFieldLefts[locals[i]].Enabled = false;
                                    break;
                                case 2:
                                    if (typeItem == 0)
                                        this.buttonFieldLefts[locals[i]].BauButton();
                                    this.buttonFieldLefts[locals[i]].Enabled = false;
                                    MessageBox.Show($"{this.buttonFieldLefts[locals[i]].Name}\nBaú");
                                    break;
                                case 3:
                                    this.pnlFieldLeft.Enabled = true;
                                    this.selectedWeapon = null;
                                    this.buttonFieldLefts[locals[i]].Enabled = false;
                                    this.MoveIndian = true;
                                    this.pnlFieldRight.Enabled = false;
                                    MessageBox.Show("Move Your Indian!");
                                    if (typeItem == 1)
                                    {
                                        Lost();
                                    }
                                    break;
                            }
                        }
                        this.myTurn = this.MoveIndian == true ? false : true;
                        if (this.myTurn) { this.lblTurn.Text = "Your Turn"; }
                    }
                    else
                    {
                        for (int i = 0; i < locals.Length; i++)
                        {
                            this.buttonFieldRights[locals[i]].DestroyedButton();
                            switch (this.buttonFieldRights[locals[i]].GetTypeButton())
                            {
                                case 1:
                                    if (this.selectedWeapon.GetTypeItem() != 1)
                                    {
                                        this.buttonFieldRights[locals[i]].EsmeraldButton();
                                        this.lblQntEsmrld.Text = Convert.ToString(Convert.ToInt32(this.lblQntEsmrld.Text) + 1);
                                    }
                                    break;
                                case 2:
                                    if (this.selectedWeapon.GetTypeItem() != 1)
                                    {
                                        this.buttonFieldRights[locals[i]].BauButton();
                                        this.lblQntChest.Text = Convert.ToString(Convert.ToInt32(this.lblQntChest.Text) + 1);
                                        int valorChest = 0;
                                        switch (this.typeBattle)
                                        {
                                            case 1:
                                                valorChest = 100;
                                                break;
                                            case 2:
                                                valorChest = 250;
                                                break;
                                            case 3:
                                                valorChest = 500;
                                                break;
                                            case 4:
                                                valorChest = 1000;
                                                break;
                                            case 5:
                                                valorChest = 2500;
                                                break;
                                            case 6:
                                                valorChest = 5000;
                                                break;
                                            case 7:
                                                valorChest = this.myside == 0 ? (this.premiumEsmerald / this.qntChestRight) : (this.premiumEsmerald / this.qntChestLeft);
                                                break;
                                        }
                                        this.lblQntEsmrld.Text = Convert.ToString(Convert.ToInt32(this.lblQntEsmrld.Text) + valorChest);
                                    }
                                    break;
                                case 3:
                                    this.buttonFieldRights[locals[i]].IndianButton();
                                    if (this.selectedWeapon.GetTypeItem() != 0)
                                    {
                                        Win();
                                    }
                                    break;
                            }
                            this.buttonFieldRights[locals[i]].Enabled = false;
                        }
                    }
                }
                else
                {
                    if (mysidefield)
                    {
                        for (int i = 0; i < locals.Length; i++)
                        {
                            this.buttonFieldRights[locals[i]].DestroyedButton();
                            switch (this.buttonFieldRights[locals[i]].GetTypeButton())
                            {
                                case 0:
                                    this.buttonFieldRights[locals[i]].Enabled = false;
                                    break;
                                case 1:
                                    if (typeItem == 0)
                                        this.buttonFieldRights[locals[i]].EsmeraldButton();
                                    this.buttonFieldRights[locals[i]].Enabled = false;
                                    break;
                                case 2:
                                    if (typeItem == 0)
                                        this.buttonFieldRights[locals[i]].BauButton();
                                    this.buttonFieldRights[locals[i]].Enabled = false;
                                    MessageBox.Show($"{this.buttonFieldRights[locals[i]].Name}\nBaú");
                                    break;
                                case 3:
                                    this.pnlFieldRight.Enabled = true;
                                    this.selectedWeapon = null;
                                    this.buttonFieldRights[locals[i]].Enabled = false;
                                    this.MoveIndian = true;
                                    this.pnlFieldLeft.Enabled = false;
                                    MessageBox.Show("Move Your Indian!");
                                    if (typeItem == 1)
                                    {
                                        Lost();
                                    }
                                    break;
                            }
                        }
                        this.myTurn = this.MoveIndian == true ? false : true;
                        if (this.myTurn) { this.lblTurn.Text = "Your Turn"; }
                    }
                    else
                    {
                        for (int i = 0; i < locals.Length; i++)
                        {
                            this.buttonFieldLefts[locals[i]].DestroyedButton();
                            switch (this.buttonFieldLefts[locals[i]].GetTypeButton())
                            {
                                case 1:
                                    if (this.selectedWeapon.GetTypeItem() != 1)
                                    {
                                        this.buttonFieldLefts[locals[i]].EsmeraldButton();
                                        this.lblQntEsmrld.Text = Convert.ToString(Convert.ToInt32(this.lblQntEsmrld.Text) + 1);
                                    }
                                    break;
                                case 2:
                                    if (this.selectedWeapon.GetTypeItem() != 1)
                                    {
                                        this.buttonFieldLefts[locals[i]].BauButton();
                                        this.lblQntChest.Text = Convert.ToString(Convert.ToInt32(this.lblQntChest.Text) + 1);
                                        int valorChest = 0;
                                        switch (this.typeBattle)
                                        {
                                            case 1:
                                                valorChest = 100;
                                                break;
                                            case 2:
                                                valorChest = 250;
                                                break;
                                            case 3:
                                                valorChest = 500;
                                                break;
                                            case 4:
                                                valorChest = 1000;
                                                break;
                                            case 5:
                                                valorChest = 2500;
                                                break;
                                            case 6:
                                                valorChest = 5000;
                                                break;
                                            case 7:
                                                valorChest = this.myside == 0 ? (this.premiumEsmerald / this.qntChestRight) : (this.premiumEsmerald / this.qntChestLeft);
                                                break;
                                        }
                                        this.lblQntEsmrld.Text = Convert.ToString(Convert.ToInt32(this.lblQntEsmrld.Text) + valorChest);
                                    }
                                    break;
                                case 3:
                                    buttonFieldLefts[locals[i]].IndianButton();
                                    if (this.selectedWeapon.GetTypeItem() != 0)
                                    {
                                        Win();
                                    }
                                    break;
                            }
                            this.buttonFieldLefts[locals[i]].Enabled = false;
                        }
                    }
                }
            }
        }

        private void OnClick_ButtonField(object sender, EventArgs e)
        {
            if (this.selectedWeapon != null && this.myTurn == true && this.MoveIndian == false)
            {
                int[] locals = this.buttonshit.ToArray();
                if (this.selectedWeapon.GetIdItem() == 1003)
                {
                    int[] localsrand = { this.buttonshit[0], this.buttonshit[1] };
                    locals = localsrand;
                }
                if (this.selectedWeapon.GetIdItem() == 1004)
                {
                    int[] localsrand = { this.buttonshit[0], this.buttonshit[1], this.buttonshit[2], this.buttonshit[3] };
                    locals = localsrand;
                }

                this.DestroyedButton(locals, false, selectedWeapon.GetTypeItem());
                this.onDestroyedButton.Invoke(this, new BtnDestroyedsEventArgs
                {
                    locals = locals,
                    loginPlayer = this.myside == 0 ? this.loginPlayer2 : this.loginPlayer1,
                    typeItem = selectedWeapon.GetTypeItem()
                });
                if (this.selectedWeapon.GetIdItem() != 1001 && this.selectedWeapon.GetIdItem() != 1011)
                {
                    this.lblQntWeapons[this.selectedWeapon.GetIdItem()].Text = Convert.ToString(Convert.ToInt32(this.lblQntWeapons[this.selectedWeapon.GetIdItem()].Text) - 1);
                    if (Convert.ToInt32(this.lblQntWeapons[this.selectedWeapon.GetIdItem()].Text) == 0) { this.pbxWeapons[this.selectedWeapon.GetIdItem()].Enabled = false; }
                }
                this.selectedWeapon = null;
                this.myTurn = false;
                this.MoveIndian = false;

            }
            else
            {
                if (myside == 0 && this.MoveIndian == true)
                {
                    ButtonField button = sender as ButtonField;
                    button.SetTypeButton(3);
                    button.IndianButton();
                    buttonFieldLefts[this.myIndian].RestorButton();
                    int oldLocal = this.myIndian;
                    this.myIndian = button.GetIdButton();
                    this.pnlFieldLeft.Enabled = false;
                    this.pnlFieldRight.Enabled = true;
                    this.SyncLocalIndian.Invoke(this, new SyncLocalIndianEventArgs
                    {
                        newLocal = this.myIndian,
                        oldLocal = oldLocal,
                        loginPlayer = this.loginPlayer2
                    });
                    this.MoveIndian = false;
                    this.myTurn = true;
                }
                else if (myside == 1 && this.MoveIndian == true)
                {
                    ButtonField button = sender as ButtonField;
                    button.SetTypeButton(3);
                    button.IndianButton();
                    buttonFieldRights[this.myIndian].RestorButton();
                    int oldLocal = this.myIndian;
                    this.myIndian = button.GetIdButton();
                    this.pnlFieldRight.Enabled = false;
                    this.pnlFieldLeft.Enabled = true;
                    this.SyncLocalIndian.Invoke(this, new SyncLocalIndianEventArgs
                    {
                        newLocal = this.myIndian,
                        oldLocal = oldLocal,
                        loginPlayer = this.loginPlayer1
                    });
                    this.MoveIndian = false;
                    this.myTurn = true;
                }
            }
            if (this.MoveIndian == false && this.myTurn == false)
            {
                this.lblTurn.Text = "Opponent's Turn";
            }
        }

        private void OnClick_PbxWeaponBattle(object sender, EventArgs e)
        {
            if (this.myTurn && this.MoveIndian == false)
            {
                PbxWeaponBattle weapon = sender as PbxWeaponBattle;
                this.selectedWeapon = this.weaponsBattle[weapon.GetIdItem()];
                if (this.myside == 0)
                {
                    for (int i = 0; i < this.buttonFieldRights.Count; i++)
                    {
                        this.buttonFieldRights[i].MouseEnter += this.AimField;
                    }
                }
                else
                {
                    for (int i = 0; i < this.buttonFieldRights.Count; i++)
                    {
                        this.buttonFieldLefts[i].MouseEnter += this.AimField;
                    }
                }

                weapon.Enabled = this.lblQntWeapons[weapon.GetIdItem()].Text != "0" ? true : false;
            }
        }

        private void AimField(object sender, EventArgs ea)
        {
            if (this.selectedWeapon != null)
            {

                Dictionary<int, ButtonField> field;
                if (this.myside == 0)
                {
                    for (int i = 0; i < this.buttonshit.Count; i++)
                    {
                        this.buttonFieldRights[this.buttonshit[i]].BackColor = Color.Transparent;
                    }
                    this.buttonshit.Clear();
                    field = this.buttonFieldRights;
                }
                else
                {
                    for (int i = 0; i < this.buttonshit.Count; i++)
                    {
                        this.buttonFieldLefts[this.buttonshit[i]].BackColor = Color.Transparent;
                    }
                    this.buttonshit.Clear();
                    field = this.buttonFieldLefts;
                }
                ButtonField buttonField = sender as ButtonField;
                buttonField.BackColor = Color.Red;

                int x = (this.selectedWeapon.GetDestructionAreaItem()) - 1;
                int b = 0;
                int c = 0;
                int[] limitRight = { 19, 39, 59, 79, 99, 119, 139, 159, 179, 199, 219, 239, 259, 279, 299 };
                int[] limitLeft = { 0, 20, 40, 60, 80, 100, 120, 140, 160, 180, 200, 220, 240, 260, 280 };
                switch (this.selectedWeapon.GetIdItem())
                {
                    case 1001:
                        break;
                    case 1002:
                        if (limitRight.Contains(buttonField.GetIdButton()) == false && myside == 0)
                        {
                            try { if (field[(buttonField.GetIdButton()) + 1].Enabled == true) { field[(buttonField.GetIdButton()) + 1].BackColor = Color.Red; } } catch { }
                        }
                        else if (limitLeft.Contains(buttonField.GetIdButton()) == false && myside == 1)
                        {
                            try { if (field[(buttonField.GetIdButton()) - 1].Enabled == true) { field[(buttonField.GetIdButton()) - 1].BackColor = Color.Red; } } catch { }
                        }
                        break;
                    case 1003:
                        b += 20;
                        c -= 20;
                        if (limitRight.Contains(buttonField.GetIdButton()) == false)
                        {
                            try { if (field[(buttonField.GetIdButton()) + b + 1].Enabled == true) { field[(buttonField.GetIdButton()) + b + 1].BackColor = Color.Red; } } catch { }
                            try { if (field[(buttonField.GetIdButton()) + c + 1].Enabled == true) { field[(buttonField.GetIdButton()) + c + 1].BackColor = Color.Red; } } catch { }
                            try { if (field[(buttonField.GetIdButton()) + 1].Enabled == true) { field[(buttonField.GetIdButton()) + 1].BackColor = Color.Red; } } catch { }
                        }
                        if (limitLeft.Contains(buttonField.GetIdButton()) == false)
                        {
                            try { if (field[(buttonField.GetIdButton()) + b - 1].Enabled == true) { field[(buttonField.GetIdButton()) + b - 1].BackColor = Color.Red; } } catch { }
                            try { if (field[(buttonField.GetIdButton()) + c - 1].Enabled == true) { field[(buttonField.GetIdButton()) + c - 1].BackColor = Color.Red; } } catch { }
                            try { if (field[(buttonField.GetIdButton()) - 1].Enabled == true) { field[(buttonField.GetIdButton()) - 1].BackColor = Color.Red; } } catch { }
                        }
                        try { if (field[(buttonField.GetIdButton()) + b].Enabled == true) { field[(buttonField.GetIdButton()) + b].BackColor = Color.Red; } } catch { }
                        try { if (field[(buttonField.GetIdButton()) + c].Enabled == true) { field[(buttonField.GetIdButton()) + c].BackColor = Color.Red; } } catch { }
                        break;
                    case 1004:
                        for (int i = 1; i < x; i++)
                        {
                            b += 20;
                            c -= 20;
                            if (limitRight.Contains(buttonField.GetIdButton()) == false)
                            {
                                try { if (field[(buttonField.GetIdButton()) + b + 1].Enabled == true) { field[(buttonField.GetIdButton()) + b + 1].BackColor = Color.Red; } } catch { }
                                try { if (field[(buttonField.GetIdButton()) + c + 1].Enabled == true) { field[(buttonField.GetIdButton()) + c + 1].BackColor = Color.Red; } } catch { }
                                try { if (field[(buttonField.GetIdButton()) + 1].Enabled == true) { field[(buttonField.GetIdButton()) + 1].BackColor = Color.Red; } } catch { }
                                if (limitRight.Contains(buttonField.GetIdButton() + 1) == false)
                                {
                                    try { if (field[(buttonField.GetIdButton()) + 2].Enabled == true) { field[(buttonField.GetIdButton()) + 2].BackColor = Color.Red; } } catch { }
                                    try { if (field[(buttonField.GetIdButton()) + b + 2].Enabled == true) { field[(buttonField.GetIdButton()) + b + 2].BackColor = Color.Red; } } catch { }
                                    try { if (field[(buttonField.GetIdButton()) + c + 2].Enabled == true) { field[(buttonField.GetIdButton()) + c + 2].BackColor = Color.Red; } } catch { }
                                }
                            }
                            if (limitLeft.Contains(buttonField.GetIdButton()) == false)
                            {
                                try { if (field[(buttonField.GetIdButton()) + b - 1].Enabled == true) { field[(buttonField.GetIdButton()) + b - 1].BackColor = Color.Red; } } catch { }
                                try { if (field[(buttonField.GetIdButton()) + c - 1].Enabled == true) { field[(buttonField.GetIdButton()) + c - 1].BackColor = Color.Red; } } catch { }
                                try { if (field[(buttonField.GetIdButton()) - 1].Enabled == true) { field[(buttonField.GetIdButton()) - 1].BackColor = Color.Red; } } catch { }
                                if (limitLeft.Contains(buttonField.GetIdButton() - 1) == false)
                                {
                                    try { if (field[(buttonField.GetIdButton()) - 2].Enabled == true) { field[(buttonField.GetIdButton()) - 2].BackColor = Color.Red; } } catch { }
                                    try { if (field[(buttonField.GetIdButton()) + b - 2].Enabled == true) { field[(buttonField.GetIdButton()) + b - 2].BackColor = Color.Red; } } catch { }
                                    try { if (field[(buttonField.GetIdButton()) + c - 2].Enabled == true) { field[(buttonField.GetIdButton()) + c - 2].BackColor = Color.Red; } } catch { }
                                }
                            }
                            try { if (field[(buttonField.GetIdButton()) + b].Enabled == true) { field[(buttonField.GetIdButton()) + b].BackColor = Color.Red; } } catch { }
                            try { if (field[(buttonField.GetIdButton()) + c].Enabled == true) { field[(buttonField.GetIdButton()) + c].BackColor = Color.Red; } } catch { }
                        }
                        break;
                    case 1005:
                        int d = 0;
                        for (int i = 0; i < x; i++)
                        {
                            d += myside == 0 ? 1 : -1;
                            if ((limitRight.Contains(buttonField.GetIdButton() + d) && myside == 1) || (limitLeft.Contains(buttonField.GetIdButton() + d) && myside == 0)) { break; }
                            try { if (field[(buttonField.GetIdButton()) + d].Enabled == true) { field[(buttonField.GetIdButton()) + d].BackColor = Color.Red; } } catch { }
                        }
                        break;
                    case 1006:
                        d = 0;
                        for (int i = 0; i < x; i++)
                        {
                            d += myside == 0 ? 1 : -1;
                            if ((limitRight.Contains(buttonField.GetIdButton() + d) && myside == 1) || (limitLeft.Contains(buttonField.GetIdButton() + d) && myside == 0)) { break; }
                            try { if (field[(buttonField.GetIdButton()) + d].Enabled == true) { field[(buttonField.GetIdButton()) + d].BackColor = Color.Red; } } catch { }
                        }
                        break;
                    case 1007:
                        d = 0;
                        for (int i = 0; i < x; i++)
                        {
                            d += myside == 0 ? 1 : -1;
                            if ((limitRight.Contains(buttonField.GetIdButton() + d) && myside == 1) || (limitLeft.Contains(buttonField.GetIdButton() + d) && myside == 0)) { break; }
                            try { if (field[(buttonField.GetIdButton()) + d].Enabled == true) { field[(buttonField.GetIdButton()) + d].BackColor = Color.Red; } } catch { }
                        }
                        break;
                    case 1008:
                        b += 20;
                        c -= 20;
                        if (limitRight.Contains(buttonField.GetIdButton()) == false)
                        {
                            try { if (field[(buttonField.GetIdButton()) + 1].Enabled == true) { field[(buttonField.GetIdButton()) + 1].BackColor = Color.Red; } } catch { }
                            try { if (field[(buttonField.GetIdButton()) + b + 1].Enabled == true) { field[(buttonField.GetIdButton()) + b + 1].BackColor = Color.Red; } } catch { }
                            try { if (field[(buttonField.GetIdButton()) + c + 1].Enabled == true) { field[(buttonField.GetIdButton()) + c + 1].BackColor = Color.Red; } } catch { }
                        }
                        if (limitLeft.Contains(buttonField.GetIdButton()) == false)
                        {
                            try { if (field[(buttonField.GetIdButton()) - 1].Enabled == true) { field[(buttonField.GetIdButton()) - 1].BackColor = Color.Red; } } catch { }
                            try { if (field[(buttonField.GetIdButton()) + b - 1].Enabled == true) { field[(buttonField.GetIdButton()) + b - 1].BackColor = Color.Red; } } catch { }
                            try { if (field[(buttonField.GetIdButton()) + c - 1].Enabled == true) { field[(buttonField.GetIdButton()) + c - 1].BackColor = Color.Red; } } catch { }
                        }
                        try { if (field[(buttonField.GetIdButton()) + c].Enabled == true) { field[(buttonField.GetIdButton()) + c].BackColor = Color.Red; } } catch { }
                        try { if (field[(buttonField.GetIdButton()) + b].Enabled == true) { field[(buttonField.GetIdButton()) + b].BackColor = Color.Red; } } catch { }
                        break;
                    case 1009:
                        for (int i = 0; i < x; i++)
                        {
                            b += 20;
                            c -= 20;
                            if (limitRight.Contains(buttonField.GetIdButton()) == false)
                            {
                                try { if (field[(buttonField.GetIdButton()) + b + 1].Enabled == true) { field[(buttonField.GetIdButton()) + b + 1].BackColor = Color.Red; } } catch { }
                                try { if (field[(buttonField.GetIdButton()) + c + 1].Enabled == true) { field[(buttonField.GetIdButton()) + c + 1].BackColor = Color.Red; } } catch { }
                                try { if (field[(buttonField.GetIdButton()) + 1].Enabled == true) { field[(buttonField.GetIdButton()) + 1].BackColor = Color.Red; } } catch { }
                                if (limitRight.Contains(buttonField.GetIdButton() + 1) == false)
                                {
                                    try { if (field[(buttonField.GetIdButton()) + b + 2].Enabled == true) { field[(buttonField.GetIdButton()) + b + 2].BackColor = Color.Red; } } catch { }
                                    try { if (field[(buttonField.GetIdButton()) + c + 2].Enabled == true) { field[(buttonField.GetIdButton()) + c + 2].BackColor = Color.Red; } } catch { }
                                    try { if (field[(buttonField.GetIdButton()) + 2].Enabled == true) { field[(buttonField.GetIdButton()) + 2].BackColor = Color.Red; } } catch { }
                                    if (limitRight.Contains(buttonField.GetIdButton() + 2) == false)
                                    {
                                        try { if (field[(buttonField.GetIdButton()) + b + 3].Enabled == true) { field[(buttonField.GetIdButton()) + b + 3].BackColor = Color.Red; } } catch { }
                                        try { if (field[(buttonField.GetIdButton()) + c + 3].Enabled == true) { field[(buttonField.GetIdButton()) + c + 3].BackColor = Color.Red; } } catch { }
                                        try { if (field[(buttonField.GetIdButton()) + 3].Enabled == true) { field[(buttonField.GetIdButton()) + 3].BackColor = Color.Red; } } catch { }
                                    }
                                }
                            }
                            if (limitLeft.Contains(buttonField.GetIdButton()) == false)
                            {
                                try { if (field[(buttonField.GetIdButton()) + b - 1].Enabled == true) { field[(buttonField.GetIdButton()) + b - 1].BackColor = Color.Red; } } catch { }
                                try { if (field[(buttonField.GetIdButton()) + c - 1].Enabled == true) { field[(buttonField.GetIdButton()) + c - 1].BackColor = Color.Red; } } catch { }
                                try { if (field[(buttonField.GetIdButton()) - 1].Enabled == true) { field[(buttonField.GetIdButton()) - 1].BackColor = Color.Red; } } catch { }
                                if (limitLeft.Contains(buttonField.GetIdButton() - 1) == false)
                                {
                                    try { if (field[(buttonField.GetIdButton()) + b - 2].Enabled == true) { field[(buttonField.GetIdButton()) + b - 2].BackColor = Color.Red; } } catch { }
                                    try { if (field[(buttonField.GetIdButton()) + c - 2].Enabled == true) { field[(buttonField.GetIdButton()) + c - 2].BackColor = Color.Red; } } catch { }
                                    try { if (field[(buttonField.GetIdButton()) - 2].Enabled == true) { field[(buttonField.GetIdButton()) - 2].BackColor = Color.Red; } } catch { }
                                    if (limitLeft.Contains(buttonField.GetIdButton() - 2) == false)
                                    {
                                        try { if (field[(buttonField.GetIdButton()) + b - 3].Enabled == true) { field[(buttonField.GetIdButton()) + b - 3].BackColor = Color.Red; } } catch { }
                                        try { if (field[(buttonField.GetIdButton()) + c - 3].Enabled == true) { field[(buttonField.GetIdButton()) + c - 3].BackColor = Color.Red; } } catch { }
                                        try { if (field[(buttonField.GetIdButton()) - 3].Enabled == true) { field[(buttonField.GetIdButton()) - 3].BackColor = Color.Red; } } catch { }
                                    }
                                }
                            }
                            try { if (field[(buttonField.GetIdButton()) + b].Enabled == true) { field[(buttonField.GetIdButton()) + b].BackColor = Color.Red; } } catch { }
                            try { if (field[(buttonField.GetIdButton()) + c].Enabled == true) { field[(buttonField.GetIdButton()) + c].BackColor = Color.Red; } } catch { }
                        }
                        break;
                    case 1010:
                        for (int i = 0; i < x; i++)
                        {
                            b += 20;
                            c -= 20;
                            if (limitRight.Contains(buttonField.GetIdButton()) == false)
                            {
                                try { if (field[(buttonField.GetIdButton()) + 1].Enabled == true) { field[(buttonField.GetIdButton()) + 1].BackColor = Color.Red; } } catch { }
                                try { if (field[(buttonField.GetIdButton()) + b + 1].Enabled == true) { field[(buttonField.GetIdButton()) + b + 1].BackColor = Color.Red; } } catch { }
                                try { if (field[(buttonField.GetIdButton()) + c + 1].Enabled == true) { field[(buttonField.GetIdButton()) + c + 1].BackColor = Color.Red; } } catch { }
                                if (limitRight.Contains(buttonField.GetIdButton() + 1) == false)
                                {
                                    try { if (field[(buttonField.GetIdButton()) + 2].Enabled == true) { field[(buttonField.GetIdButton()) + 2].BackColor = Color.Red; } } catch { }
                                    try { if (field[(buttonField.GetIdButton()) + b + 2].Enabled == true) { field[(buttonField.GetIdButton()) + b + 2].BackColor = Color.Red; } } catch { }
                                    try { if (field[(buttonField.GetIdButton()) + c + 2].Enabled == true) { field[(buttonField.GetIdButton()) + c + 2].BackColor = Color.Red; } } catch { }
                                    if (limitRight.Contains(buttonField.GetIdButton() + 2) == false)
                                    {
                                        try { if (field[(buttonField.GetIdButton()) + 3].Enabled == true) { field[(buttonField.GetIdButton()) + 3].BackColor = Color.Red; } } catch { }
                                        try { if (field[(buttonField.GetIdButton()) + b + 3].Enabled == true) { field[(buttonField.GetIdButton()) + b + 3].BackColor = Color.Red; } } catch { }
                                        try { if (field[(buttonField.GetIdButton()) + c + 3].Enabled == true) { field[(buttonField.GetIdButton()) + c + 3].BackColor = Color.Red; } } catch { }
                                        if (limitRight.Contains(buttonField.GetIdButton() + 3) == false)
                                        {
                                            try { if (field[(buttonField.GetIdButton()) + 4].Enabled == true) { field[(buttonField.GetIdButton()) + 4].BackColor = Color.Red; } } catch { }
                                            try { if (field[(buttonField.GetIdButton()) + b + 4].Enabled == true) { field[(buttonField.GetIdButton()) + b + 4].BackColor = Color.Red; } } catch { }
                                            try { if (field[(buttonField.GetIdButton()) + c + 4].Enabled == true) { field[(buttonField.GetIdButton()) + c + 4].BackColor = Color.Red; } } catch { }
                                        }
                                    }
                                }
                            }
                            if (limitLeft.Contains(buttonField.GetIdButton()) == false)
                            {
                                try { if (field[(buttonField.GetIdButton()) - 1].Enabled == true) { field[(buttonField.GetIdButton()) - 1].BackColor = Color.Red; } } catch { }
                                try { if (field[(buttonField.GetIdButton()) + b - 1].Enabled == true) { field[(buttonField.GetIdButton()) + b - 1].BackColor = Color.Red; } } catch { }
                                try { if (field[(buttonField.GetIdButton()) + c - 1].Enabled == true) { field[(buttonField.GetIdButton()) + c - 1].BackColor = Color.Red; } } catch { }
                                if (limitLeft.Contains(buttonField.GetIdButton() - 1) == false)
                                {
                                    try { if (field[(buttonField.GetIdButton()) - 2].Enabled == true) { field[(buttonField.GetIdButton()) - 2].BackColor = Color.Red; } } catch { }
                                    try { if (field[(buttonField.GetIdButton()) + b - 2].Enabled == true) { field[(buttonField.GetIdButton()) + b - 2].BackColor = Color.Red; } } catch { }
                                    try { if (field[(buttonField.GetIdButton()) + c - 2].Enabled == true) { field[(buttonField.GetIdButton()) + c - 2].BackColor = Color.Red; } } catch { }
                                    if (limitLeft.Contains(buttonField.GetIdButton() - 2) == false)
                                    {
                                        try { if (field[(buttonField.GetIdButton()) - 3].Enabled == true) { field[(buttonField.GetIdButton()) - 3].BackColor = Color.Red; } } catch { }
                                        try { if (field[(buttonField.GetIdButton()) + b - 3].Enabled == true) { field[(buttonField.GetIdButton()) + b - 3].BackColor = Color.Red; } } catch { }
                                        try { if (field[(buttonField.GetIdButton()) + c - 3].Enabled == true) { field[(buttonField.GetIdButton()) + c - 3].BackColor = Color.Red; } } catch { }
                                        if (limitLeft.Contains(buttonField.GetIdButton() - 3) == false)
                                        {

                                            try { if (field[(buttonField.GetIdButton()) - 4].Enabled == true) { field[(buttonField.GetIdButton()) - 4].BackColor = Color.Red; } } catch { }
                                            try { if (field[(buttonField.GetIdButton()) + b - 4].Enabled == true) { field[(buttonField.GetIdButton()) + b - 4].BackColor = Color.Red; } } catch { }
                                            try { if (field[(buttonField.GetIdButton()) + c - 4].Enabled == true) { field[(buttonField.GetIdButton()) + c - 4].BackColor = Color.Red; } } catch { }
                                        }
                                    }
                                }
                            }
                            try { if (field[(buttonField.GetIdButton()) + c].Enabled == true) { field[(buttonField.GetIdButton()) + c].BackColor = Color.Red; } } catch { }
                            try { if (field[(buttonField.GetIdButton()) + b].Enabled == true) { field[(buttonField.GetIdButton()) + b].BackColor = Color.Red; } } catch { }
                        }
                        break;
                    case 1011:
                        break;
                    case 1012:
                        break;
                    case 1013:
                        break;
                    case 1014:
                        break;
                    case 1015:
                        for (int i = 0; i < x; i++)
                        {
                            b += 20;
                            c -= 20;
                            if (limitRight.Contains(buttonField.GetIdButton()) == false)
                            {
                                try { if (field[(buttonField.GetIdButton()) + b + 1].Enabled == true) { field[(buttonField.GetIdButton()) + b + 1].BackColor = Color.Red; } } catch { }
                                try { if (field[(buttonField.GetIdButton()) + c + 1].Enabled == true) { field[(buttonField.GetIdButton()) + c + 1].BackColor = Color.Red; } } catch { }
                                try { if (field[(buttonField.GetIdButton()) + 1].Enabled == true) { field[(buttonField.GetIdButton()) + 1].BackColor = Color.Red; } } catch { }
                                if (limitRight.Contains(buttonField.GetIdButton() + 1) == false)
                                {
                                    try { if (field[(buttonField.GetIdButton()) + 2].Enabled == true) { field[(buttonField.GetIdButton()) + 2].BackColor = Color.Red; } } catch { }
                                    try { if (field[(buttonField.GetIdButton()) + b + 2].Enabled == true) { field[(buttonField.GetIdButton()) + b + 2].BackColor = Color.Red; } } catch { }
                                    try { if (field[(buttonField.GetIdButton()) + c + 2].Enabled == true) { field[(buttonField.GetIdButton()) + c + 2].BackColor = Color.Red; } } catch { }
                                }
                            }
                            if (limitLeft.Contains(buttonField.GetIdButton()) == false)
                            {
                                try { if (field[(buttonField.GetIdButton()) + b - 1].Enabled == true) { field[(buttonField.GetIdButton()) + b - 1].BackColor = Color.Red; } } catch { }
                                try { if (field[(buttonField.GetIdButton()) + c - 1].Enabled == true) { field[(buttonField.GetIdButton()) + c - 1].BackColor = Color.Red; } } catch { }
                                try { if (field[(buttonField.GetIdButton()) - 1].Enabled == true) { field[(buttonField.GetIdButton()) - 1].BackColor = Color.Red; } } catch { }
                                if (limitLeft.Contains(buttonField.GetIdButton() - 1) == false)
                                {
                                    try { if (field[(buttonField.GetIdButton()) - 2].Enabled == true) { field[(buttonField.GetIdButton()) - 2].BackColor = Color.Red; } } catch { }
                                    try { if (field[(buttonField.GetIdButton()) + b - 2].Enabled == true) { field[(buttonField.GetIdButton()) + b - 2].BackColor = Color.Red; } } catch { }
                                    try { if (field[(buttonField.GetIdButton()) + c - 2].Enabled == true) { field[(buttonField.GetIdButton()) + c - 2].BackColor = Color.Red; } } catch { }
                                }
                            }
                            try { if (field[(buttonField.GetIdButton()) + b].Enabled == true) { field[(buttonField.GetIdButton()) + b].BackColor = Color.Red; } } catch { }
                            try { if (field[(buttonField.GetIdButton()) + c].Enabled == true) { field[(buttonField.GetIdButton()) + c].BackColor = Color.Red; } } catch { }
                        }
                        break;
                    case 1016:
                        for (int i = 0; i < x; i++)
                        {
                            b += 20;
                            c -= 20;
                            if (limitRight.Contains(buttonField.GetIdButton()) == false)
                            {
                                try { if (field[(buttonField.GetIdButton()) + 1].Enabled == true) { field[(buttonField.GetIdButton()) + 1].BackColor = Color.Red; } } catch { }
                                try { if (field[(buttonField.GetIdButton()) + b + 1].Enabled == true) { field[(buttonField.GetIdButton()) + b + 1].BackColor = Color.Red; } } catch { }
                                try { if (field[(buttonField.GetIdButton()) + c + 1].Enabled == true) { field[(buttonField.GetIdButton()) + c + 1].BackColor = Color.Red; } } catch { }
                                if (limitRight.Contains(buttonField.GetIdButton() + 1) == false)
                                {
                                    try { if (field[(buttonField.GetIdButton()) + 2].Enabled == true) { field[(buttonField.GetIdButton()) + 2].BackColor = Color.Red; } } catch { }
                                    try { if (field[(buttonField.GetIdButton()) + b + 2].Enabled == true) { field[(buttonField.GetIdButton()) + b + 2].BackColor = Color.Red; } } catch { }
                                    try { if (field[(buttonField.GetIdButton()) + c + 2].Enabled == true) { field[(buttonField.GetIdButton()) + c + 2].BackColor = Color.Red; } } catch { }
                                    if (limitRight.Contains(buttonField.GetIdButton() + 2) == false)
                                    {
                                        try { if (field[(buttonField.GetIdButton()) + 3].Enabled == true) { field[(buttonField.GetIdButton()) + 3].BackColor = Color.Red; } } catch { }
                                        try { if (field[(buttonField.GetIdButton()) + b + 3].Enabled == true) { field[(buttonField.GetIdButton()) + b + 3].BackColor = Color.Red; } } catch { }
                                        try { if (field[(buttonField.GetIdButton()) + c + 3].Enabled == true) { field[(buttonField.GetIdButton()) + c + 3].BackColor = Color.Red; } } catch { }
                                        if (limitRight.Contains(buttonField.GetIdButton() + 3) == false)
                                        {
                                            try { if (field[(buttonField.GetIdButton()) + 4].Enabled == true) { field[(buttonField.GetIdButton()) + 4].BackColor = Color.Red; } } catch { }
                                            try { if (field[(buttonField.GetIdButton()) + b + 4].Enabled == true) { field[(buttonField.GetIdButton()) + b + 4].BackColor = Color.Red; } } catch { }
                                            try { if (field[(buttonField.GetIdButton()) + c + 4].Enabled == true) { field[(buttonField.GetIdButton()) + c + 4].BackColor = Color.Red; } } catch { }
                                        }
                                    }
                                }
                            }
                            if (limitLeft.Contains(buttonField.GetIdButton()) == false)
                            {
                                try { if (field[(buttonField.GetIdButton()) - 1].Enabled == true) { field[(buttonField.GetIdButton()) - 1].BackColor = Color.Red; } } catch { }
                                try { if (field[(buttonField.GetIdButton()) + b - 1].Enabled == true) { field[(buttonField.GetIdButton()) + b - 1].BackColor = Color.Red; } } catch { }
                                try { if (field[(buttonField.GetIdButton()) + c - 1].Enabled == true) { field[(buttonField.GetIdButton()) + c - 1].BackColor = Color.Red; } } catch { }
                                if (limitLeft.Contains(buttonField.GetIdButton() - 1) == false)
                                {
                                    try { if (field[(buttonField.GetIdButton()) - 2].Enabled == true) { field[(buttonField.GetIdButton()) - 2].BackColor = Color.Red; } } catch { }
                                    try { if (field[(buttonField.GetIdButton()) + b - 2].Enabled == true) { field[(buttonField.GetIdButton()) + b - 2].BackColor = Color.Red; } } catch { }
                                    try { if (field[(buttonField.GetIdButton()) + c - 2].Enabled == true) { field[(buttonField.GetIdButton()) + c - 2].BackColor = Color.Red; } } catch { }
                                    if (limitLeft.Contains(buttonField.GetIdButton() - 2) == false)
                                    {
                                        try { if (field[(buttonField.GetIdButton()) - 3].Enabled == true) { field[(buttonField.GetIdButton()) - 3].BackColor = Color.Red; } } catch { }
                                        try { if (field[(buttonField.GetIdButton()) + b - 3].Enabled == true) { field[(buttonField.GetIdButton()) + b - 3].BackColor = Color.Red; } } catch { }
                                        try { if (field[(buttonField.GetIdButton()) + c - 3].Enabled == true) { field[(buttonField.GetIdButton()) + c - 3].BackColor = Color.Red; } } catch { }
                                        if (limitLeft.Contains(buttonField.GetIdButton() - 3) == false)
                                        {

                                            try { if (field[(buttonField.GetIdButton()) - 4].Enabled == true) { field[(buttonField.GetIdButton()) - 4].BackColor = Color.Red; } } catch { }
                                            try { if (field[(buttonField.GetIdButton()) + b - 4].Enabled == true) { field[(buttonField.GetIdButton()) + b - 4].BackColor = Color.Red; } } catch { }
                                            try { if (field[(buttonField.GetIdButton()) + c - 4].Enabled == true) { field[(buttonField.GetIdButton()) + c - 4].BackColor = Color.Red; } } catch { }
                                        }
                                    }
                                }
                            }
                            try { if (field[(buttonField.GetIdButton()) + c].Enabled == true) { field[(buttonField.GetIdButton()) + c].BackColor = Color.Red; } } catch { }
                            try { if (field[(buttonField.GetIdButton()) + b].Enabled == true) { field[(buttonField.GetIdButton()) + b].BackColor = Color.Red; } } catch { }
                        }
                        break;
                }
            }
        }

        public void SetPremiumBattle(int premiumEsmerald, int premiumScore)
        {
            this.premiumEsmerald = premiumEsmerald;
            this.premiumScore = premiumScore;
        }

        private void Win()
        {
            GameWinOrLoserForms gameWinOrLoserFor = new GameWinOrLoserForms(1, Convert.ToInt32(this.lblQntChest.Text), Convert.ToInt32(this.lblQntEsmrld.Text) + this.premiumEsmerald, this.premiumScore);
            gameWinOrLoserFor.ShowDialog();
            this.Close();
        }

        private void Lost()
        {
            GameWinOrLoserForms gameWinOrLoserFor = new GameWinOrLoserForms(0);
            gameWinOrLoserFor.ShowDialog();
            this.Close();
        }

        private void btnExitBattle_Click(object sender, EventArgs e)
        {
            this.PbxCloseBattle.Invoke(this, new PbxFormsCloseEventeArgs() { Close = true });
        }

        private void pbxChatBattle_Click(object sender, EventArgs e)
        {
            this.gameChatBatlleForms.Visible = true;
        }

        public string GetLoginEnemy()
        {
            return myside == 0 ? this.loginPlayer2 : this.loginPlayer1;
        }
    }
}
