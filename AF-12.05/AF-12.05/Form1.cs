namespace AF_12._05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Graphics g;
        Bitmap bmp;
        Random rnd = new Random();
        Pen Pen = new Pen(Color.Indigo, 4);
        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            PointF A = new PointF(rnd.Next(10, bmp.Width - 10), rnd.Next(10, bmp.Height - 10));
            PointF B = new PointF(rnd.Next(10, bmp.Width - 10), rnd.Next(10, bmp.Height - 10));
            PointF C = new PointF(rnd.Next(10, bmp.Width - 10), rnd.Next(10, bmp.Height - 10));
            PointF D = new PointF(rnd.Next(10, bmp.Width - 10), rnd.Next(10, bmp.Height - 10));
            //DrawTriangle(A, B, C);  
            Serpinski(A,B,C);
            //Covor(A, B, C, D);
            pictureBox1.Image = bmp;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }
        public double Distanta(PointF A, PointF B)
        {
            double toRet = Math.Sqrt(Math.Pow(B.X - A.X, 2) + Math.Pow(B.Y - A.Y, 2));
            return toRet;
        }
        public void DrawTriangle(PointF A, PointF B, PointF C)
        {
            g.DrawLine(Pen, A.X, A.Y, B.X, B.Y);
            g.DrawLine(Pen, B.X, B.Y, C.X, C.Y);
            g.DrawLine(Pen, C.X, C.Y, A.X, A.Y);
        }
        public void DrawPatrulater(PointF A, PointF B, PointF C, PointF D)
        {
            g.DrawLine(Pen, A, B);
            g.DrawLine(Pen, B, C);
            g.DrawLine(Pen, C, D);
            g.DrawLine(Pen, D, A);
        }
        public void Serpinski(PointF A, PointF B, PointF C)
        {
            if (Distanta(A, B) > 1)
            {
                PointF M = new PointF((A.X + C.X) / 2, (A.Y + C.Y) / 2);
                PointF N = new PointF((A.X + B.X) / 2, (A.Y + B.Y) / 2);
                PointF P = new PointF((B.X + C.X) / 2, (B.Y + C.Y) / 2);
                DrawTriangle(A, B, C);
                Serpinski(M, A, N);
                Serpinski(M, C, P);
                Serpinski(N, B, P);
            }
        }
        public void Covor(PointF A, PointF B, PointF C, PointF D)
        {
            if (Distanta(A, B) > 1)
            {
                PointF M1 = new PointF((2 * A.X + B.X) / 3, (2 * A.Y + B.Y) / 3);
                PointF M2 = new PointF((2 * B.X + A.X) / 3, (2 * B.Y + A.Y) / 3);
                PointF N1 = new PointF((2 * B.X + C.X) / 3, (2 * B.Y + C.Y) / 3);
                PointF N2 = new PointF((2 * C.X + B.X) / 3, (2 * C.Y + B.Y) / 3);
                PointF P1 = new PointF((2 * C.X + D.X) / 3, (2 * C.Y + D.Y) / 3);
                PointF P2 = new PointF((2 * D.X + C.X) / 3, (2 * D.Y + C.Y) / 3);
                PointF Q1 = new PointF((2 * D.X + A.X) / 3, (2 * D.Y + A.Y) / 3);
                PointF Q2 = new PointF((2 * A.X + D.X) / 3, (2 * A.Y + D.Y) / 3);
                PointF I1 = new PointF((2 * M1.X + P2.X) / 3, (2 * M1.Y + P2.Y) / 3);
                PointF I2 = new PointF((2 * M2.X + P1.X) / 3, (2 * M2.Y + P1.Y) / 3);
                PointF J1 = new PointF((2 * P2.X + M1.X) / 3, (2 * P2.Y + M1.Y) / 3);
                PointF J2 = new PointF((2 * P1.X + M2.X) / 3, (2 * P1.Y + M2.Y) / 3);
                DrawPatrulater(A, B, C, D);
                Covor(A, M1, I1, Q2);
                Covor(M2, B, N1, I2);
                Covor(J2, N2, C, P1);
                Covor(Q1, J1, P2, D);
                Covor(I1, I2, J2, J1);
            }
        }
        public void DrawHexagon(PointF[] Outer)
        {
            for(int i=1; i<Outer.Length; i++)
            {
                g.DrawLine(Pen, Outer[i - 1], Outer[i]);
            }
            g.DrawLine(Pen, Outer[Outer.Length - 1], Outer[0]);
        }
        public PointF[] Hexagon(PointF Centru, float l, float fi, int n)
        {
            PointF[] toRet = new PointF[n];
            float alpha = (float)Math.PI * 2 / n;
            for (int i = 0; i < n; i++)
            {
                float X = Centru.X + l * (float)Math.Cos(i * alpha);
                float Y = Centru.Y + l * (float)Math.Cos(i * alpha);
                toRet[i] = new PointF(X, Y);
            }
            return toRet;
        }
       

    }
}