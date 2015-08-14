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
        COORD gridpos;
        COORD screen_coord;
        Texture2D texture;
        public Body_Segment(GraphicsDeviceManager graphicsdevicemanager, COORD local, COORD global)
        {
            gridpos = local;
            screen_coord = global;

            texture = new Texture2D(graphicsdevicemanager.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            texture.SetData<Color>(new Color[] { Color.White });
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, new Rectangle(screen_coord.first, screen_coord.second, 20, 20), Color.White);
            spriteBatch.End();
        }
    }
}
