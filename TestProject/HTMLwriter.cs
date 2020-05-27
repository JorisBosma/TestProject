using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace TestProject
{
    public class HTMLwriter
    {
        public string ConvertXmlToHtmlTable(string xml)
        {
            
            string htmlString = "<table align='center' border='1' class='xmlTable'>\r\n";
            try
            {
                XDocument xDocument = XDocument.Parse(xml);
                XElement root = xDocument.Root;

                var xmlAttributeCollection = root.Elements().Attributes();

                
                foreach (var ele in root.Elements())
                {
                    if (!ele.HasElements)
                    {
                        string elename = "";
                        htmlString += "<tr>";

                        //elename = ele.Name.ToString();

                        if (ele.HasAttributes)
                        {
                            IEnumerable<XAttribute> attribs = ele.Attributes();
                            foreach (XAttribute attrib in attribs)
                                elename +=  "\r\n" /*+ attrib.Name.ToString() +" = "*/ + attrib.Value.ToString() ;
                        }
                        htmlString += "<td>" + elename + "</td>";
                        htmlString += "<td>" + ele.Value + "</td>";
                        htmlString += "</tr>";
                    }
                    else
                    {
                        string elename = "";
                        htmlString += "<tr>";
                        //elename = ele.Name.ToString();
                        if (ele.HasAttributes)
                        {
                            IEnumerable<XAttribute> attribs = ele.Attributes();
                            foreach (XAttribute attrib in attribs)
                                 elename += "\r\n" /*+ attrib.Name.ToString() +" = "*/ + attrib.Value.ToString();
                        }
                        htmlString += "<td>" + elename + "</td>";
                        htmlString += "<td>" + ConvertXmlToHtmlTable(ele.ToString()) + "</td>";
                        htmlString += "</tr>";
                    }
                }
                htmlString += "</table>";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return xml;
                // Returning the original string incase of error.
            }
            System.IO.File.WriteAllText("HtmlTest.html", htmlString);
            return htmlString;
        }
    }
}