using P01Logger.Layouts;
using P01Logger.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01Logger.Factories.AppenderFactory
{
    public static class LayoutFactory
    {

        public static ILayout CreateLayout(string type)
        {
            string layoutType = type.ToLower();

            switch(layoutType)
            {
                case "simplelayout":
                    return new SimpleLayout();
                case "xmllayout":
                    return new XmlLayout();
                case "jsonlayout":
                    return new JasonLayout();
                default:
                    throw new ArgumentException("Invalid Layout");
             
            }
        }
    }
}
