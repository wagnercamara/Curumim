using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurumimClient.BtnEventArgs
{
    public class BtnRoomsInformationEventArgs:EventArgs
    {
        public int[] valuesRoom { get; set; }
    }
}
