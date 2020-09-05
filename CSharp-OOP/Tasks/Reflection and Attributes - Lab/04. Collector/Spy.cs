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

        public string AnalyzeAcessModifiers(string className)
        {
            Type classType = Type.GetType($"Stealer.{className}");

            FieldInfo[] fields = classType
                .GetFields(
                BindingFlags.Instance |
                BindingFlags.Static |
                BindingFlags.Public);

            MethodInfo[] methodsPublic = classType
                .GetMethods(
                BindingFlags.Instance | 
                BindingFlags.Public);

            MethodInfo[] methodsNonPublic = classType
                .GetMethods(
                BindingFlags.Instance | 
                BindingFlags.NonPublic);

            StringBuilder sb = new StringBuilder();

            foreach (FieldInfo field in fields)
            {
                if (field.IsPublic)
                {
                    sb.AppendLine($"{field.Name} must be private!");
                }
                
            }
            foreach (MethodInfo method in methodsNonPublic.Where(m => m.Name.StartsWith("get")))
            {
                if (method.IsPrivate)
                {
                    sb.AppendLine($"{method.Name} have to be public!");
                }                
            }
            foreach (MethodInfo method in methodsPublic.Where(m => m.Name.StartsWith("set")))
            {
                if (method.IsPublic)
                {
                    sb.AppendLine($"{method.Name} have to be private!");
                }               
            }

            return sb.ToString().TrimEnd();
        }

        public string RevealPrivateMethods(string className)
        {
            StringBuilder sb = new StringBuilder();

            Type classType = Type.GetType(className);

            MethodInfo[] privateMethods = classType
                .GetMethods(
                BindingFlags.Instance |
                BindingFlags.Static |
                BindingFlags.NonPublic);

            sb
                .AppendLine($"All Private Methods of Class: {classType.FullName}")
                .AppendLine($"Base Class: {classType.BaseType.Name}"); ;

            foreach (MethodInfo method in privateMethods)
            {
                sb.AppendLine($"{method.Name}");
            }

            return sb.ToString().TrimEnd();
        }

        public string CollectGettersAndSetters(string className)
        {
            StringBuilder sb = new StringBuilder();

            Type classType = Type.GetType(className);

            MethodInfo[] methods = classType
                            .GetMethods
                            (BindingFlags.Public |
                            BindingFlags.Instance |
                            BindingFlags.NonPublic);

            foreach (MethodInfo method in methods)
            {
                if (method.Name.StartsWith("get"))
                {
                    sb
                        .AppendLine($"{method.Name} will return {method.ReturnType}");
                }
            }

            foreach (MethodInfo method in methods)
            {
                if (method.Name.StartsWith("set"))
                {
                    sb
                        .AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
                }
            }


            return sb.ToString().TrimEnd();
        }
    }
}
