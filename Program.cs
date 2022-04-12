using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using SHA3.Net;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("Error! The number of lines must be greater than 3");
                return;
            }
            else if (args.Length % 2 == 0)
            {
                Console.WriteLine("Error! The number of lines must be odd");
                return;
            }
            //проверка на совпадения
            var strList = args.ToList().Distinct();
            if (strList.Count() != args.Length)
            {
                Console.WriteLine("Error! ");
                return;
            }

            bool b = false;
            RulesGame rules = new RulesGame(args.Length);
            while (b == false)

            {


                Console.WriteLine();
                //RandomKey key = new RandomKey();
                Random rg = new Random();
                int idx = rg.Next(args.Length);
                CalcHMAC hash = new CalcHMAC(args[idx]);
                hash.WriteHash();
                //hash.WriteKey();
                Console.WriteLine("Available moves:");
                for (int i = 0; i < args.Length; i++)
                {
                    if (args.Length > 9 && i < 9)
                        Console.WriteLine("  {0} - {1}", i + 1, args[i]);
                    else
                        Console.WriteLine(" {0} - {1}", i + 1, args[i]);
                }
                if (args.Length > 9)
                {
                    Console.WriteLine("  0 - exit");
                    Console.WriteLine("  ? - help");
                }
                else
                {
                    Console.WriteLine(" 0 - exit");
                    Console.WriteLine(" ? - help");
                }
                Console.Write("Enter your move: ");
                string sMove = Console.ReadLine();

                sMove.Trim();
                if (sMove == "?")
                {
                    HelpTable helpTbl = new HelpTable(args);
                    helpTbl.WriteHelpTable();
                    Console.WriteLine("Computer move: {0}", args[idx]);
                    hash.WriteKey();
                }
                else
                {
                    int result = 0;
                    bool bParse = int.TryParse(sMove, out result);
                    if (bParse == true)
                    {
                        if (result == 0)
                        {
                            b = true;
                        }
                        else if (result < args.Length + 1)
                        {
                            rules.SetMovePlayers(result - 1, idx);
                            Console.WriteLine("Your move: {0}", args[result - 1]);
                            Console.WriteLine("Computer move: {0}", args[idx]);
                            Console.WriteLine("You {0}!", rules.GetWinner());
                            hash.WriteKey();
                        }
                        else
                        {
                            Console.WriteLine("ERROR!!!");
                            Console.WriteLine("Your move: {0}", sMove);
                            Console.WriteLine("Computer move: {0}", args[idx]);
                            hash.WriteKey();
                        }

                    }
                    else
                    {
                        Console.WriteLine("ERROR!!!");
                        Console.WriteLine("Your move: {0}", sMove);
                        Console.WriteLine("Computer move: {0}", args[idx]);
                        hash.WriteKey();
                    }
                }
            }
        }
    }
}
