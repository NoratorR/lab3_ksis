using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Custom_Logic;
using System.Xml.Serialization;
using System.IO;

namespace Custom_client
{
    class ClientSerializer
    {
        public StringWriter ResponseSerialize(ICommand cmd)
        {
            XmlSerializer xml = new XmlSerializer(typeof(ICommand));
          
            StringWriter stringWriter = new StringWriter();
            xml.Serialize(stringWriter, cmd);
            return stringWriter;
        }

        public Response Deserialize(string str)
        {
            XmlSerializer xml = new XmlSerializer(typeof(Response));
            var read = new StringReader(str);
            return (Response)xml.Deserialize(read);

        }

    
    }
}
