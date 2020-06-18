using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pong
{
    class Program
    {
        static void Main(string[] args)
        {
            PingPong pong = new PingPong();

            pong.RemoveScrollBars();
            pong.SetInitialPositions();
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.UpArrow)
                        pong.MoveFirstPlayerUp();

                    if (keyInfo.Key == ConsoleKey.DownArrow)
                        pong.MoveFirstPlayerDown();
                }

                pong.SecondPlayerAIMove();
                pong.MoveBall();
                Console.Clear();
                pong.DrawFirstPlayer();
                pong.DrawSecondPlayer();
                pong.DrawBall();
                pong.PrintResult();
                Thread.Sleep(60);
            }
        }
    }
}
