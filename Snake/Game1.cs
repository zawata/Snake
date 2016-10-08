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

		private Food food = null;
		private bool foodEaten = false;

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
		}

		protected override void Initialize()
		{
			base.Initialize();
			spriteBatch = new SpriteBatch(GraphicsDevice);
			Screen.setScreen();
			food = new Food(GraphicsDevice, new Vector2(3,3));
		}

		protected override void LoadContent() {}
		protected override void UnloadContent() {}

		protected override void Update(GameTime gameTime)
		{
			if (Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			Vector2 nextPosition;

			elapsedTime += gameTime.ElapsedGameTime;

			if (elapsedTime > TimeSpan.FromSeconds(1.0F/FPS))
			{
				elapsedTime -= TimeSpan.FromSeconds(1.0F/FPS);
				frameRate = frameCounter;
				frameCounter = 0;

				//
				//actual game code starts here
				//
				nextPosition = Body.getNextPosition();
				nextPosition = Screen.checkBounds(nextPosition);
				if(nextPosition.Equals(food.GridPosition))
				{
					Body.MaxSegments++;
					foodEaten = true;
				}
				Body.move(nextPosition);
			}

			if (foodEaten)
			{
				foodEaten = false;
			}
			base.Update(gameTime);
			return;
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