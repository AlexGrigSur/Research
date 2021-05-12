using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Research_Reflections.Attributes;

namespace Research_Reflections.Classes
{
    [IsPreferableAttribute(false)]
    class BubbleSort : ISort
    {
        protected void Swap(ref int firstIndex, ref int secondIndex)
        {
            int temp = firstIndex;
            firstIndex = secondIndex;
            secondIndex = temp;
        }

        public void Sort(int[] array)
        {
            for (int i = 0; i < array.Length; ++i)
                for (int j = 0; j < array.Length - 1 - i; j++)
                    if (array[j] > array[j + 1])
                        Swap(ref array[j], ref array[j + 1]);
        }

        public string SortName { get; set; } = "Bubble Sort";
    }
}
