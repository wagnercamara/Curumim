using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurumimClient.PbxEventArgs
{
    public class PbxMessageSendMessageEventArgs:EventArgs
    {
        public int sender_id_tbPlayer { get; set; }
        public int receiver_id_tbPlayer { get; set; }
        public String messageMessage { get; set; }
        public String dateTimeMessage { get; set; }
    }
}
