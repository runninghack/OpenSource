using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace GridDaemon
{
    public static class XMLHelper
    {
        static void CreateXML()
        {
            new XElement("books",
                new XElement("book",
                    new XElement("author", "Fabrice Marguerie"),
                    new XElement("author", "Steve Eichert"),
                    new XElement("author", "Jim Wooley"),
                    new XElement("title", "LINQ in Action"),
                    new XElement("publisher", "Manning")
                    )
            );

        }

        static void ReadXML()
        {
            XElement x = XElement.Load(@"c:\books.xml");
        }
    }
}
