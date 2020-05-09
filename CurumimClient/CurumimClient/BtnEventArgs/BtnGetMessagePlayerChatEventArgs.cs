using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurumimClient.BtnEventArgs
{
    public class BtnGetMessagePlayerChatEventArgs : EventArgs
    {
        public int idSender { get; set; }
        public int idReceiver { get; set; }
    }
}
