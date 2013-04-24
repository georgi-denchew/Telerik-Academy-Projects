namespace Telerik.ILS.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// A class, containing extension methods for the string-type variables.
    /// </summary>
    /// 
    /// <remarks>!!!!IMPORTANT!!!! - I know that some of the comments might seem unnecessary,
    /// but the given task is to comment all PUBLIC members. I felt no need to comment the expressions
    /// inside the different methods - they seem quite understandable.</remarks>
    public static class StringExtensions
    {
        /// <summary>
        /// Method for getting hash code from a string variable.
        /// </summary>
        /// <param name="input">The input file, which has to be converted</param>
        /// <returns>String containing hash code</returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new StringBuilder to collect the bytes
            // and create a string.
            var builder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return builder.ToString();
        }

        /// <summary>
        /// Method for converting string variable in boolean.
        /// </summary>
        /// <param name="input">A string variable, holding a single positive 
        /// (or negative) statement</param>
        /// <returns>The converted boolean variable, 
        /// which indicates if the string contains a positive statement</returns>
        public static bool ToBoolean(this string input)
        {
            // Create a boolean array all values, that mean true in one way or another.
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };

            // Returns a boolean variable which indicates if a "true" value is found in the input file.
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// Method for parsing a string variable into short-type variable.
        /// </summary>
        /// <param name="input">String, containing a value, which can be parsed into short.</param>
        /// <returns>The short-parsed value.</returns>
        public static short ToShort(this string input)
        {
            //Initializing a short-type variable.
            short shortValue;

            //Parsing the string in the short-type variable.
            short.TryParse(input, out shortValue);

            //Returning the short-type result.
            return shortValue;
        }
        
        /// <summary>
        /// Method for parsing a string variable into integer-type variable.
        /// </summary>
        /// <seealso cref="StringExtensions.ToShort"/>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// Method for parsing a string variable into long-type variable.
        /// </summary>
        /// <seealso cref="StringExtensions.ToShort"/>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// Method for parsing a string variable into DateTime-type variable.
        /// </summary>
        /// <seealso cref="StringExtensions.ToShort"/>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// Method, which capitalizes the first letter of given string.
        /// </summary>
        /// <returns>String with capitalized first letter,
        /// <value>""</value> or <value>null</value> if the initial one is empty/null</returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// Method for extracting a part of given string, enclosed by two other strings
        /// </summary>
        /// <param name="input">The initial string</param>
        /// <param name="startString">The left "border" of the returned value</param>
        /// <param name="endString">The right "border" of the returned value</param>
        /// <param name="startFrom">Index, from which the search for the 
        /// <value>startString</value> and <value>endString</value> starts</param>
        /// <returns>A string value, not-containing the <value>startString</value> 
        /// and <value>endString</value>, or <value>null</value> if the</returns>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Method for converting string, containing Cyrillic alphabet symbols, into their Latin respectives sounds
        /// </summary>
        /// <param name="input">The initial string, which should be converted</param>
        /// <returns>String, containing the message of the <value>input</value> string, 
        /// written with Latin letters</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
                                       {
                                           "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                                           "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                                       };
            var latinRepresentationsOfBulgarianLetters = new[]
                                                             {
                                                                 "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                                                                 "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                                                                 "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                                                             };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// Method for converting string, containing Latin letters, into string with their Cyrillic representatives.
        /// </summary>
        /// <param name="input">The input string, which symbols should be replaced</param>
        /// <remarks>The opposite to <seealso cref=" StringExtensions.ConvertCyrillicToLatinLetters"/></remarks>
        /// <returns>String, containing the message of the <value>input</value> string,
        /// written with Cyrillic letters</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
                                   {
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                                       "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                   };

            var bulgarianRepresentationOfLatinKeyboard = new[]
                                                             {
                                                                 "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                                                                 "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                                                                 "в", "ь", "ъ", "з"
                                                             };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }


        /// <summary>
        /// Method, used to extract a valid username from given string.
        /// </summary>
        /// <param name="input">The initial string, from which username is extracted</param>
        /// <returns>String value with valid username characters</returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// Method, used to extract a valide latin filename from given string.
        /// </summary>
        /// <param name="input">The initial string, from which valid latin filename is extracted</param>
        /// <returns>String value with valid latin filename characters</returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Method, used to extract the first <value>charsCount</value> symbols from given string variable.
        /// </summary>
        /// <param name="input">The initial string variable, used for character extraction.</param>
        /// <param name="charsCount">The number of characters to be returned as string value</param>
        /// <returns>String value containing the first <value>charsCount</value> numbers of the 
        /// <value>input</value> string</returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// Method, used for returning the extension of a file, given as a string
        /// </summary>
        /// <param name="fileName">The initial string variable, containing the filename
        /// and it's extension</param>
        /// <returns>String value, containing the file extension</returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// Gets the type of given extension
        /// <example> .jpg - image/jpeg</example>
        /// </summary>
        /// <param name="fileExtension">Initial string value, containing extension format</param>
        /// <returns>String value, containing the given file's content type</returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
                                                 {
                                                     { "jpg", "image/jpeg" },
                                                     { "jpeg", "image/jpeg" },
                                                     { "png", "image/x-png" },
                                                     {
                                                         "docx",
                                                         "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                                     },
                                                     { "doc", "application/msword" },
                                                     { "pdf", "application/pdf" },
                                                     { "txt", "text/plain" },
                                                     { "rtf", "application/rtf" }
                                                 };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// Get's ASCII code of each symbol in the string
        /// </summary>
        /// <param name="input">Initial string value</param>
        /// <returns>Byte array of ASCII symbol numbers of the <value>input</value> string characters,
        /// separated by <value>0</value> </returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}
