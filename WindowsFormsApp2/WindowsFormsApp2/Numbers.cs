//Класс який містить кординати для створення рисунків по кординатам
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class Numbers
    {
        public List<Sticks> firstFigure = new List<Sticks>
        {
            new Sticks (150, 55, 150, 155),
            new Sticks(255, 55, 255, 155),
            new Sticks(50, 155, 150, 155),
            new Sticks(155, 155, 255, 155),
            new Sticks(260, 155, 360, 155),
            new Sticks(150, 160, 150, 260),
            new Sticks(255, 160, 255, 260),
            new Sticks (50, 260, 150, 260),
            new Sticks(155, 260, 255, 260),
            new Sticks(260, 260, 360, 260),
            new Sticks(150, 265, 150, 365),
            new Sticks(255, 265, 255, 365),
        };

        public List<StickDropZone> firstFigureCounter = new List<StickDropZone>
        {
            new StickDropZone(50, 50, 150, 50),
            new StickDropZone(155, 50, 255, 50),
            new StickDropZone(260, 50, 360, 50),

            new StickDropZone(45, 55, 45, 155),
            new StickDropZone(150, 55, 150, 155),
            new StickDropZone(255, 55, 255, 155),
            new StickDropZone(360, 55, 360, 155),

            new StickDropZone(50, 155, 150, 155),
            new StickDropZone(155, 155, 255, 155),
            new StickDropZone(260, 155, 360, 155),

            new StickDropZone(45, 160, 45, 260),
            new StickDropZone(150, 160, 150, 260),
            new StickDropZone(255, 160, 255, 260),
            new StickDropZone(360, 160, 360, 260),

            new StickDropZone (50, 260, 150, 260),
            new StickDropZone(155, 260, 255, 260),
            new StickDropZone(260, 260, 360, 260),

            new StickDropZone(45, 265, 45, 365),
            new StickDropZone(150, 265, 150, 365),
            new StickDropZone(255, 265, 255, 365),
            new StickDropZone(360, 265, 360, 365),

            new StickDropZone(50, 365, 150, 365),
            new StickDropZone(155, 365, 255, 365),
            new StickDropZone(260, 365, 360, 365),


        };

        public List<Sticks> secondFigure = new List<Sticks>
        {
            new Sticks(50, 50, 150, 50),

            new Sticks(45, 55, 45, 155),
            new Sticks(150, 55, 150, 155),

            new Sticks(50, 155, 150, 155),
            new Sticks(155, 155, 255, 155),

            new Sticks(45, 160, 45, 260),
            new Sticks(150, 160, 150, 260),
            new Sticks(255, 160, 255, 260),

            new Sticks (50, 260, 150, 260),
            new Sticks(155, 260, 255, 260),
            new Sticks(260, 260, 360, 260),

            new Sticks(45, 265, 45, 365),
            new Sticks(150, 265, 150, 365),
            new Sticks(255, 265, 255, 365),
            new Sticks(360, 265, 360, 365),

            new Sticks(50, 365, 150, 365),
            new Sticks(155, 365, 255, 365),
            new Sticks(260, 365, 360, 365),

        };

    }
}
