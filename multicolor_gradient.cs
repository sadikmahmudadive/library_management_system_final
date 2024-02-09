using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class ThreeColorGradientPanel : Panel
{
    private Color color1;
    private Color color2;
    private Color color3;

    public Color Color1
    {
        get { return color1; }
        set
        {
            color1 = value;
            Invalidate();
        }
    }

    public Color Color2
    {
        get { return color2; }
        set
        {
            color2 = value;
            Invalidate();
        }
    }

    public Color Color3
    {
        get { return color3; }
        set
        {
            color3 = value;
            Invalidate();
        }
    }

    public ThreeColorGradientPanel()
    {
        color1 = Color.Red; // Default colors
        color2 = Color.Yellow;
        color3 = Color.Green;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        using (LinearGradientBrush brush = new LinearGradientBrush(
            ClientRectangle, color1, color3, LinearGradientMode.Horizontal))
        {
            ColorBlend colorBlend = new ColorBlend();
            colorBlend.Positions = new[] { 0, 0.5f, 1 };
            colorBlend.Colors = new[] { color1, color2, color3 };
            brush.InterpolationColors = colorBlend;

            e.Graphics.FillRectangle(brush, ClientRectangle);
        }
    }
}
