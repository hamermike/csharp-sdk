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

using Bandwidth.Standard.TwoFactorAuth.Models;
using Bandwidth.Standard;
using Bandwidth.Standard.Utilities;

namespace Bandwidth.Standard.TwoFactorAuth.Exceptions
{
    public class InvalidRequestException : ApiException
    {
        /// <summary>
        /// An error message pertaining to what the issue could be
        /// </summary>
        [JsonProperty("result")]
        public string Result { get; set; }

        /// <summary>
        /// Base class constructor
        /// </summary>
        /// <param name="reason"> The reason for throwing exception </param>
        /// <param name="context"> The HTTP context that encapsulates request and response objects </param>
        public InvalidRequestException(string reason, HttpContext context)
            : base(reason, context) { }

        /// <summary>
        /// Initialization constructor
        /// </summary>
        /// <param name="reason"> The reason for throwing exception </param>
        /// <param name="context"> The HTTP context that encapsulates request and response objects </param>
        public InvalidRequestException(string reason, HttpContext context, string result = null): base(reason, context)
        {
            this.Result = result;
        }
    }
}