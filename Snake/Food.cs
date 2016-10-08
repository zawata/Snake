using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Snake
{
	class Food
	{
		public Vector2 GridPosition { get; private set; }
		private Texture2D texture;

		public Food(GraphicsDevice graphicsdevice, Vector2 local)
		{
			this.GridPosition = local;

			texture = new Texture2D(graphicsdevice, 1, 1, false, SurfaceFormat.Color);
			texture.SetData<Color>(new Color[] { Color.Green });
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