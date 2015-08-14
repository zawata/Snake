using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Snake
{
    class Body_Segment
    {
        private COORD _gridpos;
        public COORD GridPosition
        {
            get { return _gridpos; }
            set { _gridpos = value; }
        }
        private COORD _screen_coord
        private COORD Screen_Coordinates
        {
            get { return _screen_coord; }
            set { _screen_coord = value; }
        }
        Texture2D texture;
        public Body_Segment(GraphicsDevice graphicsdevice, COORD local, COORD global)
        {
            gridpos = local;
            screen_coord = global;

            texture = new Texture2D(graphicsdevice, 1, 1, false, SurfaceFormat.Color);
            texture.SetData<Color>(new Color[] { Color.White });
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, new Rectangle(screen_coord.First, screen_coord.Second, 20, 20), Color.White);
            spriteBatch.End();
        }
    }
}
