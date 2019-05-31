using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractalLib
{
    public interface IFractal: IImageBase
    {
        double Zoom { get; set; }
        double MoveX { get; set; }
        double MoveY { get; set; }
        int MaxIterations { get; set; }

    }
}
