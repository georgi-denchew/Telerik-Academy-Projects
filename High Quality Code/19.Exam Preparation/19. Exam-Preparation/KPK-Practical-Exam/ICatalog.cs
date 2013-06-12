using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace CatalogOfFreeContent
{
    public interface ICatalog
    {
        /// <summary>
        /// Add content item to the catalog.
        /// </summary>
        void Add(IContentItem contentItem);


        /// <summary>
        /// Finds all content items in the catalog that match
        /// the scpecified title. The order of the returned elements is
        /// alphabetical regarding their ToString representation.
        /// </summary>
        /// <param name="title">Title of the element we search for.</param>
        /// <param name="numberOfContentElementsToList">Maximal number of returned elements</param>
        /// <remarks>This method can return less than all matching
        /// elements in the catalog. For example: if we have 30 matching
        /// elements but only 10 requested, the method will return 10.
        /// And vice versa: if we request 10 elements, but only 3 are matching,
        /// those 3 will be returned</remarks>
        /// <returns>Return no more than<value>numberOfContentElementsToList</value>
        /// elements. </returns>
        IEnumerable<IContentItem> GetListContent(string title, 
            int numberOfContentElementsToList);

        int UpdateContent(string oldUrl, string newUrl);
    }
}
