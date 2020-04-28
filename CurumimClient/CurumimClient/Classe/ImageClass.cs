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

        public Image GetImageIconArsenal(string nameIcon)
        {
            return Image.FromFile(fillApp + @"Icon/player/"+ nameIcon + @".png");
        }
        public Image GetImageAvatar(string nameAvatar)
        {
            return Image.FromFile(fillApp + @"/Avatar/" + nameAvatar + ".png");
        }


    }
}
