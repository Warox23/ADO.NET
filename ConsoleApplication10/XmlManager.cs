using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;


namespace ConsoleApplication10
{
    class XmlManager
    {
        public void Serializable(object obj,string path)
        {
            XmlSerializer xs = new XmlSerializer(obj.GetType());
            
            using (FileStream fs = new FileStream(path,FileMode.Create,FileAccess.Write))
            {
                xs.Serialize(fs, obj);
            }
        }

      

        public object Deserializable(Type t ,string path)
        {
            XmlSerializer xs = new XmlSerializer(t);
            object items;

            using (StreamReader sr = new StreamReader(path))
            {
                items = (Items)xs.Deserialize(sr);
            }
            return items;
        }

        public Items DeserializableToListItems(Type t ,string path)
        {
            return (Items) Deserializable( t , path);

        }

    }
}
