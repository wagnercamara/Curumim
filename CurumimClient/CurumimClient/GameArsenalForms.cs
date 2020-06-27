using CurumimClient.Classe;
using CurumimClient.PbxEventArgs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurumimGameForms
{
    public partial class GameArsenalForms : Form
    {
        private EventHandler pbxCloseArsenal { get; set; }
        private EventHandler pbxStartBattle { get; set; }
        private ImageClass ImageClass { get; set; }

        private Dictionary<string, dynamic> battleList;
        private Dictionary<string, GameWeaponsClasse> BattleList;
        private Dictionary<string, GameWeaponsClasse> itemArsenal;
        private Boolean startBattle { get; set; }
        private Boolean butomBattle { get; set; }
        private Boolean openListBattle { get; set; }
        private string avatar { get; set; }

        public GameArsenalForms(bool type, string avatar, Dictionary<string, GameWeaponsClasse> itemArsenal, EventHandler PbxCloseArsenal, EventHandler pbxStartBattle)//GameProfileClasse gameProfileClasse, Boolean sender, GameWeaponsClasse gameWeaponsClasse)
        {
            InitializeComponent();
            this.pbxCloseArsenal = PbxCloseArsenal;
            this.pbxStartBattle = pbxStartBattle;
            this.avatar = avatar;
            this.itemArsenal = itemArsenal;
            this.startBattle = type;
            this.butomBattle = type;
        }
        private void pbxBow1_Click(object sender, EventArgs e)
        {
            if (startBattle == true)
            {
                SelectByImage("Bow1", this.lblQtdBrow1, this.pbxBow1);
            }
        }
        private void pbxBow2_Click(object sender, EventArgs e)
        {
            if (startBattle == true)
            {
                SelectByImage("Bow2", this.lblQtdBrow2, this.pbxBow2);
            }
        }
        private void pbxBow3_Click(object sender, EventArgs e)
        {
            if (startBattle == true)
            {
                SelectByImage("Bow3", this.lblQtdBrow3, this.pbxBow3);
            }
        }
        private void pbxCatapult1_Click(object sender, EventArgs e)
        {
            if (startBattle == true)
            {
                SelectByImage("Catapult1", this.lblQtdCatapult1, this.pbxCatapult1);
            }
        }
        private void pbxCatapult2_Click(object sender, EventArgs e)
        {
            if (startBattle == true)
            {
                SelectByImage("Catapult2", this.lblQtdCatapult2, this.pbxCatapult2);
            }
        }
        private void pbxCatapult3_Click(object sender, EventArgs e)
        {
            if (startBattle == true)
            {
                SelectByImage("Catapult3", this.lblQtdCatapult3, this.pbxCatapult3);
            }
        }
        private void pbxCrossbow1_Click(object sender, EventArgs e)
        {
            if (startBattle == true)
            {
                SelectByImage("Crossbow1", this.lblQtdCrossbow1, this.pbxCrossbow1);
            }
        }
        private void pbxCrossbow2_Click(object sender, EventArgs e)
        {
            if (startBattle == true)
            {
                SelectByImage("Crossbow2", this.lblQtdCrossbow2, this.pbxCrossbow2);
            }
        }
        private void pbxCrossbow3_Click(object sender, EventArgs e)
        {
            if (startBattle == true)
            {
                SelectByImage("Crossbow3", this.lblQtdCrossbow3, this.pbxCrossbow3);
            }
        }
        private void pbxFishingNet1_Click(object sender, EventArgs e)
        {
            if (startBattle == true)
            {
                SelectByImage("FishingNet1", this.lblQtdFishingNet1, this.pbxFishingNet1);
            }
        }
        private void pbxFishingNet2_Click(object sender, EventArgs e)
        {
            if (startBattle == true)
            {
                SelectByImage("FishingNet2", this.lblQtdFishingNet2, this.pbxFishingNet2);
            }
        }
        private void pbxHookRope1_Click(object sender, EventArgs e)
        {
            if (startBattle == true)
            {
                SelectByImage("HookRope1", this.lblQtdHookRope1, this.pbxHookRope1);
            }
        }
        private void pbxHookRope2_Click(object sender, EventArgs e)
        {
            if (startBattle == true)
            {
                SelectByImage("HookRope2", this.lblQtdHookRope2, this.pbxHookRope2);
            }
        }
        private void pbxHookRope3_Click(object sender, EventArgs e)
        {
            if (startBattle == true)
            {
                SelectByImage("HookRope3", this.lblQtdHookRope3, this.pbxHookRope3);
            }
        }
        private void pbxArsenalBattle_Click(object sender, EventArgs e)
        {
            OpenDataGridBattle();
        }
        private void pbxClouse_Click(object sender, EventArgs e)
        {
            this.pbxCloseArsenal.Invoke(this, new PbxFormsCloseEventeArgs { Close = true });
        }
        private void pbxModBattle_Click(object sender, EventArgs e)
        {
            switch (this.butomBattle)
            {
                case true:
                    this.butomBattle = false; //fechar modo batalha
                    ModeVisible(true);
                    break;
                case false:
                    this.butomBattle = true; //abrir modo batalha
                    ModeVisible(true);
                    break;
            }
        }
        private void GameArsenalForms_Load(object sender, EventArgs e)
        {
            ImageClass = new ImageClass();
            ColumnsDatagrid();
            ModeVisible(this.startBattle);
            CarryWarArsenal();
        }
        private void pbxSubtract_Click_1(object sender, EventArgs e)
        {
            DatagridOperation("remove");
        }
        private void pbxAdd_Click_1(object sender, EventArgs e)
        {
            DatagridOperation("add");
        }
        private void pbxTrash_Click_1(object sender, EventArgs e)
        {
            DatagridOperation("trash");
        }
        private void pbxBattle_Click(object sender, EventArgs e)
        {
            this.BattleList = new Dictionary<string, GameWeaponsClasse>();
            foreach (KeyValuePair<string, dynamic> weapon in this.battleList)
            {
                this.BattleList.Add((weapon.Key).ToLower(), this.itemArsenal[(weapon.Key).ToLower()]);
                this.BattleList[(weapon.Key).ToLower()].SetAmountWeapons(this.battleList[weapon.Key].numberOfWeaponsInTheList);
            }
            this.pbxStartBattle.Invoke(this, new PbxStartBattleEventArgs
            {
                battleList = this.BattleList
            });
        }
        // metodos
        private void CarryWarArsenal()
        {
            this.pbxAvatar.Image = this.ImageClass.GetImageAvatar(this.avatar);

            GameWeaponsClasse gameWeapons = null;
            string nameWeapons = String.Empty;
            Int32 StockQuantity = 0;

            foreach (KeyValuePair<string, GameWeaponsClasse> p in itemArsenal)
            {
                gameWeapons = p.Value;
                nameWeapons = p.Key;
                StockQuantity = gameWeapons.GetAmountWeapons();
                if (StockQuantity > 0)
                {
                    ActivateAndLoadImage(nameWeapons, StockQuantity);
                }
            }
        }
        private void ActivateAndLoadImage(string nameWeapons, int StockQuantity)
        {
            switch (nameWeapons.ToLower())
            {
                case "bow1":
                    this.pbxBow1.Enabled = true;
                    this.pbxBow1.Visible = true;
                    this.pbxBow1.Image = ImageClass.GetImageIconArsenal(nameWeapons);
                    this.lblQtdBrow1.Visible = true;
                    this.lblQtdBrow1.Text = StockQuantity.ToString();
                    break;
                case "bow2":
                    this.pbxBow2.Enabled = true;
                    this.pbxBow2.Visible = true;
                    this.pbxBow2.Image = ImageClass.GetImageIconArsenal(nameWeapons);
                    this.lblQtdBrow2.Visible = true;
                    this.lblQtdBrow2.Text = StockQuantity.ToString();
                    break;
                case "bow3":
                    this.pbxBow3.Enabled = true;
                    this.pbxBow3.Visible = true;
                    this.pbxBow3.Image = ImageClass.GetImageIconArsenal(nameWeapons);
                    this.lblQtdBrow3.Visible = true;
                    this.lblQtdBrow3.Text = StockQuantity.ToString();
                    break;
                case "catapult1":
                    this.pbxCatapult1.Enabled = true;
                    this.pbxCatapult1.Visible = true;
                    this.pbxCatapult1.Image = ImageClass.GetImageIconArsenal(nameWeapons);
                    this.lblQtdCatapult1.Visible = true;
                    this.lblQtdCatapult1.Text = StockQuantity.ToString();
                    break;
                case "catapult2":
                    this.pbxCatapult2.Enabled = true;
                    this.pbxCatapult2.Visible = true;
                    this.pbxCatapult2.Image = ImageClass.GetImageIconArsenal(nameWeapons);
                    this.lblQtdCatapult2.Visible = true;
                    this.lblQtdCatapult2.Text = StockQuantity.ToString();
                    break;
                case "catapult3":
                    this.pbxCatapult3.Enabled = true;
                    this.pbxCatapult3.Visible = true;
                    this.pbxCatapult3.Image = ImageClass.GetImageIconArsenal(nameWeapons);
                    this.lblQtdCatapult3.Visible = true;
                    this.lblQtdCatapult3.Text = StockQuantity.ToString();
                    break;
                case "crossbow1":
                    this.pbxCrossbow1.Enabled = true;
                    this.pbxCrossbow1.Visible = true;
                    this.pbxCrossbow1.Image = ImageClass.GetImageIconArsenal(nameWeapons);
                    this.lblQtdCrossbow1.Visible = true;
                    this.lblQtdCrossbow1.Text = StockQuantity.ToString();
                    break;
                case "crossbow2":
                    this.pbxCrossbow2.Enabled = true;
                    this.pbxCrossbow2.Visible = true;
                    this.pbxCrossbow2.Image = ImageClass.GetImageIconArsenal(nameWeapons);
                    this.lblQtdCrossbow2.Visible = true;
                    this.lblQtdCrossbow2.Text = StockQuantity.ToString();
                    break;
                case "crossbow3":
                    this.pbxCrossbow3.Enabled = true;
                    this.pbxCrossbow3.Visible = true;
                    this.pbxCrossbow3.Image = ImageClass.GetImageIconArsenal(nameWeapons);
                    this.lblQtdCrossbow3.Visible = true;
                    this.lblQtdCrossbow3.Text = StockQuantity.ToString();
                    break;
                case "fishingnet1":
                    this.pbxFishingNet1.Enabled = true;
                    this.pbxFishingNet1.Visible = true;
                    this.pbxFishingNet1.Image = ImageClass.GetImageIconArsenal(nameWeapons);
                    this.lblQtdFishingNet1.Visible = true;
                    this.lblQtdFishingNet1.Text = StockQuantity.ToString();
                    break;
                case "fishingnet2":
                    this.pbxFishingNet2.Enabled = true;
                    this.pbxFishingNet2.Visible = true;
                    this.pbxFishingNet2.Image = ImageClass.GetImageIconArsenal(nameWeapons);
                    this.lblQtdFishingNet2.Visible = true;
                    this.lblQtdFishingNet2.Text = StockQuantity.ToString();
                    break;
                case "hookrope1":
                    this.pbxHookRope1.Enabled = true;
                    this.pbxHookRope1.Visible = true;
                    this.pbxHookRope1.Image = ImageClass.GetImageIconArsenal(nameWeapons);
                    this.lblQtdHookRope1.Visible = true;
                    this.lblQtdHookRope1.Text = StockQuantity.ToString();
                    break;
                case "hookrope2":
                    this.pbxHookRope2.Enabled = true;
                    this.pbxHookRope2.Visible = true;
                    this.pbxHookRope2.Image = ImageClass.GetImageIconArsenal(nameWeapons);
                    this.lblQtdHookRope2.Visible = true;
                    this.lblQtdHookRope2.Text = StockQuantity.ToString();
                    break;
                case "hookrope3":
                    this.pbxHookRope3.Enabled = true;
                    this.pbxHookRope3.Visible = true;
                    this.pbxHookRope3.Image = ImageClass.GetImageIconArsenal(nameWeapons);
                    this.lblQtdHookRope3.Visible = true;
                    this.lblQtdHookRope3.Text = StockQuantity.ToString();
                    break;
            }
        }
        private void ModeVisible(Boolean activateBattleMode = false)
        {
            switch (activateBattleMode)
            {
                case true:

                    switch (this.butomBattle)
                    {
                        case true: //ativar modo de batalha
                            startBattle = true;
                            this.LoadCursorSelect(true);
                            this.battleList = new Dictionary<string, dynamic>();
                            this.openListBattle = true; // iniciando variavel para abrir painel
                            this.pbxArsenalBattle.Visible = true;
                            this.pnlRight.Visible = true;
                            break;

                        case false:
                            int ListWithItem = this.battleList.Count;
                            if (this.openListBattle == false)
                            {
                                OpenDataGridBattle();
                            }

                            if (ListWithItem > 0)
                            {
                                GiveBack();
                            }

                            this.startBattle = false;
                            this.pbxArsenalBattle.Visible = false;
                            this.pnlRight.Visible = false;
                            this.LoadCursorSelect(true);
                            break;
                    }
                    break;
                case false:
                    switch (this.startBattle)
                    {
                        case true: // load em modo batalha
                            this.battleList = new Dictionary<string, dynamic>();
                            this.openListBattle = true; // iniciando variavel para abrir painel
                            this.pbxArsenalBattle.Visible = true;
                            this.pbxModBattle.Visible = false;
                            this.pbxModBattle.Enabled = false;
                            this.pnlRight.Visible = true;
                            break;
                        case false: // load em modo arsenal.
                            this.butomBattle = false; //habilitando função do botão batalha.
                            this.pbxArsenalBattle.Visible = false;
                            this.pbxModBattle.Visible = true;
                            this.pbxModBattle.Enabled = true;
                            this.pnlRight.Visible = false;
                            break;
                    }
                    break;
            }
        }
        private void LoadCursorSelect(Boolean v)
        {
            switch (v)
            {
                case true:
                    this.pbxBow1.Cursor = Cursors.Hand;
                    this.pbxBow2.Cursor = Cursors.Hand;
                    this.pbxBow3.Cursor = Cursors.Hand;
                    this.pbxCatapult1.Cursor = Cursors.Hand;
                    this.pbxCatapult2.Cursor = Cursors.Hand;
                    this.pbxCatapult3.Cursor = Cursors.Hand;
                    this.pbxCrossbow1.Cursor = Cursors.Hand;
                    this.pbxCrossbow2.Cursor = Cursors.Hand;
                    this.pbxCrossbow3.Cursor = Cursors.Hand;
                    this.pbxFishingNet1.Cursor = Cursors.Hand;
                    this.pbxFishingNet2.Cursor = Cursors.Hand;
                    this.pbxHookRope1.Cursor = Cursors.Hand;
                    this.pbxHookRope2.Cursor = Cursors.Hand;
                    this.pbxHookRope3.Cursor = Cursors.Hand;
                    break;
                case false:
                    this.pbxBow1.Cursor = Cursors.Default;
                    this.pbxBow2.Cursor = Cursors.Default;
                    this.pbxBow3.Cursor = Cursors.Default;
                    this.pbxCatapult1.Cursor = Cursors.Default;
                    this.pbxCatapult2.Cursor = Cursors.Default;
                    this.pbxCatapult3.Cursor = Cursors.Default;
                    this.pbxCrossbow1.Cursor = Cursors.Default;
                    this.pbxCrossbow2.Cursor = Cursors.Default;
                    this.pbxCrossbow3.Cursor = Cursors.Default;
                    this.pbxFishingNet1.Cursor = Cursors.Default;
                    this.pbxFishingNet2.Cursor = Cursors.Default;
                    this.pbxHookRope1.Cursor = Cursors.Default;
                    this.pbxHookRope2.Cursor = Cursors.Default;
                    this.pbxHookRope3.Cursor = Cursors.Default;
                    break;
            }
        }
        private void GiveBack()
        {
            string weaponName;
            dynamic d;
            int stockQuantity = 0;
            Label labelQuantity;
            PictureBox picture;

            for (int i = 0; i < this.battleList.Count; i++)
            {
                weaponName = GetName(i);
                d = GetVaue(i);
                labelQuantity = d.labelQuantity;
                picture = d.picture;
                stockQuantity = d.stockQuantity + d.numberOfWeaponsInTheList;

                labelQuantity.Text = stockQuantity.ToString();

                if (picture.Image == null)
                {
                    labelQuantity.Visible = true;
                    ActivateAndLoadImage(weaponName, stockQuantity);
                }

            }
        }
        private void OpenDataGridBattle()
        {
            switch (this.openListBattle)
            {
                case true:
                    this.pnlBase.Visible = false;
                    for (int i = 0; i <= 395; i++)
                    {
                        this.pnlRight.Width = i;
                    }
                    this.openListBattle = false;
                    this.pnlBase.Visible = true;
                    break;
                case false:
                    this.pnlBase.Visible = false;
                    for (int i = 395; i >= 0; i--)
                    {
                        this.pnlRight.Width = i;
                    }
                    this.openListBattle = true;
                    this.pnlBase.Visible = true;
                    break;
            }
        }
        private void ColumnsDatagrid()
        {
            this.dgvListBattle.Columns.Add("weaponName", "WeaponName");
            this.dgvListBattle.Columns[0].Width = 100;
            this.dgvListBattle.Columns[0].Resizable = DataGridViewTriState.False;

            this.dgvListBattle.Columns.Add("numberOfWeaponsInTheList", "NumWeaponsList");
            this.dgvListBattle.Columns[1].Width = 120;
            this.dgvListBattle.Columns[1].Resizable = DataGridViewTriState.False;

            this.dgvListBattle.Columns.Add("stockQuantity", "StockQuantity");
            this.dgvListBattle.Columns[2].Width = 100;
            this.dgvListBattle.Columns[2].Resizable = DataGridViewTriState.False;

            this.dgvListBattle.Columns.Add("labelQuantity", "Label");
            this.dgvListBattle.Columns[3].Visible = false;

            this.dgvListBattle.Columns.Add("pictureBox", "picture");
            this.dgvListBattle.Columns[4].Visible = false;
        }
        private void DatagridOperation(string Add_Remove)
        {
            if (this.dgvListBattle.SelectedRows.Count > 0)
            {
                DataGridViewRow line = this.dgvListBattle.SelectedRows[0];

                string weaponName = Convert.ToString(line.Cells["weaponName"].Value);
                int numberOfWeaponsInTheList = Convert.ToInt32(line.Cells["numberOfWeaponsInTheList"].Value);
                int stockQuantity = Convert.ToInt32(line.Cells["stockQuantity"].Value);
                Label labelQuantity = (Label)(line.Cells["labelQuantity"].Value);
                PictureBox picture = (PictureBox)(line.Cells["pictureBox"].Value);

                if (weaponName != "")
                {
                    switch (Add_Remove)
                    {
                        case "add":
                            if (stockQuantity > 0)
                            {
                                stockQuantity = stockQuantity - 1;

                                if (stockQuantity <= 0)
                                {
                                    labelQuantity.Visible = false;
                                    picture.Enabled = false;
                                    picture.Image = null;
                                }

                                numberOfWeaponsInTheList = numberOfWeaponsInTheList + 1;

                                labelQuantity.Text = stockQuantity.ToString();

                                AddBattleList(weaponName, numberOfWeaponsInTheList, stockQuantity, labelQuantity, picture);
                            }
                            else
                            {
                                this.lblErroDataGrid.Visible = true;
                                this.lblErroDataGrid.Text = "Você não possui mais Esse armamento em seu arsenal";
                            }
                            break;

                        case "remove":

                            if (numberOfWeaponsInTheList > 0)
                            {

                                numberOfWeaponsInTheList = numberOfWeaponsInTheList - 1;
                                stockQuantity = stockQuantity + 1;

                                if (picture.Image == null)
                                {
                                    labelQuantity.Visible = true;

                                    ActivateAndLoadImage(weaponName.ToLower(), stockQuantity);
                                }

                                switch (numberOfWeaponsInTheList)
                                {
                                    case 0:
                                        labelQuantity.Text = stockQuantity.ToString();
                                        this.battleList.Remove(weaponName);
                                        break;
                                    default:
                                        labelQuantity.Text = stockQuantity.ToString();
                                        AddBattleList(weaponName, numberOfWeaponsInTheList, stockQuantity, labelQuantity, picture);
                                        break;
                                }
                            }

                            break;

                        case "trash":


                            stockQuantity = (stockQuantity + numberOfWeaponsInTheList);
                            labelQuantity.Text = (stockQuantity).ToString();


                            if (picture.Image == null)
                            {
                                labelQuantity.Visible = true;
                                ActivateAndLoadImage(weaponName.ToLower(), stockQuantity);
                            }

                            this.battleList.Remove(weaponName);

                            break;
                    }
                    ClearDatagridView();
                    LoadBattleList();
                }
                else
                {
                    MessageBox.Show("A linha selecionada não contem Item");
                }

            }
            else
            {
                MessageBox.Show("Não a linha selecionadas");
            }
        }
        private void ClearDatagridView()
        {
            this.dgvListBattle.Rows.Clear();
        }
        private void SelectByImage(string weaponName, Label labelQuantity, PictureBox picture)
        {
            Boolean existsInTheList = this.battleList.ContainsKey(weaponName);
            int numberOfWeaponsInTheList = 1;
            int stockQuantity = (Convert.ToInt32(labelQuantity.Text) - 1);
            labelQuantity.Text = stockQuantity.ToString();

            if (stockQuantity <= 0)
            {
                picture.Image = null;
                picture.Enabled = false;
                labelQuantity.Visible = false;
            }

            switch (existsInTheList)
            {
                case true:
                    dynamic d = this.battleList[weaponName];
                    numberOfWeaponsInTheList = d.numberOfWeaponsInTheList;

                    numberOfWeaponsInTheList = numberOfWeaponsInTheList + 1;

                    AddBattleList(weaponName, numberOfWeaponsInTheList, stockQuantity, labelQuantity, picture);
                    break;
                case false:
                    AddBattleList(weaponName, numberOfWeaponsInTheList, stockQuantity, labelQuantity, picture);
                    break;
            }

            ClearDatagridView();
            LoadBattleList();
        }
        private void AddBattleList(string weaponName, int numberOfWeaponsInTheList, int stockQuantity, Label labelQuantity, PictureBox picture) // NumberOfWeaponsInTheList
        {
            Boolean existsInTheList = this.battleList.ContainsKey(weaponName);

            switch (existsInTheList)
            {
                case true:
                    this.battleList.Remove(weaponName);

                    this.battleList.Add(weaponName, new
                    {
                        numberOfWeaponsInTheList,
                        stockQuantity,
                        labelQuantity,
                        picture
                    });
                    break;
                case false:
                    this.battleList.Add(weaponName, new
                    {
                        numberOfWeaponsInTheList,
                        stockQuantity,
                        labelQuantity,
                        picture
                    });
                    break;
            }
        }
        private void LoadBattleList()
        {
            dynamic d = null;
            string weaponName = "";
            Label labelQuantity = null;
            PictureBox picture = null;
            int stockQuantity = 0;
            int numberOfWeaponsInTheList = 0;

            ClearDatagridView();

            for (int i = 0; i < this.battleList.Count; i++)
            {
                d = GetVaue(i);
                weaponName = GetName(i);
                numberOfWeaponsInTheList = d.numberOfWeaponsInTheList;
                stockQuantity = d.stockQuantity;
                labelQuantity = d.labelQuantity;
                picture = d.picture;

                this.dgvListBattle.Rows.Add(weaponName, numberOfWeaponsInTheList, stockQuantity, labelQuantity, picture);
            }
        }
        private dynamic GetVaue(int index)
        {
            ICollection valorColecao = this.battleList.Values;
            dynamic[] mValores = new dynamic[this.battleList.Count];
            valorColecao.CopyTo(mValores, 0);

            return mValores[index];
        }
        private string GetName(int index)
        {
            ICollection chaveColecao = this.battleList.Keys;
            String[] mChaves = new String[this.battleList.Count];
            chaveColecao.CopyTo(mChaves, 0);

            return mChaves[index];
        }
    }
}

