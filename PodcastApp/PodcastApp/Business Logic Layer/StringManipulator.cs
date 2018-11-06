using System;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public class StringManipulator
    {
        // Removes special characters from a string
        public string RemoveSpecialChars(string input)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in input)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        public static string EscapeXMLValue(string xmlString)
        {

            if (xmlString == null)
                throw new ArgumentNullException("xmlString");

            return xmlString.Replace("&", "&amp;");
        }

        public static string UnescapeXMLValue(string xmlString)
        {
            if (xmlString == null)
                throw new ArgumentNullException("xmlString");

            return xmlString.Replace("&amp;", "&");
        }

        public static string RemoveXmlTags(string input)
        {

            string xmlEscape = EscapeXMLValue(input);
            string textWithoutTags = "";

            var startAsXml = "<root>" + xmlEscape + "</root>";
            var doc = XElement.Parse(startAsXml);

            foreach (var node in doc.Nodes())
            {
                if (node.NodeType == XmlNodeType.Text)
                {
                    textWithoutTags += node.ToString().Trim();
                }
            }
            return UnescapeXMLValue(textWithoutTags);
        }
    }
}
