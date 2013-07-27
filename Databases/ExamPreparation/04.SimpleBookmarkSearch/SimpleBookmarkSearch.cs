using BookmarkSite.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _04.SimpleBookmarkSearch
{
    class SimpleBookmarkSearch
    {
        static void Main(string[] args)
        {
            BookmarkSiteEntities context = new BookmarkSiteEntities();

            XmlDocument queryDocument = new XmlDocument();
            queryDocument.Load("../../simple-query.xml");
            string queryPath = "query";
            XmlNodeList queries = queryDocument.SelectNodes(queryPath);

            List<string> urls = new List<string>();

            foreach (XmlNode query in queries)
            {
                string username = GetInnerText(query, "username");
                string tag = GetInnerText(query, "tag");
                GetUrls(context, null, tag, ref urls);
            }

            if (urls.Count > 0)
            {
                foreach (var url in urls)
                {
                    Console.WriteLine(url);
                }
            }
            else
            {
                Console.WriteLine("Nothing found");
            }
        }

        private static void GetUrls(
            BookmarkSiteEntities context, string username, string tag, ref List<string> urls)
        {
            var result =
                from b in context.Bookmarks.Include("User").Include("Tags")
                where b.Tags.Any(t => t.TagName == tag)
                select b;

            if (username != null)
            {
                result =
                    from r in result
                    where r.User.Username == username
                    select r;
            }

            foreach (Bookmark bookmark in result)
            {
                if (!urls.Any(u => u == bookmark.URL))
                {
                    urls.Add(bookmark.URL);
                }
            }
            urls.Sort();
        }

        private static string GetInnerText(XmlNode bookmark, string childNodeName)
        {
            var childNode = bookmark.SelectSingleNode(childNodeName);

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
