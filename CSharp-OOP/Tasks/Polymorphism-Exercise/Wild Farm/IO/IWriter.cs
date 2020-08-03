using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.AnimalModels;

namespace WildFarm
{
    public interface IWriter
    {
        void CustomWriteLine(string text);

        void CustomWrite(string text);
        void CustomWriteLine(Animal animal);
    }
}
