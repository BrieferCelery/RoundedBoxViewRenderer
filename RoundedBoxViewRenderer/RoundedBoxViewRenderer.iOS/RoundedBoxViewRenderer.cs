using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreGraphics;
using Foundation;
using RoundedBoxViewRenderer;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly:ExportRendererAttribute(typeof(RoundedBoxView), typeof(RoundedBoxViewRenderer.iOS.RoundedBoxViewRenderer)) ]

namespace RoundedBoxViewRenderer.iOS
{
   public class RoundedBoxViewRenderer : BoxRenderer
    {
        public void Draw(System.Drawing.RectangleF rect)
        {
            RoundedBoxView rbv = (RoundedBoxView) this.Element;

            using (var context = UIGraphics.GetCurrentContext())
            {
                context.SetFillColor(rbv.Color.ToCGColor());
                context.SetStrokeColor(rbv.Stroke.ToCGColor());
                context.SetLineWidth((float)rbv.StrokeThickness);

                var rc = this.Bounds.Inset((int)rbv.StrokeThickness, (int)rbv.StrokeThickness);

                float radius = (float) rbv.CornerRadius;
                radius = (float) Math.Max(0, Math.Min(radius, Math.Max(rc.Height / 2, rc.Width / 2)));

                var path = CGPath.FromRoundedRect(rc, radius, radius);
                context.AddPath(path);
                context.DrawPath(CGPathDrawingMode.FillStroke);


            }
        }
    }
}