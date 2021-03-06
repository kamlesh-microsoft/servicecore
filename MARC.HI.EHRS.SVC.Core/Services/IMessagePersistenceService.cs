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
 * Date: 1-8-2012
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MARC.HI.EHRS.SVC.Core.DataTypes;
using System.IO;

namespace MARC.HI.EHRS.SVC.Core.Services
{

    /// <summary>
    /// Message information
    /// </summary>
    public class MessageInfo
    {
        /// <summary>
        /// Gets the id of the message
        /// </summary>
        public String Id { get; set; }
        /// <summary>
        /// Gets the message id that this message responds to or the response of this message.
        /// </summary>
        public String Response { get; set; }
        /// <summary>
        /// Gets the remote endpoint of the message
        /// </summary>
        public Uri Source { get; set; }
        /// <summary>
        /// Gets the local endpoint of the message
        /// </summary>
        public Uri Destination { get; set; }
        /// <summary>
        /// Gets the time the message was received
        /// </summary>
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Gets the body of the message
        /// </summary>
        public byte[] Body { get; set; }

    }

    /// <summary>
    /// Identifies a structure for message persistence service implementations
    /// </summary>
    public interface IMessagePersistenceService : IUsesHostContext
    {

        /// <summary>
        /// Get the state of a message
        /// </summary>
        MessageState GetMessageState(string messageId);

        /// <summary>
        /// Persists the message 
        /// </summary>
        void PersistMessage(string messageId, Stream message);

        /// <summary>
        /// Persist message extension
        /// </summary>
        void PersistMessageInfo(MessageInfo message);

        /// <summary>
        /// Get the identifier of the message that represents the response to the current message
        /// </summary>
        Stream GetMessageResponseMessage(string messageId);

        /// <summary>
        /// Get a message
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns></returns>
        Stream GetMessage(string messageId);

        /// <summary>
        /// Persist
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="response"></param>
        void PersistResultMessage(string messageId, string respondsToId, Stream response);

        /// <summary>
        /// Get all message ids between the specified time(s)
        /// </summary>
        IEnumerable<String> GetMessageIds(DateTime from, DateTime to);

        /// <summary>
        /// Get message extended attribute
        /// </summary>
        MessageInfo GetMessageInfo(string messageId);


    }
}
