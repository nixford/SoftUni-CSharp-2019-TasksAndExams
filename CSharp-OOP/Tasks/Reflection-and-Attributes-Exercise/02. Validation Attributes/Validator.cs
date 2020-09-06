using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using ValidationAttributes.Attributes;

namespace ValidationAttributes
{
    public class Validator
    {

        public static bool IsValid(object obj)
        {
            Type objType = obj.GetType();

            PropertyInfo[] propertyInfos = objType.GetProperties();

            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                List<Attribute> allAtributes = propertyInfo.GetCustomAttributes().ToList();
                List<MyValidationAttribute> allMyAtributes = propertyInfo.GetCustomAttributes<MyValidationAttribute>().ToList();
            }

            return true;
        }       
    }
}
