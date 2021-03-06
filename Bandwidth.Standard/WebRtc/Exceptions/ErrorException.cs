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
using Bandwidth.Standard.Http.Client;
using Bandwidth.Standard.Exceptions;
using Bandwidth.Standard.WebRtc.Models;
using Bandwidth.Standard;
using Bandwidth.Standard.Utilities;

namespace Bandwidth.Standard.WebRtc.Exceptions
{
    public class ErrorException : ApiException
    {
        /// <summary>
        /// Initialization constructor
        /// </summary>
        /// <param name="reason"> The reason for throwing exception </param>
        /// <param name="context"> The HTTP context that encapsulates request and response objects </param>
        public ErrorException(string reason, HttpContext context)
            : base(reason, context) { }

        /// <summary>
        /// Getter for code
        /// </summary>
        [JsonProperty("code")]
        public int Code { get; set; }

        /// <summary>
        /// Getter for message
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

    }
}