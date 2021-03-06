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
    public class Media 
    {
        public Media() { }

        public Media(object inputStream = null,
            string content = null,
            string url = null,
            string contentLength = null,
            string contentType = null,
            List<Models.Tag> tags = null,
            string userId = null,
            string mediaName = null,
            string mediaId = null,
            string cacheControl = null)
        {
            InputStream = inputStream;
            Content = content;
            Url = url;
            ContentLength = contentLength;
            ContentType = contentType;
            Tags = tags;
            UserId = userId;
            MediaName = mediaName;
            MediaId = mediaId;
            CacheControl = cacheControl;
        }

        /// <summary>
        /// Getter for inputStream
        /// </summary>
        [JsonProperty("inputStream")]
        public object InputStream { get; set; }

        /// <summary>
        /// Getter for content
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; }

        /// <summary>
        /// Getter for url
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Getter for contentLength
        /// </summary>
        [JsonProperty("contentLength")]
        public string ContentLength { get; set; }

        /// <summary>
        /// Getter for contentType
        /// </summary>
        [JsonProperty("contentType")]
        public string ContentType { get; set; }

        /// <summary>
        /// Getter for tags
        /// </summary>
        [JsonProperty("tags")]
        public List<Models.Tag> Tags { get; set; }

        /// <summary>
        /// Getter for userId
        /// </summary>
        [JsonProperty("userId")]
        public string UserId { get; set; }

        /// <summary>
        /// Getter for mediaName
        /// </summary>
        [JsonProperty("mediaName")]
        public string MediaName { get; set; }

        /// <summary>
        /// Getter for mediaId
        /// </summary>
        [JsonProperty("mediaId")]
        public string MediaId { get; set; }

        /// <summary>
        /// Getter for cacheControl
        /// </summary>
        [JsonProperty("cacheControl")]
        public string CacheControl { get; set; }

    }
}