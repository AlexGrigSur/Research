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
        static public void ActivatorCreateInstance()
        {
            // Typeof instance
            var bubbleActivatorObject = (BubbleSort)Activator.CreateInstance(typeof(BubbleSort));
            Console.WriteLine(bubbleActivatorObject.SortName);

            // Assembly instance
            var selectionActivatorObject = (SelectionSort)Activator.CreateInstance(null, "Research_Reflections.Classes.SelectionSort").Unwrap();
            Console.WriteLine(selectionActivatorObject.SortName);

            // Generic instance
            var selectionActivatorGenericType = Activator.CreateInstance<SelectionSort>();
            Console.WriteLine(selectionActivatorGenericType.SortName);
        }
    }
}