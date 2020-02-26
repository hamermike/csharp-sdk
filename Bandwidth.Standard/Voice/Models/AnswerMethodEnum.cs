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
    public enum AnswerMethodEnum
    {
        POST,
        GET,
    }

    /// <summary>
    /// Helper for the enum type AnswerMethodEnum
    /// </summary>
    public static class AnswerMethodEnumHelper
    {
        //string values corresponding the enum elements
        private static List<string> stringValues = new List<string> { "POST", "GET" };

        /// <summary>
        /// Converts a AnswerMethodEnum value to a corresponding string value
        /// </summary>
        /// <param name="enumValue">The AnswerMethodEnum value to convert</param>
        /// <returns>The representative string value</returns>
        public static string ToValue(AnswerMethodEnum enumValue)
        {
            switch(enumValue)
            {
                //only valid enum elements can be used
                //this is necessary to avoid errors
                case AnswerMethodEnum.POST:
                case AnswerMethodEnum.GET:
                    return stringValues[(int)enumValue];

                //an invalid enum value was requested
                default:
                    return null;
            }
        }

        /// <summary>
        /// Convert a list of AnswerMethodEnum values to a list of strings
        /// </summary>
        /// <param name="enumValues">The list of AnswerMethodEnum values to convert</param>
        /// <returns>The list of representative string values</returns>
        public static List<string> ToValue(List<AnswerMethodEnum> enumValues)
        {
            if (null == enumValues)
                return null;

            return enumValues.Select(eVal => ToValue(eVal)).ToList();
        }

        /// <summary>
        /// Converts a string value into AnswerMethodEnum value
        /// </summary>
        /// <param name="value">The string value to parse</param>
        /// <returns>The parsed AnswerMethodEnum value</returns>
        public static AnswerMethodEnum ParseString(string value)
        {
            int index = stringValues.IndexOf(value);
            if(index < 0)
                throw new InvalidCastException(string.Format("Unable to cast value: {0} to type AnswerMethodEnum", value));

            return (AnswerMethodEnum) index;
        }
    }
}