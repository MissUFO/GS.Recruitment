using System;
using System.Xml.Linq;

namespace GS.Recruitment.Framework.SQLDataAccess.Interface
{
    public interface IEntity
    {
        Guid Id { get; set; }
        string Name { get; set; }

        bool IsSelected { get; set; }

        void UnpackXML(XElement xml, string childNodeName = null);
    }
}
