/*
 * Bandwidth.Standard
 *
 * This file was automatically generated by APIMATIC v2.0 ( https://apimatic.io ).
 */
using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Bandwidth.Standard;
using Bandwidth.Standard.Utilities;

namespace Bandwidth.Standard.Voice.Models
{
    [JsonConverter(typeof(StringValuedEnumConverter))]
    public enum CallbackMethodEnum
    {
        GET,
        HEAD,
        POST,
        PUT,
        PATCH,
        DELETE,
        OPTIONS,
        TRACE,
    }

    /// <summary>
    /// Helper for the enum type CallbackMethodEnum
    /// </summary>
    public static class CallbackMethodEnumHelper
    {
        //string values corresponding the enum elements
        private static List<string> stringValues = new List<string> { "GET", "HEAD", "POST", "PUT", "PATCH", "DELETE", "OPTIONS", "TRACE" };

        /// <summary>
        /// Converts a CallbackMethodEnum value to a corresponding string value
        /// </summary>
        /// <param name="enumValue">The CallbackMethodEnum value to convert</param>
        /// <returns>The representative string value</returns>
        public static string ToValue(CallbackMethodEnum enumValue)
        {
            switch(enumValue)
            {
                //only valid enum elements can be used
                //this is necessary to avoid errors
                case CallbackMethodEnum.GET:
                case CallbackMethodEnum.HEAD:
                case CallbackMethodEnum.POST:
                case CallbackMethodEnum.PUT:
                case CallbackMethodEnum.PATCH:
                case CallbackMethodEnum.DELETE:
                case CallbackMethodEnum.OPTIONS:
                case CallbackMethodEnum.TRACE:
                    return stringValues[(int)enumValue];

                //an invalid enum value was requested
                default:
                    return null;
            }
        }

        /// <summary>
        /// Convert a list of CallbackMethodEnum values to a list of strings
        /// </summary>
        /// <param name="enumValues">The list of CallbackMethodEnum values to convert</param>
        /// <returns>The list of representative string values</returns>
        public static List<string> ToValue(List<CallbackMethodEnum> enumValues)
        {
            if (null == enumValues)
                return null;

            return enumValues.Select(eVal => ToValue(eVal)).ToList();
        }

        /// <summary>
        /// Converts a string value into CallbackMethodEnum value
        /// </summary>
        /// <param name="value">The string value to parse</param>
        /// <returns>The parsed CallbackMethodEnum value</returns>
        public static CallbackMethodEnum ParseString(string value)
        {
            int index = stringValues.IndexOf(value);
            if(index < 0)
                throw new InvalidCastException(string.Format("Unable to cast value: {0} to type CallbackMethodEnum", value));

            return (CallbackMethodEnum) index;
        }
    }
}