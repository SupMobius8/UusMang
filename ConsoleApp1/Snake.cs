using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	class Snake : Figure
	{
		Direction direction;
		int score = 0;

		public Snake(ConsoleApp1.Point tail, int length, ConsoleApp1.Direction _direction)
		{
			direction = _direction;
			pList = new List<ConsoleApp1.Point>();
			for (int i = 0; i < length; i++)
			{
                ConsoleApp1.Point p = new ConsoleApp1.Point(tail);
				p.Move(i, direction);
				pList.Add(p);
			}
		}

		public void Move()
		{
            ConsoleApp1.Point tail = pList.First();
			pList.Remove(tail);
            ConsoleApp1.Point head = GetNextPoint();
			pList.Add(head);

			tail.Clear();
			head.Draw();
		}

		public ConsoleApp1.Point GetNextPoint()
		{
            ConsoleApp1.Point head = pList.Last();
            ConsoleApp1.Point nextPoint = new ConsoleApp1.Point(head);
			nextPoint.Move(1, direction);
			return nextPoint;
		}

		public bool IsHitTail()
		{
			var head = pList.Last();
			for (int i = 0; i < pList.Count - 2; i++)
			{
				if (head.IsHit(pList[i]))
					return true;
			}
			return false;
		}

		public void HandleKey(ConsoleKey key)
		{
			if (key == ConsoleKey.LeftArrow)
				direction = Direction.LEFT;
			else if (key == ConsoleKey.RightArrow)
				direction = Direction.RIGHT;
			else if (key == ConsoleKey.DownArrow)
				direction = Direction.DOWN;
			else if (key == ConsoleKey.UpArrow)
				direction = Direction.UP;
		}

		public bool Eat(ConsoleApp1.Point food)
		{
            ConsoleApp1.Point head = GetNextPoint();
			if (head.IsHit(food))
			{
				score++;
				Console.SetCursorPosition(82, 10);
				Console.WriteLine($"Score: {score}");
				food.sym = head.sym;
				pList.Add(food);
				return true;
			}
			else
				return false;
		}
	}
}

