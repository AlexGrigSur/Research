using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Research_Reflections.Reflections
{
    static class ReflectionsManipulator
    {
        static public void ShowMembers(object objectToScan)
        {
            Type type = objectToScan.GetType();
            var memberList = type.GetMembers(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetProperty);
            foreach (var member in memberList)
            {
                Console.WriteLine($"{member.Name}");
            }
        }

        static public void GetFields(object objectToScan)
        {
            Type type = objectToScan.GetType();
            var fieldList = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var field in fieldList)
            {
                Console.WriteLine($"{field.Name}:{field.GetValue(objectToScan)}");
            }
        }

        static public void SetFields(object objectToScan, string fieldToSet, object valueToSet)
        {
            Type type = objectToScan.GetType();
            var fieldList = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetProperty);
            foreach (var field in fieldList)
            {
                if (field.Name == fieldToSet)
                {
                    try
                    {
                        field.SetValue(objectToScan, valueToSet);
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine("Value type doesn't match: {0}",e.Message);
                    }
                    
                }
            }
        }
    }
}
