using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Snake
{
    static class Body
    {
        static Queue<Body_Segment> body_queue = new Queue<Body_Segment>();
        public static int Max_Segments {get; set;}
        static Body()
        {
            Max_Segments = 5;
            addSegment(new Vector2(1,1));
        }
        private static int old_direction = 0;
        private static Vector2 newpos = default(Vector2);
        public static void move()
        {
            //direction
            // 1 = left
            // 2 = up
            // 3 = right
            // 4 = down

            Vector2 head_pos = body_queue.Last<Body_Segment>().GridPosition;
            
            Keys[] keys = Keyboard.GetState().GetPressedKeys();
            bool moved = false;
            if (keys.GetLength(0) > 0)
            {
                foreach (Keys key in keys)
                {
                    switch (key)
                    {
                        case Keys.Left:
                                newpos = new Vector2(head_pos.X - 1, head_pos.Y);
                            moved = true;
                            old_direction = 1;
                            break;
                        case Keys.Up:
                                newpos = new Vector2(head_pos.X, head_pos.Y - 1);
                            moved = true;
                            old_direction = 2;
                            break;
                        case Keys.Right:
                                newpos = new Vector2(head_pos.X + 1, head_pos.Y);
                            moved = true;
                            old_direction = 3;
                            break;
                        case Keys.Down:
                                newpos = new Vector2(head_pos.X, head_pos.Y + 1);
                            moved = true;
                            old_direction = 4;
                            break;
                        default:
                            break;
                    }
                    if (moved)
                        break;
                }
            }
            else
            {
                switch (old_direction)
                {
                    case 1:
                            newpos = new Vector2(head_pos.X - 1, head_pos.Y);
                        break;
                    case 2:
                            newpos = new Vector2(head_pos.X, head_pos.Y - 1);
                        break;
                    case 3:
                            newpos = new Vector2(head_pos.X + 1, head_pos.Y);
                        break;
                    case 4:
                            newpos = new Vector2(head_pos.X, head_pos.Y + 1);
                        break;
                    default:
                        break;
                }
            }
                addSegment(newpos);
                drop_last_Segment();
        }
        public static void draw(SpriteBatch spriteBatch)
        {
            foreach (Body_Segment element in body_queue)
            {
                element.Draw(spriteBatch);
            }
        }

        public static void addSegment(Vector2 gridpos)
        {
            body_queue.Enqueue(new Body_Segment(Game1.graphics.GraphicsDevice, gridpos));
        }
        public static void drop_last_Segment()
        {
            if (Max_Segments >= body_queue.Count) return;
            body_queue.Dequeue();
        }
        public static int ConvertCoord(int num)
        {
            return (num * 25) + 5;
        }
    }
}
