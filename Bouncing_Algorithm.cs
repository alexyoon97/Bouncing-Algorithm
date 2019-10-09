using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace ica2
{
    class Ball
    {
        static private Random rand = new Random();
        private Point Location
        {
            get { return pLocation; }
        }
        private Point pLocation;
        private int velX;
        public int velx
        {
            set { velX = value; }
        }
        private int velY;
        public int vely
        {
            set
            {
                if (value > 10)
                    velY = 10;
                else if (value < -10)
                    velY = -10;
                else
                    velY = value;
            }
        }
        private Color BallColor;
        public int BallOpa
        {
            get;
            set;
        }
        public readonly int Ballrad;

        public Ball (Point p)
        {
            BallColor = RandColor.GetColor();
            Ballrad = 40;
            velX = rand.Next(-11, 11);
            velY = rand.Next(-11, 11);
            BallOpa = 128;
            pLocation = p;

        }
        public void MoveBall(CDrawer canvas)
        {
            if ((pLocation.X + velX + Ballrad) >= canvas.ScaledWidth || (pLocation.X + velX - Ballrad) <= 0)
            {
                if((pLocation.X + velX + Ballrad) >= canvas.ScaledWidth)
                    pLocation.X = canvas.ScaledWidth - Ballrad;
                else if ((pLocation.X += velX - Ballrad) <= 0)
                    pLocation.X = 0 + Ballrad;
                velX = -velX;
            }
            if ((pLocation.Y + velY + Ballrad) >= canvas.ScaledHeight || (pLocation.Y + velY - Ballrad) <= 0)
            {
                if((pLocation.Y + velY + Ballrad) >= canvas.ScaledHeight)
                    pLocation.Y = canvas.ScaledHeight - Ballrad;
                else if ((pLocation.Y += velY - Ballrad) <= 0)
                    pLocation.Y = 0 + Ballrad;
                velY = -velY;
            }
            pLocation.Y += velY ;
            pLocation.X += velX ;


        }
        public void ShowBall(CDrawer canvas)
        {
            canvas.AddCenteredEllipse(pLocation, 2*Ballrad, 2*Ballrad, Color.FromArgb(BallOpa, BallColor));
        }
        public override string ToString()
        {
            return $"[X={pLocation.X},Y={pLocation.Y}]Opacity : {BallOpa} Vel : {velX}, {velY}";
        }
    }
}
