using System.Linq;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Snake
{
	public static class Body
	{
		public static int Max_Segments {get; set;}
		public static int currentDirection {get; private set;} = 0;

		private static Queue<Body_Segment> body_queue = new Queue<Body_Segment>();

		static Body()
		{
			Max_Segments = 5;
			addSegment(new Vector2(1,1));
		}

		public static void move(Vector2 pos)
		{
			addSegment(pos);
			drop_last_Segment();
		}
		public static Vector2 getNextPosition()
		{
			//direction
			// 1 = left
			// 2 = up
			// 3 = right
			// 4 = down

			Vector2 headPosition = body_queue.Last<Body_Segment>().GridPosition;
			Vector2 nextPosition = new Vector2(0,0);
			Keys[] keys = Keyboard.GetState().GetPressedKeys();

			if (keys.GetLength(0) > 0) //if key pressed
			{
				foreach (Keys key in keys) //iterate through all pressed keys
				{
					switch (key) // set direction if changed
					{
						case Keys.Left:
							if (currentDirection != 3)
								currentDirection = 1;
							break;
						case Keys.Up:
							if (currentDirection != 4)
								currentDirection = 2;
							break;
						case Keys.Right:
							if (currentDirection != 1)
								currentDirection = 3;
							break;
						case Keys.Down:
							if (currentDirection != 2)
								currentDirection = 4;
							break;
						default:
							// Other Keys
							break;
					}
				}
			}
			switch (currentDirection) //set next cell whether changed or not
			{
				case 1:
					nextPosition = new Vector2(headPosition.X - 1, headPosition.Y);
					break;
				case 2:
					nextPosition = new Vector2(headPosition.X, headPosition.Y - 1);
					break;
				case 3:
					nextPosition = new Vector2(headPosition.X + 1, headPosition.Y);
					break;
				case 4:
					nextPosition = new Vector2(headPosition.X, headPosition.Y + 1);
					break;
				default:
					break;
			}
			return nextPosition; //return next head segment position
		}

		public static void draw(SpriteBatch spriteBatch)
		{
			foreach (Body_Segment element in body_queue) //iterate through all body sements...
				element.Draw(spriteBatch); //...and draw them
		}

		public static void addSegment(Vector2 gridpos) //shorter version
		{
			body_queue.Enqueue(new Body_Segment(Game1.graphics.GraphicsDevice, gridpos));
		}

		public static void drop_last_Segment()
		{
			if (Max_Segments >= body_queue.Count) 
				return;
			body_queue.Dequeue();
		}

		public static int ConvertCoord(int num) //from grid to window coord
		{
			return (num * 25) + 5; 
		}
	}
}
