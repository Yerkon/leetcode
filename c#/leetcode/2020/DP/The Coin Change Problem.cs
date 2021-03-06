﻿using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace HackerRank {
    class Result {
        /*
         * Complete the 'getWays' function below.
         *
         * The function is expected to return a LONG_INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER n
         *  2. LONG_INTEGER_ARRAY c
         */

        // DP. bottom-up
        public static long getWays(int N, List<long> c) {
            if (N == 0 || c.Count == 0) return 0;

            long[][] dp = new long[c.Count + 1][];

            for (int i = 0; i < dp.Length; i++) {
                long[] row = new long[N + 1];
                dp[i] = row;
            }

            for (int i = 1; i < dp.Length; i++) {
                for (int j = 0; j < dp[0].Length; j++) { // iterate up to N

                    if (c[i - 1] > j) {
                        dp[i][j] = dp[i - 1][j];
                    } else {
                        long found = j - c[i - 1] == 0 ? 1 : 0;
                        long include = dp[i][j - c[i - 1]];
                        long prev = dp[i - 1][j];

                        dp[i][j] = include + found + prev;
                    }
                }
            }

            //   for(int i = 0; i<dp.Length; i++) {
            //       for(int j = 0; j < dp[0].Length; j++) {
            //           Console.Write(dp[i][j] + " ");
            //       }
            //       Console.WriteLine();
            //   }

            return dp[c.Count][N];
        }

        // DP. Top-down solution
        public static long getWays2(int W, List<long> c) {
            long[][] dp = new long[c.Count][];

            for (int i = 0; i < dp.Length; i++) {
                long[] row = new long[W + 1];
                dp[i] = row;

                for (int j = 0; j < row.Length; j++) {
                    dp[i][j] = -1;
                }
            }

            return Calc(W, c, 0, dp);
        }

        public static long Calc(long N, List<long> c, int idx, long[][] dp) {
            if (N == 0 || c.Count == 0 || c.Count == idx) return 0;


            if (dp[idx][N] == -1) {

                if (N - c[idx] < 0) {
                    dp[idx][N] = Calc(N, c, idx + 1, dp);
                }

                if (N - c[idx] >= 0) {
                    int found = N - c[idx] == 0 ? 1 : 0;
                    long include = Calc(N - c[idx], c, idx, dp);
                    long next = Calc(N, c, idx + 1, dp);

                    dp[idx][N] = include + found + next;
                }
            }

            return dp[idx][N];
        }
    }

    //class Solution1 {
    //    private static void Main(string[] args) {
    //        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

    //        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

    //        int n = Convert.ToInt32(firstMultipleInput[0]);

    //        int m = Convert.ToInt32(firstMultipleInput[1]);

    //        List<long> c = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(cTemp => Convert.ToInt64(cTemp)).ToList();

    //        // Print the number of ways of making change for 'n' units using coins having the values given by 'c'

    //        long ways = Result.getWays(n, c);

    //        textWriter.WriteLine(ways);

    //        textWriter.Flush();
    //        textWriter.Close();
    //    }
    //}

}