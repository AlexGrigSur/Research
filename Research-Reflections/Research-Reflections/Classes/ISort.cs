using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research_Reflections.Classes
{
    interface ISort
    {
        void Sort(int[] array);
        string SortName { get; set; }
    }
}
