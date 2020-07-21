using P01Logger.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01Logger.Layouts
{
    public class SimpleLayout : ILayout
    {
        string ILayout.Format => "{0} - {1} - {2}";
    }
}
