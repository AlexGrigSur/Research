using Research_Reflections.Attributes;

namespace Research_Reflections.Classes
{
    [IsPreferableAttribute(true)]
    public class SelectionSort : ISort
    {
        private int _reflectionField = 10;

        public string SortName { get; set; } = "Selection Sort";
        private string Complexity { get; set; } = "O(n^2)";

        public void Sort(int[] array)
        {
            for (int i = 0; i < array.Length; ++i)
                for (int j = i + 1; j < array.Length; j++)
                    if (array[i] > array[j])
                        Swap(ref array[i], ref array[j]);
        }

        protected void Swap(ref int firstIndex, ref int secondIndex)
        {
            int temp = firstIndex;
            firstIndex = secondIndex;
            secondIndex = temp;
        }
    }
}