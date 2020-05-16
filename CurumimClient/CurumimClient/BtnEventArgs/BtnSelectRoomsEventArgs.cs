using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurumimClient.BtnEventArgs
{
    public class BtnSelectRoomsEventArgs:EventArgs
    {
        public Boolean Open { get; set; }
        public String TypeRooms { get; set; }
    }
}
