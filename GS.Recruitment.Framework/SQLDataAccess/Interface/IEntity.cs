using System.Xml.Linq;

namespace GS.Recruitment.Framework.SQLDataAccess.Interface
{
    public interface IEntity
    {
        int ID { get; set; }
        string Name { get; set; }

        void UnpackXML(XElement xml, string childNodeName = null);
    }
}
