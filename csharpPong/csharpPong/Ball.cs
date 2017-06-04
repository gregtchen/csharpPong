using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace csharpPong
{
    class Ball
    {
        int x;
        public int X
        {
            get
            {
                return x;
            }
        }
        int y;
        public int Y
        {
            get
            {
                return y;
            }
        }
        int size;
        public int Size
        {
            get
            {
                return size;
            }
        }
        public int xspeed;
        int yspeed;
        Color color;
        public Rectangle hitbox;

        public Ball(int x, int y, int size, int xspeed, int yspeed, Color color)
        {
            this.x = x;
            this.y = y;
            this.size = size;
            this.xspeed = xspeed;
            this.yspeed = yspeed;
            this.color = color;
            hitbox = new Rectangle(x, y, size, size);
        }

        public void draw(Graphics gfx)
        {
            gfx.FillEllipse(new SolidBrush(color), x, y, size, size);
        }

        public void erase(Graphics gfx, Color backcolor)
        {
            gfx.FillEllipse(new SolidBrush(backcolor), x, y, size, size);
        }

        public void move(int width, int height)
        {
            if(y < 0)
            {
                yspeed = -yspeed;
            }
            if(y + size > height)
            {
                yspeed = -yspeed;
            }
            x += xspeed;
            y += yspeed;

            hitbox = new Rectangle(x, y, size, size);
        }

        public void reverseX()
        {
            xspeed = -xspeed;

        }
    }
}
