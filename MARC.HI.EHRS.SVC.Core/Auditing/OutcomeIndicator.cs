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

namespace MARC.HI.EHRS.SVC.Core.DataTypes
{
    /// <summary>
    /// Represents potential outcomes
    /// </summary>
    public enum OutcomeIndicator
    {
        /// <summary>
        /// Successful operation
        /// </summary>
        Success = 0x00,
        /// <summary>
        /// Minor failure, action should be restarted
        /// </summary>
        MinorFail = 0x04,
        /// <summary>
        /// Action was terminated
        /// </summary>
        SeriousFail = 0x08,
        /// <summary>
        /// Major failure, action is made unavailable
        /// </summary>
        EpicFail = 0x0C
    }
}
