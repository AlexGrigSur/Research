using Research_Reflections.Attributes;

namespace Research_Reflections.Classes
{

    [IsPreferableAttribute(isPreferable: false)]
    public class BubbleSort : ISort
    {
        private int _reflectionField = 10;

        public string SortName { get; set; } = "Bubble Sort";
        private string Complexity { get; set; } = "O(n^2)";

        public void Sort(int[] array)
        {
            for (int i = 0; i < array.Length; ++i)
            for (int j = 0; j < array.Length - 1 - i; j++)
                if (array[j] > array[j + 1])
                    Swap(ref array[j], ref array[j + 1]);
        }
        protected void Swap(ref int firstIndex, ref int secondIndex)
        {
            int temp = firstIndex;
            firstIndex = secondIndex;
            secondIndex = temp;
        }
    }
}
