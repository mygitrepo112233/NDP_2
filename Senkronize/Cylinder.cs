using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Senkronize {
    internal class Cylinder {
        public PointF cylinderVelocity;//konum ve hız bilgileri
        public PointF cylinderPosition;

        public float cylinderWidth;//silidnidirn uzunluk bilgileri
        public float cylinderHeight;
        public float ellipseWidth;
        public float ellipseHeight;
        public float sideLineLength;

        public void MoveCylinder(int FormWidth, int FormHeight) {//silindirin hareket etmesini saglayan fonksiyon
            cylinderPosition.X += cylinderVelocity.X;
            cylinderPosition.Y += cylinderVelocity.Y;

            if (cylinderPosition.X - ellipseWidth / 2 <= 0 || cylinderPosition.X + ellipseWidth / 2 >= FormWidth) {
                cylinderVelocity.X *= -1;
            }
            if (cylinderPosition.Y / 2 <= 0 || cylinderPosition.Y + cylinderHeight / 2 >= FormHeight) {
                cylinderVelocity.Y *= -1;
            }
        }

        public void DrawCylinder(Graphics g, Pen pen,Pen pen1, Brush brush) {//silindiri cizen fonksiyon
            g.DrawEllipse(pen, cylinderPosition.X - ellipseWidth / 2, cylinderPosition.Y - cylinderHeight / 2, ellipseWidth, ellipseHeight);
            g.DrawEllipse(pen, cylinderPosition.X - ellipseWidth / 2, cylinderPosition.Y + cylinderHeight / 2 - ellipseHeight, ellipseWidth, ellipseHeight);
            g.DrawLine(pen, cylinderPosition.X - ellipseWidth / 2, cylinderPosition.Y - sideLineLength, cylinderPosition.X - ellipseWidth / 2, cylinderPosition.Y + sideLineLength);
            g.DrawLine(pen, cylinderPosition.X + ellipseWidth / 2, cylinderPosition.Y - sideLineLength, cylinderPosition.X + ellipseWidth / 2, cylinderPosition.Y + sideLineLength);
            g.DrawRectangle(pen1, cylinderPosition.X - ellipseWidth / 2, cylinderPosition.Y - sideLineLength, ellipseWidth, sideLineLength * 2);

            g.FillEllipse(brush, cylinderPosition.X - ellipseWidth / 2, cylinderPosition.Y - cylinderHeight / 2, ellipseWidth, ellipseHeight);
            g.FillEllipse(brush, cylinderPosition.X - ellipseWidth / 2, cylinderPosition.Y + cylinderHeight / 2 - ellipseHeight, ellipseWidth, ellipseHeight);
            g.FillRectangle(brush, cylinderPosition.X - ellipseWidth / 2, cylinderPosition.Y - sideLineLength, ellipseWidth, sideLineLength * 2);
        }

        public Cylinder() {//constructer
            cylinderWidth = 100;
            cylinderHeight = 200;
            ellipseWidth = cylinderWidth;
            ellipseHeight = (cylinderWidth / 2);
            sideLineLength = (cylinderHeight / 3) *1.16F;
        }
    }
}