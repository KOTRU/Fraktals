﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractalLib
{
    public interface IFractalJulian: IFractal
    {
        Complex C { get; set; }
    }
}
