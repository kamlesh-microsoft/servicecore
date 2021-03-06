using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MARC.HI.EHRS.SVC.Messaging.FHIR.DataTypes;
using System.Xml.Serialization;
using System.ComponentModel;
using MARC.HI.EHRS.SVC.Messaging.FHIR.Attributes;

namespace MARC.HI.EHRS.SVC.Messaging.FHIR.Resources
{
    /// <summary>
    /// Resource definition
    /// </summary>
    [XmlType("Resource", Namespace = "http://hl7.org/fhir")]
    public class ResourceDefinition : Shareable
    {

        /// <summary>
        /// Creates a new resource definition
        /// </summary>
        public ResourceDefinition()
        {
            this.Operation = new List<OperationDefinition>();
            this.SearchParams = new List<SearchParam>();
        }

        /// <summary>
        /// Gets or sets the type of resource
        /// </summary>
        [XmlElement("type")]
        [Description("Resource type")]
        [ElementProfile(MinOccurs = 1)]
        public PrimitiveCode<String> Type { get; set; }

        /// <summary>
        /// The profile reference
        /// </summary>
        [XmlElement("profile")]
        [Description("Resource profiles supported")]
        public Resource<Profile> Profile { get; set; }

        /// <summary>
        /// Gets or sets the operations supported
        /// </summary>
        [XmlElement("operation")]
        [Description("Operations supported")]
        public List<OperationDefinition> Operation { get; set; }

        /// <summary>
        /// True if history is supported
        /// </summary>
        [XmlElement("readHistory")]
        [Description("Whether vRead can return past versions")]
        public FhirBoolean ReadHistory { get; set; }

        /// <summary>
        /// Search parameters defined
        /// </summary>
        [XmlElement("searchParam")]
        [Description("Search parameters defined")]
        public List<SearchParam> SearchParams { get; set; }

        /// <summary>
        /// Write test
        /// </summary>
        internal override void WriteText(System.Xml.XmlWriter w)
        {
            this.Type.WriteText(w);
            // Now profiles?
            if (this.Profile != null)
            {
                w.WriteStartElement("blockquote");
                w.WriteElementString("strong", "Profiles:");
                w.WriteStartElement("br");
                w.WriteEndElement();
                this.Profile.WriteText(w);
                w.WriteStartElement("br");
                w.WriteEndElement();
                w.WriteEndElement(); // blockquote
                w.WriteStartElement("blockquote");
                w.WriteElementString("strong", "Search Parameters:");
                w.WriteStartElement("br");
                w.WriteEndElement();
                foreach (var itm in this.SearchParams)
                {
                    w.WriteStartElement("a");
                    w.WriteAttributeString("href", itm.Definition.Value.ToString());
                    itm.Name.WriteText(w);
                    w.WriteEndElement(); // a
                    w.WriteStartElement("br");
                    w.WriteEndElement();
                }
                w.WriteEndElement(); // blockquote
            }
        }
    }
}
