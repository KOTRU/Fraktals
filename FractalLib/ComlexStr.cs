using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractalLib
{
   public struct Complex
    {
        public double Re { get; set; }
        public double Im { get; set; }
        public Complex(double Re, double Im)
        {
            this.Re = Re;
            this.Im = Im;
        }
    }
}
