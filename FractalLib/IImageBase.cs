using System;
using System.Collections.Generic;
using System.Drawing;
namespace FractalLib
{
    public interface IImageBase
    {
        int R { get; set; }
        int G { get; set; }
        int B { get; set; }
        int Width { get; set; }
        int Height { get; set; }
        Bitmap Draw();
    }
}
