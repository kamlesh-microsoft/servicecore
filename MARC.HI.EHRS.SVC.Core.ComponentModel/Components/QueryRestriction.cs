/**
 * Copyright 2012-2013 Mohawk College of Applied Arts and Technology
 * 
 * Licensed under the Apache License, Version 2.0 (the "License"); you 
 * may not use this file except in compliance with the License. You may 
 * obtain a copy of the License at 
 * 
 * http://www.apache.org/licenses/LICENSE-2.0 
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the 
 * License for the specific language governing permissions and limitations under 
 * the License.
 * 
 * User: fyfej
 * Date: 7-5-2012
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MARC.HI.EHRS.SVC.Core.DataTypes;
using System.Xml.Serialization;

namespace MARC.HI.EHRS.SVC.Core.ComponentModel.Components
{
    /// <summary>
    /// Query restriction component is used to filter additional 
    /// data from a query match object
    /// </summary>
    [Serializable]
    [XmlType("QueryRestriction", Namespace = "urn:marc-hi:svc:componentModel")]
    public class QueryRestriction : HealthServiceRecordComponent
    {

        /// <summary>
        /// Signals that the SHR should filter on records that have
        /// been ammended or created since the date specified
        /// </summary>
        [XmlElement("amendDate")]
        public TimestampPart AmmendedDate { get; set; }

        /// <summary>
        /// Signals that the SHR should filter to only the most
        /// recent record of each type
        /// </summary>
        [XmlAttribute("mostRecentByType")]
        public bool MostRecentByType { get; set; }

    }
}
