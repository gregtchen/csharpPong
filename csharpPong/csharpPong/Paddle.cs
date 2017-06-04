using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace csharpPong
{
    class Paddle
    {
        public int x;
        public int y;
        int height;
        public  int Height
        {
            get
            {
                return height;
            }
        }
        int width;
        public int Width
        {
            get
            {
                return width;
            }
        }
        int yspeed;
        public int Yspeed
        {
            get
            {
                return yspeed;
            }
        }
        Color color;
        public Rectangle hitbox;

        public Paddle(int x, int y, int height, int width, int yspeed, Color color)
        {
            this.x = x;
            this.y = y;
            this.height = height;
            this.width = width;
            this.yspeed = yspeed;
            this.color = color;
            hitbox = new Rectangle(x, y, width, height);
        }

        public void draw(Graphics gfx)
        {
            gfx.FillRectangle(new SolidBrush(color), x, y, width, height);
        }

        public void erase(Graphics gfx, Color backcolor)
        {
            gfx.FillRectangle(new SolidBrush(backcolor), x, y, width, height);

        }
        
    }
}
