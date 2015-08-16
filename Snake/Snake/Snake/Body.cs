using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Snake
{
    static class Body
    {
        //static Queue<Body_Segment> body_queue = new Queue<Body_Segment>();
        public static int Max_Segments {get; set;}
        static Body()
        {
            Max_Segments = 3;
            addSegment(new Vector2(1,1));
        }
        public static void move(byte direction)
        {
            //direction
            // 3 = up
            // 4 = down
            // 1 = left
            // 2 = right

            //Vector2 head_pos = body_queue.Last<Body_Segment>().GridPosition;
            Vector2 head_pos = LinkedQueue<Body_Segment>.last().GridPosition;
            Vector2 newpos;
            switch(direction)
            {
                case 1:
                    newpos = new Vector2(head_pos.X - 1, head_pos.Y);
                    break;
                case 2:
                    newpos = new Vector2(head_pos.X + 1, head_pos.Y);
                    break;
                case 3:
                    newpos = new Vector2(head_pos.X, head_pos.Y - 1);
                    break;
                case 4:
                    newpos = new Vector2(head_pos.X, head_pos.Y+1);
                    break;
                default:
                    throw new Exception("invalid direction: " + direction);
            }
            LinearDoubleNode<Body_Segment> temp = LinkedQueue<Body_Segment>.tail;
            temp = temp.getPrev();
            Body_Segment temp_body = temp.getElement();
            if(temp_body.Equals(null))
            {
                if (temp_body.GridPosition.Equals(newpos))
                {
                    addSegment(newpos);
                    newpos = default(Vector2);
                }
        }
            drop_last_Segment();
        }
        public static void draw(SpriteBatch spriteBatch)
        {
            /*foreach (Body_Segment element in body_queue)
            {
                element.Draw(spriteBatch);
            }
            */
            LinearDoubleNode<Body_Segment> temp = LinkedQueue<Body_Segment>.head;
            temp = LinkedQueue<Body_Segment>.head;
            for (int i = 0; i < LinkedQueue<Body_Segment>.NodeCount; i++)
            {
                temp.getElement().Draw(spriteBatch);
                temp = temp.getNext();
            }
        }

        public static void addSegment(Vector2 gridpos)
        {
            //body_queue.Enqueue(new Body_Segment(Game1.graphics.GraphicsDevice, gridpos));
            LinkedQueue<Body_Segment>.enqueue(new Body_Segment(Game1.graphics.GraphicsDevice, gridpos));
        }
        public static void drop_last_Segment()
        {
            //if (Max_Segments >= body_queue.Count) return;
            if (Max_Segments >= LinkedQueue<Body_Segment>.NodeCount) return;
            //body_queue.Dequeue();
            LinkedQueue<Body_Segment>.dequeue();
        }
        public static int ConvertCoord(int num)
        {
            return (num * 25) + 5;
        }
    }
}
