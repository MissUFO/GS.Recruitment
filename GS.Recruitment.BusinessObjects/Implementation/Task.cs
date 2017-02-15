﻿using GS.Recruitment.Framework.SQLDataAccess.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GS.Recruitment.BusinessObjects.Implementation
{
    /// <summary>
    /// Recruiters tasks
    /// </summary>
    [DataContract]
    public class Task : Entity
    {
        public string Title {get;set;}

        public string UserFromLogin { get; set; }

        public string UserToLogin { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        protected override void CreateObjectFromXml(XElement xml)
        {
            this.Id = xml.Attribute("Id").ToType<Guid>();
        }
    }
}
