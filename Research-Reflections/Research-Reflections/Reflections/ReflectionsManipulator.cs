using System;
using System.Reflection;

namespace Research_Reflections.Reflections
{
    public static class ReflectionsManipulator
    {
        public static void ShowMembers(object objectToScan)
        {
            Type type = objectToScan.GetType();
            var memberList = type.GetMembers(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetProperty);
            foreach (var member in memberList)
            {
                Console.WriteLine($"{member.Name}");
            }
        }
        public static void GetFields(object objectToScan)
        {
            Type type = objectToScan.GetType();
            var fieldList = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetProperty);
            foreach (var field in fieldList)
            {
                Console.WriteLine($"{field.Name}:{field.GetValue(objectToScan)}");
            }
        }
        public static void SetFields(object objectToScan, string fieldToSet, object valueToSet)
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
