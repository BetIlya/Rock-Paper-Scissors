using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHA3.Net;

namespace Task_3
{
    class RulesGame
    {
        private int movePlayer, moveComp, count, cntWinPlayer, cntWinComp;
        public RulesGame(int cnt)
        {
            movePlayer = 0;
            moveComp = 0;
            count = cnt;
            cntWinPlayer = 0;
            cntWinComp = 0;
        }
        public RulesGame(int pl, int cmp, int cnt)
        {
            movePlayer = pl;
            moveComp = cmp;
            count = cnt;
            cntWinPlayer = 0;
            cntWinComp = 0;
        }
        public void SetMovePlayers(int pl, int cmp)
        {
            movePlayer = pl;
            moveComp = cmp;
        }
        public static string GetResult(int result)
        {
            string s = string.Empty;
            switch (result)
            {
                case 0:
                    s = "win";
                    break;
                case 1:
                    s = "lose";
                    break;
                case 2:
                    s = "draw";
                    break;
            }
            return s;
        }
        public string GetWinner()
        {
            if (movePlayer == moveComp)
                return GetResult(2);
            int i1 = movePlayer;
            int i2 = moveComp;
            if (movePlayer > moveComp)
                i2 += count;
            if (i2 - i1 > count / 2)
            {
                cntWinComp++;
                return GetResult(1);
            }
            else
            {
                cntWinPlayer++;
                return GetResult(0);
            }
        }

    }

}
