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
			food = new Food(GraphicsDevice, Screen.Size);
		}

		protected override void LoadContent() {}
		protected override void UnloadContent() {}

		protected override void Update(GameTime gameTime)
		{
			Vector2 nextPosition;

			if (Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			elapsedTime += gameTime.ElapsedGameTime;

			if (elapsedTime > TimeSpan.FromSeconds(1.0F/FPS))
			{
				elapsedTime -= TimeSpan.FromSeconds(1.0F/FPS);
				frameRate = frameCounter;
				frameCounter = 0;

				//
				//actual game code starts here
				//
				if(foodEaten)
				{
					foodEaten = false;
					Vector2 food_pos = new Vector2();
					bool properPos = true;
					do
					{
						food_pos = food.getNextPosition(Screen.Size);
						foreach(Vector2 position in Body.GetBodyPositions())
						{
							if(position.Equals(food_pos))
							{
								properPos = false;
								break;
							}
						}
					}
					while(!properPos);
					properPos = true;
					food.setNextPosition(food_pos);
				}

				nextPosition = Body.getNextPosition();
				nextPosition = Screen.checkBounds(nextPosition);
				if(nextPosition.Equals(food.GridPosition) && !foodEaten)
				{
					Body.MaxSegments++;
					foodEaten = true;
				}
				Body.move(nextPosition);
			}

			base.Update(gameTime);
			return;
		}

		protected override void Draw(GameTime gameTime)
		{
			frameCounter++;
			GraphicsDevice.Clear(Color.Black);
			if(!foodEaten)
				food.Draw(spriteBatch);
			Body.draw(spriteBatch);
			base.Draw(gameTime);
		}
	}
}