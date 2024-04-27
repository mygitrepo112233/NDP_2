using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Senkronize {
    internal class Circle {
        public PointF circleVelocity;//cemberlerin koordinatlarını ve hızlarını tutar
        public PointF circlePosition;

        public void DrawEllipse(Graphics g, Pen pen) {//cember cizer
            g.DrawEllipse(pen, new RectangleF(circlePosition.X - CircleRadius, circlePosition.Y - CircleRadius, 2 * CircleRadius, 2 * CircleRadius));
        }
        public void MoveCircle(int FormWidth, int FormHeight) {//cemberi hareket ettirir
            circlePosition.X += circleVelocity.X;
            circlePosition.Y += circleVelocity.Y;


            if (circlePosition.X < 0 || circlePosition.X > FormWidth - 2 * CircleRadius) {
                //cember hareket ederken form'un koselerine ulastiginda sekmesini saglar
                circleVelocity.X *= -1;
                circlePosition.X = Math.Max(0, Math.Min(FormWidth - 2 * CircleRadius, circlePosition.X));
            }
            if (circlePosition.Y < 0 || circlePosition.Y > FormHeight - 2 * CircleRadius) {
                circleVelocity.Y *= -1;
                circlePosition.Y = Math.Max(0, Math.Min(FormHeight - 2 * CircleRadius, circlePosition.Y));
            }
        }
        public int CircleRadius;
        public Circle() {//constructer
            this.CircleRadius = 25;
        }
    }
}