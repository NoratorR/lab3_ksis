using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Custom_Logic
{
    class Serializer
    {
        public ICommand Deserialize(string src)
        {
            XmlSerializer xml = new XmlSerializer(typeof(ICommand));
            StringReader read = new StringReader(src);
            return (ICommand)xml.Deserialize(read);

        }

        public string Serialize(Response resp)
        {
            XmlSerializer xml = new XmlSerializer(typeof(Response));
            StringWriter write = new StringWriter();
            try
            {
                xml.Serialize(write, resp);
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return write.ToString();

        }
    }
}
