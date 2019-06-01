using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractalLib
{
    interface IFractalCantor: IFractal
    {
        int Length { get; set; }
        int RecHeight { get; set; }
        int RecMargin { get; set; }
    }
}
