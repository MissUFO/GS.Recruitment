using GS.Recruitment.Framework.SQLDataAccess.Extensions;
using System;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace GS.Recruitment.BusinessObjects.Implementation
{
    /// <summary>
    /// Attached files like CV or cover letter
    /// </summary>
    [DataContract]
    public class Attachment : Entity
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string FileName { get; set; }
        [DataMember]
        public string FileContent { get; set; }
        [DataMember]
        public int AttachmentType { get; set; }
        [DataMember]
        public DateTime CreatedOn { get; set; }
        [DataMember]
        public DateTime ModifiedOn { get; set; }

        protected override void CreateObjectFromXml(XElement xml)
        {
            this.Id = xml.Attribute("Id").ToType<Guid>();
            this.FileName = xml.Attribute("FileName").ToType<string>();
            this.FileContent = xml.Attribute("FileContent").ToType<string>();
            this.AttachmentType = xml.Attribute("AttachmentType").ToType<int>();
            this.CreatedOn = xml.Attribute("CreatedOn").ToType<DateTime>();
            this.ModifiedOn = xml.Attribute("ModifiedOn").ToType<DateTime>();
        }
    }
}
