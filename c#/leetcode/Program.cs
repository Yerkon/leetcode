﻿using System;
using System.Collections.Generic;
using System.Linq;
using ArrayType;

namespace leetcode {
    class Program {
        static void Main(string[] args) {
            //Solution sol = new Solution();
            Solution sol = new Solution();
            //  sol.FindDisappearedNumbers (new int[] { 10, 2, 5, 10, 9, 1, 1, 4, 3, 7 });
            // 

            // [1,2,6,3,0,7,1,7,1,9,7,5,6,6,4,4,0,0,6,3]
            // 516

            sol.NumEquivDominoPairs(new int[][] {
                new int[] { 1, 2 },
                    new int[] { 2, 1 },
                    new int[] { 3, 4 },
                    new int[] { 5, 6 },
            });
        }

    }
}