using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurumimClient.Classe
{
    public class GameWeaponsClasse
    {
        private Int32 idItem { get; } //QTD
        private Int32 amountWeapons { get; set; } //QTD
        private Int32 levelItem { get; } //level da arma
        private Int32 valueUnitItem { get; } // valor do item OBS: pode tirar
        private Int32 destructionAreaItem { get; } // area de destruição 3x3
        private Int32 spaceHit { get; } // quantidade de dano 3quadrados
        private Int32 reach { get; } // alcanço no campo
        private Int32 typeItem { get; } // arma ou coletor

        public GameWeaponsClasse(Int32 idItem, Int32 levelItem, Int32 valueUnitItem, Int32 destructionAreaItem, Int32 spaceHit, Int32 reach, Int32 typeItem)
        {
            this.idItem = idItem;
            this.levelItem = levelItem;
            this.valueUnitItem = valueUnitItem;
            this.destructionAreaItem = destructionAreaItem;
            this.spaceHit = spaceHit;
            this.reach = reach;
            this.typeItem = typeItem;
        }
        public Int32 GetIdItem() { return this.idItem; }
        public Int32 GetAmountWeapons() { return this.amountWeapons; }
        public Int32 GetLevelItem() { return this.levelItem; }
        public Int32 GetValueUnitItem() { return this.valueUnitItem; }
        public Int32 GetDestructionAreaItem() { return this.destructionAreaItem; }
        public Int32 GetSpaceHit() { return this.spaceHit; }
        public Int32 GetReach() { return this.reach; }
        public Int32 GetTypeItem() { return this.typeItem; }
        public void SetAmountWeapons(Int32 amount) { this.amountWeapons = amount; }
    }
}
