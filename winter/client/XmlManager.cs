using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
namespace client
{
	public class XmlManager<T>
	{
        public object Obj { get; private set; }
        public Type Type{ get; set; }
		public T LoaderOptimization(string path)
		{
			T instance;
			using (TextReader reader = new StreamReader(path))
			{
				XmlSerializer xml = new XmlSerializer (Type);
				instance = (T)xml.Deserialize (reader);
			}
			return instance;
		}
		public void Save(string path)
		{
			using (TextWriter writer = new StreamWriter(path)) 
			{
				XmlSerializer xml = new XmlSerializer (Type);
				xml.Serialize (writer, Obj);
			}
		}
	}
}

