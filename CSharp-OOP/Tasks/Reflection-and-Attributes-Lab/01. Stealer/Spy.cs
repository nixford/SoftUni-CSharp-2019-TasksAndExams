using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string nameOfClassToInvestigate, params string[] namesOfTheFieldsToInvestigate)
        {
            Type classForInv = Type.GetType($"Stealer.{nameOfClassToInvestigate}");

            FieldInfo[] fields = classForInv
                .GetFields(BindingFlags.Public | 
                BindingFlags.NonPublic |
                BindingFlags.Instance |
                BindingFlags.GetField);

            Hacker fieldInstance = new Hacker();

            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine($"Class under investigation: {classForInv.FullName}");

            foreach (var field in fields)
            {
               
                if (namesOfTheFieldsToInvestigate.Contains(field.Name))
                {
                    sb
                    .AppendLine($"{field.Name} = {field.GetValue(fieldInstance)}");
                }
            }
            
            return sb.ToString().TrimEnd();
        }
    }
}
