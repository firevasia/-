// Нащадок класу стік який потрібен для створення контурів ліній
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public class StickDropZone : Sticks
    {
        public StickDropZone(int x1, int y1, int x2, int y2) : base(x1, y1, x2, y2) { }

        public Rectangle GetRectangle()
        {
            if (x1 == x2)
            {
                return new Rectangle(x1, y1, 5, y2 - y1);
            }
            else
            {
                return new Rectangle(x1, y1, x2 - x1, 5);
            }
        }

        public void Paint(object sender, PaintEventArgs e)
        {
            Pen zonePen = new Pen(Color.Gray, 1);
            e.Graphics.DrawRectangle(zonePen, this.GetRectangle());
        }
    }
}
