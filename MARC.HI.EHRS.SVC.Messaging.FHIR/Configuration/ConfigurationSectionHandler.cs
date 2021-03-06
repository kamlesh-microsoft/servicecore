using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Xml;

namespace MARC.HI.EHRS.SVC.Messaging.FHIR.Configuration
{
    /// <summary>
    /// Configuration section handler for FHIR
    /// </summary>
    public class ConfigurationSectionHandler : IConfigurationSectionHandler
    {
        #region IConfigurationSectionHandler Members

        /// <summary>
        /// Create the configuration object
        /// </summary>
        public object Create(object parent, object configContext, System.Xml.XmlNode section)
        {
            
            // Section
            XmlElement serviceElement = section.SelectSingleNode("./*[local-name() = 'service']") as XmlElement;
            XmlNodeList resourceElements = section.SelectNodes("./*[local-name()= 'resourceProcessors']/*[local-name() = 'add']"),
                actionMap = section.SelectNodes("./*[local-name() = 'actionMap']/*[local-name() = 'add']");

            string wcfServiceName = String.Empty,
                landingPage = String.Empty;

            if (serviceElement != null)
            {
                XmlAttribute serviceName = serviceElement.Attributes["wcfServiceName"],
                    landingPageNode = serviceElement.Attributes["landingPage"];
                if (serviceName != null)
                    wcfServiceName = serviceName.Value;
                else
                    throw new ConfigurationErrorsException("Missing wcfServiceName attribute", serviceElement);
                if (landingPageNode != null)
                    landingPage = landingPageNode.Value;
            }
            else
                throw new ConfigurationErrorsException("Missing serviceElement", section);

            var retVal = new FhirServiceConfiguration(wcfServiceName, landingPage);

            // Add instructions
            foreach (XmlElement addInstruction in resourceElements)
            {
                if (addInstruction.Attributes["type"] == null)
                    throw new ConfigurationErrorsException("add instruction missing @type attribute");
                Type tType = Type.GetType(addInstruction.Attributes["type"].Value);
                if (tType == null)
                    throw new ConfigurationErrorsException(String.Format("Could not find type described by '{0}'", addInstruction.Attributes["type"].Value));
                retVal.ResourceHandlers.Add(tType);
            }

            foreach (XmlElement mapInstruction in actionMap)
            {
                String resourceName = String.Empty,
                    resourceAction = String.Empty,
                    eventTypeCode = String.Empty,
                    eventTypeCodeSystem = String.Empty,
                    eventTypeCodeName = String.Empty;

                if (mapInstruction.Attributes["resource"] != null)
                    resourceName = mapInstruction.Attributes["resource"].Value;
                if (mapInstruction.Attributes["action"] != null)
                    resourceAction = mapInstruction.Attributes["action"].Value;
                if (mapInstruction.Attributes["code"] != null)
                    eventTypeCode = mapInstruction.Attributes["code"].Value;
                if (mapInstruction.Attributes["codeSystem"] != null)
                    eventTypeCodeSystem = mapInstruction.Attributes["codeSystem"].Value;
                if (mapInstruction.Attributes["displayName"] != null)
                    eventTypeCodeName = mapInstruction.Attributes["displayName"].Value;

                retVal.ActionMap.Add(String.Format("{0} {1}", resourceAction, resourceName), new Core.DataTypes.CodeValue(
                    eventTypeCode, eventTypeCodeSystem) { DisplayName = eventTypeCodeName });
            }
            return retVal;
        }

        #endregion
    }
}
