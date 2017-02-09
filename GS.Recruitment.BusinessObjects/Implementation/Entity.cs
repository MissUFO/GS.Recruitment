using GS.Recruitment.Framework.SQLDataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GS.Recruitment.BusinessObjects.Implementation
{
    [DataContract]
    public class Entity : IEntity
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }

        public void UnpackXML(XElement xml, string childNodeName = null)
        {
            XElement workingXML = null;

            if (string.IsNullOrWhiteSpace(childNodeName))
            {
                workingXML = xml;
            }
            else
            {
                if (xml != null)
                {
                    workingXML = xml.Element(childNodeName);
                }
            }
            if (workingXML == null)
            {
                return;
            }
            CreateObjectFromXml(workingXML);
        }

        protected virtual void CreateObjectFromXml(XElement xml)
        {

        }
    }
}
