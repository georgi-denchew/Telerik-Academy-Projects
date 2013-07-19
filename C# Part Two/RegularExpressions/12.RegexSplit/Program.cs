using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _12.RegexSplit
{
    class Program
    {
        static void Main(string[] args)
        {
            String text = "zuzi@kaval.bg;; ciki@duduk.net, " +
            "bob@mail.bg\n\nfn12345@fmi.uni-sofia.bg\n" +
            "    mente@eu.int | , , ;;; gero@dir.bg";
            string splitPattern = @"[;|,|\s|\|]+";
            string[] emails = Regex.Split(text, splitPattern);
            Console.WriteLine(String.Join(", ", emails));
            // Резултат: zuzi@kaval.bg, ciki@duduk.net, bob@mail.bg,
            // fn12345@fmi.uni-sofia.bg, mente@eu.int, gero@dir.bg

        }
    }
}
