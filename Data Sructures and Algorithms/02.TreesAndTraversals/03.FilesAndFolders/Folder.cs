namespace _03.FilesAndFolders
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Numerics;

    public class Folder : IComparable
    {
        public Folder(string name, string path)
        {
            if (name == string.Empty || name == null)
            {
                throw new ArgumentException("Folder name cannot be null or an empty string");
            }

            if (path == string.Empty || path == null)
            {
                throw new ArgumentException("Folder path cannot be null or an empty string");
            }

            this.Name = name;
            this.Path = path;
            this.Files = new SortedSet<File>();
            this.ChildFolders = new SortedSet<Folder>();

            this.InitializeChildren();
        }

        public string Name { get; private set; }

        public string Path { get; private set; }

        /// <summary>
        /// Gets the files, contained in the current folder.
        /// </summary>
        /// <remarks>
        /// Files are kept in a SortedSet, because the task
        /// does not require getting files by index, but they
        /// should be ordered alphabetically.
        /// </remarks>
        public SortedSet<File> Files { get; private set; }

        /// <summary>
        /// Gets the folders, contained in the current folder.
        /// </summary>
        /// <remarks>
        /// Folders are kept in a SortedSet, because the task
        /// does not require getting folders by index, but they
        /// should be ordered alphabetically.
        /// </remarks>
        public SortedSet<Folder> ChildFolders { get; private set; }

        /// <summary>
        /// Calculates the size of all the files and folders
        /// kept in the given folder.
        /// </summary>
        /// <returns>The sum of all files and folders
        /// inside the given folder</returns>
        public BigInteger Size()
        {
            BigInteger size = 0;
            size = this.CalculateSize(size);
            return size;
        }

        public int CompareTo(object obj)
        {
            return this.Name.CompareTo((obj as Folder).Name);
        }

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

        /// <summary>
        /// This method calculates the size of the current
        /// folder using DFS Traversal.
        /// </summary>
        private BigInteger CalculateSize(BigInteger size)
        {
            foreach (var childFolder in this.ChildFolders)
            {
                int childSize = 0;
                size += childFolder.CalculateSize(childSize);
            }

            foreach (var file in this.Files)
            {
                size += file.Size;
            }

            return size;
        }

        private void InitializeChildren()
        {
            if (!Accessible(this.Path))
            {
                return;
            }

            string[] childFolders = Directory.GetDirectories(this.Path);            
            
            for (int i = 0; i < childFolders.Length; i++)
            {
                FileInfo currentFolder = new FileInfo(childFolders[i]);
                string childFolderName = currentFolder.Name;
                this.ChildFolders.Add(new Folder(childFolderName, childFolders[i]));
            }

            string[] files = Directory.GetFiles(this.Path);

            for (int i = 0; i < files.Length; i++)
            {
                FileInfo currentFile = new FileInfo(files[i]);
                string fileName = currentFile.Name;
                string filePath = currentFile.Directory.ToString();
                this.Files.Add(new File(fileName, filePath));
            }
        }
    }
}
