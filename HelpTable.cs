using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHA3.Net;

namespace Task_3
{
    class HelpTable
    {
        private string[] strItem;
        private int itemCount;
        public HelpTable()
        {
            itemCount = 0;
        }
        public HelpTable(string[] strArr)
        {
            strItem = strArr;
            itemCount = strArr.Length;
        }

        public void WriteHelpTable()
        {
            if (itemCount <= 0)
                Console.WriteLine("=============================================================================");
            int maxlen = 4;
            string str = "";
            for (int i = 0; i < itemCount; i++)
            {
                if (strItem[i].Length > maxlen)
                {
                    maxlen = strItem[i].Length;
                }

                if (strItem[i].Length < 4)
                    str = str.PadRight(str.Length + 5, '-');
                else
                    str = str.PadRight(str.Length + strItem[i].Length + 1, '-');


            }
            str = str.PadRight(str.Length + maxlen + 2, '-');
            Console.WriteLine(str);
            string s = "|";
            Console.Write(s.PadRight(maxlen + 1));
            for (int i = 0; i < itemCount; i++)
            {
                s = "|";
                //Console.Write("|");
                s += strItem[i];
                if (strItem[i].Length < 4)
                    s = s.PadRight(5);
                Console.Write(s);
            }
            Console.WriteLine("|");
            Console.WriteLine(str);

            for (int i = 0; i < itemCount; i++)
            {
                s = "|";
                s += strItem[i];
                if (strItem[i].Length < maxlen)
                    s = s.PadRight(maxlen + 1);
                for (int j = 0; j < itemCount; j++)
                {
                    RulesGame rs = new RulesGame(i, j, itemCount);
                    s += "|";
                    string s1 = rs.GetWinner();// i, j, strArr.Length);
                    s += s1;
                    if (s1.Length <= strItem[j].Length)
                    {
                        if(strItem[j].Length < 4)
                            s = s.PadRight(s.Length + 4 - s1.Length);
                        else
                            s = s.PadRight(s.Length + strItem[j].Length - s1.Length);
                    }
                    else
                    {
                        if (s1.Length < 4)
                            s = s.PadRight(s.Length + 4 - s1.Length);

                    }
                }
                s += "|";
                Console.WriteLine(s);
                Console.WriteLine(str);
            }
        }
    }
}
