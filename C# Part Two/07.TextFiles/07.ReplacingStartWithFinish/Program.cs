﻿using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        using (StreamReader input = new StreamReader("input.txt"))
        {
            using (StreamWriter output = new StreamWriter("output.txt"))
            {
                
                string line = input.ReadLine();
                while (line != null)
                {
                    output.WriteLine(line.Replace("start", "finish"));
                    line = input.ReadLine();
                    // output.WriteLine(Regex.Replace(line, @"\bstart\b", "finish")); // Exercise 8
                }
            }
        }
    }
}