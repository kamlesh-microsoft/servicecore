﻿using MARC.HI.EHRS.SVC.Core.Wcf;
using MARC.HI.EHRS.SVC.Messaging.FHIR.Backbone;
using MARC.HI.EHRS.SVC.Messaging.FHIR.Handlers;
using MARC.HI.EHRS.SVC.Messaging.FHIR.Resources;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace MARC.HI.EHRS.SVC.Messaging.FHIR.Util
{
    /// <summary>
    /// Conformance utility
    /// </summary>
    public static class ConformanceUtil
    {
        // Conformance built
        private static Conformance s_conformance = null;
        // Sync lock
        private static Object s_syncLock = new object();

        // FHIR trace source
        private static TraceSource s_traceSource = new TraceSource("MARC.HI.EHRS.Messaging.FHIR");

        /// <summary>
        /// Get Conformance Statement from FHIR service
        /// </summary>
        public static Conformance GetConformanceStatement()
        {
            if (s_conformance == null)
                lock (s_syncLock)
                {
                    BuildConformanceStatement();
                    WebOperationContext.Current.OutgoingResponse.LastModified = DateTime.Now;
                }

            return s_conformance;
        }

        /// <summary>
        /// Build conformance statement
        /// </summary>
        private static void BuildConformanceStatement()
        {
            try
            {
                
                // No output of any exceptions
                Assembly entryAssembly = Assembly.GetEntryAssembly();

                // First assign the basic attributes
                s_conformance = new Conformance()
                {
                    Software = SoftwareDefinition.FromAssemblyInfo(),
                    AcceptUnknown = UnknownContentCode.None,
                    Date = DateTime.Now,
                    Description = "Automatically generated by ServiceCore FHIR framework",
                    Experimental = true,
                    FhirVersion = "3.0.1",
                    Format = new List<DataTypes.FhirCode<string>>() { "xml", "json" },
                    Implementation = new ImplementationDefinition()
                    {
                        Url = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.BaseUri,
                        Description = entryAssembly.GetCustomAttribute<AssemblyDescriptionAttribute>().Description
                    },
                    Name = "SVC-CORE FHIR",
                    Publisher = entryAssembly.GetCustomAttribute<AssemblyCompanyAttribute>().Company,
                    Title = $"Auto-Generated statement - {entryAssembly.GetCustomAttribute<AssemblyProductAttribute>()?.Product} v{entryAssembly.GetName().Version} ({entryAssembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion})",
                    Status = PublicationStatus.Active,
                    Copyright = entryAssembly.GetCustomAttribute<AssemblyCopyrightAttribute>()?.Copyright
                };
                
                // Generate the rest description
                // TODO: Reflect the current WCF context and get all the types of communication supported
                s_conformance.Rest.Add(CreateRestDefinition());
                s_conformance.Text = null;
            }
            catch(Exception e)
            {
                s_traceSource.TraceEvent(TraceEventType.Error, e.HResult, "Error building conformance statement: {0}",  e.Message);
                throw;
            }
        }

        /// <summary>
        /// Rest definition creator
        /// </summary>
        private static RestDefinition CreateRestDefinition()
        {
            // Security settings
            String security = null;
            var authorizationPolicy = OperationContext.Current.Host.Authorization.ExternalAuthorizationPolicies.Select(o => o.GetType().GetCustomAttribute<AuthenticationSchemeDescriptionAttribute>()?.Scheme)?.Where(o => o != null)?.FirstOrDefault();
            if(authorizationPolicy.HasValue)
                switch(authorizationPolicy.Value)
                {
                    case AuthenticationScheme.Basic:
                        security = "Basic";
                        break;
                    case AuthenticationScheme.OAuth:
                    case AuthenticationScheme.OAuth2:
                        security = "OAuth";
                        break;
                    case AuthenticationScheme.Custom:
                        security = "SMART-on-FHIR";
                        break;
                }

            var retVal = new RestDefinition()
            {
                Mode = "server",
                Documentation = "Default WCF REST Handler",
                Security = new SecurityDefinition()
                {
                    Cors = true,
                    Service = security == null ? null : new List<DataTypes.FhirCodeableConcept>() {  new DataTypes.FhirCodeableConcept(new Uri("http://hl7.org/fhir/restful-security-service"), security) }
                },
                Resource = FhirResourceHandlerUtil.GetRestDefinition().ToList()
            };
            return retVal;


        }
    }
}
