using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FiyiStackApp.Library.UI
{
    public static class UI
    {
        public static void SetBorderRadiusToControl(ref object ControlObject, int LeftRadiusBorder, int RightRadiusBorder)
        {
            GraphicsPath p = new GraphicsPath();
            p.StartFigure();
            //Top left corner
            p.AddArc(new Rectangle(0, 0, LeftRadiusBorder, LeftRadiusBorder), 180, 90);
            p.AddLine(40, 0, ((Control)ControlObject).Width - LeftRadiusBorder, 0);
            //Top right control
            p.AddArc(new Rectangle(((Control)ControlObject).Width - RightRadiusBorder, 0, RightRadiusBorder, RightRadiusBorder), -90, 90);
            p.AddLine(((Control)ControlObject).Width, 40, ((Control)ControlObject).Width, ((Control)ControlObject).Height - RightRadiusBorder);
            //Bottom right corner
            p.AddArc(new Rectangle(((Control)ControlObject).Width - RightRadiusBorder, ((Control)ControlObject).Height - RightRadiusBorder, RightRadiusBorder, RightRadiusBorder), 0, 90);
            p.AddLine(((Control)ControlObject).Width - RightRadiusBorder, ((Control)ControlObject).Height, RightRadiusBorder, ((Control)ControlObject).Height);
            //Bottom left corner
            p.AddArc(new Rectangle(0, ((Control)ControlObject).Height - LeftRadiusBorder, LeftRadiusBorder, LeftRadiusBorder), 90, 90);
            p.CloseFigure();
            ((Control)ControlObject).Region = new Region(p);
        }
    }
}
