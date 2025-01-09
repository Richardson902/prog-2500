using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort_Utest
{
    public class TestMe
    {
        public int[] integer_array_sort(in int[] unsorted_array)
        {
            // stub implementation of method

            // to_do:  fix the nested for loops to sort the unsorted array
            // DO NOT USE ArrayList.Sort in the assignment

            int[] working_array;
            working_array = unsorted_array;
            int swap;

            for (int i = 2; i < working_array.Length; i++)
            {
                for (int j = 0; j < working_array.Length; j++)
                {
                    if (working_array[i] > working_array[j])
                    {
                        swap = working_array[i];
 //                       working_array[i] = working_array[j];
                        working_array[j] = swap;
                    }
                }
            }

            return working_array;
        }
    }
}
