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
using System.Web.UI;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
       
    
        public ActionResult Index()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult Index(string CRe, string CIm, string Zoom, string MoveX, string MoveY, string MaxIterations, string Width, string Height)
        {
            try
            {
                Complex C = new Complex(Convert.ToDouble(CRe), Convert.ToDouble(CIm));
                FractalJulian fractal = new FractalJulian(C.Re, C.Im, Convert.ToDouble(Zoom), Convert.ToDouble(MoveX), Convert.ToDouble(MoveY), Convert.ToInt32(MaxIterations), Convert.ToInt32(Width), Convert.ToInt32(Height));
                ImageConverter converter = new ImageConverter();
                var imageBytes = (byte[])converter.ConvertTo(fractal.Draw(), typeof(byte[]));
                var imgString = "data:image/png;base64," + Convert.ToBase64String(imageBytes);
                ViewData["Head"] = imgString;
            }
            catch(FormatException e)
            {
                
                ViewBag.Message = string.Format("Hello.\\nCurrent Date and Time: {0}",CRe);
            }
            return View();
   
        }
        public ActionResult About()
        {

            return View();
        }
        [HttpPost]
        public ActionResult About(string Length, string RecHeight, string RecMargin, string Zoom, string MoveX, string MoveY, string MaxIterations, string Width, string Height)
        {
            try
            {

                FractalCantor fractal = new FractalCantor(Convert.ToInt32(Length), Convert.ToInt32(RecHeight), Convert.ToInt32(RecMargin), Convert.ToDouble(Zoom), Convert.ToDouble(MoveX), Convert.ToDouble(MoveY), Convert.ToInt32(MaxIterations), Convert.ToInt32(Width), Convert.ToInt32(Height));
                ImageConverter converter = new ImageConverter();
                var imageBytes = (byte[])converter.ConvertTo(fractal.Draw(), typeof(byte[]));
                var imgString = "data:image/png;base64," + Convert.ToBase64String(imageBytes);
                ViewData["Head1"] = imgString;
            }
            catch (FormatException e)
            {

                ViewBag.Message = string.Format("Hello.\\nCurrent Date and Time: {0}",123);
            }
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}