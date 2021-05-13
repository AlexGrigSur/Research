using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Research_Reflections.Attributes;
using Research_Reflections.Classes;

namespace Research_Reflections
{
    class MainHandler
    {
        private ISort[] SortMethods = new ISort[]
        {
            new BubbleSort(),
            new SelectionSort()
        };

        private void PrintMenu()
        {
            Console.WriteLine("Choose method to sort:");
            for (int i = 0; i < SortMethods.Length; ++i)
                Console.WriteLine($"\t{i}:{SortMethods[i].SortName}");
            Console.WriteLine("***************");
            Console.WriteLine("Choose method to sort or empty string to exit:");
        }
        public void Start()
        {
            //ActivatorClass.ActivatorCreateInstance();
            beginSort(SortMethods[1]);

            //PrintMenu();
            //string result = Console.ReadLine();
            //int inputResult;
            //// TODO: CHOOSE SORT METHOD
        }
        private void beginSort(ISort method)
        {
            int[] GenerateArray(int count)
            {
                if (count < 1)
                    throw new ArgumentOutOfRangeException("Elements count less that 1");

                int[] array = new int[count];

                for (int i = 0; i < count; ++i)
                    array[count - i - 1] = i;

                return array;
            }

            string attributePropertyValue = GetCustomAttributes.GetAttribute(method);
            Console.WriteLine(attributePropertyValue);

            // TODO: GET CLASS PROPERTY FIELD
            // TODO: IF NOT PREFERABLE - ASK USER TO CONTINUE
            // TODO: THEN CALL SORT METHOD
        }
    }
}
