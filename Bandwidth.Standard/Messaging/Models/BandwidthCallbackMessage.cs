/*
 * Bandwidth.Standard
 *
 * This file was automatically generated by APIMATIC v2.0 ( https://apimatic.io ).
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Bandwidth.Standard;
using Bandwidth.Standard.Utilities;


namespace Bandwidth.Standard.Messaging.Models
{
    public class BandwidthCallbackMessage 
    {
        public BandwidthCallbackMessage() { }

        public BandwidthCallbackMessage(string time = null,
            string type = null,
            string to = null,
            string errorCode = null,
            string description = null,
            Models.BandwidthMessage message = null)
        {
            Time = time;
            Type = type;
            To = to;
            ErrorCode = errorCode;
            Description = description;
            Message = message;
        }

        /// <summary>
        /// Getter for time
        /// </summary>
        [JsonProperty("time")]
        public string Time { get; set; }

        /// <summary>
        /// Getter for type
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Getter for to
        /// </summary>
        [JsonProperty("to")]
        public string To { get; set; }

        /// <summary>
        /// Getter for errorCode
        /// </summary>
        [JsonProperty("errorCode")]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Getter for description
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Getter for message
        /// </summary>
        [JsonProperty("message")]
        public Models.BandwidthMessage Message { get; set; }

    }
}