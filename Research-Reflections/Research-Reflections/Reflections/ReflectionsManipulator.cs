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
        public static void GetProperty(object objectToScan, string propertyName)
        {
            Type type = objectToScan.GetType();
            var property = type.GetProperty(propertyName);
            if (property == null)
            {
                return;
            }
            Console.WriteLine($"{property.Name}:{property.GetValue(objectToScan)}");
        }
        public static void SetProperty(object objectToScan, string propToSet, object valueToSet)
        {
            Type type = objectToScan.GetType();
            var property = type.GetProperty(propToSet);
            if (property == null)
            {
                return;
            }
            property.SetValue(objectToScan, valueToSet);
        }
    }
}
