using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurumimClient.BtnEventArgs
{
    class BtnDestroyedsEventArgs : EventArgs
    {
        public int[] locals { get; set; }
        public string loginPlayer { get; set; }

        public int typeItem { get; set; }
    }
}
