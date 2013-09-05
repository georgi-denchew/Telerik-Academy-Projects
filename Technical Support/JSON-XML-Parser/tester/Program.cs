using JSON_XML_Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace tester
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../Catalogue.xml");
            var jsonString = Parser.XMLToJSON(doc);

            Parser.JSONToXML(jsonString, "../../result.xml", "rootElement");
        }
    }
}
