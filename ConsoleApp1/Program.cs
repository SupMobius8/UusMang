using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static int speed;
        static void Main(string[] args)
        {
            Console.WriteLine("Vali Kiirus 1-tavaline 2-kiirem!");
            speed = Convert.ToInt32(Console.ReadLine());
            Kiirus diff = new Kiirus(speed);
            diff.diffSet(speed);
            Console.Clear();
            Walls walls = new Walls(80, 25);
            walls.Draw();

            FoodCreator foodCreator = new FoodCreator(80, 25, 'o');
            Point food = foodCreator.CreateFood();
            food.Draw();

            Point p = new Point(4, 5, '+');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                }
                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }
                Thread.Sleep(diff.snSpeed);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }


            }
            WriteGameOver(); //Конец игры
            Console.ReadLine();
        }

        static void WriteGameOver() // Подробности конца игры
        {
            int xOffset = 16;
            int yOffset = 8;
            Console.ForegroundColor = ConsoleColor.Red; // Цвет написанного
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=", xOffset, yOffset++);
            WriteText("              G A M E   O V E R", xOffset + 1, yOffset++);
            yOffset++;
            WriteText("Creator: Maksim Tsvetkov & a few Google searchs", xOffset, yOffset++);
            WriteText("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=", xOffset, yOffset++);
        }
        static void WriteText(String text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);

        }
    }
 
}
