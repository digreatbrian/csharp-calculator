using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class RoundedButton : Button
{
    protected override void OnPaint(PaintEventArgs pevent)
    {
        base.OnPaint(pevent);
        Graphics g = pevent.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;
        
        Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
        GraphicsPath path = new GraphicsPath();
        int radius = 20; // Adjust radius as needed
        
        path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
        path.AddArc(rect.X + rect.Width - radius, rect.Y, radius, radius, 270, 90);
        path.AddArc(rect.X + rect.Width - radius, rect.Y + rect.Height - radius, radius, radius, 0, 90);
        path.AddArc(rect.X, rect.Y + rect.Height - radius, radius, radius, 90, 90);
        path.CloseAllFigures();
        
        this.Region = new Region(path);
        using (Pen pen = new Pen(Color.Black, 1))
        {
            g.DrawPath(pen, path);
        }
    }
}