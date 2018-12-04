﻿using System.IO;
using System.Linq;

namespace FileExtensions
{
    public static class FileExtensions
    {
        public static int[] ReadIntArrayFromFile(string filePath) =>
            File
                .ReadLines(filePath)
                .Select(s => s.Trim())
                .Select(int.Parse)
                .ToArray();

        public static int[][] ReadIntMatrixFromFile(string filePath) =>
            File
                .ReadLines(filePath)
                .Select(line => line.Split(' ')
                    .Select(int.Parse)
                    .ToArray())
                .ToArray();

        public static string[][] ReadStringMatrixFromFile(string filePath) =>
            File
                .ReadLines(filePath)
                .Select(line => line.Split(' '))
                .ToArray();
    }
}
