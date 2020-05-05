using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace CurumimClient.BtnEventArgs
{
    public class BtnMessageOff_On_LineEventArgs : EventArgs
    {
        public Boolean Off_On_Line { get; set; }
    }
}
