using BookmarkSite.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml;

namespace _03.BookmarksImporter
{
    class BookmarksImporter
    {
        static void Main(string[] args)
        {
            using (TransactionScope scope = 
                new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = IsolationLevel.RepeatableRead }))
            {
                BookmarkSiteEntities context = new BookmarkSiteEntities();

                XmlDocument bookmarkDocument = new XmlDocument();
                bookmarkDocument.Load("../../bookmarks.xml");
                string bookmarkPath = "bookmarks/bookmark";

                XmlNodeList bookmarkNodes = bookmarkDocument.SelectNodes(bookmarkPath);

                foreach (XmlNode bookmark in bookmarkNodes)
                {
                    string username = GetInnerText(bookmark, "username");
                    string title = GetInnerText(bookmark, "title");
                    string URL = GetInnerText(bookmark, "url");

                    string notes = GetInnerText(bookmark, "notes");
                    string tagsString = GetInnerText(bookmark, "tags");

                    InsertIntoContext(context, username, title, URL, notes, tagsString);
                }
                scope.Complete();
            }
        }
        private static void InsertIntoContext(BookmarkSiteEntities context, string username, string title, string URL, string notes, string tagsString)
        {
            if (username == null || title == null || URL == null ||
                username == string.Empty || title == string.Empty || URL == string.Empty)
            {
                throw new ArgumentException("Username, title and URL are obligatory and cannot be null or empty.");
            }

            User user = CreateOrLoadUser(context, username);

            HashSet<Tag> tags = new HashSet<Tag>();

            CreateOrLoadTags(context, title, ref tags);
            CreateOrLoadTags(context, tagsString, ref tags);

            AddBookmark(context, user, title, URL, tags, notes);
        }

        private static void AddBookmark(BookmarkSiteEntities context, User user, string title, string URL, HashSet<Tag> tags, string notes)
        {
            Bookmark newBookmark = new Bookmark();
            newBookmark.UserID = user.UserID;
            newBookmark.URL = URL;
            newBookmark.Title = title;
            newBookmark.Notes = notes;

            foreach (Tag tag in tags)
            {
                newBookmark.Tags.Add(tag);
            }

            context.Bookmarks.Add(newBookmark);
            context.SaveChanges();
        }


        private static void CreateOrLoadTags(BookmarkSiteEntities context, string allTagsString, ref HashSet<Tag> resultTags)
        {
            if (allTagsString == null)
            {
                return;
            }

            string[] allTags = allTagsString.Split(new char[] { ',', ' ', '!', '.', '?', '\'', }, StringSplitOptions.RemoveEmptyEntries);


            foreach (var tagName in allTags)
            {
                if (tagName.Length < 2 ||
                    resultTags.Any(x => x.TagName.ToLower() == tagName.ToLower()))
                {
                    continue;
                }

                Tag existingTag = context.Tags.FirstOrDefault(x => x.TagName == tagName);

                if (existingTag != null)
                {
                    resultTags.Add(existingTag);
                }
                else
                {
                    Tag newTag = new Tag();
                    newTag.TagName = tagName;
                    context.Tags.Add(newTag);
                    context.SaveChanges();
                    resultTags.Add(newTag);
                }
            }

        }

        private static User CreateOrLoadUser(BookmarkSiteEntities context, string username)
        {
            var existingUser = context.Users.FirstOrDefault(x => x.Username == username);

            if (existingUser != null)
            {
                return existingUser;
            }
            else
            {
                User newUser = new User();
                newUser.Username = username;
                context.Users.Add(newUser);
                context.SaveChanges();
                return newUser;
            }
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
