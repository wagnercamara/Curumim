using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurumimClient.EventArgsForms
{
    public class GetSearchPlayerEventArgs: EventArgs
    {
        public Boolean typeSearch { get; set; }
        public string loginPlayer { get; set; }
    }
}
