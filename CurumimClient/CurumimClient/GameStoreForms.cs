using CurumimClient.Classe;
using CurumimClient.PbxEventArgs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CurumimGameForms
{
    public partial class GameStoreForms : Form
    {
        private GameProfileClasse gameProfileClasse;
        private Dictionary<string, dynamic> purchase = new Dictionary<string, dynamic>();
        private Dictionary<string, GameWeaponsClasse> itemStore;
        private List<dynamic> buyCar;
        private EventHandler PbxCloseStore { get; set; }
        private EventHandler BuyItemOnCLick { get; set; }
        private Boolean OpenCar = true;
        private int ValueWallet { get; set; }
        private int ValuePurchase { get; set; }
        public GameStoreForms(EventHandler pbxCloseStore, Dictionary<string, GameWeaponsClasse> ItemStore, GameProfileClasse gameProfileClasse, EventHandler BuyItemOnCLick)
        {
            InitializeComponent();
            this.gameProfileClasse = gameProfileClasse;
            this.ValueWallet = this.gameProfileClasse.GetEsmeraldPlayer();
            this.lblWallet.Text = $"{this.ValueWallet}£";
            this.itemStore = ItemStore;
            this.PbxCloseStore = pbxCloseStore;
            this.BuyItemOnCLick = BuyItemOnCLick;
            ColumnsDatagrid();
        }
        private void pbxArco1_Click(object sender, EventArgs e)
        {
            PurchaseSum("Bow1", this.lblQtdArc1, this.lblValArc1);
        }
        private void pbxArco2_Click(object sender, EventArgs e)
        {
            PurchaseSum("Bow2", this.lblQtdArc2, this.lblValArc2);
        }
        private void pbxArco3_Click(object sender, EventArgs e)
        {
            PurchaseSum("Bow3", this.lblQtdArc3, this.lblValArc3);
        }
        private void pbxBest1_Click(object sender, EventArgs e)
        {
            PurchaseSum("Crossbow1", this.lblQtdBest1, this.lblValBest1);
        }
        private void pbxBest2_Click(object sender, EventArgs e)
        {
            PurchaseSum("Crossbow2", this.lblQtdBest2, this.lblValBest2);
        }
        private void pbxBest3_Click(object sender, EventArgs e)
        {
            PurchaseSum("Crossbow3", this.lblQtdBest3, this.lblValBest3);
        }
        private void pbxCat1_Click(object sender, EventArgs e)
        {
            PurchaseSum("Catapult1", this.lblQtdCat1, this.lblValCat1);
        }
        private void pbxCat2_Click(object sender, EventArgs e)
        {
            PurchaseSum("Catapult2", this.lblQtdCat2, this.lblValCat2);
        }
        private void pbxCat3_Click(object sender, EventArgs e)
        {
            PurchaseSum("Catapult3", this.lblQtdCat3, this.lblValCat3);
        }
        private void pbxRop1_Click(object sender, EventArgs e)
        {
            PurchaseSum("HookRope1", this.lblQtdRope1, this.lblValRop1);
        }
        private void pbxRop2_Click(object sender, EventArgs e)
        {
            PurchaseSum("HookRope2", this.lblQtdRope2, this.lblValRop2);
        }
        private void pbxRop3_Click(object sender, EventArgs e)
        {
            PurchaseSum("HookRope3", this.lblQtdRope3, this.lblValRop3);
        }
        private void pbxRed1_Click(object sender, EventArgs e)
        {
            PurchaseSum("FishingNet1", this.lblQtdRed1, this.lblValRed1);
        }
        private void pbxRed2_Click(object sender, EventArgs e)
        {
            PurchaseSum("FishingNet2", this.lblQtdRed2, this.lblValRed2);
        }
        private void pbxList_Click(object sender, EventArgs e)
        {
            OpenPnlCar();
        }
        private void pbxSubtract_Click(object sender, EventArgs e)
        {
            AddOrRemoveDateGrid("remove");
        }
        private void pbxAdd_Click(object sender, EventArgs e)
        {
            AddOrRemoveDateGrid("add");
        }
        private void pbxTrash_Click(object sender, EventArgs e)
        {
            AddOrRemoveDateGrid("Trash");
        }
        private void pbxBuyList_Click(object sender, EventArgs e)
        {
            buyCar = new List<dynamic>();
            dynamic dyn;
            string nameItem = "";
            Int32 id_tbItem = 0;
            Int32 amountItemPurchase = 0;
            Int32 valueUnitItemPurchase = 0;
            Int32 valueTotalItemPurchase = 0;
            GameWeaponsClasse gwc;

            foreach (KeyValuePair<string,dynamic> car in this.purchase)
            {
                nameItem = car.Key;
                dyn = car.Value;
                gwc = this.itemStore[nameItem.ToLower()];
                id_tbItem = gwc.GetIdItem();
                amountItemPurchase = dyn.qtd;
                valueUnitItemPurchase = dyn.valueUn;
                valueTotalItemPurchase = dyn.valueFull;
                
                buyCar.Add(new
                {
                    id_tbItem,
                    amountItemPurchase,
                    valueUnitItemPurchase,
                    valueTotalItemPurchase,
                    this.ValueWallet
                });
            }
            this.BuyItemOnCLick.Invoke(this, new PbxItemsEventArgs() { Items = this.buyCar });
        }
        private void pbxClouse_Click(object sender, EventArgs e)
        {
            this.PbxCloseStore.Invoke(this, new PbxFormsCloseEventeArgs { Close = true });
        }
        private void GameStoreForms_Load(object sender, EventArgs e)
        {
            GameWeaponsClasse gameWeapons = null;
            string nameWeapons = String.Empty;
            Int32 valueUnitItem = 0;

            foreach (KeyValuePair<string, GameWeaponsClasse> p in itemStore)
            {
                gameWeapons = p.Value;
                nameWeapons = p.Key;
                valueUnitItem = gameWeapons.GetValueUnitItem();
                LoadValueItem(nameWeapons, valueUnitItem);
            }
        }
        private void LoadValueItem(string nameWeapons, Int32 valueUnitItem)
        {
            switch(nameWeapons.ToLower())
            {
                case "bow1":
                    lblValArc1.Text = valueUnitItem.ToString();
                    break;
                case "bow2":
                    lblValArc2.Text = valueUnitItem.ToString();
                    break;
                case "bow3":
                    lblValArc3.Text = valueUnitItem.ToString();
                    break;
                case "crossbow1":
                    lblValBest1.Text = valueUnitItem.ToString();
                    break;
                case "crossbow2":
                    lblValBest2.Text = valueUnitItem.ToString();
                    break;
                case "crossbow3":
                    lblValBest3.Text = valueUnitItem.ToString();
                    break;
                case "catapult1":
                    lblValCat1.Text = valueUnitItem.ToString();
                    break;
                case "catapult2":
                    lblValCat2.Text = valueUnitItem.ToString();
                    break;
                case "catapult3":
                    lblValCat3.Text = valueUnitItem.ToString();
                    break;
                case "hookrope1":
                    lblValRop1.Text = valueUnitItem.ToString();
                    break;
                case "hookrope2":
                    lblValRop2.Text = valueUnitItem.ToString();
                    break;
                case "hookrope3":
                    lblValRop3.Text = valueUnitItem.ToString();
                    break;
                case "fishingnet1":
                    lblValRed1.Text = valueUnitItem.ToString();
                    break;
                case "fishingnet2":
                    lblValRed2.Text = valueUnitItem.ToString();
                    break;
                default:
                    break;
            }
        }
        // Colunas Data GRid
        private void ColumnsDatagrid()
        {
            this.dgvListPurchase.Columns.Add("nameArm", "Item");
            this.dgvListPurchase.Columns[0].Width = 90;
            this.dgvListPurchase.Columns[0].Resizable = DataGridViewTriState.False;

            this.dgvListPurchase.Columns.Add("valueItem", "ValorItem");
            this.dgvListPurchase.Columns[1].Width = 80;
            this.dgvListPurchase.Columns[1].Resizable = DataGridViewTriState.False;

            this.dgvListPurchase.Columns.Add("QtdItem", "Quantidade");
            this.dgvListPurchase.Columns[2].Width = 80;
            this.dgvListPurchase.Columns[2].Resizable = DataGridViewTriState.False;

            this.dgvListPurchase.Columns.Add("valuePurchase", "ValorTotal");
            this.dgvListPurchase.Columns[3].Width = 80;
            this.dgvListPurchase.Columns[3].Resizable = DataGridViewTriState.False;

            this.dgvListPurchase.Columns.Add("labelQtd", "Label");
            this.dgvListPurchase.Columns[4].Visible = false;
        }

        // Alteração a partir do data grid
        private void AddOrRemoveDateGrid(String Add_Remove)
        {
            if (this.dgvListPurchase.SelectedRows.Count > 0)
            {
                DataGridViewRow line = this.dgvListPurchase.SelectedRows[0];

                string nameArm = Convert.ToString(line.Cells["nameArm"].Value);
                int valueUn = Convert.ToInt32(line.Cells["valueItem"].Value);
                int qtd = Convert.ToInt32(line.Cells["QtdItem"].Value);
                int valueItem = Convert.ToInt32(line.Cells["valuePurchase"].Value);//valor total dos itens.
                Label labelQtd = (Label)(line.Cells["labelQtd"].Value);

                if (nameArm != "")
                {
                    switch (Add_Remove)
                    {
                        case "add":
                           
                            if (valueUn <= this.ValueWallet)
                            {
                                qtd = qtd + 1;
                                labelQtd.Text = qtd.ToString();
                                AddCarPurchase(nameArm, valueUn, qtd, valueItem, labelQtd);
                            }
                            else
                            {
                                AlertInsufficientFunds(true);
                            }

                            break;

                        case "remove":
                            
                            qtd = qtd - 1;

                            RemoveCar(valueUn);

                            switch (qtd)
                            {
                                case 0:
                                    labelQtd.Text = "";
                                    labelQtd.Visible = false;
                                    this.purchase.Remove(nameArm);
                                    break;
                                default:
                                    labelQtd.Text = qtd.ToString();
                                    AddCarPurchase(nameArm, valueUn, qtd, valueItem, labelQtd);
                                    break;
                            }
                            AlertInsufficientFunds(false);
                            break;

                        case "Trash":
                            labelQtd.Text = "";
                            labelQtd.Visible = false;
                            RemoveCar(valueItem);
                            this.purchase.Remove(nameArm);
                            AlertInsufficientFunds(false);
                            break;
                    }

                    LoadingDgv();
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

        // Selecionar um item pela imagens
        private void PurchaseSum(String nameArm, Label labelQtd, Label labelVal)
        {
            ClearDatagridView();
            int valueItem = (Convert.ToInt32(labelVal.Text));
            labelQtd.Visible = true;
            labelQtd.ForeColor = Color.Red;
            if (this.ValueWallet >= valueItem)
            {
                this.lblInsufficientFunds.Text = "";
                if (labelQtd.Text == "")
                {
                    labelQtd.Text = "0";
                }
                int qtdItem = (Convert.ToInt32(labelQtd.Text) + 1);
                labelQtd.Text = (qtdItem).ToString();

                this.ValuePurchase = (this.ValuePurchase + valueItem);
                this.ValueWallet = this.ValueWallet - valueItem;

                this.lblWallet.Text = $"{this.ValueWallet}£";
                AddCarPurchase(nameArm, valueItem, qtdItem, valueItem, labelQtd);
            }
            else
            {
                AlertInsufficientFunds(true);
            }
            LoadingDgv();

        }
        private void AlertInsufficientFunds(Boolean visible)
        {
            this.lblInsufficientFunds.Text = "Insufficient Funds";
            this.lblInsufficientFunds.Visible = visible;
            this.pbxAlert.Visible = visible;
        }
        // Devolve um determinado valor a Carteira
        private void RemoveCar(int valueUn)
        {
            this.ValueWallet = this.ValueWallet + valueUn;
            this.lblWallet.Text = $"{this.ValueWallet}£";
        }

        //Adiciona ao carrinho.
        private void AddCarPurchase(string nameArm, int valueUn, int qtd, int valueItem, Label labelQtd)
        {
            int valueFull = qtd * valueUn;

            Boolean HeveInCart = this.purchase.ContainsKey(nameArm);

            switch (HeveInCart)
            {
                case false:

                this.purchase.Add(nameArm, new
                {
                    valueUn,
                    qtd,
                    valueFull,
                    labelQtd
                });
                    break;

                case true:

                    this.purchase.Remove(nameArm);

                    this.purchase.Add(nameArm, new
                    {
                        valueUn,
                        qtd,
                        valueFull,
                        labelQtd
                    });
                    break;
            }
        }

        //Atualiza o Data Grid. sepre será chamado após alguma alteração.
        private void LoadingDgv()
        {
            dynamic d = null;
            string nameArm = "";
            Label labelQtd = null;
            int valueUn, qtd, valueFull;

            ClearDatagridView();
            this.ValuePurchase = 0;
            for (int i = 0; i < this.purchase.Count; i++)
            {
                d = GetVaue(i);
                nameArm = GetName(i);
                valueUn = d.valueUn;
                qtd = d.qtd;
                valueFull = d.valueFull;
                labelQtd = d.labelQtd;

                this.ValuePurchase = this.ValuePurchase + valueFull;

                dgvListPurchase.Rows.Add(nameArm, valueUn, qtd, valueFull, labelQtd);
            }
            this.lblValPurchase.Text = $"{this.ValuePurchase}£";
            this.lblFullPurchase.Text = $"{this.ValuePurchase}£";
        }
        private void ClearDatagridView()
        {
            this.dgvListPurchase.Rows.Clear();
        }

        //Funcionalidade painel.
        private void OpenPnlCar()
        {
            if (this.OpenCar == true)
            {
                this.pnlBase.Visible = false;
                this.pnlCar.Visible = true;
                this.pnlCar.BackColor = Color.FromArgb(45, 45, 48);
                for (int i = 0; i <= 400; i++)
                {
                    this.pnlCar.Width = i;
                }
                this.pnlBase.Visible = true;

                this.OpenCar = false;
            }
            else
            {
                this.pnlBase.Visible = false;
                for (int i = 400; i >= 0; i--)
                {
                    this.pnlCar.Width = i;
                }

                this.pnlBase.Visible = true;
                this.pnlCar.Visible = true;
                this.OpenCar = true;
            }
            LoadingDgv();
        }
        private dynamic GetVaue(int index)
        {
            ICollection valorColecao = this.purchase.Values;
            dynamic[] mValores = new dynamic[this.purchase.Count];
            valorColecao.CopyTo(mValores, 0);

            return mValores[index];
        }
        private string GetName(int index)
        {
            ICollection chaveColecao = this.purchase.Keys;
            String[] mChaves = new String[this.purchase.Count];
            chaveColecao.CopyTo(mChaves, 0);

            return mChaves[index];
        }
        private delegate void BuySucessDelegate();
        public void BuySucess()
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new BuySucessDelegate(BuySucess), new object[] {});
            }
            else
            {
                if (this.OpenCar == false)
                {
                    OpenPnlCar();
                }
                this.purchase.Clear();
                this.gameProfileClasse.SetEsmeraldPlayer(this.ValueWallet);
                ClearLbl();
                MessageBox.Show("Purchase successful", "Congratulations");
            }
        }
        private void ClearLbl()
        {
            lblQtdArc1.Text = "";
            lblQtdArc2.Text = "";
            lblQtdArc3.Text = "";

            lblQtdBest1.Text = "";
            lblQtdBest2.Text = "";
            lblQtdBest3.Text = "";

            lblQtdCat1.Text = "";
            lblQtdCat2.Text = "";
            lblQtdCat3.Text = "";

            lblQtdRed1.Text = "";
            lblQtdRed2.Text = "";

            lblQtdRope1.Text = "";
            lblQtdRope2.Text = "";
            lblQtdRope3.Text = "";

            lblFullPurchase.Text = "";
            lblValPurchase.Text = "";
        }
    }
}
