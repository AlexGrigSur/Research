using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Research_Reflections.Attributes;

namespace Research_Reflections.Classes
{
    [IsPreferableAttribute(true)]
    class SelectionSort : ISort
    {
        public void Sort(int[] array)
        {
            for (int i = 0; i < array.Length; ++i)
                for (int j = i + 1; j < array.Length; j++)
                    if (array[i] > array[j])
                        Swap(ref array[i], ref array[j]);
        }

        public string SortName { get; set; }

        protected void Swap(ref int firstIndex, ref int secondIndex)
        {
            int temp = firstIndex;
            firstIndex = secondIndex;
            secondIndex = temp;
        }
    }
}
