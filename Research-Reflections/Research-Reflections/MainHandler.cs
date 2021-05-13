using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Research_Reflections.Attributes;
using Research_Reflections.Classes;
using Research_Reflections.Reflections;

namespace Research_Reflections
{
    class MainHandler
    {
        private ISort[] SortMethods = new ISort[]
        {
            new BubbleSort(),
            new SelectionSort()
        };

        public void Start()
        {
            ActivatorClassTestSystem();
            GetCustomAttributes.GetAttribute/*<IsPreferableAttribute>*/(SortMethods[1]);
            ReflectionTestSystem(SortMethods[1]);
        }

        private void ActivatorClassTestSystem()
        {
            try
            {
                ActivatorClass.ActivatorCreateInstance<BubbleSort>("Research_Reflections.Classes.BubbleSort");
                ActivatorClass.ActivatorCreateInstance<SelectionSort>("Research_Reflections.Classes.SelectionSort");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        private void ReflectionTestSystem(ISort sortMethod)
        {
            Console.WriteLine("********************************");
            Console.WriteLine("Reflection Get/Set");
            try
            {
                ReflectionsManipulator.GetFields(sortMethod);
                ReflectionsManipulator.SetFields(sortMethod, "reflectionField", "hello");
                ReflectionsManipulator.GetFields(sortMethod);
            }
            catch(Exception e)
            {
                Console.WriteLine("Reflection Test System Error:{0}", e.Message);
            }
        }

        //private void beginSort(ISort method)
        //{
        //    int[] GenerateArray(int count)
        //    {
        //        if (count < 1)
        //            throw new ArgumentOutOfRangeException("Elements count less that 1");

        //        int[] array = new int[count];

        //        for (int i = 0; i < count; ++i)
        //            array[count - i - 1] = i;

        //        return array;
        //    }

        //    //string attributePropertyValue = GetCustomAttributes.GetAttribute(method);
        //    //Console.WriteLine(attributePropertyValue);

        //    // TODO: GET CLASS PROPERTY FIELD
        //    // TODO: IF NOT PREFERABLE - ASK USER TO CONTINUE
        //    // TODO: THEN CALL SORT METHOD
        //}
    }
}
