using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using FractalLib;
namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
     
        public ActionResult Index()
        {
            return View();
        }
        public FileResult GetImage()
        {
            FractalJulian fractal = new FractalJulian(-0.70196, -0.3842, 1,0,0,300,640,480);
            //Отдельная функция
            ImageConverter converter = new ImageConverter();
            var imageBytes = (byte[])converter.ConvertTo(fractal.Draw(), typeof(byte[]));
            return File(imageBytes, "image /jpg");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
    public class Fractal
    {
        public static void DrawFractal(InlineImageResult bmp,int w, int h, Pen pen)
        {
            double cRe, cIm;
            double newRe, newIm, oldRe, oldIm;
            double zoom = 1, moveX = 0, moveY = 0;
            int maxIterations = 300;
            cRe = -0.70176;
            cIm = -0.3842;
            //"перебираем" каждый пиксель
            for (int x = 0; x < w; x++)
                for (int y = 0; y < h; y++)
                {
                    //вычисляется реальная и мнимая части числа z
                    //на основе расположения пикселей,масштабирования и значения позиции
                    newRe = 1.5 * (x - w / 2) / (0.5 * zoom * w) + moveX;
                    newIm = (y - h / 2) / (0.5 * zoom * h) + moveY;

                    //i представляет собой число итераций 
                    int i;

                    //начинается процесс итерации
                    for (i = 0; i < maxIterations; i++)
                    {

                        //Запоминаем значение предыдущей итерации
                        oldRe = newRe;
                        oldIm = newIm;

                        // в текущей итерации вычисляются действительная и мнимая части 
                        newRe = oldRe * oldRe - oldIm * oldIm + cRe;
                        newIm = 2 * oldRe * oldIm + cIm;

                        // если точка находится вне круга с радиусом 2 - прерываемся
                        if ((newRe * newRe + newIm * newIm) > 4) break;
                    }

                    //определяем цвета
                    pen.Color = Color.FromArgb(255, (i * 9) % 255, 0, (i * 9) % 255);
                    //рисуем пиксель
                    bmp.Graphics.DrawRectangle(pen, x, y, 1, 1);
                }
            
            
    
        }
        public Fractal()
        {
     
        }
    }
    public sealed class InlineImageResult : ActionResult
    {
        private readonly Image bmp;

        public InlineImageResult(int width, int height)
        {
           
            this.bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);

            this.Graphics = Graphics.FromImage(this.bmp);
         
            this.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            this.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            this.Graphics.InterpolationMode = InterpolationMode.High;
           
            this.Graphics.Clear(Color.Transparent);
        }

        public Graphics Graphics { get; private set; }

        public override void ExecuteResult(ControllerContext context)
        {
            using (this.bmp)
            using (this.Graphics)
            using (var stream = new MemoryStream())
            {
                
                var format = ImageFormat.Png;

                this.bmp.Save(stream, format);

                var img = String.Format("<img src=\"data:image/{0};base64,{1}\"/>", format.ToString().ToLower(), Convert.ToBase64String(stream.ToArray()));

                context.HttpContext.Response.Write(img);
            }
        }
    }
}