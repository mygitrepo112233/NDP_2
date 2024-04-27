using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Senkronize {
    internal class Point {
        public PointF pointPosition;//koordinat ve hız bilgisi
        public PointF pointVelocity;

        public void DrawPoint(Graphics g) {//noktayı cizen fonksiyon
            g.FillRectangle(Brushes.Red, new RectangleF(pointPosition, new SizeF(3, 3)));
        }
        public void MovePoint(int FormWidth, int FormHeight) {//noktayı hareket ettiren fonksiyon
            pointPosition.X += pointVelocity.X;
            pointPosition.Y += pointVelocity.Y;

            if (pointPosition.X < 0 || pointPosition.X > FormWidth) {
                pointVelocity.X *= -1;
            }
            if (pointPosition.Y < 0 || pointPosition.Y > FormHeight) {
                pointVelocity.Y *= -1;
            }
        }
    }
}