using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurumimClient.Classe
{
    public class GameWeaponsClasse
    {
        private int idWeapons { get; set; } // tirar id > dicionario no base
        private string nameWeapons { get; set; } //Nome da Arma.
        private Int32 amountWeapons { get; set; } //QTD
        private Int32 levelItem { get; set; } //level da arma
        private Int32 valueUnitItem { get; set; } // valor do item OBS: pode tirar
        private Int32 destructionAreaItem { get; set; } // area de destruição 3x3
        private Int32 spaceHit { get; set; } // quantidade de dano 3quadrados
        private Int32 reach { get; set; } // alcanço no campo
        private Int32 typeItem { get; set; } // arma ou coletor

        public GameWeaponsClasse(int idWeapons, string nameWeapons)
        {

        }
    }
}
