using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Research_Reflections.Attributes;
using Research_Reflections.Classes;
using Research_Reflections.Reflections;

namespace Research_Reflections
{
    public class MainHandler
    {
        public void Start()
        {
            // ex #1
            var typesList = GetTypesFromCurrentAssembly<IsPreferableAttribute>();
            
            // ex #2
            var instanceList = ActivatorCreateInstance(typesList);

            // ex #3-4
            for (int i = 0; i < instanceList.Count; i++)
            {
                ReflectionTestSystem(instanceList[i], "<SortName>k__BackingField", "SAY HELLO TO MY LITTLE SORT");
            }
        }

        private List<Type> GetTypesFromCurrentAssembly<TAttribute>() where TAttribute : Attribute
        {
            var typeList = from type in Assembly.GetExecutingAssembly().GetTypes()
                where type.IsClass && type.GetCustomAttributes(typeof(TAttribute))!=null && type.GetInterfaces().Contains(typeof(ISort)) // ISort to generic?
                select type;
            return typeList.ToList();
        }
        private List<object> ActivatorCreateInstance(List<Type> typesToCreate)
        {
            List<object> result = new List<object>(typesToCreate.Count);

            // try..catch?
            for (int i = 0; i < typesToCreate.Count; i++)
            {
                var assemblyInstance = Activator.CreateInstance(typesToCreate[i]);
                result.Add(assemblyInstance);
            }
            return result;
        }
        private void ReflectionTestSystem(object objectToReflect, string fieldToChange, object valueToChange)
        {
            try
            {
                Console.WriteLine("***********************");
                Console.WriteLine(objectToReflect.GetType());
                Console.WriteLine("GET");
                ReflectionsManipulator.GetFields(objectToReflect);
                Console.WriteLine("-----------------------");
                Console.WriteLine("SET");
                ReflectionsManipulator.SetFields(objectToReflect,fieldToChange,valueToChange);
                Console.WriteLine("{0}:{1}", fieldToChange, valueToChange);
                Console.WriteLine("-----------------------");
                Console.WriteLine("GET CHANGED");
                ReflectionsManipulator.GetFields(objectToReflect);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
