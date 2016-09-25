using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Snake
{
	public class Game1 : Game
	{
		public static GraphicsDeviceManager graphics;
		public static SpriteBatch spriteBatch;
		public static float FPS = 10;

		private int frameRate = 0;
		private int frameCounter = 0;
		private TimeSpan elapsedTime = TimeSpan.Zero;

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
		}

		protected override void Initialize()
		{
			base.Initialize();
		}

		protected override void LoadContent()
		{
			spriteBatch = new SpriteBatch(GraphicsDevice);
		}

		protected override void UnloadContent()
		{
		}

		protected override void Update(GameTime gameTime)
		{
			Vector2 NextPosition;
			
			if (Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			elapsedTime += gameTime.ElapsedGameTime;

			if (elapsedTime > TimeSpan.FromSeconds(1.0F/FPS))
			{
				elapsedTime -= TimeSpan.FromSeconds(1.0F/FPS);
				frameRate = frameCounter;
				frameCounter = 0;
			}
			else
			{
				base.Update(gameTime);
				return;
			}

			NextPosition = Body.getNextPosition();
			Body.move(NextPosition);

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			frameCounter++;

			GraphicsDevice.Clear(Color.Black);
			Body.draw(spriteBatch);
			base.Draw(gameTime);
		}
	}
}
