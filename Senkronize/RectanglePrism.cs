using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Senkronize {
    internal class RectanglePrism {
        public PointF prismPosition;//koordinat ve hiz bilgisi
        public PointF prismVelocity;
        public RectangleF frontRect;
        public RectangleF backRect;

        public int width;
        public int height;
        public int depth;

        public void MovePrism(int FormWidth, int FormHeight) {//prizmayi hareket ettiren fonksiyon
            prismPosition.X += prismVelocity.X;
            prismPosition.Y += prismVelocity.Y;

            if (prismPosition.X < 0 || prismPosition.X > FormWidth - height) {
                prismVelocity.X *= -1;
                prismPosition.X = Math.Max(0, Math.Min(FormWidth - height, prismPosition.X));
            }
            if (prismPosition.Y < 0 || prismPosition.Y > FormHeight - width) {
                prismVelocity.Y *= -1;
                prismPosition.Y = Math.Max(0, Math.Min(FormHeight - width, prismPosition.Y));
            }
        }

        public void DrawPrism(Graphics g, Pen pen, Brush brush) {//prizmayi cizen fonksiyon
            g.DrawRectangle(Pens.Black, frontRect.X, frontRect.Y, frontRect.Width, frontRect.Height);
            g.DrawRectangle(Pens.Black, backRect.X, backRect.Y, backRect.Width, backRect.Height);

            g.DrawLine(Pens.Black, prismPosition.X, prismPosition.Y, prismPosition.X + depth / 2, prismPosition.Y + depth);
            g.DrawLine(Pens.Black, prismPosition.X + width, prismPosition.Y, prismPosition.X + width + depth / 2, prismPosition.Y + depth);
            g.DrawLine(Pens.Black, prismPosition.X, prismPosition.Y + height, prismPosition.X + depth / 2, prismPosition.Y + height + depth);
            g.DrawLine(Pens.Black, prismPosition.X + width, prismPosition.Y + height, prismPosition.X + width + depth / 2, prismPosition.Y + height + depth);
        }
        public RectanglePrism() {
            prismPosition = new PointF(150, 200);
            this.width = 100;
            this.height = 150;
            this.depth = 75;
        }
        public RectanglePrism(PointF location) {
            prismPosition = location;
            this.width = 100;
            this.height = 150;
            this.depth = 75;
        }
    }
}