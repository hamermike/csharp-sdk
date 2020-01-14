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
    public class ApiModifyCallRequest 
    {
        public ApiModifyCallRequest() { }

        public ApiModifyCallRequest(string redirectUrl,
            Models.StateEnum? state = null,
            Models.RedirectMethodEnum? redirectMethod = null,
            string username = null,
            string password = null,
            string tag = null)
        {
            State = state;
            RedirectUrl = redirectUrl;
            RedirectMethod = redirectMethod;
            Username = username;
            Password = password;
            Tag = tag;
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("state", ItemConverterType = typeof(StringValuedEnumConverter))]
        public Models.StateEnum? State { get; set; }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("redirectUrl")]
        public string RedirectUrl { get; set; }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("redirectMethod", ItemConverterType = typeof(StringValuedEnumConverter))]
        public Models.RedirectMethodEnum? RedirectMethod { get; set; }

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