/*
 * Bandwidth.Standard
 *
 * This file was automatically generated by APIMATIC v2.0 ( https://apimatic.io ).
 */
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Bandwidth.Standard.Utilities;
using Bandwidth.Standard.Http.Client;

namespace Bandwidth.Standard.Exceptions
{
    /// <summary>
    /// This is the base class for all exceptions that represent an error response from the server.
    /// </summary>
    [JsonObject]
    public class ApiException : Exception
    {
        /// <summary>
        /// The HTTP response code from the API request
        /// </summary>
        [JsonIgnore]
        public int ResponseCode
        {
            get { return this.HttpContext != null ? HttpContext.Response.StatusCode : -1; }
        }

        /// <summary>
        /// HttpContext stores the request and response
        /// </summary>
        [JsonIgnore]
        public HttpContext HttpContext { get; internal set; }

        /// <summary>
        /// Initialization constructor
        /// </summary>
        /// <param name="reason"> The reason for throwing exception </param>
        /// <param name="context"> The HTTP context that encapsulates request and response objects </param>
        public ApiException(string reason, HttpContext context)
            : base(reason)
        {
            this.HttpContext = context;

            //if a derived exception class is used, then perform deserialization of response body
            if ((context == null) || (context.Response == null)
                || (context.Response.RawBody == null)
                || (!context.Response.RawBody.CanRead))
                {
                    return;
                }

            using (var reader = new StreamReader(context.Response.RawBody))
            {
                string responseBody = reader.ReadToEnd();
                if (!string.IsNullOrWhiteSpace(responseBody))
                {
                    try
                    {
                        JObject body = JObject.Parse(responseBody);

                        if(!this.GetType().Name.Equals("ApiException", StringComparison.OrdinalIgnoreCase))
                        {
                            JsonConvert.PopulateObject(responseBody, this);
                        }
                    }
                    catch (JsonReaderException)
                    {
                        // Ignore deserialization and IO issues to prevent exception being thrown when this exception
                        // instance is being constructed.
                    }
                }
            }
        }
    }
}