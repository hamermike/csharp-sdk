using System;
using System.Collections.Generic;
using System.IO;

namespace Bandwidth.Standard.Http.Response
{
    public sealed class HttpStringResponse : HttpResponse
    {
        /// <summary>
        /// Raw string body of the http response.
        /// </summary>
        public string Body { get; }

        /// <summary>
        /// Initializes a new HttpStringResponse object with the specified parameters.
        /// </summary>
        public HttpStringResponse(int statusCode, Dictionary<string,string> headers, Stream rawBody, string body) : base(statusCode, headers, rawBody)
        {
            this.Body = body;
        }
    }
}
