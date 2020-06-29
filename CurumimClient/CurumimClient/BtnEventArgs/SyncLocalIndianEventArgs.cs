using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurumimClient.BtnEventArgs
{
    class SyncLocalIndianEventArgs : EventArgs
    {
        public int oldLocal { get; set; }
        public int newLocal { get; set; }
        public string loginPlayer { get; set; }
    }
}