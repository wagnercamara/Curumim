using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurumimGameForms.BtnEventArgs
{
    public class BtnLoginOnClickEventArgs : EventArgs
    {
        public string loginPlayer { get; set; }
        public string passwordPlayer { get; set; }

    }
}
