namespace CohesionAndCoupling
{
    using System;

    public static class File
    {
        public static string GetFileExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".");

            if (indexOfLastDot == -1)
            {
                return "FILE HAS NO EXTENSION"; // my other option was to throw an exception - i think both are acceptable
            }

            string extension = fileName.Substring(indexOfLastDot + 1);
            return extension;
        }

        public static string GetFileNameWithoutExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".");

            // If the file has no extension that doesn't make the return result
            // wrong - that's why I consider this appropriate behaviour
            if (indexOfLastDot == -1)
            {
                return fileName;
            }

            string extension = fileName.Substring(0, indexOfLastDot);
            return extension;
        }
    }
}
