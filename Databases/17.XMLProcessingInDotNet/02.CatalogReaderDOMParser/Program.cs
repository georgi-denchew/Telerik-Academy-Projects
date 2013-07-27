using CatalogueLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _02.CatalogReaderDOMParser
{
    class Program
    {
        private static HashSet<Artist> artists = new HashSet<Artist>();

        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../Catalogue.xml");

            XmlNode catalogue = doc.DocumentElement;


            foreach (XmlNode album in catalogue)
            {
                string albumName = album["name"].Name;
                

            }
        }
    }
}
