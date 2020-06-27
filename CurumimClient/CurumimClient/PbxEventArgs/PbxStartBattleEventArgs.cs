using CurumimClient.Classe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurumimClient.PbxEventArgs
{
    class PbxStartBattleEventArgs : EventArgs
    {
        public Dictionary<string, GameWeaponsClasse> battleList { get; set; }
    }
}
