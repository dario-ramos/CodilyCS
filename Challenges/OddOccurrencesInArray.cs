using System;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class OddOccurrencesInArray
{
    public int solution(int[] A)
    {
        // write your code in C# 6.0 with .NET 4.5 (Mono)
        int result = A[0];
        Array.Sort(A);
        for (int i = 0; i < A.Length; i++)
        {
            if (i == A.Length - 1)
            {
                return A[i];
            }
            if (A[i] == A[i + 1])
            {
                i++;
            }
            else
            {
                return A[i];
            }
        }
        return result;
    }
}
