using System.Xml.Serialization;

namespace DataManager
{
    public class Serialiser
    {
        private string filename;

        public string Filename { get => filename; set => filename = value; }

        public Serialiser(string filename)
        {
            this.filename = filename;
        }

        public void Serialise(Part[] data)
        {
            XmlSerializer serialiser = new XmlSerializer(typeof(Part[]));
            StreamWriter writer = new StreamWriter(filename);
            serialiser.Serialize(writer, data);
            writer.Close();
        }

        public Part[]? Deserialise()
        {
            XmlSerializer serialiser = new XmlSerializer(typeof(Part[]));
            FileStream fileStream = new FileStream(filename, FileMode.Open);
            Part[]? data = (Part[]?)serialiser.Deserialize(fileStream);
            fileStream.Close();
            return data;
        }
    }
}
