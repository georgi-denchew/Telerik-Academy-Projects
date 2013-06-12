namespace _03.FilesAndFolders
{
    using System;
    using System.Numerics;

    class Aplication
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("This program creates a tree of the windows folder in your PC. " + 
            "Note: if your windows folder's directory is other than C:\\Windows, " +
            "please change the program's Main method. The program may take a while to display the result "+
            "(on my PC it takes about 20-30 seconds).");

            Folder windowsFolder = new Folder("Windows", "C:\\Windows");
            
            BigInteger size = windowsFolder.Size();

            Console.WriteLine("The size of your Windows folder is approximately: {0:0 000 000 000} bytes.", size);
            Console.WriteLine("The size may not be completely accurate due to inaccessible files and folders.");
        }
    }
}
