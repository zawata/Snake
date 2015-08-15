using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake
{
    static class Body
    {
        public static void move(byte direction)
        {
            //direction
            // 1 = up
            // 2 = down
            // 3 = left
            // 4 = right
            COORD head_pos = LinkedQueue<Body_Segment>.first().GridPosition;
            switch(direction)
            {
                case 1:
                    addSegment(new COORD { head_pos.First-1, head_pos.Second });
                    break;
                case 2:
                    addSegment(new COORD { head_pos.First+1, head_pos.Second });
                    break;
                case 3:
                    addSegment(new COORD { head_pos.First, head_pos.Second-1 });
                    break;
                case 4:
                    addSegment(new COORD { head_pos.First, head_pos.Second+1 });
                    break;
                default:
                    throw new Exception("invalid direction: " + direction);
            }
            drop_last_Segment();
        }

        public static void addSegment(COORD gridpos)
        {
            LinkedQueue<Body_Segment>.enqueue(new Body_Segment(Game1.graphics.GraphicsDevice, gridpos));
        }
        public static void drop_last_Segment()
        {
            LinkedQueue<Body_Segment>.dequeue();
        }
        public static int ConvertCoord(int num)
        {
            return (num * 25) + 5;
        }
    }
}
