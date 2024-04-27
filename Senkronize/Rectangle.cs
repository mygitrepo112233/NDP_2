using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Senkronize {
    internal class Rectangle {
        public PointF RectanglePosition;//koordinat ve hız bilgisi
        public PointF rectangleVelocity;

        public void MoveRectangle(int FormWidth, int FormHeight) {//dikdortgeni hareket ettiren fonksiyon
            RectanglePosition.X += rectangleVelocity.X;
            RectanglePosition.Y += rectangleVelocity.Y;

            if (RectanglePosition.X < 0 || RectanglePosition.X > FormWidth - RectangleHeight) {
                rectangleVelocity.X *= -1;
                RectanglePosition.X = Math.Max(0, Math.Min(FormWidth - RectangleHeight, RectanglePosition.X));
            }
            if (RectanglePosition.Y < 0 || RectanglePosition.Y > FormHeight - RectangleSize) {
                rectangleVelocity.Y *= -1;
                RectanglePosition.Y = Math.Max(0, Math.Min(FormHeight - RectangleSize, RectanglePosition.Y));
            }
        }

        public void DrawRectangle(Graphics g) {//dikdortgeni cizen fonksiyon
            g.FillRectangle(Brushes.Blue, new RectangleF(RectanglePosition, new SizeF(RectangleSize, RectangleHeight)));

        }
        public int RectangleSize;
        public int RectangleHeight;

        public Rectangle() {
            this.RectangleSize = 120;
            this.RectangleHeight = 60;
        }
    }
}