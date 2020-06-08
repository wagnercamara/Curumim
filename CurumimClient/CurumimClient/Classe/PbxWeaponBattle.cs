using CurumimClient.Classe;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurumimGameForms
{
    internal class PbxWeaponBattle : PictureBox
    {
        private ImageClass ImageClass = new ImageClass();

        private Dictionary<int, string> imagens = new Dictionary<int, string>{ { 1001, "stone" }, { 1002,"bow1" }, { 1003,"bow2" }, { 1004,"bow3" },
            { 1005,"crossbow1" }, { 1006,"crossbow2" }, { 1007,"crossbow3" },{ 1008,"catapult1" }, { 1009,"catapult2" }, { 1010,"catapult3" }, { 1011,"Rope" },
            { 1012,"hookRope1" }, { 1013,"hookRope2" }, { 1014,"hookRope3" }, { 1015,"fishingNet1" }, { 1016,"fishingNet2" } };

        private int idItem;

        public PbxWeaponBattle(int idItem)
        {
            this.idItem = idItem;
            this.BackColor = Color.Transparent;
            this.BackgroundImageLayout = ImageLayout.Zoom;
            this.BackgroundImage = this.ImageClass.GetImageIconBattleForms(imagens[this.idItem]);
            this.Size = new Size(60, 50);
            this.TabIndex = 0;
            this.Enabled = true;
        }
    }
}
