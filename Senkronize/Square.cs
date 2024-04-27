using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Senkronize {
    internal class Square {
        public PointF squarePosition;//koordinat ve hiz bilgisi
        public PointF squareVelocity;

        public void DrawSquare(Graphics g) {//cizici fonksiyon
            g.FillRectangle(Brushes.Blue, new RectangleF(squarePosition, new SizeF(squareSize, squareSize)));
        }
        public void MoveSquare(int FormWidth, int FormHeight) {//hareket ettirici fonksiyon
            squarePosition.X += squareVelocity.X;
            squarePosition.Y += squareVelocity.Y;

            if (squarePosition.X < 0 || squarePosition.X > FormWidth - squareSize) {
                squareVelocity.X *= -1;
                squarePosition.X = Math.Max(0, Math.Min(FormWidth - squareSize, squarePosition.X));
            }
            if (squarePosition.Y < 0 || squarePosition.Y > FormHeight - squareSize) {
                squareVelocity.Y *= -1;
                squarePosition.Y = Math.Max(0, Math.Min(FormHeight - squareSize, squarePosition.Y));
            }
        }
        public int squareSize { get; set; }

        public Square() {
            this.squareSize = 85;
        }
    }
}