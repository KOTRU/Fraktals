using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace FractalLib
{
    public class FractalJulian : IFractalJulian
    {
        private const double CRE = -0.70176;

        private const double CIM = -0.3842;

        private const int MAX_ITERATIONS = 300;

        private const int INIT_WIDTH = 640;

        private const int INIT_HEIGHT = 480;

        public Complex C { get; set; }
        public double Zoom { get; set; }
        public double MoveX { get; set; }
        public double MoveY { get; set; }
        public int MaxIterations { get; set; }
        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public FractalJulian()
        {
            C = new Complex(CRE, CIM);
            Zoom = 1;
            MoveX = MoveY = 0;
            MaxIterations = MAX_ITERATIONS;
            Width = INIT_WIDTH;
            Height = INIT_HEIGHT;
        }

        public FractalJulian(double CRe, double CIm, double Zoom, double MoveX, double MoveY, int MaxIterations, int Width, int Height)
        {
            C = new Complex(CRe, CIm);
            this.Zoom = Zoom;
            this.MoveX = MoveX;
            this.MoveY = MoveY;
            this.MaxIterations = MaxIterations;
            this.Width = Width;
            this.Height = Height;
        }

        public Bitmap Draw()
        {
            var bmp = new Bitmap(Width, Height);
            double newRe, newIm, oldRe, oldIm;
            //"перебираем" каждый пиксель
            for (var x = 0; x < Width; x++)
            {
                for (var y = 0; y < Height; y++)
                {
                    //вычисляется реальная и мнимая части числа z
                    //на основе расположения пикселей,масштабирования и значения позиции
                    newRe = 1.5 * (x - Width / 2) / (0.5 * Zoom * Width) + MoveX;
                    newIm = (y - Height / 2) / (0.5 * Zoom * Height) + MoveY;

                    //i представляет собой число итераций 
                    int i;

                    //начинается процесс итерации
                    for (i = 0; i < MaxIterations; i++)
                    {
                        //Запоминаем значение предыдущей итерации
                        oldRe = newRe;
                        oldIm = newIm;

                        // в текущей итерации вычисляются действительная и мнимая части 
                        newRe = oldRe * oldRe - oldIm * oldIm + C.Re;
                        newIm = 2 * oldRe * oldIm + C.Im;

                        // если точка находится вне круга с радиусом 2 - прерываемся
                        if ((newRe * newRe + newIm * newIm) > 4) break;
                    }

                    //определяем цвета
                    bmp.SetPixel(x, y, Color.FromArgb(255, (i * 9) % 255, 0, (i * 9) % 255));

                }
            }

            return bmp;


        }
    }
}
