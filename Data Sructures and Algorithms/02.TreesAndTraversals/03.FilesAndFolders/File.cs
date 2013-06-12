namespace _03.FilesAndFolders
{
    using System;
    using System.IO;

    public class File : IComparable
    {
        public File(string name, string path)
        {
            if (name == string.Empty || name == null)
            {
                throw new ArgumentException("File name cannot be null or an empty string");
            }

            this.Name = name;
            this.Path = path;

            this.Size = this.CalculateSize();
        }

        public string Name { get; private set; }

        public string Path { get; private set; }

        public long Size { get; private set; }

        public int CompareTo(object obj)
        {
            return this.Name.CompareTo((obj as File).Name);
        }

        private long CalculateSize()
        {
            string fullPath = this.Path + "\\" + this.Name;
            FileInfo fileInfo = new FileInfo(fullPath);

            return fileInfo.Length;
        }
    }
}
