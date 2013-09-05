using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace JSON_XML_Parser
{
    public class Parser
    {
        #region XML To JSON
        /// <summary>
        /// This method converts a XML Document to a string object in JSON format.
        /// </summary>
        /// <param name="xmlDocument">The document to be converted</param>
        /// <returns>String variable, containing JSON format information</returns>
        /// <remarks>A StringBuilder is used to build the JSON string</remarks>
        public static string XMLToJSON(XmlDocument xmlDocument)
        {
            // Creating a StringBuilder where the JSON data will be initially filled
            StringBuilder jsonBuilder = new StringBuilder();
            
            XmlElement rootNode = xmlDocument.DocumentElement;
            
            // Start appending the nodes - the first one is the root node
            AppendNode(jsonBuilder, rootNode);

            var result = jsonBuilder.ToString();
            
            return result;
        }

        /// <summary>
        /// Parsing and appending a given XMLNode to the JSON string variable
        /// </summary>
        /// <param name="jsonBuilder">JSON StringBuilder variable where
        /// the <see cref="node"/> will be appended</param>
        /// <param name="node">XMLNode to be appended</param>
        private static void AppendNode(StringBuilder jsonBuilder, XmlNode node)
        {
            jsonBuilder.Append("{ ");

            // Appending the attributes first
            AppendNodeAttributes(jsonBuilder, node);

            // Appending the child nodes (if any)
            AppendChildNodes(jsonBuilder, node);

            jsonBuilder.Append("}");

            // If the node has a sibling node a comma is added
            if (node.NextSibling != null)
            {
                jsonBuilder.Append(", ");
            }
            else
            {
                jsonBuilder.Append(" ");
            }
        }

        /// <summary>
        /// Appending the child nodes of a given XMLNode (if any)
        /// to the JSON StringBuilder variable
        /// </summary>
        /// <param name="jsonBuilder">JSON StringBuilder variable where
        /// the <see cref="node"/> child nodes will be appended</param>
        /// <param name="node">The XMLNode, whose child nodes will
        /// be appended to the JSON StringBuilder variable</param>
        private static void AppendChildNodes(StringBuilder jsonBuilder, XmlNode node)
        {
            foreach (XmlNode childNode in node.ChildNodes)
            {
                jsonBuilder.AppendFormat("\"{0}\":", childNode.Name);

                // If the childNode has no childer of it's own 
                // (the inner text is also considered a child)
                // that means it's value is null
                if (!childNode.HasChildNodes)
                {
                    jsonBuilder.Append("null, ");
                }
                else if (childNode.FirstChild.Name == "#text")
                {
                    jsonBuilder.AppendFormat("\"{0}\",", childNode.InnerText.Trim());
                }
                else
                {
                    // All steps made so far are repeated for each child node
                    AppendNode(jsonBuilder, childNode);
                }
            }
        }
        
        /// <summary>
        /// Parsing and appending attributes of a given XMLNode to a JSON StringBuilder variable
        /// </summary>
        /// <param name="jsonBuilder">JSON StringBuilder variable where
        /// the <see cref="node"/> attributes will be appended</param>
        /// <param name="node">THE XMLNode, whose attributes will be appended
        /// to the JSON StringBuilder variable</param>
        private static void AppendNodeAttributes(StringBuilder jsonBuilder, XmlNode node)
        {
            foreach (XmlAttribute attribute in node.Attributes)
            {
                jsonBuilder.AppendFormat("\"@{0}\":\"{1}\", ", attribute.Name, attribute.Value);
            }

            // If attribute nodes were appended that means there is an unnecessary comma
            // after the last appended attribute and it must be removed
            if (node.Attributes.Count > 0)
            {
                jsonBuilder.Replace(", ", " ", jsonBuilder.Length - 2, 2);
            }
        }
        #endregion

        #region JSON To XML

        /// <summary>
        /// This Method uses Newtonsoft.Json library for parsing JSONstring to XMLDocument
        /// </summary>
        /// <param name="jsonString">The JSONstring that to be parsed</param>
        /// <param name="xmlFilePath">The path where the XML file should be created</param>
        /// <param name="rootElementName">Root element name for the XML Document</param>
        public static void JSONToXML(string jsonString, string xmlFilePath, string rootElementName)
        {
            XmlDocument result = JsonConvert.DeserializeXmlNode(jsonString, rootElementName);

            XmlWriter writer = XmlWriter.Create(xmlFilePath);
            result.WriteContentTo(writer);
            writer.Close();
        }

        #endregion
    }
}
