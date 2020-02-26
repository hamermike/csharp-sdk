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
    public class Transcript 
    {
        public Transcript() { }

        public Transcript(string text = null,
            double? confidence = null)
        {
            Text = text;
            Confidence = confidence;
        }

        /// <summary>
        /// Getter for text
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// Getter for confidence
        /// </summary>
        [JsonProperty("confidence")]
        public double? Confidence { get; set; }

    }
}