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
            Max_Segments = 100;
            addSegment(new Vector2(1,1));
        }
        private static int old_direction = 0;
        private static Vector2 newpos = new Vector2(0,0);

        public static void move(Vector2 pos)
        {
            addSegment(pos);
            drop_last_Segment();
        }
        public static Vector2 getNextPos()
        {
            //direction
            // 1 = left
            // 2 = up
            // 3 = right
            // 4 = down

            Vector2 head_pos = body_queue.Last<Body_Segment>().GridPosition;
            
            Keys[] keys = Keyboard.GetState().GetPressedKeys();
            bool moved = false;
            if (keys.GetLength(0) > 0) //if key pressed
            {
                foreach (Keys key in keys) //iterate through all pressed keys
                {
                    switch (key) // change direction based on keypress or if not moving initially
                    {
                        case Keys.Left:
                            if (old_direction != 3 || old_direction == 0)
                            {
                                newpos = new Vector2(head_pos.X - 1, head_pos.Y);
                                moved = true;
                                old_direction = 1;
                            }
                            break;
                        case Keys.Up:
                            if (old_direction != 4 || old_direction == 0)
                            {
                                newpos = new Vector2(head_pos.X, head_pos.Y - 1);
                                moved = true;
                                old_direction = 2;
                            }
                            break;
                        case Keys.Right:
                            if (old_direction != 1 || old_direction == 0)
                            {
                                newpos = new Vector2(head_pos.X + 1, head_pos.Y);
                                moved = true;
                                old_direction = 3;
                            }
                            break;
                        case Keys.Down:
                            if (old_direction != 2 || old_direction == 0)
                            {
                                newpos = new Vector2(head_pos.X, head_pos.Y + 1);
                                moved = true;
                                old_direction = 4;
                            }
                            break;
                        default:
                            break;
                    }
                    switch (old_direction) // move forward if key already pressed
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
            }
            else
            {
                switch (old_direction) // move forward anyways if key not already pressed
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
            return newpos; //add new head segments
        }
        public static void draw(SpriteBatch spriteBatch)
        {
            foreach (Body_Segment element in body_queue) //iterate through all body sements...
            {
                element.Draw(spriteBatch); //...and draw them
            }
        }

        public static void addSegment(Vector2 gridpos) //shorter version
        {
            body_queue.Enqueue(new Body_Segment(Game1.graphics.GraphicsDevice, gridpos));
        }
        public static void drop_last_Segment()
        {
            if (Max_Segments >= body_queue.Count) return;
            body_queue.Dequeue();
        }
        public static int ConvertCoord(int num) //from grid to window coord
        {

            return (num * 25) + 5; 
        }
    }
}
