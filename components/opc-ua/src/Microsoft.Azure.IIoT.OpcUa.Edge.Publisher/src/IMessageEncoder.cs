﻿// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.Azure.IIoT.OpcUa.Edge.Publisher {
    using Microsoft.Azure.IIoT.OpcUa.Edge.Publisher.Models;
    using System.Collections.Generic;

    /// <summary>
    /// Encoder to encode data set writer messages
    /// </summary>
    public interface IMessageEncoder {

        /// <summary>
        /// Number of notifications that are too big to be processed to IotHub Messages
        /// </summary>
        long NotificationsDroppedCount { get; }

        /// <summary>
        /// Number of successfully processed notifications from OPC client
        /// </summary>
        long NotificationsProcessedCount { get; }

        /// <summary>
        /// Number of successfully processed messages
        /// </summary>
        long MessagesProcessedCount { get; }

        /// <summary>
        /// Average notifications in a message
        /// </summary>
        double AvgNotificationsPerMessage { get; }

        /// <summary>
        /// Average notifications in a message
        /// </summary>
        double AvgMessageSize { get; }

        /// <summary>
        /// Encodes the list of messages into single message NetworkMessageModel list
        /// </summary>
        /// <param name="message"></param>
        /// <param name="maxMessageSize"></param>
        /// <returns></returns>
        IList<NetworkMessageModel> Encode(
            IList<DataSetMessageModel> message, int maxMessageSize);

        /// <summary>
        /// Encodes the list of messages into batched NetworkMessageModel list
        /// </summary>
        /// <param name="messages"></param>
        /// <param name="maxMessageSize"></param>
        /// <returns></returns>
        IList<NetworkMessageModel> EncodeBatch(
            IList<DataSetMessageModel> messages, int maxMessageSize);
    }
}