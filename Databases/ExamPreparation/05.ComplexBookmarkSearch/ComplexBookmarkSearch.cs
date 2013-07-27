using BookmarkSite.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _05.ComplexBookmarkSearch
{
    class ComplexBookmarkSearch
    {
        private static List<Bookmark> bookmaks = new List<Bookmark>();

        static void Main(string[] args)
        {
            BookmarkSiteEntities context = new BookmarkSiteEntities();

            string fileName = "../../search-results.xml";

            using (XmlTextWriter writer = new XmlTextWriter(fileName, Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("search-results");

                FillBookmarks(writer, context);

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        private static void FillBookmarks(XmlTextWriter writer, BookmarkSiteEntities context)
        {
            XmlDocument queriesDocument = new XmlDocument();
            queriesDocument.Load("../../complex-query.xml");
            string queriesPath = "queries/query";

            XmlNodeList queries = queriesDocument.SelectNodes(queriesPath);

            foreach (XmlNode query in queries)
            {
                XmlNode maxResultsNode = query.Attributes["max-results"];
                string username = GetInnerText(query, "username");
                XmlNodeList tagNodes = query.SelectNodes("tag");

                List<string> allTags = new List<string>();

                foreach (XmlNode tagNode in tagNodes)
                {
                    allTags.Add(tagNode.InnerText.ToLower());
                }

                if (maxResultsNode != null)
                {
                    int maxResults = int.Parse(maxResultsNode.Value);
                    GetBookmarks(writer, context, username, allTags, maxResults);
                }
                else
                {
                    GetBookmarks(writer, context, username, allTags);
                }
            }
        }

        private static void GetBookmarks(XmlTextWriter writer, BookmarkSiteEntities context, string username, List<string> allTags, int maxResults = 10)
        {
            if (allTags.Count == 0)
            {
                return;
            }

            string currentTag = allTags[0];

            var result =
                from b in context.Bookmarks.Include("User").Include("Tags")
                where b.Tags.Any(t => t.TagName.ToLower() == currentTag.ToLower())
                select b;

            for (int i = 1; i < allTags.Count; i++)
            {
                currentTag = allTags[i];

                result =
                    from r in result
                    where r.Tags.Any(t => t.TagName.ToLower() == currentTag.ToLower())
                    select r;
            }

            if (username != null)
            {
                result =
                    from r in result
                    where r.User.Username.ToLower() == username.ToLower();
                    select r;
            }

            result = result.OrderBy(b => b.URL);

            result = result.Take(maxResults);

            WriteResults(writer, result);
        }

        private static void WriteResults(XmlTextWriter writer, IQueryable<Bookmark> result)
        {
            foreach (Bookmark bookmark in result)
            {
                writer.WriteStartElement("result-set");

                writer.WriteStartElement("username");
                writer.WriteString(bookmark.User.Username);
                writer.WriteEndElement();

                writer.WriteStartElement("title");
                writer.WriteString(bookmark.Title);
                writer.WriteEndElement();

                writer.WriteStartElement("URL");
                writer.WriteString(bookmark.URL);
                writer.WriteEndElement();

                writer.WriteStartElement("tags");

                var tagsToAppend = bookmark.Tags.OrderBy(t => t.TagName);

                var tagsString =
                    from t in tagsToAppend
                    select t.TagName.ToLower();

                string joinedTags = string.Join(", ", tagsString);

                writer.WriteString(joinedTags);
                writer.WriteEndElement();

                if (bookmark.Notes != null)
                {
                    writer.WriteStartElement("notes");
                    writer.WriteString(bookmark.Notes);
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
            }
        }

        private static string GetInnerText(XmlNode query, string childNodeName)
        {
            var childNode = query.SelectSingleNode(childNodeName);

            if (childNode != null)
            {
                return childNode.InnerText;
            }
            else
            {
                return null;
            }
        }
    }
}
