using CurumimClient.BtnEventArgs;
using CurumimClient.Classe;
using CurumimClient.PbxEventArgs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurumimGameForms
{
    public partial class GameRoomsForms : Form
    {
        private string fileIndexRooms = "../../img/Rooms/";
        private ImageClass ImageClass = new ImageClass();
        private GameProfileClasse gameProfileClasse;
        private EventHandler ClouseRooms;
        private EventHandler IformationRoom;
        private Boolean caller { get; set; }
        private Boolean OpenPnl = false;
        private int CountIndex = 0;
        private string[] nameRooms { get; set; }
        public GameRoomsForms(Boolean caller, GameProfileClasse gameProfileClasse, EventHandler ClouseRooms, EventHandler IformationRoom) // tirar isso.
        {
            InitializeComponent();
            this.caller = caller;
            this.gameProfileClasse = gameProfileClasse;
            this.ClouseRooms = ClouseRooms;
            this.IformationRoom = IformationRoom;
        }

        private void pbxNext_Click(object sender, EventArgs e)
        {
            this.CountIndex++;
            MoveImagemPnl();
        }

        private void pbxReturn_Click(object sender, EventArgs e)
        {
            this.CountIndex--;
            MoveImagemPnl();
        }
        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenPnlLeft();
        }
        private void PbxClousePnl_Click(object sender, EventArgs e)
        {
            OpenPnlLeft();
        }
        private void btnCLouse_Click(object sender, EventArgs e)
        {
            this.ClouseRooms.Invoke(this, new PbxFormsCloseEventeArgs() { Close = true });
        }
        private void btnBattle_Click(object sender, EventArgs e)
        {
            if ((Convert.ToInt32(this.lblAmoutEmeralPlayer.Text) >= (Convert.ToInt32(this.lblAmoutEmeraldRoom.Text))))
            {
                int NumberRoom = this.CountIndex + 1;
                int BetRoom = Convert.ToInt32(this.lblAmoutEmeraldRoom.Text);
                int PontuctionRoom = Convert.ToInt32(this.lblPontuction.Text);
                int DetachedRoom = Convert.ToInt32(this.lblAmoutEmerald.Text);
                int AmountChestRoom = Convert.ToInt32(this.lblAmoutChest.Text);
                int ValueChest = Convert.ToInt32(this.lblAmoutEmeraldChest.Text);

                this.IformationRoom.Invoke(this, new BtnRoomsInformationEventArgs()
                {
                    valuesRoom = new int[]
                    {
                        NumberRoom,
                        BetRoom,
                        PontuctionRoom,
                        DetachedRoom,
                        AmountChestRoom,
                        ValueChest
                    }
                });
            }
            else
            {
                MessageBox.Show("You don't have enough emerald to bet.", "Insufficient funds", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void txtApostRoom_TextChanged(object sender, EventArgs e)
        {
            if (txtApostRoom.Text.Trim() == "")
            {
                this.lblAmoutEmeraldRoom.Text = "";//valor da aposta
                this.lblPontuction.Text = "";//portuação da sala
                this.lblAmoutEmerald.Text = ""; // quantidade de esmeraldas avulças
                this.lblAmoutChest.Text = ""; // quantidade de baús
                this.lblAmoutEmeraldChest.Text = "";//quantidade de esmeralda em casa bau
            }
            else
            {
                SetValueRoom8();
            }
        }
        private void SetValueRoom8()
        {
            this.lblAmoutEmeraldRoom.Text = this.txtApostRoom.Text;
            this.lblPontuction.Text = $"{Math.Truncate(Convert.ToDouble(this.txtApostRoom.Text) / 2)}";//portuação da sala
            this.lblAmoutEmerald.Text = $"{RendonValue(100, 300)}"; // quantidade de esmeraldas avulças
            this.lblAmoutChest.Text = $"{RendonValue(1, 10)}"; // quantidade de baús
            this.lblAmoutEmeraldChest.Text = $"{Math.Truncate(Convert.ToDouble(this.txtApostRoom.Text) / Convert.ToDouble(this.lblAmoutChest.Text))}";//quantidade de esmeralda em casa bau
            BalancePlayer();
        }
        private int RendonValue(int x, int y)
        {
            Random rnd = new Random();
            return (rnd.Next(x, y));
        }
        private void btnExclamation_Click(object sender, EventArgs e)
        {
            MoreInformation();
        }
        private void GameRoomsForms_Load(object sender, EventArgs e)
        {
            this.CountIndex = 0;
            this.lblAmoutEmeralPlayer.Text = $"{this.gameProfileClasse.GetEsmeraldPlayer()}";
            this.pbxImgPlayer.Image = ImageClass.GetImageAvatar(this.gameProfileClasse.GetAvatarPlayer());
            LoadNameRoom();
        }
        private void LoadNameRoom()
        {
            if (UploadFile(this.fileIndexRooms) == false)
            {
                MessageBox.Show("Error loading images, check the Index file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                LoadInformationRooms(nameRooms[this.CountIndex]);
            }
        }
        private Boolean UploadFile(string fileIndex)
        {
            try
            {
                this.nameRooms = File.ReadAllLines(fileIndex + @"Index.txt", Encoding.UTF8);
                return true;
            }
            catch
            {
                return false;
            }
        }
        private void LoadInformationRooms(string nameSala)
        {
            this.lblNameRooms.Text = $"Room {nameSala}";
            this.lblPnlNameRoom.Text = $"Room {nameSala}";
            this.txtApostRoom.Visible = false;
            this.lblBet.Visible = false;
            this.lblAmoutChest.Text = "2";
            switch (nameSala)
            {
                case "Acauã": //room 1
                    PnlBase.BackgroundImage = ImageClass.GetImageRooms(this.nameRooms[this.CountIndex]);
                    this.lblAmoutEmeraldRoom.Text = "0";
                    this.lblAmoutEmeraldChest.Text = "0";
                    this.lblAmoutEmerald.Text = "0";
                    this.lblPontuction.Text = "5";
                    this.lblAmoutChest.Text = "0";
                    break;
                case "Kianumaka-Manã": //room 2
                    PnlBase.BackgroundImage = ImageClass.GetImageRooms(this.nameRooms[this.CountIndex]);
                    this.lblAmoutEmeraldRoom.Text = 100.ToString();
                    this.lblAmoutEmeraldChest.Text = 100.ToString();
                    this.lblAmoutEmerald.Text = 50.ToString();
                    this.lblPontuction.Text = "20";
                    break;
                case "Jací": //room 3
                    PnlBase.BackgroundImage = ImageClass.GetImageRooms(this.nameRooms[this.CountIndex]);
                    this.lblAmoutEmeraldRoom.Text = 250.ToString();
                    this.lblAmoutEmeraldChest.Text = 250.ToString();
                    this.lblAmoutEmerald.Text = 60.ToString();
                    this.lblPontuction.Text = "40";
                    break;
                case "Iara": // room 4
                    PnlBase.BackgroundImage = ImageClass.GetImageRooms(this.nameRooms[this.CountIndex]);
                    this.lblAmoutEmeraldRoom.Text = 500.ToString();
                    this.lblAmoutEmeraldChest.Text = 500.ToString();
                    this.lblAmoutEmerald.Text = 70.ToString();
                    this.lblPontuction.Text = "60";
                    break;
                case "Caipora": //room 5
                    PnlBase.BackgroundImage = ImageClass.GetImageRooms(this.nameRooms[this.CountIndex]);
                    this.lblAmoutEmeraldRoom.Text = 1000.ToString();
                    this.lblAmoutEmeraldChest.Text = 1000.ToString();
                    this.lblAmoutEmerald.Text = 80.ToString();
                    this.lblPontuction.Text = "100";
                    break;
                case "Tupã": //room 6
                    PnlBase.BackgroundImage = ImageClass.GetImageRooms(this.nameRooms[this.CountIndex]);
                    this.lblAmoutEmeraldRoom.Text = 2500.ToString();
                    this.lblAmoutEmeraldChest.Text = 2500.ToString();
                    this.lblAmoutEmerald.Text = 90.ToString();
                    this.lblPontuction.Text = "250";
                    break;
                case "Anhangá"://room 7
                    PnlBase.BackgroundImage = ImageClass.GetImageRooms(this.nameRooms[this.CountIndex]);
                    this.lblAmoutEmeraldRoom.Text = 5000.ToString();
                    this.lblAmoutEmeraldChest.Text = 5000.ToString();
                    this.lblAmoutEmerald.Text = 150.ToString();
                    this.lblPontuction.Text = "500";
                    break;
                case "Folclore": //room Maluca
                    PnlBase.BackgroundImage = ImageClass.GetImageRooms(this.nameRooms[this.CountIndex]);
                    this.lblAmoutEmeraldRoom.Text = "0";//valor da aposta
                    this.lblPontuction.Text = "0";//portuação da sala
                    this.lblAmoutEmerald.Text = "0"; // quantidade de esmeraldas avulças
                    this.lblAmoutChest.Text = "0"; // quantidade de baús
                    this.lblAmoutEmeraldChest.Text = "0";//quantidade de esmeralda em casa bau
                    this.txtApostRoom.Visible = true;
                    this.lblBet.Visible = true;

                    break;
            }
            BalancePlayer();
            LoadIformationRoom(this.CountIndex);
        }
        private void BalancePlayer()
        {
            if ((Convert.ToInt32(this.lblAmoutEmeralPlayer.Text) >= (Convert.ToInt32(this.lblAmoutEmeraldRoom.Text))))
            {
                this.lblAmoutEmeralPlayer.ForeColor = Color.Blue;
            }
            else
            {
                this.lblAmoutEmeralPlayer.ForeColor = Color.Red;
            }
        }
        private void MoveImagemPnl()
        {
            if (this.CountIndex < 0)
            {
                this.CountIndex = nameRooms.Length - 1;
            }
            else if (this.CountIndex > nameRooms.Length - 1)
            {
                this.CountIndex = 0;
            }
            LoadInformationRooms(nameRooms[this.CountIndex]);
        }
        private void LoadIformationRoom(int numberRoom)
        {
            string roomTxt = $"{this.fileIndexRooms}xroom{numberRoom + 1}.txt";
            this.lblIformationRoom.Text = File.ReadAllText(roomTxt, Encoding.UTF8);
            if (numberRoom + 1 > 1 && numberRoom + 1 <= 7)
            {
                this.btnExclamation.Visible = true;
                this.lblIformationDefaut.Text = File.ReadAllText($"{this.fileIndexRooms}xroomIformation.txt", Encoding.UTF8);
            }
            else
            {
                this.btnExclamation.Visible = false;
            }
        }
        private void OpenPnlLeft()
        {
            switch (this.OpenPnl)
            {
                case true:
                    PnlLeft.Width = 45;
                    btnBattle.Width = 42;
                    this.OpenPnl = false;
                    this.btnOpen.Visible = true;
                    this.BtnClousePnl.Visible = false;
                    this.btnCLouse.Enabled = true;
                    break;
                case false:
                    PnlLeft.Width = 424;
                    btnBattle.Width = 423;
                    this.OpenPnl = true;
                    this.btnOpen.Visible = false;
                    this.BtnClousePnl.Visible = true;
                    this.btnCLouse.Enabled = false;
                    break;
            }
        }
        private void MoreInformation()
        {
            if (this.lblIformationDefaut.Visible == false)
            {
                this.lblIformationDefaut.Visible = true;
                this.lblIformationRoom.Visible = false;
            }
            else
            {
                this.lblIformationDefaut.Visible = false;
                this.lblIformationRoom.Visible = true;
            }
        }

    }
}
