using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace Persistance
{
    public static class ObjectDeepCopy
    {
        // Deep copy
        public static T DeepCopy<T>(this T objInstance)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, objInstance);
            stream.Seek(0, SeekOrigin.Begin);
            T copy = (T)formatter.Deserialize(stream);
            stream.Close();
            return copy;
        }
    }
    public class ReadConfigFactory
    {
        //holds type of object that will be dynamicaly created
        private Dictionary<string,string> xmlEntries = new Dictionary<string, string>();
        private Dictionary<string,object> persistanceObjects = new Dictionary<string, object>();

        // read xml file using LINQ
        private Dictionary<string, string> ReadXML(string file)
        {
            return XDocument
                    .Load(file)
                    .Descendants("types")
                    .Descendants("type")
                    .ToDictionary(d => d.Attribute("key").Value, d => d.Attribute("value").Value);
        }

        // cstr
        public ReadConfigFactory(string fileToRead)
        {
            xmlEntries = ReadXML(fileToRead);
        }

        public object GetPersitanceObject(string key)
        {
            object deepCopy = null;
            if (persistanceObjects.TryGetValue(key, out deepCopy))
                return deepCopy.DeepCopy<object>();

            string objectClass = null;
            xmlEntries.TryGetValue(key, out objectClass);
            if (objectClass== null)
                return null;
            string classAlias = objectClass;
            Type type = Type.GetType(classAlias);
            if(type==null)
                return null;
            persistanceObjects[key]=(Object)Activator.CreateInstance(type);
            return persistanceObjects[key];

        }

    }
}
