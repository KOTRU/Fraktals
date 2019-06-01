using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractalLib
{
   public class FractalCantor : IFractalCantor
    {
        

        private const int MAX_ITERATIONS = 3;

        private const int INIT_WIDTH = 640;

        private const int INIT_HEIGHT = 480;

        private const int INIT_RECHEIGHT = 12;

        private const int INIT_RECMARGIN = 40;
        public double Zoom { get; set; }
        public double MoveX { get; set; }
        public double MoveY { get; set; }
        public int MaxIterations { get; set; }
        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }
        public int Width { get; set; }
        public int RecHeight { get; set; }
        public int Length { get  ; set  ; }
        public int Height { get  ; set  ; }
        public int RecMargin { get  ; set  ; }

        public FractalCantor()
        {
            RecMargin = INIT_RECMARGIN;
            RecHeight = INIT_RECHEIGHT;
            Length = INIT_WIDTH;
            Zoom = 1;
            MoveX = MoveY = 0;
            MaxIterations = MAX_ITERATIONS;
            Width = INIT_WIDTH;
            Height = INIT_HEIGHT;
        }
        public FractalCantor(int Length, int RecHeight, int RecMargin, double Zoom, double MoveX, double MoveY, int MaxIterations, int Width, int Height)
        {
            this.RecMargin = RecMargin;
            this.Length = Length;
            this.Zoom = Zoom;
            this.MoveX = MoveX;
            this.MoveY = MoveY;
            this.MaxIterations = MaxIterations;
            this.Width = Width;
            this.Height = Height;
            this.RecHeight = RecHeight;
        }

        public Bitmap Draw()
        {
            var bmp = new Bitmap(Width, Height);
            int x = Width / 2 - Length / 2;
            
                KantorDraw(x, MoveY, Length, bmp);
            
            return bmp;
        }
        private void KantorDraw(int x, double y, int width, Bitmap bmp)
        {
            if (y < bmp.Height)
            {


                if (width >= MaxIterations)
                {

                    for (var i = x; i < x + width; i++)
                    {
                        for (var j = 0; j < RecHeight; j++)
                        {

                            bmp.SetPixel((int)(i + MoveX), (int)(y + j), Color.FromArgb(255, 255, 0, 255));
                        }
                    }

                    y = y + RecMargin;

                    KantorDraw(x + width * 2 / 3, y, width / 3, bmp);
                    KantorDraw(x, y, width / 3, bmp);

                }
            }
        }
    }
}
