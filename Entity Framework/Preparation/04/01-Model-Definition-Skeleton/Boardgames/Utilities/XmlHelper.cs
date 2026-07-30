using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Medicines.Utilities
{
    public static class XmlHelper
    {
        public static string SerializeToXml<T>(T dto, string xmlRootAttribute)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootAttribute));

            StringBuilder sb = new StringBuilder();

            using (StringWriter sw = new StringWriter(sb, CultureInfo.InvariantCulture))
            {
                XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
                xsn.Add(string.Empty, string.Empty);

                try
                {
                    xmlSerializer.Serialize(sw, dto, xsn);
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static T DeserializeFromXml<T>(string xml,string xmlRootAttribute)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootAttribute));

            using (StringReader sr = new StringReader(xml))
            {
                try
                {
                    return (T)xmlSerializer.Deserialize(sr);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
