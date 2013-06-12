using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

namespace CatalogOfFreeContent
{
    public class Program
    {
        public static void Main()
        {
            StringBuilder output = new StringBuilder();
            Catalog catalog = new Catalog();
            ICommandExecutor cmdExecutor = new CommandExecutor();

            var commands = ReadInputComments();

            foreach (ICommand cmd in commands)
            {
                cmdExecutor.ExecuteCommand(catalog, cmd, output);
            }

            Console.Write(output);
        }

        private static List<ICommand> ReadInputComments()
        {
            List<ICommand> commands = new List<ICommand>();

            while(true)
            {
                string line = Console.ReadLine();
                if (line.Trim() == "End")
                {
                    break;
                }
                commands.Add(new Command(line));
            }

            return commands;
        }
    }

    public class CommandExecutor : ICommandExecutor
    {
        public void ExecuteCommand(ICatalog contentCatalog,
            ICommand cmd, StringBuilder output)
        {
            switch (cmd.Type)
            {
                case CommandType.AddBook:
                    contentCatalog.Add(new ContentItem(ContentType.Book, cmd.Parameters));
                    output.AppendLine("Book added");
                    break;
                case CommandType.AddMovie:
                    contentCatalog.Add(new ContentItem(ContentType.Movie, cmd.Parameters));
                    output.AppendLine("Movie added");
                    break;
                case CommandType.AddSong:
                    contentCatalog.Add(new ContentItem(ContentType.Song, cmd.Parameters));
                    output.AppendLine("Song added");
                    break;
                case CommandType.AddApplication:
                    contentCatalog.Add(new ContentItem(ContentType.Application, cmd.Parameters));
                    output.AppendLine("Application added");
                    break;
                case CommandType.Update:
                    ProcessUpdateCommand(contentCatalog, cmd, output);
                    break;
                case CommandType.Find:
                    ProcesFindCommand(contentCatalog, cmd, output);
                    break;
                default:
                    throw new InvalidOperationException("Unknown command!");
            }
        }

        private static void ProcessUpdateCommand(ICatalog contentCatalog, 
            ICommand cmd, StringBuilder output)
        {
            if (cmd.Parameters.Length != 2)
            {
                throw new ArgumentException("Invalid number of parameters!");
            }

            int itemsUpdated = contentCatalog.UpdateContent(cmd.Parameters[0],
                cmd.Parameters[1]);
            output.AppendLine(String.Format("{0} items updated",
                itemsUpdated));
        }

        private static void ProcesFindCommand(ICatalog contentCatalog,
            ICommand cmd, StringBuilder output)
        {
            if (cmd.Parameters.Length != 2)
            {
                throw new ArgumentException("Invalid number of parameters!");
            }

            int numberOfElementsToList = Int32.Parse(cmd.Parameters[1]);

            IEnumerable<IContentItem> foundContent =
                contentCatalog.GetListContent(cmd.Parameters[0],
                numberOfElementsToList);

            if (foundContent.Count() == 0)
            {
                output.AppendLine("No items found");
            }
            else
            {
                foreach (IContentItem content in foundContent)
                {
                    output.AppendLine(content.TextRepresentation);
                }
            }
        }
    }

    public class Catalog : ICatalog
    {
        private MultiDictionary<string, IContentItem> url;
        private OrderedMultiDictionary<string, IContentItem> title;

        public Catalog()
        {
            bool allowDuplicateValues = true;
            this.title = new OrderedMultiDictionary<string, IContentItem>(allowDuplicateValues);
            this.url = new MultiDictionary<string, IContentItem>(allowDuplicateValues);
        }

        public void Add(IContentItem content)
        {
            this.title.Add(content.Title, content);
            this.url.Add(content.URL, content);
        }

        public IEnumerable<IContentItem> GetListContent(string title,
            int numberOfContentElementsToList)
        {
            IEnumerable<IContentItem> contentToList =
                from c in this.title[title]
                select c;

            return contentToList.Take(numberOfContentElementsToList);
        }

        public int UpdateContent(string oldUrl, string newUrl)
        {
            int theElements = 0;
            List<IContentItem> contentToList = this.url[oldUrl].ToList();


            foreach (ContentItem content in contentToList)
            {
                this.title.Remove(content.Title, content);
                theElements++; //increase updatedElements
            }

            this.url.Remove(oldUrl);

            foreach (IContentItem content in contentToList)
            {
                content.URL = newUrl;
            }

            //again
            foreach (IContentItem content in contentToList)
            {
                this.title.Add(content.Title, content);
                this.url.Add(content.URL, content);
            }

            return theElements;
        }

        public int Count
        {
            get
            {
                return this.title.KeyValuePairs.Count;
            }
        }
    }

    public class ContentItem : IComparable, IContentItem
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public Int64 Size { get; set; }

        private string url;

        public string URL
        {
            get
            {
                return this.url;
            }
            set
            {
                this.url = value;
                this.TextRepresentation = this.ToString(); // To update the text representation
            }
        }

        public ContentType Type { get; set; }

        public string TextRepresentation { get; set; }

        public ContentItem(ContentType type, string[] commandParams)
        {
            this.Type = type;
            this.Title = commandParams[(int)acpi.Title];
            this.Author = commandParams[(int)acpi.Author];
            this.Size = Int64.Parse(commandParams[(int)acpi.Size]);
            this.URL = commandParams[(int)acpi.Url];
        }

        public int CompareTo(object obj)
        {
            if (null == obj)
                return 1;

            ContentItem otherContent = obj as ContentItem;
            if (otherContent != null)
            {
                int comparisonResul = this.TextRepresentation.CompareTo(
                    otherContent.TextRepresentation);

                return comparisonResul;
            }

            throw new ArgumentException("Cannot compare Content with non-Content object");
        }

        public override string ToString()
        {
            string output = String.Format("{0}: {1}; {2}; {3}; {4}",
                this.Type.ToString(), this.Title, this.Author, this.Size, this.URL);

            return output;
        }
    }

    public class Command : ICommand
    {
        readonly char[] paramsSeparators = { ';' };
        readonly char commandEnd = ':';

        public CommandType Type { get; set; }

        public string OriginalForm { get; set; }

        public string Name { get; set; }

        public string[] Parameters { get; set; }

        private int commandNameEndIndex;

        public Command(string input)
        {
            this.OriginalForm = input.Trim();
            this.Parse();
        }

        private void Parse()
        {
            this.commandNameEndIndex = this.GetCommandNameEndIndex();

            this.Name = this.ParseName();
            this.Parameters = this.ParseParameters();
            this.TrimParams();

            this.Type = this.ParseCommandType(this.Name);
        }

        public CommandType ParseCommandType(string commandName)
        {

            if (commandName.Contains(':') || commandName.Contains(';'))
            {
                throw new FormatException("Invalid command. Commands cannot contain : or ;");
            }

            switch (commandName.Trim())
            {
                case "Add book":
                    return CommandType.AddBook;
                case "Add movie":
                    return CommandType.AddMovie;
                case "Add song":
                    return CommandType.AddSong;
                case "Add application":
                    return CommandType.AddApplication;
                case "Update":
                    return CommandType.Update;
                case "Find":
                    return CommandType.Find;
                default:
                    throw new FormatException("Invalid command: " + commandName);
            }
        }

        public string ParseName()
        {
            string name = this.OriginalForm.Substring(0, this.commandNameEndIndex + 1);
            return name;
        }

        public string[] ParseParameters()
        {
            int paramsLength = 
                this.OriginalForm.Length - (this.commandNameEndIndex + 3);

            string paramsOriginalForm = this.OriginalForm.Substring(
                this.commandNameEndIndex + 3, paramsLength);

            string[] parameters = paramsOriginalForm.Split(
                paramsSeparators, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < parameters.Length; i++)
            {
                parameters[i] = parameters[i];
            }

            return parameters;
        }

        public int GetCommandNameEndIndex()
        {
            int endIndex = this.OriginalForm.IndexOf(commandEnd) - 1;
            return endIndex;
        }

        private void TrimParams()
        {
            for (int i = 0; i < this.Parameters.Length ; i++)
            {
                this.Parameters[i] = this.Parameters[i].Trim();
            }
        }

        public override string ToString()
        {
            string toString = "" + this.Name + " ";

            foreach (string param in this.Parameters)
            {
                toString += param + " ";
            } 
            return toString;
        }
    }
}
