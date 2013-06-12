using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace _02.TraversingThroughWindowsDirectory
{
    class WindowsTraverse
    {
        static void Main(string[] args)
        {

            string[] windowsFolders = Directory.GetDirectories("C:\\Windows");

            Queue<string> folders = new Queue<string>();

            for (int i = 0; i < windowsFolders.Length; i++)
            {
                folders.Enqueue(windowsFolders[i]);
            }
            
            while (folders.Count > 0)
            {
                string currentFolder = folders.Dequeue();
                
                
                if (Accessible(currentFolder))
                {
                    if (Directory.GetDirectories(currentFolder).Count() > 0)
                    {
                        foreach (var folder in Directory.GetDirectories(currentFolder))
                        {
                            folders.Enqueue(folder);
                        }
                    }

                    foreach (var executable in Directory.GetFiles(currentFolder, "*.exe"))
                    {
                        Console.WriteLine(executable);
                    }
                }
            }
        }

        /// <summary>
        /// This is a very simple and silly check - I couldn't find a
        /// proper and simple way to check if a folder is accessible.
        /// So this check gets the Directories of a folder and 
        /// if an exception is thrown it is caught and the result is false.
        /// </summary>
        private static bool Accessible(string currentFolder)
        {
            try
            {
                var accessControlList = Directory.GetAccessControl(currentFolder);
                Directory.GetDirectories(currentFolder);
                return true;
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
        }
    }
}
