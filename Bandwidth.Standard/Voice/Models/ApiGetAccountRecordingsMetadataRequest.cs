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


namespace Bandwidth.Standard.Voice.Models
{
    public class ApiGetAccountRecordingsMetadataRequest 
    {
        public ApiGetAccountRecordingsMetadataRequest() { }

        public ApiGetAccountRecordingsMetadataRequest(string mFrom,
            string to,
            DateTime minStartTime,
            DateTime maxStartTime)
        {
            MFrom = mFrom;
            To = to;
            MinStartTime = minStartTime;
            MaxStartTime = maxStartTime;
        }

        /// <summary>
        /// Format is E164
        /// </summary>
        [JsonProperty("from")]
        public string MFrom { get; set; }

        /// <summary>
        /// Format is E164
        /// </summary>
        [JsonProperty("to")]
        public string To { get; set; }

        /// <summary>
        /// ISO8601 format
        /// </summary>
        [JsonConverter(typeof(IsoDateTimeConverter))]
        [JsonProperty("minStartTime")]
        public DateTime MinStartTime { get; set; }

        /// <summary>
        /// ISO8601 format
        /// </summary>
        [JsonConverter(typeof(IsoDateTimeConverter))]
        [JsonProperty("maxStartTime")]
        public DateTime MaxStartTime { get; set; }

    }
} 