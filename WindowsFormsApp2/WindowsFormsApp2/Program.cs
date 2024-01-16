using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp2;
public class MyForm : Form
{
    private Sticks selectedStick = null;
    private Point lastMouseLocation;

    private List<Sticks> allSticks = new List<Sticks>();


    Numbers figure = new Numbers();
    private Label infoLabel;
    private int n;

    public MyForm FirstLevel()
    {
        infoLabel = new Label();
        infoLabel.Text = "Потрібно перемістити 3 спічки так щоб утворилось 3 рівних квадрати коли будете готові натисніть SPACE";
        infoLabel.Location = new Point(10, 10);
        infoLabel.Font = new Font(infoLabel.Font.FontFamily, 16, FontStyle.Regular);
        infoLabel.AutoSize = true;

        this.Controls.Add(infoLabel);

        allSticks.AddRange(figure.firstFigure);

        StickDrawingZone(figure.firstFigureCounter);
        StickDrawing(allSticks);

        return this;
    }


    public MyForm SecondLevel()
    {
        infoLabel = new Label();
        infoLabel.Text = "Потрібно прибрати 2 спічки щоб отримати 4 рівних квадрати коли будете готові натисніть SPACE";
        infoLabel.Location = new Point(10, 10);
        infoLabel.Font = new Font(infoLabel.Font.FontFamily, 16, FontStyle.Regular);
        infoLabel.AutoSize = true;

        this.Controls.Add(infoLabel);

        allSticks.AddRange(figure.secondFigure);

        StickDrawingZone(figure.firstFigureCounter);
        StickDrawing(allSticks);


        return this;
    }

    private void StickDrawing(List<Sticks> DrawStick)
    {
        foreach (var stick in DrawStick)
        {
            this.Paint += new PaintEventHandler(stick.Paint);
        }
    }

    private void StickDrawingZone(List<StickDropZone> DrawStick)
    {
        foreach (var stick in DrawStick)
        {
            this.Paint += new PaintEventHandler(stick.Paint);
        }
    }

    public MyForm(int n)
    {
        this.KeyPreview = true;
        this.MouseDown += new MouseEventHandler(Form_MouseDown);
        this.MouseMove += new MouseEventHandler(Form_MouseMove);
        this.MouseUp += new MouseEventHandler(Form_MouseUp);
        this.KeyDown += new KeyEventHandler(Form_KeyDown);
        this.n = n;
    }
    private void StickMoving(List<Sticks> listMove, object sender, MouseEventArgs e)
    {
        StickDrawing(listMove);

        foreach (var stick in listMove)
        {
            if (stick.IsHit(e.Location))
            {
                selectedStick = stick;
                lastMouseLocation = e.Location;
                break;
            }
        }
    }
    private void Form_MouseDown(object sender, MouseEventArgs e)
    {
        StickMoving(allSticks, sender, e);
    }
    private void Form_MouseMove(object sender, MouseEventArgs e)
    {
        if (selectedStick != null)
        {
            selectedStick.Move(e.Location.X - lastMouseLocation.X, e.Location.Y - lastMouseLocation.Y);
            lastMouseLocation = e.Location;

            this.Invalidate();
        }
    }
    private void Form_MouseUp(object sender, MouseEventArgs e)
    {
        selectedStick = null;

        foreach (var stick in allSticks)
        {
            foreach (var zone in figure.firstFigureCounter)
            {
                if (stick.Intersects(zone.GetRectangle()))
                {
                    stick.SnapToZone(zone);
                }
            }
        }

        this.Invalidate();
    }
    private bool CheckAllSticksInTargetZones1()
    {
        List<Rectangle> targetZones1 = new List<Rectangle>
        {
            new Rectangle(155, 50, 100, 0),
            new Rectangle(150, 55, 0, 100),
            new Rectangle(255, 55, 0, 100),
            new Rectangle(50, 155, 100, 0),
            new Rectangle(155, 155, 100, 0),
            new Rectangle(260, 155, 100, 0),
            new Rectangle(45, 160, 0, 100),
            new Rectangle(150, 160, 0, 100),
            new Rectangle(255, 160, 0, 100),
            new Rectangle(360, 160, 0, 100),
            new Rectangle(50, 260, 100, 0),
            new Rectangle(260, 260, 100, 0),
        };

        List<Rectangle> targetZones2 = new List<Rectangle>
        {
            new Rectangle(50, 155, 100, 0),
            new Rectangle(260, 155, 100, 0),
            new Rectangle(45, 160, 0, 100),
            new Rectangle(150, 160, 0, 100),
            new Rectangle(255, 160, 0, 100),
            new Rectangle(360, 160, 0, 100),
            new Rectangle(50, 260, 100, 0),
            new Rectangle(155, 260, 100, 0),
            new Rectangle(260, 260, 100, 0),
            new Rectangle(150, 265, 0, 100),
            new Rectangle(255, 265, 0, 100),
            new Rectangle(155, 365, 100, 0),

        };

        if (CheckConditionInZone(targetZones2) || CheckConditionInZone(targetZones1))
        {
            return true;
        }
        return false;
    }
    private bool CheckConditionInZone(List<Rectangle> targetZones)
    {
        foreach (var stick in allSticks)
        {
            bool stickInAnyZone = false;

            foreach (var zone in targetZones)
            {
                if (IsPointInRectangle(stick.x1, stick.y1, zone) && IsPointInRectangle(stick.x2, stick.y2, zone))
                {
                    stickInAnyZone = true;
                    break;
                }
            }

            if (!stickInAnyZone)
            {
                return false;
            }
        }

        return true;
    }
    private bool CheckAllSticksInTargetZones()
    {
        List<Rectangle> targetZones3 = new List<Rectangle>
         {

             new Rectangle(50, 50, 100, 0),
             new Rectangle(45, 55, 0, 100),
             new Rectangle(150, 55, 0, 100),
             new Rectangle(50, 155, 100, 0),
             new Rectangle(155, 155, 100, 0),
             new Rectangle(150, 160, 0, 100),
             new Rectangle(255, 160, 0, 100),
             new Rectangle (50, 260, 100, 0),
             new Rectangle(155, 260, 100, 0),
             new Rectangle(260, 260, 100, 0),
             new Rectangle(45, 265, 0, 100),
             new Rectangle(150, 265, 0, 100),
             new Rectangle(255, 265, 0, 100),
             new Rectangle(360, 265, 0, 100),
             new Rectangle(50, 365, 100, 0),
             new Rectangle(260, 365, 100, 0),

         };

        List<Rectangle> emptyZones3 = new List<Rectangle>
         {
             new Rectangle(155, 50, 100, 0),
             new Rectangle(260, 50, 100, 0),

             new Rectangle(255, 55, 0, 100),
             new Rectangle(360, 55, 0, 100),

             new Rectangle(260, 155, 100, 0),

             new Rectangle(45, 160, 0, 100),
             new Rectangle(360, 160, 0, 100),

             new Rectangle(155, 365, 100, 0),

         };

        if (CheckAllSticksAbsentFromZones(emptyZones3) && CheckConditionInzone2(targetZones3))
        {
            return true;
        }
        return false;
    }

    private bool CheckAllSticksAbsentFromZones(List<Rectangle> emptyZones)
    {

        foreach (var zone in emptyZones)
        {
            bool stickInAnyZone = true;

            foreach (var stick in allSticks)
            {
                if (IsPointInRectangle(stick.x1, stick.y1, zone) && IsPointInRectangle(stick.x2, stick.y2, zone))
                {
                    stickInAnyZone = false;
                    break;
                }
            }
            if (!stickInAnyZone)
            {
                return false;
            }
        }

        return true;
    }
    private bool CheckConditionInzone2(List<Rectangle> targetZones)
    {
        foreach (var stick in allSticks)
        {
            bool stickInAnyZone = false;

            foreach (var zone in targetZones)
            {
                if (IsPointInRectangle(stick.x1, stick.y1, zone) && IsPointInRectangle(stick.x2, stick.y2, zone))
                {
                    stickInAnyZone = true;
                    break;
                }
            }
        }

        return true;
    }
    private bool IsPointInRectangle(int x, int y, Rectangle rect)
    {
        return x >= rect.Left && x <= rect.Right && y >= rect.Top && y <= rect.Bottom;
    }

    private void Form_KeyDown(object sender, KeyEventArgs e)
    {
        bool allSticksInTargetZones;
        if (e.KeyCode == Keys.Space)
        {
            if (n == 1)
            {
                allSticksInTargetZones = CheckAllSticksInTargetZones1();
            }
            else
            {
                allSticksInTargetZones = CheckAllSticksInTargetZones();

            }

            if (allSticksInTargetZones)
            {
                MessageBox.Show("Ви пройшли рівень! Успішно!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Невірне рішення продовжуйте рішення!");
            }
        }
    }

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        int n = 1;
        MyForm firstLevel = new MyForm(n);
        Application.Run(firstLevel.FirstLevel());
        n++;
        MyForm secondLevel = new MyForm(n);
        Application.Run(secondLevel.SecondLevel());
    }
}