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
    public class ApiCallResponse 
    {
        public ApiCallResponse() { }

        public ApiCallResponse(string callId,
            string applicationId,
            string to,
            string mFrom,
            string callUrl,
            string answerUrl,
            Models.AnswerMethodEnum answerMethod,
            Models.DisconnectMethodEnum disconnectMethod,
            DateTime? startTime = null,
            double? callTimeout = null,
            string disconnectUrl = null,
            string username = null,
            string password = null,
            string tag = null)
        {
            CallId = callId;
            ApplicationId = applicationId;
            To = to;
            MFrom = mFrom;
            StartTime = startTime;
            CallUrl = callUrl;
            CallTimeout = callTimeout;
            AnswerUrl = answerUrl;
            AnswerMethod = answerMethod;
            DisconnectUrl = disconnectUrl;
            DisconnectMethod = disconnectMethod;
            Username = username;
            Password = password;
            Tag = tag;
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("callId")]
        public string CallId { get; set; }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("applicationId")]
        public string ApplicationId { get; set; }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("to")]
        public string To { get; set; }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("from")]
        public string MFrom { get; set; }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonConverter(typeof(IsoDateTimeConverter))]
        [JsonProperty("startTime")]
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("callUrl")]
        public string CallUrl { get; set; }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("callTimeout")]
        public double? CallTimeout { get; set; }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("answerUrl")]
        public string AnswerUrl { get; set; }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("answerMethod", ItemConverterType = typeof(StringValuedEnumConverter))]
        public Models.AnswerMethodEnum AnswerMethod { get; set; }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("disconnectUrl")]
        public string DisconnectUrl { get; set; }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("disconnectMethod", ItemConverterType = typeof(StringValuedEnumConverter))]
        public Models.DisconnectMethodEnum DisconnectMethod { get; set; }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; set; }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("password")]
        public string Password { get; set; }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("tag")]
        public string Tag { get; set; }

    }
} 