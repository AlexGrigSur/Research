using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Research_Reflections.Classes;

namespace Research_Reflections
{
    public class ActivatorClass
    {
        static public void ActivatorCreateInstance<T>(string typeName) where T:class
        {
            Console.WriteLine("*******************************");
            Console.WriteLine(typeof(T).Name);

            // Typeof instance
            var typeOfInstance = (T)Activator.CreateInstance(typeof(T));
            Console.WriteLine("typeOfInstance:{0}",typeOfInstance.GetType());

            // Assembly instance
            // "Research_Reflections.Classes.SelectionSort"
            var assemblyInstance = (T)Activator.CreateInstance(null, typeName).Unwrap();
            Console.WriteLine("assemblyInstance:{0}", assemblyInstance.GetType());

            // Generic instance
            var genericInstance = Activator.CreateInstance<T>();
            Console.WriteLine("genericInstance:{0}", genericInstance.GetType());
        }
    }
}