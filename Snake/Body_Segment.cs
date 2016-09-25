using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Snake
{
	class Body_Segment
	{
		public Vector2 GridPosition { get; private set; }
		private Texture2D texture;

		public Body_Segment(GraphicsDevice graphicsdevice, Vector2 local)
		{
			this.GridPosition = local;

			texture = new Texture2D(graphicsdevice, 1, 1, false, SurfaceFormat.Color);
			texture.SetData<Color>(new Color[] { Color.White });
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Begin();
			spriteBatch.Draw(texture, new Rectangle(Body.ConvertCoord((int)GridPosition.X), Body.ConvertCoord((int)GridPosition.Y), 20, 20), Color.White);
			spriteBatch.End();
		}
	}
}
