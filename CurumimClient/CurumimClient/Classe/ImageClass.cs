using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurumimClient.Classe
{
    public class ImageClass
    {
        private string fillApp = "../../img/";

        public Image GetImageIconArsenal(string nameArm)
        {
            return Image.FromFile(fillApp + @"Icon/player/arsenal/" + nameArm + @".png");
        }
        public Image GetImageAvatar(string nameAvatar)
        {
            return Image.FromFile(fillApp + @"/Avatar/" + nameAvatar + ".png");
        }
        public Image GetImageIconStore(string nameArm)
        {
            return Image.FromFile(fillApp + @"Icon/player/store/" + nameArm + @".png");
        }
        public Image GetImageIconLevel(string level)
        {
            return Image.FromFile(fillApp + @"Icon/level/96x96/" + level + @".png");
        }
        public Image GetImageIconForms(string level)
        {
            return Image.FromFile(fillApp + @"Icon/player/" + level + @".png");
        }
        public Image GetImageIconBattleForms(String nameIcon)
        {
            return Image.FromFile(fillApp + @"Icon/battleForm/" + nameIcon + @".png");
        }
    }
}
