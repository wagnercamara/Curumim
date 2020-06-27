using System;
using System.Collections.Generic;
using System.Text;

namespace CurumimServer
{
    class GameBattle
    {
        private int[] buttonFieldLefts = new int[300];
        private int[] buttonFieldRights = new int[300];
        private int fieldHeight = 15;
        private int fieldWidth = 20;
        private int premiumScore;
        private int premiumEsmerald;
        private int singleEsmeralds;
        private int chestBattle;
        private int typeBattle;
        private Random random = new Random();
        private string loginPlayer1;
        private string loginPlayer2;
        public GameBattle(int typeBattle, string loginPlayer1, string loginPlayer2)
        {
            this.typeBattle = typeBattle;
            this.loginPlayer1 = loginPlayer1;
            this.loginPlayer2 = loginPlayer2;

            LoadTypeBattle();
            LoadFieldLeft();
            LoadFieldRight();
        }

        private void LoadTypeBattle()
        {
            switch (this.typeBattle)
            {
                case 0:
                    this.singleEsmeralds = 0;
                    this.chestBattle = 2;
                    this.premiumEsmerald = 100;
                    this.premiumScore = 5;
                    break;
                case 1:
                    this.singleEsmeralds = 50;
                    this.chestBattle = 2;
                    this.premiumEsmerald = 100;
                    this.premiumScore = 20;
                    break;
                case 2:
                    this.singleEsmeralds = 60;
                    this.chestBattle = 2;
                    this.premiumEsmerald = 250;
                    this.premiumScore = 40;
                    break;
                case 3:
                    this.singleEsmeralds = 70;
                    this.chestBattle = 2;
                    this.premiumEsmerald = 500;
                    this.premiumScore = 60;
                    break;
                case 4:
                    this.singleEsmeralds = 80;
                    this.chestBattle = 2;
                    this.premiumEsmerald = 1000;
                    this.premiumScore = 100;
                    break;
                case 5:
                    this.singleEsmeralds = 90;
                    this.chestBattle = 2;
                    this.premiumEsmerald = 2500;
                    this.premiumScore = 250;
                    break;
                case 6:
                    this.singleEsmeralds = 150;
                    this.chestBattle = 2;
                    this.premiumEsmerald = 5000;
                    this.premiumScore = 500;
                    break;
                case 7:
                    this.singleEsmeralds = this.random.Next(100, 401);
                    this.chestBattle = this.random.Next(1, 11);
                    break;
            }
        }

        public void SetPremiumEsmeraldCrazy(int premiumEsmeraldCrazy)
        {
            this.premiumEsmerald = premiumEsmeraldCrazy;
            this.premiumScore = this.premiumEsmerald / this.chestBattle;
        }

        private void LoadFieldLeft()
        {
            int localIndian = this.random.Next(0, 300);
            int localchest = 0;
            int singleEsmeraldsLeft = 0;

            for (int i = 0; i < this.buttonFieldLefts.Length; i++)
            {
                this.buttonFieldLefts[i] = this.random.Next(0, 3);

                if (this.buttonFieldLefts[i] == 2)
                {
                    if (localchest < this.chestBattle) { localchest += 1; }
                    else { this.buttonFieldLefts[i] = 0; }
                }

                if (this.buttonFieldLefts[i] == 1)
                {
                    if (singleEsmeraldsLeft < this.singleEsmeralds) { singleEsmeraldsLeft += 1; }
                    else { this.buttonFieldLefts[i] = 0; }
                }

                if (this.buttonFieldLefts[i] == 3)
                {
                    this.buttonFieldLefts[i] = 0;
                }
            }

            int button = 0;
            for (int i = 0; i < this.fieldHeight; i++)
            {
                for (int j = 0; j < this.fieldWidth; j++)
                {
                    if (button == localIndian)
                    {
                        this.buttonFieldLefts[button] = 3;
                    }
                    button++;
                }
            }
        }

        private void LoadFieldRight()
        {
            int localIndian = this.random.Next(0, 300);
            int localchest = 0;
            int singleEsmeraldsRight = 0;

            for (int i = 0; i < this.buttonFieldRights.Length; i++)
            {
                this.buttonFieldRights[i] = this.random.Next(0, 3);

                if (this.buttonFieldRights[i] == 2)
                {
                    if (localchest < this.chestBattle) { localchest += 1; }
                    else { this.buttonFieldRights[i] = 0; }
                }

                if (this.buttonFieldRights[i] == 1)
                {
                    if (singleEsmeraldsRight < this.singleEsmeralds) { singleEsmeraldsRight += 1; }
                    else { this.buttonFieldRights[i] = 0; }
                }

                if(this.buttonFieldRights[i] == 3)
                {
                    this.buttonFieldRights[i] = 0;
                }
            }

            int button = 0;
            for (int i = 0; i < this.fieldHeight; i++)
            {
                for (int j = 0; j < this.fieldWidth; j++)
                {
                    if (button == localIndian)
                    {
                        this.buttonFieldRights[button] = 3;
                    }
                    button++;
                }
            }
        }

        public int[] GetFieldLeft()
        {
            return this.buttonFieldLefts;
        }

        public int[] GetFieldRight()
        {
            return this.buttonFieldRights;
        }

        public string GetIdPlayer1()
        {
            return this.loginPlayer1;
        }

        public string GetIdPlayer2()
        {
            return this.loginPlayer2;
        }

        public int GetPremimEsmerald()
        {
            return this.premiumEsmerald;
        }

        public int GetPremimScore()
        {
            return this.premiumScore;
        }
    }
}
