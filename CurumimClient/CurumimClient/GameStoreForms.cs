using Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CurumimGameForms
{
    public partial class GameStoreForms : Form
    {
        private Dictionary<string, dynamic> purchase = new Dictionary<string, dynamic>();

        private Boolean OpenCar = true;
        private int valueWallet { get; set; }
        private int valuePurchase { get; set; }
        public GameStoreForms()
        {
            InitializeComponent();
            this.valueWallet = 200;
            this.lblWallet.Text = $"{this.valueWallet}£"; ;
            ColumnsDatagrid();
        }

        private void pbxArco1_Click(object sender, EventArgs e)
        {
            PurchaseSum("bow1", this.lblQtdArc1, this.lblValArc1);
        }
        private void pbxArco2_Click(object sender, EventArgs e)
        {
            PurchaseSum("bow2", this.lblQtdArc2, this.lblValArc2);
        }
        private void pbxArco3_Click(object sender, EventArgs e)
        {
            PurchaseSum("bow3", this.lblQtdArc3, this.lblValArc3);
        }
        private void pbxBest1_Click(object sender, EventArgs e)
        {
            PurchaseSum("crossbow1", this.lblQtdBest1, this.lblValBest1);
        }
        private void pbxBest2_Click(object sender, EventArgs e)
        {
            PurchaseSum("crossbow2", this.lblQtdBest2, this.lblValBest2);
        }
        private void pbxBest3_Click(object sender, EventArgs e)
        {
            PurchaseSum("crossbow3", this.lblQtdBest3, this.lblValBest3);
        }
        private void pbxCat1_Click(object sender, EventArgs e)
        {
            PurchaseSum("catapult1", this.lblQtdCat1, this.lblValCat1);
        }
        private void pbxCat2_Click(object sender, EventArgs e)
        {
            PurchaseSum("catapult2", this.lblQtdCat2, this.lblValCat2);
        }
        private void pbxCat3_Click(object sender, EventArgs e)
        {
            PurchaseSum("catapult3", this.lblQtdCat3, this.lblValCat3);
        }
        private void pbxRop1_Click(object sender, EventArgs e)
        {
            PurchaseSum("hookRope1", this.lblQtdRope1, this.lblValRop1);
        }
        private void pbxRop2_Click(object sender, EventArgs e)
        {
            PurchaseSum("hookRope2", this.lblQtdRope2, this.lblValRop2);
        }
        private void pbxRop3_Click(object sender, EventArgs e)
        {
            PurchaseSum("hookRope3", this.lblQtdRope3, this.lblValRop3);
        }
        private void pbxRed1_Click(object sender, EventArgs e)
        {
            PurchaseSum("fishingNet1", this.lblQtdRed1, this.lblValRed1);
        }
        private void pbxRed2_Click(object sender, EventArgs e)
        {
            PurchaseSum("fishingNet2", this.lblQtdRed2, this.lblValRed2);
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
            ///carriho
        }
        private void pbxClouse_Click(object sender, EventArgs e)
        {
            this.Close();
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
                           
                            if (valueUn <= this.valueWallet)
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
            if (this.valueWallet >= valueItem)
            {
                this.lblInsufficientFunds.Text = "";
                if (labelQtd.Text == "")
                {
                    labelQtd.Text = "0";
                }
                int qtdItem = (Convert.ToInt32(labelQtd.Text) + 1);
                labelQtd.Text = (qtdItem).ToString();

                this.valuePurchase = (this.valuePurchase + valueItem);
                this.valueWallet = this.valueWallet - valueItem;

                this.lblWallet.Text = $"{this.valueWallet}£";
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
            this.valueWallet = this.valueWallet + valueUn;
            this.lblWallet.Text = $"{this.valueWallet}£";
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
            this.valuePurchase = 0;
            for (int i = 0; i < this.purchase.Count; i++)
            {
                d = GetVaue(i);
                nameArm = GetName(i);
                valueUn = d.valueUn;
                qtd = d.qtd;
                valueFull = d.valueFull;
                labelQtd = d.labelQtd;

                this.valuePurchase = this.valuePurchase + valueFull;

                dgvListPurchase.Rows.Add(nameArm, valueUn, qtd, valueFull, labelQtd);
            }
            this.lblValPurchase.Text = $"{this.valuePurchase}£";
            this.lblFullPurchase.Text = $"{this.valuePurchase}£";
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


    }
}
