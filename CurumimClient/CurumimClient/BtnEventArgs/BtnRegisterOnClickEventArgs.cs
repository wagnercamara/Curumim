using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurumimGameForms.BtnEventArgs
{
    public class BtnRegisterOnClickEventArgs : EventArgs
    {
        public string fullNamePlayer { get; set; }
        public string loginPlayer { get; set; }
        public string passwordPlayer { get; set; }
        public string secretPhresePlayer { get; set; }
        public string avatarPlayer { get; set; }

    }
}
