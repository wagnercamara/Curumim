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
                case 1:
                    this.singleEsmeralds = 0;
                    this.premiumEsmerald = 100;
                    this.premiumScore = 5;
                    break;
                case 2:
                    this.singleEsmeralds = 50;
                    this.premiumEsmerald = 100;
                    this.premiumScore = 20;
                    break;
                case 3:
                    this.singleEsmeralds = 60;
                    this.premiumEsmerald = 250;
                    this.premiumScore = 40;
                    break;
                case 4:
                    this.singleEsmeralds = 70;
                    this.premiumEsmerald = 500;
                    this.premiumScore = 60;
                    break;
                case 5:
                    this.singleEsmeralds = 80;
                    this.premiumEsmerald = 1000;
                    this.premiumScore = 100;
                    break;
                case 6:
                    this.singleEsmeralds = 90;
                    this.premiumEsmerald = 2500;
                    this.premiumScore = 250;
                    break;
                case 7:
                    this.singleEsmeralds = 150;
                    this.premiumEsmerald = 5000;
                    this.premiumScore = 500;
                    break;
                case 8:
                    this.singleEsmeralds = this.random.Next(100, 401);
                    break;
            }
        }

        public void SetPremiumEsmeraldCrazy(int premiumEsmeraldCrazy)
        {
            this.premiumEsmerald = premiumEsmeraldCrazy;
            this.premiumScore = this.premiumEsmerald / 5;
        }

        private void LoadFieldLeft()
        {
            int localIndian = this.random.Next(0, 300);
            int localchest = -1;
            if (this.typeBattle != 1) { localchest = this.random.Next(0, 300); }
            int singleEsmeraldsLeft = 0;

            for (int i = 0; i < this.buttonFieldLefts.Length; i++)
            {
                if (singleEsmeraldsLeft < this.singleEsmeralds)
                {
                    this.buttonFieldLefts[i] = this.random.Next(0, 2);
                    if (this.buttonFieldLefts[i] == 1) { singleEsmeraldsLeft += 1; }
                }
                else
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
                    else if (button == localchest)
                    {
                        this.buttonFieldLefts[button] = 2;
                    }
                    button++;
                }
            }
        }

        private void LoadFieldRight()
        {
            int localIndian = this.random.Next(0, 300);
            int localchest = -1;
            if (this.typeBattle != 1) { localchest = this.random.Next(0, 300); }
            int singleEsmeraldsRight = 0;

            for (int i = 0; i < this.buttonFieldRights.Length; i++)
            {
                if (singleEsmeraldsRight < this.singleEsmeralds)
                {
                    this.buttonFieldRights[i] = this.random.Next(0, 2);
                    if (this.buttonFieldRights[i] == 1) { singleEsmeraldsRight += 1; }
                }
                else
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
                    else if (button == localchest)
                    {
                        this.buttonFieldRights[button] = 2;
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
    }
}
