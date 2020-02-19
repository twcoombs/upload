using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Diagnostics;

namespace upload.Classes
{
    class XMLRead
    {

        public List<string> readXML (string filePath)
        {
            XDocument xdoc = new XDocument();
            xdoc = XDocument.Load(filePath);//load xml file url

            //Response.Write(element.Attributes("attribute-id").First().Value);

            List<string> meta = new List<string>();

            foreach (XElement element in xdoc.Root.Nodes())
            {
                if (element.HasAttributes)
                {

                    IEnumerable<XAttribute> attributes = element.Attributes();
                    foreach (XAttribute attribute in attributes)
                    {
                        if (!meta.Contains("ID: " + element.Name + "-" + attribute.Name))
                            meta.Add("ID: " + element.Name + "-" + attribute.Name);
                    }
                }
            }

            XmlDocument xml = new XmlDocument();

            xml.Load(filePath);

            XmlNode childNodes = xml.DocumentElement.ChildNodes.Cast<XmlNode>().ToList()[0];

            foreach (XmlNode node in childNodes)
            {
                meta.Add("NODE: " + node.Name);
                //Debug.WriteLine("NODE: " + node.Name);
            }

            return meta;
        }

    }

}