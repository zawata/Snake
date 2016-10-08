using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Snake
{
	public static class Screen
	{
		public static Vector2 Size = new Vector2(24,24);
		public static class Bounds
		{
			public static int Width
			{
				get { return Game1.graphics.GraphicsDevice.Viewport.Width; }
				set
				{
					Game1.graphics.PreferredBackBufferWidth = value;
					Game1.graphics.ApplyChanges();
				}
			}
			public static int Height
			{
				get { return Game1.graphics.GraphicsDevice.Viewport.Height; }
				set
				{
					Game1.graphics.PreferredBackBufferHeight = value;
					Game1.graphics.ApplyChanges();
				}
			}
		}

		public static void setScreen()
		{
			Bounds.Width = Cell2pix((int)Size.X + 1);
			Bounds.Height = Cell2pix((int)Size.Y + 1);
		}

		public static Vector2 checkBounds(Vector2 pos)
		{
			Vector2 retval = new Vector2();
			if (pos.X > Size.X)
				retval.X = 0;
			else
				if (pos.X < 0)
					retval.X = Size.X;
				else
					retval.X = pos.X;

			if (pos.Y > Size.Y)
				retval.Y = 0;
			else
				if (pos.Y < 0)
					retval.Y = Size.Y;
				else
					retval.Y = pos.Y;

			return retval;
		}

		public static int Cell2pix(int num) //from grid num to pixels
		{
			return (num * 25) + 5;
		}
        public static int pix2Cell(int num) //from pixels to grid num
		{
		    return (num - (num % 25))/25;
		}
	}
}