using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurumimGameForms
{

    public class GameProfileClasse
    {
        private string fullNamePlayer { get; }
        private string loginPlayer { get; }
        private string avatarPlayer { get; set; }
        private Int32 idPlayer { get; }
        private Int32 punctuationPlayer { get; set; }
        private Int32 rankingPlayer { get; set; }
        private Int32 victoryPlayer { get; set; }
        private Int32 totalBatllesPlayer { get; set; }
        private Int32 esmeraldPlayer { get; set; }

        public GameProfileClasse(Int32 idPlayer, string fullNamePlayer, string loginPlayer, string avatarPlayer)
        {
            this.fullNamePlayer = fullNamePlayer;
            this.loginPlayer = loginPlayer;
            this.idPlayer = idPlayer;
            this.avatarPlayer = avatarPlayer;
        }

        //Get
        public string GetAvatarPlayer()
        {
            return this.avatarPlayer;
        }
        public string GetFullNamePlayer()
        {
            return this.fullNamePlayer;
        }
        public string GetLoginPlayer()
        {
            return this.loginPlayer;
        }
        public Int32 GetIdPlayer()
        {
            return this.idPlayer;
        }
        public Int32 GetPunctuationPlayer()
        {
            return this.punctuationPlayer;
        }
        public Int32 GetRankingPlayer()
        {
            return this.rankingPlayer;
        }
        public Int32 GetVictoryPlayer()
        {
            return this.victoryPlayer;
        }
        public Int32 GetTotalBattlesPlayer()
        {
            return this.totalBatllesPlayer;
        }
        public Int32 GetEsmeraldPlayer()
        {
            return this.esmeraldPlayer;
        }

        public string GetLevelPlayer()
        {
            if (this.punctuationPlayer <= 500)
            {
                return "Curumim";
            }
            if (this.punctuationPlayer > 500 && this.punctuationPlayer <= 2000)
            {
                return "Indio";
            }
            if (this.punctuationPlayer > 2000 && this.punctuationPlayer <= 5000)
            {
                return "Page";
            }
            return "Cacique";
        }
        //Set
        public void SetPunctuationPlayer(Int32 punctuationPlayer)
        {
            this.punctuationPlayer = punctuationPlayer;
        }
        public void SetRankingPlayer(Int32 rankingPlayer)
        {
            this.rankingPlayer = rankingPlayer;
        }
        public void SetVictoryPlayer(Int32 victoryPlayer)
        {
            this.victoryPlayer = victoryPlayer;
        }
        public void SetTotalBatllesPlayer(Int32 totalBatllesPlayer)
        {
            this.totalBatllesPlayer = totalBatllesPlayer;
        }
        public void SetEsmeraldPlayer(Int32 esmeraldPlayer)
        {
            this.esmeraldPlayer = esmeraldPlayer;
        }
    }

}
