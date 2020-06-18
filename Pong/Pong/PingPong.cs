using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    class PingPong
    {
        static int firstPlayerPadSize = 10;
        static int secondPlayerPadSize = 4;
        static int ballPositionX = 0;
        static int ballPositionY = 0;
        static bool ballDirectionUp = true;
        static bool ballDirectionRight = false;
        static int firstPlayerPosition = 0;
        static int secondPlayerPosition = 0;
        static int firstPlayerResult = 0;
        static int secondPlayerResult = 0;
        static Random randomGenerator = new Random();

        public void RemoveScrollBars()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
        }

        public void PrintAtPosition(int x, int y, char symbol)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(symbol);
        }

        public void DrawFirstPlayer()
        {
            for (int y = firstPlayerPosition; y < firstPlayerPosition + firstPlayerPadSize; y++)
            {
                PrintAtPosition(0, y, '|');
                PrintAtPosition(1, y, '|');
            }
        }

        public void DrawSecondPlayer()
        {
            for (int y = secondPlayerPosition; y < secondPlayerPosition + secondPlayerPadSize; y++)
            {
                PrintAtPosition(Console.WindowWidth - 1, y, '|');
                PrintAtPosition(Console.WindowWidth - 2, y, '|');
            }
        }

        public void SetBallAtTheMiddleOfTheGameField()
        {
            ballPositionX = Console.WindowWidth / 2;
            ballPositionY = Console.WindowHeight / 2;
        }

        public void SetInitialPositions()
        {
            firstPlayerPosition = Console.WindowHeight / 2 - firstPlayerPadSize / 2;
            secondPlayerPosition = Console.WindowHeight / 2 - secondPlayerPadSize / 2;
            SetBallAtTheMiddleOfTheGameField();
        }

        public void DrawBall()
        {
            PrintAtPosition(ballPositionX, ballPositionY, '@');
        }

        public void PrintResult()
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 1, 0);
            Console.Write("{0}-{1}", firstPlayerResult, secondPlayerResult);
        }

        public void MoveFirstPlayerDown()
        {
            if (firstPlayerPosition < Console.WindowWidth - firstPlayerPadSize)
                firstPlayerPosition++;
        }

        public void MoveFirstPlayerUp()
        {
            if (firstPlayerPosition > 0)
                firstPlayerPosition--;
        }

        public void MoveSecondPlayerDown()
        {
            if (secondPlayerPosition < Console.WindowWidth - secondPlayerPadSize)
                secondPlayerPosition++;
        }

        public void MoveSecondPlayerUp()
        {
            if (secondPlayerPosition > 0)
                secondPlayerPosition--;
        }

        public void SecondPlayerAIMove()
        {
            int randomNumber = randomGenerator.Next(1, 101);

            if (randomNumber <= 70)
            {
                if (ballDirectionUp == true)
                    MoveSecondPlayerUp();
                else
                    MoveSecondPlayerDown();
            }
        }

        public void MoveBall()
        {
            if (ballPositionY == 0)
                ballDirectionUp = false;

            if (ballPositionY == Console.WindowHeight - 1)
                ballDirectionUp = true;

            if (ballPositionX == Console.WindowWidth - 1)
            {
                SetBallAtTheMiddleOfTheGameField();
                ballDirectionRight = false;
                ballDirectionUp = true;
                firstPlayerResult++;
                Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                Console.Write("First Player Wins!");
                Console.ReadKey();
            }

            if (ballPositionX == 0)
            {
                SetBallAtTheMiddleOfTheGameField();
                ballDirectionRight = true;
                ballDirectionUp = true;
                secondPlayerResult++;
                Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                Console.Write("Second Player Wins!");
                Console.ReadKey();
            }

            if (ballPositionX < 3)
            {
                if (ballPositionY >= firstPlayerPosition && ballPositionY < firstPlayerPosition + firstPlayerPadSize)
                    ballDirectionRight = true;
            }

            if (ballPositionX >= Console.WindowWidth -3 - 1)
            {
                if (ballPositionY >= secondPlayerPosition && ballPositionY < secondPlayerPosition + secondPlayerPadSize)
                    ballDirectionRight = false;
            }

            if (ballDirectionUp)
                ballPositionY--;
            else
                ballPositionY++;

            if (ballDirectionRight)
                ballPositionX++;
            else
                ballPositionX--;
        }
    }
}
