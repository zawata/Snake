using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Snake
{
	class Food
	{
		public Vector2 GridPosition { get; private set; }
		private Texture2D texture;
		private Random randGen = new Random();

		public Food(GraphicsDevice graphicsdevice, Vector2 ScreenSize)
		{
			this.GridPosition = new Vector2(randGen.Next(0, (int)(ScreenSize.X + 1)),randGen.Next(0, (int)(ScreenSize.Y + 1)));

			texture = new Texture2D(graphicsdevice, 1, 1, false, SurfaceFormat.Color);
			texture.SetData<Color>(new Color[] { Color.Green });
		}

		public Vector2 getNextPosition(Vector2 ScreenSize)
		{
			return new Vector2(randGen.Next(0, (int)(ScreenSize.X + 1)),randGen.Next(0, (int)(ScreenSize.Y + 1)));
		}
		public void setNextPosition(Vector2 position)
		{
			GridPosition = position;
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			Rectangle bounds = new Rectangle(Screen.Cell2pix((int)GridPosition.X), Screen.Cell2pix((int)GridPosition.Y), 20, 20);
			spriteBatch.Begin();
			spriteBatch.Draw(texture, bounds, Color.White);
			spriteBatch.End();
		}
	}
}