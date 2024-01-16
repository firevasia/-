//Класс за допомогою якого відворюється малювання ліній та їх фіксування в певних зонах
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MyForm;

namespace WindowsFormsApp2
{
    public class Sticks
    {
        public int x1;
        public int y1;
        public int x2;
        public int y2;
        public Sticks(int x1, int y1, int x2, int y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }

        public bool Intersects(Rectangle zoneRect)
        {
            Rectangle stickRect = new Rectangle(x1, y1, Math.Abs(x2 - x1), Math.Abs(y2 - y1));
            Rectangle zoneRectangle = new Rectangle(zoneRect.Left, zoneRect.Top, Math.Abs(zoneRect.Width), Math.Abs(zoneRect.Height));

            return stickRect.IntersectsWith(zoneRectangle);
        }



        public void SnapToZone(StickDropZone zone)
        {
            x1 = zone.x1;
            y1 = zone.y1;
            x2 = zone.x2;
            y2 = zone.y2;

        }

        public void Paint(object sender, PaintEventArgs e)
        {
            Pen myPen = new Pen(Color.Black, 5);

            e.Graphics.DrawLine(myPen, x1, y1, x2, y2);
        }

        public bool IsHit(Point location)
        {
            Rectangle rect;
            if (x1 == x2)
            {
                rect = new Rectangle(x1, y1, 5, y2 - y1);
            }
            else
            {
                rect = new Rectangle(x1, y1, x2 - x1, 5);
            }

            return rect.Contains(location);
        }

        public void Move(int dx, int dy)
        {
            x1 += dx;
            y1 += dy;
            x2 += dx;
            y2 += dy;
        }
    }
}
