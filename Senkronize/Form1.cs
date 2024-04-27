/****************************************************************************
**					SAKARYA ÜNİVERSİTESİ
**			         BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**				    BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**				          PROGRAMLAMAYA GİRİŞİ DERSİ
**	
**				ÖDEV NUMARASI…...:NDP 2.ODEV
**				ÖĞRENCİ ADI...............:SERHAT HAR
**				ÖĞRENCİ NUMARASI.:G231210040
**				DERS GRUBU…………:2.A
****************************************************************************/

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Senkronize {
    public partial class Form1 : Form {
        private Timer timer;
        private Random random;
        private const int FormWidth = 800;
        private const int FormHeight = 600;

        Rectangle rectangle = new Rectangle();//programda carpisma denetimi yapılacak geometrik cisimlerin nesnesinin olusturulmasi.
        Rectangle rectangle1 = new Rectangle();
        Square square = new Square();
        Square square1 = new Square();
        Circle circle = new Circle();
        Circle circle1 = new Circle();
        Point point = new Point();
        Cylinder cylinder = new Cylinder();
        Cylinder cylinder1 = new Cylinder();
        RectanglePrism prism = new RectanglePrism();
        RectanglePrism prism1 = new RectanglePrism(new PointF(550, 50));
        public Form1() {
            InitializeComponent();
            button2.Enabled = false;//durdur butonu form basladiginda erisilemez olacak
            button2.Visible = false;
        }

        private void Timer_Tick(object sender, EventArgs e) {//timer tick fonksiyonu
            rectangle1.MoveRectangle(FormWidth, FormHeight);//her tick'te geometrik cisimler hareket edicek
            point.MovePoint(FormWidth, FormHeight);
            cylinder.MoveCylinder(FormWidth, FormHeight);
            cylinder1.MoveCylinder(FormWidth, FormHeight);
            square.MoveSquare(FormWidth, FormHeight);
            square1.MoveSquare(FormWidth, FormHeight);
            rectangle.MoveRectangle(FormWidth, FormHeight);
            circle.MoveCircle(FormWidth, FormHeight);
            circle1.MoveCircle(FormWidth, FormHeight);
            prism.MovePrism(FormWidth, FormHeight);
            prism1.MovePrism(FormWidth, FormHeight);
            CheckCollisions();//en son olarak carpisma denetimi gerceklesecek
            this.Invalidate();//eger carpisma varsa ilgili fonksiyon cagrilacak, yoksa burda form tekrar cizilecek
        }

        private void button2_Click(object sender, EventArgs e) {//programi istenilen zamanda durdurur.
            Stop();
        }

        private void Stop() {//program durunca button2yi kapatırken button1 ve combo'yu aktif eder
            timer.Stop();
            button2.Enabled = false;
            button2.Visible = false;
            comboBox1.Visible = true;
            comboBox1.Enabled = true;
            button1.Visible = true;
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e) {//baslat butonunun event fonksiyonu
            this.Size = new Size(FormWidth, FormHeight);
            this.DoubleBuffered = true;//cizimde titresimi yok ederek temiz bir goruntu ortaya cikarir
            random = new Random();

            //combobox'ta yapilan secime gore cisimlerin konumlari ve hizlari ayarlanir.
            if (comboBox1.SelectedIndex == 0) {//dortgen-nokta
                square.squarePosition = new PointF(FormWidth / 2, FormHeight / 2);
                point.pointPosition = new PointF(FormWidth / 8, FormHeight / 12);
                square.squareVelocity = new PointF(random.Next(-10, 11), random.Next(-10, 11));
                point.pointVelocity = new PointF(random.Next(-10, 11), random.Next(-10, 11));
            }
            if (comboBox1.SelectedIndex == 1) {//nokta-cember
                point.pointPosition = new PointF(FormWidth / 4, FormHeight / 2);
                circle.circlePosition = new PointF(FormWidth * 3 / 4, FormHeight / 2);
                point.pointVelocity = new PointF(random.Next(-10, 11), random.Next(-10, 11));
                circle.circleVelocity = new PointF(random.Next(-10, 11), random.Next(-10, 11));
            }
            if (comboBox1.SelectedIndex == 2) {//dikdortgen-dikdortgen
                rectangle.RectanglePosition = new PointF(FormWidth / 4, FormHeight / 2);
                rectangle.rectangleVelocity = new PointF(random.Next(-10, 11), random.Next(-10, 11));
                rectangle1.RectanglePosition = new PointF(FormWidth / 12, FormHeight / 12);
                rectangle1.rectangleVelocity = new PointF(random.Next(-10, 11), random.Next(-10, 11));
            }
            if (comboBox1.SelectedIndex == 3) {//dikdortgen-cember
                rectangle.RectanglePosition = new PointF(FormWidth / 4, FormHeight / 2);
                rectangle.rectangleVelocity = new PointF(random.Next(-10, 11), random.Next(-10, 11));
                circle.circlePosition = new PointF(FormWidth * 3 / 4, FormHeight / 2);
                circle.circleVelocity = new PointF(random.Next(-10, 11), random.Next(-10, 11));
            }
            if (comboBox1.SelectedIndex == 4) {//cember-cember
                circle.circlePosition = new PointF(FormWidth * 1 / 8, FormHeight / 4);
                circle1.circlePosition = new PointF(FormWidth * 3 / 4, FormHeight / 2);
                circle.circleVelocity = new PointF(random.Next(-10, 11) + 5, random.Next(-10, 11) + 5);
                circle1.circleVelocity = new PointF(random.Next(-10, 11) + 5, random.Next(-10, 11) + 5);
            }
            if (comboBox1.SelectedIndex == 5) {//kure-nokta
                circle.circlePosition = new PointF(FormWidth * 1 / 8, FormHeight / 4);
                point.pointPosition = new PointF(FormWidth / 4, FormHeight / 2);
                point.pointVelocity = new PointF(random.Next(-10, 11), random.Next(-10, 11));
                circle.circleVelocity = new PointF(random.Next(-10, 11), random.Next(-10, 11));
            }
            if (comboBox1.SelectedIndex == 6) {//nokta-prizma
                point.pointPosition = new PointF(FormWidth / 2, FormHeight / 2);
                point.pointVelocity = new PointF(random.Next(-10, 11), random.Next(-10, 11));
                prism.prismVelocity = new PointF(random.Next(-10, 11), random.Next(-10, 11));
            }
            if (comboBox1.SelectedIndex == 7) {//nokta-silindir
                point.pointPosition = new PointF(FormWidth / 4, FormHeight / 2);
                point.pointVelocity = new PointF(random.Next(-10, 11), random.Next(-10, 11));
                cylinder.cylinderPosition = new PointF(80, 100);
                cylinder.cylinderVelocity = new PointF(random.Next(-4, 4), random.Next(-4, 4));
            }
            if (comboBox1.SelectedIndex == 8) {//silindir-silindir
                cylinder.cylinderPosition = new PointF(80, 100);
                cylinder.cylinderVelocity = new PointF(random.Next(-4, 4), random.Next(-4, 4));
                cylinder1.cylinderPosition = new PointF(300, 400);
                cylinder1.cylinderVelocity = new PointF(random.Next(-4, 4), random.Next(-4, 4));
            }
            if (comboBox1.SelectedIndex == 9) {//kure-kure
                circle.circlePosition = new PointF(FormWidth * 1 / 8, FormHeight / 4);
                circle1.circlePosition = new PointF(FormWidth * 3 / 4, FormHeight / 2);
                circle.circleVelocity = new PointF(random.Next(-10, 11), random.Next(-10, 11));
                circle1.circleVelocity = new PointF(random.Next(-10, 11), random.Next(-10, 11));
            }
            if (comboBox1.SelectedIndex == 10) {//kure-silindir
                circle.circlePosition = new PointF(FormWidth / 2, FormHeight / 4);
                circle.circleVelocity = new PointF(random.Next(-10, 11), random.Next(-10, 11));
                cylinder.cylinderPosition = new PointF(80, 100);
                cylinder.cylinderVelocity = new PointF(random.Next(-4, 4), random.Next(-4, 4));
            }
            if (comboBox1.SelectedIndex == 11) {//kure-yuzey
                circle.circlePosition = new PointF(FormWidth / 2, FormHeight / 2);
                circle.circleVelocity = new PointF(random.Next(-10, 11), random.Next(-10, 11));
            }
            if (comboBox1.SelectedIndex == 12) {//prizma-yuzey
                prism.prismVelocity = new PointF(random.Next(-10, 11), random.Next(-10, 11));
            }
            if (comboBox1.SelectedIndex == 13) {//silindir-yuzey
                cylinder.cylinderPosition = new PointF(400, 300);
                cylinder.cylinderVelocity = new PointF(random.Next(-4, 4), random.Next(-4, 4));
            }
            if (comboBox1.SelectedIndex == 14) {//silindir-prizma
                circle.circlePosition = new PointF(FormWidth / 2, FormHeight / 4);
                circle.circleVelocity = new PointF(random.Next(-10, 11), random.Next(-10, 11));
                prism.prismVelocity = new PointF(random.Next(-10, 11), random.Next(-10, 11));
            }
            if (comboBox1.SelectedIndex == 15) {//prizma-prizma
                prism.prismVelocity = new PointF(random.Next(-10, 11), random.Next(-10, 11));
                prism1.prismVelocity = new PointF(random.Next(-10, 11), random.Next(-10, 11));
            }
            timer = new Timer();
            timer.Interval = 16; // form 16ms'de bir yeniden cizilir yani saniyede 60 kare
            timer.Tick += Timer_Tick;
            timer.Start();
            comboBox1.Visible = false;
            comboBox1.Enabled = false;
            button1.Visible = false;
            button1.Enabled = false;
            button2.Enabled = true;
            button2.Visible = true;
        }

        private void CheckCollisions() {//cisimlerin hitboxlarini kontrol ederek carpisma olup olmadigini kontrol eder
            RectangleF squareRect = new RectangleF(square.squarePosition, new SizeF(square.squareSize, square.squareSize));
            RectangleF pointRect = new RectangleF(point.pointPosition, new SizeF(3, 3));
            RectangleF rectangleRect = new RectangleF(rectangle.RectanglePosition, new SizeF(rectangle.RectangleSize, rectangle.RectangleHeight));
            RectangleF cylinderRect = new RectangleF(cylinder.cylinderPosition.X - cylinder.ellipseWidth / 2, cylinder.cylinderPosition.Y - cylinder.sideLineLength, cylinder.ellipseWidth, cylinder.sideLineLength * 2);
            RectangleF cylinderRect1 = new RectangleF(cylinder1.cylinderPosition.X - cylinder1.ellipseWidth / 2, cylinder1.cylinderPosition.Y - cylinder1.sideLineLength, cylinder1.ellipseWidth, cylinder1.sideLineLength * 2);
            RectangleF circleRect = new RectangleF(circle.circlePosition.X - circle.CircleRadius, circle.circlePosition.Y - circle.CircleRadius, 2 * circle.CircleRadius, 2 * circle.CircleRadius);
            RectangleF circle1Rect = new RectangleF(circle1.circlePosition.X - circle1.CircleRadius, circle1.circlePosition.Y - circle1.CircleRadius, 2 * circle1.CircleRadius, 2 * circle1.CircleRadius);
            RectangleF wallRect = new RectangleF(rectangle.RectanglePosition, new SizeF(10, 600));
            RectangleF rectangleRect1 = new RectangleF(rectangle1.RectanglePosition, new SizeF(rectangle1.RectangleSize, rectangle1.RectangleHeight));

            RectangleF frontRect = new RectangleF(prism.prismPosition.X, prism.prismPosition.Y, prism.width, prism.height);
            RectangleF backRect = new RectangleF(prism.prismPosition.X + prism.depth / 2, prism.prismPosition.Y + prism.depth, prism.width, prism.height);
            prism.frontRect = frontRect;
            prism.backRect = backRect;
            prism.prismPosition.X = frontRect.X;
            prism.prismPosition.Y = frontRect.Y;

            RectangleF frontRect1 = new RectangleF(prism1.prismPosition.X, prism1.prismPosition.Y, prism1.width, prism1.height);
            RectangleF backRect1 = new RectangleF(prism1.prismPosition.X + prism1.depth / 2, prism1.prismPosition.Y + prism1.depth, prism1.width, prism1.height);
            prism1.frontRect = frontRect1;
            prism1.backRect = backRect1;
            prism1.prismPosition.X = frontRect1.X;
            prism1.prismPosition.Y = frontRect1.Y;

            if (comboBox1.SelectedIndex == 0) {//nokta kare carpisma denetimi
                if (squareRect.IntersectsWith(pointRect)) {
                    HandleCollision();
                    MessageBox.Show("Kare ve Nokta çarpıştı");
                }
            }
            if (comboBox1.SelectedIndex == 1) {//nokta ceber carpisma denetimi
                if (circleRect.IntersectsWith(pointRect)) {
                    HandleCollision();
                    MessageBox.Show("1");
                }
            }
            if (comboBox1.SelectedIndex == 2) {//dikdörtgen dikdörtgen carpisma denetimi
                if (rectangleRect.IntersectsWith(rectangleRect1)) {
                    HandleCollision();
                    MessageBox.Show("2");
                }
            }
            if (comboBox1.SelectedIndex == 3) {//dikdortgen cember carpisma denetimi
                if (rectangleRect.IntersectsWith(circleRect)) {
                    HandleCollision();
                    MessageBox.Show("3");
                }
            }
            if (comboBox1.SelectedIndex == 4) {//cember cember carpisma denetimi
                if (circleRect.IntersectsWith(circle1Rect)) {
                    HandleCollision();
                    MessageBox.Show("4");
                }
            }
            if (comboBox1.SelectedIndex == 5) {//nokta kure carpisma denetimi
                if (circleRect.IntersectsWith(pointRect)) {
                    HandleCollision();
                    MessageBox.Show("5");
                }
            }
            if (comboBox1.SelectedIndex == 6) {//nokta prizma carpisma denetimi
                if (frontRect.IntersectsWith(pointRect) || backRect.IntersectsWith(pointRect)) {
                    HandleCollision();
                    MessageBox.Show("6");
                }
            }
            if (comboBox1.SelectedIndex == 7) {//silindir nokta carpisma denetimi
                if (cylinderRect.IntersectsWith(pointRect)) {
                    HandleCollision();
                    MessageBox.Show("7");
                }
            }
            if (comboBox1.SelectedIndex == 8) {//silindir silindir carpisma denetimi
                if (cylinderRect.IntersectsWith(cylinderRect1)) {
                    HandleCollision();
                    MessageBox.Show("silindir silindir");
                }
            }
            if (comboBox1.SelectedIndex == 9) {//kure kure carpisma denetimi
                if (circleRect.IntersectsWith(circle1Rect)) {
                    HandleCollision();
                    MessageBox.Show("9");
                }
            }
            if (comboBox1.SelectedIndex == 10) {//kure silindir carpisma denetimi
                if (circleRect.IntersectsWith(cylinderRect)) {
                    HandleCollision();
                    MessageBox.Show("10");
                }
            }
            if (comboBox1.SelectedIndex == 11) {//kure yuzey carpisma denetimi
                if (circleRect.IntersectsWith(wallRect)) {
                    HandleCollision();
                    MessageBox.Show("11");
                }
            }
            if (comboBox1.SelectedIndex == 12) {//prizma yuzey carpisma denetimi
                if (frontRect.IntersectsWith(wallRect) || backRect.IntersectsWith(wallRect)) {
                    HandleCollision();
                    MessageBox.Show("12");
                }
            }
            if (comboBox1.SelectedIndex == 13) {//silindir yuzey carpisma denetimi
                if (cylinderRect.IntersectsWith(wallRect)) {
                    HandleCollision();
                    MessageBox.Show("13");
                }
            }
            if (comboBox1.SelectedIndex == 14) {//prizma kure carpisma denetimi
                if (frontRect.IntersectsWith(circleRect) || backRect.IntersectsWith(circleRect)) {
                    HandleCollision();
                    MessageBox.Show("14");
                }
            }
            if (comboBox1.SelectedIndex == 15) {//prizma prizma carpisma denetimi
                if (frontRect.IntersectsWith(frontRect1) || frontRect.IntersectsWith(backRect1) ||
                    backRect.IntersectsWith(frontRect1) || backRect.IntersectsWith(frontRect1)) {
                    HandleCollision();
                    MessageBox.Show("15");
                }
            }
        }

        private void HandleCollision() {//carpisma gerceklestiginde cagrilir.
            timer.Stop();
            MessageBox.Show("Çarpışma gerçekleşti");
            prism.prismPosition = new PointF(150, 200);
            prism.frontRect = new RectangleF(prism.prismPosition.X, prism.prismPosition.Y, prism.width, prism.height);
            prism.backRect = new RectangleF(prism.prismPosition.X + prism.depth / 2, prism.prismPosition.Y + prism.depth, prism.width, prism.height);
            prism1.prismPosition = new PointF(550, 50);
            prism1.frontRect = new RectangleF(prism1.prismPosition.X, prism1.prismPosition.Y, prism1.width, prism1.height);
            prism1.backRect = new RectangleF(prism1.prismPosition.X + prism1.depth / 2, prism1.prismPosition.Y + prism1.depth, prism1.width, prism1.height);
            comboBox1.Visible = true;//erisilemez yapilan butonlar tekrar kullanima acilir
            comboBox1.Enabled = true;
            button1.Visible = true;
            button1.Enabled = true;
        }

        protected override void OnPaint(PaintEventArgs e) {//cisimlerin cizimini gerceklestirir
            base.OnPaint(e);
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;//kaliteli cizim icin bazi ayarlar
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

            /*e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;//anti-AA ile kenar yumusatma yapilir
            e.Graphics.CompositingQuality = System.Drawing.Drawing2D.QualityMode.High*/
            Pen pen = new Pen(Color.DarkGreen);
            Pen pen1 = new Pen(Color.FromArgb(0, 0, 0, 0));
            Brush brush = new SolidBrush(Color.FromArgb(128, Color.Yellow));

            if (comboBox1.SelectedIndex == 0) {
                square.DrawSquare(graphics);
                point.DrawPoint(graphics);
            }
            if (comboBox1.SelectedIndex == 1) {
                point.DrawPoint(graphics);
                circle.DrawEllipse(graphics, pen);
            }
            if (comboBox1.SelectedIndex == 2) {
                rectangle.DrawRectangle(graphics);
                rectangle1.DrawRectangle(graphics);
            }
            if (comboBox1.SelectedIndex == 3) {
                rectangle.DrawRectangle(graphics);
                circle.DrawEllipse(graphics, pen);
            }
            if (comboBox1.SelectedIndex == 4) {
                circle.DrawEllipse(graphics, pen);
                circle1.DrawEllipse(graphics, pen);
            }
            if (comboBox1.SelectedIndex == 5) {
                point.DrawPoint(graphics);
                graphics.FillEllipse(brush, new RectangleF(circle.circlePosition.X - circle.CircleRadius, circle.circlePosition.Y - circle.CircleRadius, 2 * circle.CircleRadius, 2 * circle.CircleRadius));
            }
            if (comboBox1.SelectedIndex == 6) {//nokta-prizma
                point.DrawPoint(graphics);
                prism.DrawPrism(graphics, pen, brush);
            }
            if (comboBox1.SelectedIndex == 7) {
                point.DrawPoint(graphics);
                cylinder.DrawCylinder(graphics, pen, pen1, brush);
            }
            if (comboBox1.SelectedIndex == 8) {
                cylinder.DrawCylinder(graphics, pen, pen1, brush);
                cylinder1.DrawCylinder(graphics, pen, pen1, brush);
            }
            if (comboBox1.SelectedIndex == 9) {
                graphics.FillEllipse(brush, new RectangleF(circle.circlePosition.X - circle.CircleRadius, circle.circlePosition.Y - circle.CircleRadius, 2 * circle.CircleRadius, 2 * circle.CircleRadius));
                graphics.FillEllipse(brush, new RectangleF(circle1.circlePosition.X - circle1.CircleRadius, circle1.circlePosition.Y - circle1.CircleRadius, 2 * circle1.CircleRadius, 2 * circle1.CircleRadius));
            }
            if (comboBox1.SelectedIndex == 10) {
                graphics.FillEllipse(brush, new RectangleF(circle.circlePosition.X - circle.CircleRadius, circle.circlePosition.Y - circle.CircleRadius, 2 * circle.CircleRadius, 2 * circle.CircleRadius));
                cylinder.DrawCylinder(graphics, pen, pen1, brush);
            }
            if (comboBox1.SelectedIndex == 11) {
                graphics.FillEllipse(brush, new RectangleF(circle.circlePosition.X - circle.CircleRadius, circle.circlePosition.Y - circle.CircleRadius, 2 * circle.CircleRadius, 2 * circle.CircleRadius));
                graphics.FillRectangle(Brushes.Blue, new RectangleF(rectangle.RectanglePosition, new SizeF(10, 600)));
            }
            if (comboBox1.SelectedIndex == 12) {
                graphics.FillRectangle(Brushes.Blue, new RectangleF(rectangle.RectanglePosition, new SizeF(10, 600)));
                prism.DrawPrism(graphics, pen, brush);
            }
            if (comboBox1.SelectedIndex == 13) {
                graphics.FillRectangle(Brushes.Blue, new RectangleF(rectangle.RectanglePosition, new SizeF(10, 600)));
                cylinder.DrawCylinder(graphics, pen, pen1, brush);
            }
            if (comboBox1.SelectedIndex == 14) {
                graphics.FillEllipse(brush, new RectangleF(circle.circlePosition.X - circle.CircleRadius, circle.circlePosition.Y - circle.CircleRadius, 2 * circle.CircleRadius, 2 * circle.CircleRadius));

                prism.DrawPrism(graphics, pen, brush);
            }
            if (comboBox1.SelectedIndex == 15) {
                prism.DrawPrism(graphics, pen, brush);
                prism1.DrawPrism(graphics, pen, brush);
            }
        }
    }
}